// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Client.Http.Serialization;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Class containing methods for performing ImageStoreClient operataions.
    /// </summary>
    internal partial class ImageStoreClient : IImageStoreClient
    {
        private readonly ServiceFabricHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the ImageStoreClient class.
        /// </summary>
        /// <param name="httpClient">ServiceFabricHttpClient instance.</param>
        public ImageStoreClient(ServiceFabricHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<ImageStoreContent> GetImageStoreContentAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            contentPath.ThrowIfNull(nameof(contentPath));

            await this.LoadImageStoreConnectionString();
            if (this.isLocalStore)
            {
                var path = Path.Combine(this.imageStorePath, contentPath);
                var directories = Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories).Select(d => new FolderInfo(d.Replace(this.imageStorePath, string.Empty), (long)Directory.EnumerateFiles(d).Count())).ToList();
                var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).Select(f => new System.IO.FileInfo(f)).Select(f => new Common.FileInfo(f.Length.ToString(), new FileVersion(), f.LastWriteTimeUtc, f.FullName.Replace(this.imageStorePath, string.Empty))).ToList();
                return new ImageStoreContent(files, directories);
            }
            else
            {
                serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
                var requestId = Guid.NewGuid().ToString();
                var url = "ImageStore/{contentPath}";
                url = url.Replace("{contentPath}", Uri.EscapeDataString(contentPath));
                var queryParams = new List<string>();

                // Append to queryParams if not null.
                serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
                queryParams.Add("api-version=6.2");
                url += "?" + string.Join("&", queryParams);

                HttpRequestMessage RequestFunc()
                {
                    var request = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                    };
                    return request;
                }

                return await this.httpClient.SendAsyncGetResponse(RequestFunc, url, ImageStoreContentConverter.Deserialize, requestId, cancellationToken);
            }
        }

        /// <inheritdoc />
        public async Task DeleteImageStoreContentAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            contentPath.ThrowIfNull(nameof(contentPath));

            await this.LoadImageStoreConnectionString();
            if (this.isLocalStore)
            {
                var path = Path.Combine(this.imageStorePath, contentPath);
                var attr = File.GetAttributes(path);

                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    Directory.Delete(path, true);
                }
                else
                {
                    File.Delete(path);
                }
            }
            else
            {
                serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
                var requestId = Guid.NewGuid().ToString();
                var url = "ImageStore/{contentPath}";
                url = url.Replace("{contentPath}", Uri.EscapeDataString(contentPath));
                var queryParams = new List<string>();

                // Append to queryParams if not null.
                serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
                queryParams.Add("api-version=6.0");
                url += "?" + string.Join("&", queryParams);

                HttpRequestMessage RequestFunc()
                {
                    var request = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Delete,
                    };
                    return request;
                }

                await this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
            }
        }

        /// <inheritdoc />
        public async Task<ImageStoreContent> GetImageStoreRootContentAsync(
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.LoadImageStoreConnectionString();
            if (this.isLocalStore)
            {
                var directories = Directory.EnumerateDirectories(this.imageStorePath, "*", SearchOption.TopDirectoryOnly).Select(d => new FolderInfo(d.Replace(this.imageStorePath, string.Empty), (long)Directory.EnumerateFiles(d).Count())).ToList();
                var files = Directory.EnumerateFiles(this.imageStorePath, "*", SearchOption.TopDirectoryOnly).Select(f => new System.IO.FileInfo(f)).Select(f => new Common.FileInfo(f.Length.ToString(), new FileVersion(), f.LastWriteTimeUtc, f.FullName.Replace(this.imageStorePath, string.Empty))).ToList();
                return new ImageStoreContent(files, directories);
            }
            else
            {
                serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
                var requestId = Guid.NewGuid().ToString();
                var url = "ImageStore";
                var queryParams = new List<string>();

                // Append to queryParams if not null.
                serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
                queryParams.Add("api-version=6.0");
                url += "?" + string.Join("&", queryParams);

                HttpRequestMessage RequestFunc()
                {
                    var request = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                    };
                    return request;
                }

                return await this.httpClient.SendAsyncGetResponse(RequestFunc, url, ImageStoreContentConverter.Deserialize, requestId, cancellationToken);
            }
        }

        /// <inheritdoc />
        public async Task CopyImageStoreContentAsync(
            ImageStoreCopyDescription imageStoreCopyDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            imageStoreCopyDescription.ThrowIfNull(nameof(imageStoreCopyDescription));

            await this.LoadImageStoreConnectionString();
            if (this.isLocalStore)
            {
                var source = Path.Combine(this.imageStorePath, imageStoreCopyDescription.RemoteSource);
                var destination = Path.Combine(this.imageStorePath, imageStoreCopyDescription.RemoteDestination);

                var attr = File.GetAttributes(source);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    var files = Directory.EnumerateFiles(source, "*", SearchOption.AllDirectories)
                    .Select(file => new System.IO.FileInfo(file));

                    foreach (var file in files)
                    {
                        var targetPath = Path.Combine(this.imageStorePath, Path.Combine(destination, file.FullName.Substring(source.Length + 1)));
                        if (!Directory.Exists(Path.GetDirectoryName(targetPath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
                        }

                        File.Copy(file.FullName, targetPath, true);
                    }
                }
                else
                {
                    File.Copy(source, destination, true);
                }
            }
            else
            {
                serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
                var requestId = Guid.NewGuid().ToString();
                var url = "ImageStore/$/Copy";
                var queryParams = new List<string>();

                // Append to queryParams if not null.
                serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
                queryParams.Add("api-version=6.0");
                url += "?" + string.Join("&", queryParams);

                string content;
                using (var sw = new StringWriter())
                {
                    ImageStoreCopyDescriptionConverter.Serialize(new JsonTextWriter(sw), imageStoreCopyDescription);
                    content = sw.ToString();
                }

                HttpRequestMessage RequestFunc()
                {
                    var request = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Post,
                        Content = new StringContent(content, Encoding.UTF8),
                    };
                    request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                    return request;
                }

                await this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
            }
        }

        /// <inheritdoc />
        public Task DeleteImageStoreUploadSessionAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            sessionId.ThrowIfNull(nameof(sessionId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "ImageStore/$/DeleteUploadSession";
            var queryParams = new List<string>();

            // Append to queryParams if not null.
            sessionId?.AddToQueryParameters(queryParams, $"session-id={sessionId.ToString()}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Delete,
                };
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task CommitImageStoreUploadSessionAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            sessionId.ThrowIfNull(nameof(sessionId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "ImageStore/$/CommitUploadSession";
            var queryParams = new List<string>();

            // Append to queryParams if not null.
            sessionId?.AddToQueryParameters(queryParams, $"session-id={sessionId.ToString()}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                };
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<UploadSession> GetImageStoreUploadSessionByIdAsync(
            Guid? sessionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            sessionId.ThrowIfNull(nameof(sessionId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "ImageStore/$/GetUploadSession";
            var queryParams = new List<string>();

            // Append to queryParams if not null.
            sessionId?.AddToQueryParameters(queryParams, $"session-id={sessionId.ToString()}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, UploadSessionConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<UploadSession> GetImageStoreUploadSessionByPathAsync(
            string contentPath,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            contentPath.ThrowIfNull(nameof(contentPath));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "ImageStore/{contentPath}/$/GetUploadSession";
            url = url.Replace("{contentPath}", Uri.EscapeDataString(contentPath));
            var queryParams = new List<string>();

            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, UploadSessionConverter.Deserialize, requestId, cancellationToken);
        }
    }
}
