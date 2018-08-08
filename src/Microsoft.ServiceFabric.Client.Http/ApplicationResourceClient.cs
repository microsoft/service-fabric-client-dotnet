// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

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

    /// <summary>
    /// Class containing methods for performing ApplicationResourceClient operations.
    /// </summary>
    internal partial class ApplicationResourceClient : IApplicationResourceClient
    {
        private readonly ServiceFabricHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the ApplicationResourceClient class.
        /// </summary>
        /// <param name="httpClient">ServiceFabricHttpClient instance.</param>
        public ApplicationResourceClient(ServiceFabricHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task CreateApplicationResourceAsync(
            string applicationResourceName,
            ApplicationResourceDescription applicationResourceDescription,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationResourceName.ThrowIfNull(nameof(applicationResourceName));
            applicationResourceDescription.ThrowIfNull(nameof(applicationResourceDescription));
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Applications/{applicationResourceName}";
            url = url.Replace("{applicationResourceName}", applicationResourceName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            queryParams.Add("api-version=6.3-preview");
            url += "?" + string.Join("&", queryParams);
            
            string content;
            using (var sw = new StringWriter())
            {
                ApplicationResourceDescriptionConverter.Serialize(new JsonTextWriter(sw), applicationResourceDescription);
                content = sw.ToString();
            }

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    Content = new StringContent(content, Encoding.UTF8),
                };
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                return request;
            }

            return this.httpClient.SendAsync(RequestFunc, url, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ApplicationResourceDescription> GetApplicationResourceAsync(
            string applicationResourceName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationResourceName.ThrowIfNull(nameof(applicationResourceName));
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Applications/{applicationResourceName}";
            url = url.Replace("{applicationResourceName}", applicationResourceName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            queryParams.Add("api-version=6.3-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ApplicationResourceDescriptionConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteApplicationResourceAsync(
            string applicationResourceName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationResourceName.ThrowIfNull(nameof(applicationResourceName));
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Applications/{applicationResourceName}";
            url = url.Replace("{applicationResourceName}", applicationResourceName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            queryParams.Add("api-version=6.3-preview");
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
        public Task<PagedServiceResourceDescriptionList> GetServicesAsync(
            string applicationResourceName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationResourceName.ThrowIfNull(nameof(applicationResourceName));
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Applications/{applicationResourceName}/Services";
            url = url.Replace("{applicationResourceName}", applicationResourceName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            queryParams.Add("api-version=6.3-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, PagedServiceResourceDescriptionListConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ServiceResourceDescription> GetServiceAsync(
            string applicationResourceName,
            string serviceResourceName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationResourceName.ThrowIfNull(nameof(applicationResourceName));
            serviceResourceName.ThrowIfNull(nameof(serviceResourceName));
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Applications/{applicationResourceName}/Services/{serviceResourceName}";
            url = url.Replace("{applicationResourceName}", applicationResourceName);
            url = url.Replace("{serviceResourceName}", serviceResourceName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            queryParams.Add("api-version=6.3-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ServiceResourceDescriptionConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<PagedServiceResourceReplicaDescriptionList> GetReplicasAsync(
            string applicationResourceName,
            string serviceResourceName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationResourceName.ThrowIfNull(nameof(applicationResourceName));
            serviceResourceName.ThrowIfNull(nameof(serviceResourceName));
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Applications/{applicationResourceName}/Services/{serviceResourceName}/replicas";
            url = url.Replace("{applicationResourceName}", applicationResourceName);
            url = url.Replace("{serviceResourceName}", serviceResourceName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            queryParams.Add("api-version=6.3-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, PagedServiceResourceReplicaDescriptionListConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<ServiceResourceReplicaDescription> GetReplicaAsync(
            string applicationResourceName,
            string serviceResourceName,
            string replicaName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationResourceName.ThrowIfNull(nameof(applicationResourceName));
            serviceResourceName.ThrowIfNull(nameof(serviceResourceName));
            replicaName.ThrowIfNull(nameof(replicaName));
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Applications/{applicationResourceName}/Services/{serviceResourceName}/Replicas/{replicaName}";
            url = url.Replace("{applicationResourceName}", applicationResourceName);
            url = url.Replace("{serviceResourceName}", serviceResourceName);
            url = url.Replace("{replicaName}", replicaName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            queryParams.Add("api-version=6.3-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, ServiceResourceReplicaDescriptionConverter.Deserialize, requestId, cancellationToken);
        }
    }
}
