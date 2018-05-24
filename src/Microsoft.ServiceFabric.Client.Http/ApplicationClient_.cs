// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Client.Exceptions;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Utilities;

    /// <inheritdoc />
    internal partial class ApplicationClient : IApplicationClient
    {
        private const int UploadLimitSizeInBytes = 25 * 1024 * 1024;
        private const int MaxConcurrentUpload = 10;
        private const int MaxUploadTry = 2;
        private const string ZipExtension = "zip";
        private const long ServerTimeOutInSecondsForUpload = 60;

        /// <inheritdoc />
        public async Task UploadApplicationPackageAsync(
            string applicationPackagePath,
            bool compressPackage,
            string applicationPackagePathInImageStore = default(string),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationPackagePath.ThrowIfNull(nameof(applicationPackagePath));

            var requestId = Guid.NewGuid();
            ServiceFabricHttpClientEventSource.Current.InfoMessage($"{this.httpClient.ClientId}:{requestId}",
                "Processing call for ApplicationClient.DeleteApplicationAsync");

            var absPkgPath = FileUtilities.GetAbsolutePath(applicationPackagePath);

            var pkgPathInImageStore = applicationPackagePathInImageStore;
            if (string.IsNullOrEmpty(pkgPathInImageStore))
            {
                pkgPathInImageStore = applicationPackagePath.Replace(Path.GetDirectoryName(applicationPackagePath), "");
            }

            pkgPathInImageStore = pkgPathInImageStore.Trim('\\', '/');

            if (!Directory.Exists(applicationPackagePath))
            {
                throw new InvalidOperationException($"Application package path {applicationPackagePath} not found.");
            }

            if (compressPackage)
            {
                await CompressApplicationPackage(absPkgPath);
            }

            // List of dirs to determine where to upload _.dir fileInfo.
            var dirPathsInImageStore =
                new List<string> { GetPathInImageStore(absPkgPath, pkgPathInImageStore, absPkgPath) };

            dirPathsInImageStore.AddRange(
                Directory.EnumerateDirectories(absPkgPath, "*", SearchOption.AllDirectories)
                    .Select(dir => GetPathInImageStore(absPkgPath, pkgPathInImageStore, dir)));

            // list of Files to upload.
            var files = Directory.EnumerateFiles(absPkgPath, "*", SearchOption.AllDirectories)
                .Select(file => new System.IO.FileInfo(file));

            // Upload small files in single upload. Upload bigger fileInfo using chunked upload.
            // Get info to upload single files.
            var singleFileUploadInfos = files.Where(file => file.Length <= UploadLimitSizeInBytes)
                .Select(file => new FileUploadInfo(
                    file,
                    GetPathInImageStore(absPkgPath, pkgPathInImageStore, file.FullName)));


            // Get info to upload chunks for files.
            var chunkInfos = new List<ChunkInfo>();
            foreach (var file in files.Where(file => file.Length > UploadLimitSizeInBytes))
            {
                var pathInImageStore = GetPathInImageStore(absPkgPath, pkgPathInImageStore, file.FullName);
                chunkInfos.AddRange(GetChunksInfoForFile(file, pathInImageStore));
            }

            // upload single files with up to MaxConcurrentUpload in parallel. 
            await UploadAllSingleFiles(singleFileUploadInfos, requestId, cancellationToken);

            // upload chunks with up to MaxConcurrentUpload in parallel. 
            await UploadAllChunksAsync(chunkInfos, requestId, cancellationToken);

            // upload _.dirs with up to MaxConcurrentUpload in parallel. 
            await UploadDirectoryCompletionMarkerFiles(dirPathsInImageStore, requestId, cancellationToken);
        }

        private static IEnumerable<ChunkInfo> GetChunksInfoForFile(
            System.IO.FileInfo fileInfo,
            string filePathInImageStore)
        {
            var chunkInfos = new List<ChunkInfo>();
            var uploadSessionId = Guid.NewGuid();
            var fileUploadInfo = new FileUploadInfo(fileInfo, filePathInImageStore);

            var fileSize = fileInfo.Length;
            var chunks = fileSize / UploadLimitSizeInBytes;
            if (fileSize % UploadLimitSizeInBytes > 0)
            {
                chunks++;
            }

            long startPosition = 0;
            for (var chunk = 1; chunk <= chunks; chunk++)
            {
                long endPosition = UploadLimitSizeInBytes * (chunk) - 1;

                if (endPosition >= fileSize)
                {
                    endPosition = fileSize - 1;
                }

                chunkInfos.Add(
                    new ChunkInfo
                    {
                        StartPosition = startPosition,
                        EndPosition = endPosition,
                        SessionId = uploadSessionId,
                        FileUploadInfo = fileUploadInfo
                    });

                startPosition = endPosition + 1;
            }

            return chunkInfos;
        }

        private async Task UploadAllChunksAsync(
            ICollection<ChunkInfo> chunkInfos,
            Guid requestId,
            CancellationToken cancellationToken)
        {
            if (chunkInfos.Count > 0)
            {
                var chunkInfosBag = new ConcurrentBag<ChunkInfo>(chunkInfos);
                var concurrentOperationsRunner = new ConcurrentOperationsRunner<ChunkInfo>(
                    chunkInfo =>
                        this.UploadChunkAsync(
                            chunkInfo,
                            requestId.ToString(),
                            cancellationToken),
                    chunkInfosBag.TryTake,
                    MaxConcurrentUpload);

                await concurrentOperationsRunner.RunAll();

                var sessiodIds = new ConcurrentBag<Guid>();
                foreach (var sessionId in chunkInfos.Select(x => x.SessionId).Distinct())
                {
                    sessiodIds.Add(sessionId);
                }

                // TODO: Before commiting check for missing chunlks and upload them again.

                // commit all chunkuploads with up to MaxConcurrentUpload in parallel. 
                var sessionIdCommits = new ConcurrentOperationsRunner<Guid>(
                    sessionId =>
                        this.httpClient.ImageStore.CommitImageStoreUploadSessionAsync(
                            sessionId,
                            cancellationToken: cancellationToken),
                    sessiodIds.TryTake,
                    MaxConcurrentUpload);

                await sessionIdCommits.RunAll();
            }
        }

        private async Task UploadChunkAsync(
            ChunkInfo chunkInfo,
            string parentRequestId,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Get the chunk
            var length = chunkInfo.StartPosition - chunkInfo.EndPosition + 1;
            var chunk = new byte[length];

            using (var streamSource = new FileStream(chunkInfo.FileUploadInfo.FileInfo.FullName, FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                streamSource.Seek(chunkInfo.StartPosition, SeekOrigin.Begin);
                await streamSource.ReadAsync(chunk, 0, (int)length, cancellationToken);
            }

            // retry once on network, timeout issues
            var tryCount = 1;

            try
            {
                await ((ImageStoreClient)this.httpClient.ImageStore).UploadFileChunkAsync(
                    chunk,
                    chunkInfo.FileUploadInfo.FilePathInImageStore,
                    chunkInfo.SessionId,
                    chunkInfo.StartPosition,
                    chunkInfo.EndPosition,
                    chunkInfo.FileUploadInfo.FileInfo.Length,
                    $"{parentRequestId}:{Guid.NewGuid()}",
                    ServerTimeOutInSecondsForUpload,
                    cancellationToken);
            }
            catch (ServiceFabricRequestException)
            {
                if (tryCount >= MaxUploadTry)
                {
                    throw;
                }

                tryCount++;
            }
        }

        private Task UploadAllSingleFiles(
            IEnumerable<FileUploadInfo> singleFileUploadInfos,
            Guid requestId,
            CancellationToken cancellationToken)
        {
            var singleFileUploadInfosBag = new ConcurrentBag<FileUploadInfo>(singleFileUploadInfos);
            var concurrentOperationsRunner = new ConcurrentOperationsRunner<FileUploadInfo>(
                uploadInfo =>
                    this.UploadSingleFile(
                        File.ReadAllBytes(uploadInfo.FileInfo.FullName),
                        uploadInfo.FilePathInImageStore,
                        requestId.ToString(),
                        cancellationToken),
                singleFileUploadInfosBag.TryTake,
                MaxConcurrentUpload);

            return concurrentOperationsRunner.RunAll();
        }

        private Task UploadDirectoryCompletionMarkerFiles(
            IEnumerable<string> dirPathsInImageStore,
            Guid requestId,
            CancellationToken cancellationToken)
        {
            var dirPaths = new ConcurrentBag<string>(dirPathsInImageStore);
            var concurrentOperationsRunner = new ConcurrentOperationsRunner<string>(
                dirPathInImageStore =>
                    this.UploadSingleFile(
                        new byte[0],
                        $"{dirPathInImageStore}{Path.DirectorySeparatorChar}_.dir",
                        requestId.ToString(),
                        cancellationToken),
                dirPaths.TryTake,
                MaxConcurrentUpload);

            return concurrentOperationsRunner.RunAll();
        }

        private async Task UploadSingleFile(
            byte[] fileContent,
            string filePathInImageStore,
            string parentRequestId,
            CancellationToken cancellationToken)
        {
            // retry once on network, timeout issues
            var tryCount = 1;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await ((ImageStoreClient)this.httpClient.ImageStore).UploadFileAsync(
                    fileContent,
                    filePathInImageStore,
                    $"{parentRequestId}:{Guid.NewGuid()}",
                    ServerTimeOutInSecondsForUpload,
                    cancellationToken);
            }
            catch (ServiceFabricRequestException)
            {
                if (tryCount >= MaxUploadTry)
                {
                    throw;
                }

                tryCount++;
            }
        }

        /// <summary>
        /// Compresses Application Package. Code, Config and Data Pkg folders are compressed in each service package.
        /// </summary>
        /// <param name="appPkgPath">Absolute path to application package.</param>
        private static Task CompressApplicationPackage(string appPkgPath)
        {
            var dirsToCompress = new List<string>();

            // Get the service packages in application package
            foreach (var servicePackage in new DirectoryInfo(appPkgPath).GetDirectories())
            {
                // Get Code/Config/Data packages for each service package.
                dirsToCompress.AddRange(servicePackage.GetDirectories().Select(package => package.FullName));
            }

            return Task.WhenAll(dirsToCompress.Select(dir => Task.Run(() => CompressDirectory(dir, $"{dir}.{ZipExtension}", true))).ToArray());
        }

        private static void CompressDirectory(string sourceDirToCompress, string destCompressedFile,
            bool deleteSourceDirAfterCompression)
        {
            if (File.Exists(destCompressedFile))
            {
                File.Delete(destCompressedFile);
            }

            ZipFile.CreateFromDirectory(sourceDirToCompress, destCompressedFile);

            if (deleteSourceDirAfterCompression)
            {
                Directory.Delete(sourceDirToCompress, true);
            }
        }

        /// <summary>
        /// Gets the path to upload to in image store.
        /// </summary>
        /// <param name="compressedPkgPath">Path to local compressed package</param>
        /// <param name="pkgPathInImageStore">Package Path in image store.</param>
        /// <param name="pathInCompressedPackage">Path to fileInfo/dir in compressed package.</param>
        /// <returns>Relative PAth in image store.</returns>
        private static string GetPathInImageStore(
            string compressedPkgPath,
            string pkgPathInImageStore,
            string pathInCompressedPackage)
        {
            var relativePath = pathInCompressedPackage.Replace(compressedPkgPath, "").Trim('\\', '/');

            return relativePath.Equals(string.Empty)
                ? pkgPathInImageStore
                : $"{pkgPathInImageStore}{Path.DirectorySeparatorChar}{relativePath}";
        }

        /// <summary>
        /// Contains Information about a chunk to be uploaded.
        /// </summary>
        private class ChunkInfo
        {
            internal long StartPosition { get; set; }

            internal long EndPosition { get; set; }

            internal Guid SessionId { get; set; }

            internal FileUploadInfo FileUploadInfo { get; set; }
        }

        /// <summary>
        /// Contians Information about File to be uploaded.
        /// </summary>
        internal class FileUploadInfo
        {
            internal FileUploadInfo(System.IO.FileInfo fileInfo, string filePathInImageStore)
            {
                this.FileInfo = fileInfo;
                this.FilePathInImageStore = filePathInImageStore;
            }

            internal System.IO.FileInfo FileInfo { get; }

            internal string FilePathInImageStore { get; }
        }
    }
}

