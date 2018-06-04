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
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Client.Exceptions;
    using Microsoft.ServiceFabric.Client.Http.Serialization;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Utilities;
    using Newtonsoft.Json;

    /// <summary>
    /// Class containing methods for performing ImageStoreClient operataions.
    /// </summary>
    internal partial class LocalImageStoreClient : IImageStoreClient
    {
        private readonly ServiceFabricHttpClient httpClient;
        private readonly string connectionString;
        private readonly string imageStorePath;

        /// <summary>
        /// Initializes a new instance of the ImageStoreClient class.
        /// </summary>
        /// <param name="httpClient">ServiceFabricHttpClient instance.</param>
        /// <param name="connectionString">The connection string for the image store</param>
        public LocalImageStoreClient(ServiceFabricHttpClient httpClient, string connectionString)
        {
            this.httpClient = httpClient;
            this.connectionString = connectionString;
            imageStorePath = new Uri(connectionString).LocalPath;
        }


        /// <inheritdoc />
        public Task<ImageStoreContent> GetImageStoreContentAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            contentPath.ThrowIfNull(nameof(contentPath));

            var path = Path.Combine(imageStorePath, contentPath);
            var directories = Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories).Select(d => new FolderInfo(d, (long)Directory.EnumerateFiles(d).Count())).ToList();
            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).Select(f => new System.IO.FileInfo(f)).Select(f => new Common.FileInfo(f.Length.ToString(), new FileVersion(), f.LastWriteTimeUtc, f.FullName.Replace(imageStorePath, ""))).ToList();
            return Task.FromResult(new ImageStoreContent(files, directories));
        }

        /// <inheritdoc />
        public Task DeleteImageStoreContentAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            contentPath.ThrowIfNull(nameof(contentPath));

            var path = Path.Combine(imageStorePath, contentPath);
            FileAttributes attr = File.GetAttributes(path);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                Directory.Delete(path, true);
            else
                File.Delete(path);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<ImageStoreContent> GetImageStoreRootContentAsync(
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var directories = Directory.EnumerateDirectories(imageStorePath, "*", SearchOption.TopDirectoryOnly).Select(d => new FolderInfo(d, (long)Directory.EnumerateFiles(d).Count())).ToList();
            var files = Directory.EnumerateFiles(imageStorePath, "*", SearchOption.TopDirectoryOnly).Select(f => new System.IO.FileInfo(f)).Select(f => new Common.FileInfo(f.Length.ToString(), new FileVersion(), f.LastWriteTimeUtc, f.FullName.Replace(imageStorePath, ""))).ToList();
            return Task.FromResult(new ImageStoreContent(files, directories));
        }

        /// <inheritdoc />
        public Task CopyImageStoreContentAsync(
            ImageStoreCopyDescription imageStoreCopyDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            imageStoreCopyDescription.ThrowIfNull(nameof(imageStoreCopyDescription));
            var source = Path.Combine(imageStorePath, imageStoreCopyDescription.RemoteSource);
            var destination = Path.Combine(imageStorePath, imageStoreCopyDescription.RemoteDestination);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task DeleteImageStoreUploadSessionAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task CommitImageStoreUploadSessionAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<UploadSession> GetImageStoreUploadSessionByIdAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(new UploadSession());
        }

        /// <inheritdoc />
        public Task<UploadSession> GetImageStoreUploadSessionByPathAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(new UploadSession());
        }

        /// <inheritdoc />
        public Task UploadApplicationPackageAsync(
            string applicationPackagePath,
            bool compressPackage = false,
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

            var files = Directory.EnumerateFiles(absPkgPath, "*", SearchOption.AllDirectories)
                .Select(file => new System.IO.FileInfo(file));

            foreach (var file in files)
            {
                var targetPath = Path.Combine(imageStorePath, Path.Combine(pkgPathInImageStore, file.FullName.Substring(absPkgPath.Length+1)));
                if (!Directory.Exists(Path.GetDirectoryName(targetPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
                File.Copy(file.FullName, targetPath, true);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task UploadFileAsync(
            byte[] fileContentsToUpload,
            string pathInImageStore,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UploadFileAsync(
                fileContentsToUpload,
                pathInImageStore,
                null,
                serverTimeout,
                cancellationToken);
        }

        /// <summary>
        /// Uploads contents of the file to the image store.
        /// Used by IApplicationClient.UploadApplicationPackageAsync to trace a request Id associated with original Uplaod call.
        /// </summary>
        /// <param name="fileContentsToUpload">File contents to upload.</param>
        /// <param name ="pathInImageStore">Relative path to file or folder in the image store from its root.</param>
        /// <param name="requestId">Request Id to use for tracing.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        internal Task UploadFileAsync(
            byte[] fileContentsToUpload,
            string pathInImageStore,
            string requestId = null,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            pathInImageStore.ThrowIfNull(nameof(fileContentsToUpload));
            pathInImageStore.ThrowIfNull(nameof(pathInImageStore));
            File.WriteAllBytes(Path.Combine(imageStorePath, pathInImageStore), fileContentsToUpload);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task UploadFileChunkAsync(
            byte[] fileChunkToUpload,
            string pathInImageStore,
            Guid? sessionId,
            long startBytePosition,
            long endBytePosition,
            long length,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UploadFileChunkAsync(
                fileChunkToUpload,
                pathInImageStore,
                sessionId,
                endBytePosition,
                endBytePosition,
                length,
                null,
                serverTimeout,
                cancellationToken);
        }

        internal  Task UploadFileChunkAsync(
            byte[] fileChunkToUpload,
            string pathInImageStore,
            Guid? sessionId,
            long startBytePosition,
            long endBytePosition,
            long length,
            string requestId = null,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            fileChunkToUpload.ThrowIfNull(nameof(fileChunkToUpload));
            pathInImageStore.ThrowIfNull(nameof(pathInImageStore));

            using (var fs = File.OpenWrite(Path.Combine(imageStorePath, pathInImageStore)))
            {
                fs.Write(fileChunkToUpload, (int)startBytePosition, (int)length);
            }

            return Task.CompletedTask;
        }


    }
}
