// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

using System.Net.Http.Headers;


namespace Microsoft.ServiceFabric.Client.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Client.Http.Serialization;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;

    internal partial class ImageStoreClient
    {
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
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var url = "ImageStore/{pathInImageStore}";
            url = url.Replace("{pathInImageStore}", Uri.EscapeDataString(pathInImageStore.ToString()));
            requestId = requestId ?? Guid.NewGuid().ToString();
            var queryParams = new List<string>();

            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    Content = new ByteArrayContent(fileContentsToUpload)
                };

                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
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

        /// <summary>
        /// Uploads a file chunk to the image store relative path. Used by IApplicationClient.UploadApplicationPackageAsync to trace a request Id associated with original Uplaod call.
        /// </summary>
        /// <param name="fileChunkToUpload">Byte array containing file chunk to upload.</param>
        /// <param name ="pathInImageStore">Relative path to file or folder in the image store from its root.</param>
        /// <param name ="sessionId">A GUID generated by the user for a file uploading. It identifies an image store upload
        /// session which keeps track of all file chunks until it is committed.</param>
        /// <param name ="startBytePosition">The start position of the chunk in byte array represnting file contents.</param>
        /// <param name ="endBytePosition">The end position of the chunk in byte array representing file contents.</param>
        /// <param name="length">The size, in bytes, of the file for which chunk is to be uploaded.</param>
        /// <param name="requestId">Request Id to use for tracing.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <remarks>
        /// When uploading file chunks to the image store,  the Content Range information is sent to server.
        /// Example: if the total file length is 20,000 bytes, and chunk being uploaded is for first 5,000 bytes,
        /// value of <paramref name="startBytePosition"/> would be 0, value of <paramref name="endBytePosition"/> would be 4999 and value of
        /// <paramref name="length"/> would be 5000.
        /// </remarks>
        internal async Task UploadFileChunkAsync(
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
            pathInImageStore.ThrowIfNull(nameof(fileChunkToUpload));
            pathInImageStore.ThrowIfNull(nameof(pathInImageStore));
            sessionId.ThrowIfNull(nameof(sessionId));
            startBytePosition.ThrowIfNull(nameof(startBytePosition));
            endBytePosition.ThrowIfNull(nameof(endBytePosition));
            length.ThrowIfNull(nameof(length));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            requestId = requestId ?? Guid.NewGuid().ToString();
            var url = "ImageStore/{pathInImageStore}/$/UploadChunk";
            url = url.Replace("{pathInImageStore}", Uri.EscapeDataString(pathInImageStore.ToString()));
            var queryParams = new List<string>();

            // Append to queryParams if not null.
            sessionId?.AddToQueryParameters(queryParams, $"session-id={sessionId}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.0");
            url += "?" + string.Join("&", queryParams);

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    Content = new ByteArrayContent(fileChunkToUpload)
                };

                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                request.Content.Headers.ContentRange =
                    new ContentRangeHeaderValue(startBytePosition, endBytePosition, length);
                return request;
            }

            await this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }
    }
}
