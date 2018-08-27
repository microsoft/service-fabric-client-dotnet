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
    /// Class containing methods for performing MeshNetworksClient operations.
    /// </summary>
    internal partial class MeshNetworksClient : IMeshNetworksClient
    {
        private readonly ServiceFabricHttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the MeshNetworksClient class.
        /// </summary>
        /// <param name="httpClient">ServiceFabricHttpClient instance.</param>
        public MeshNetworksClient(ServiceFabricHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<DeployedNetworkCodePackageInfo> GetDeployedNetworkCodePackageInfoAsync(
            NodeName nodeName,
            string networkName,
            string codePackageName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            nodeName.ThrowIfNull(nameof(nodeName));
            networkName.ThrowIfNull(nameof(networkName));
            codePackageName.ThrowIfNull(nameof(codePackageName));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Nodes/{nodeName}/$/GetNetworks/{networkName}/$/GetCodePackages/{codePackageName}";
            url = url.Replace("{nodeName}", Uri.EscapeDataString(nodeName.ToString()));
            url = url.Replace("{networkName}", networkName);
            url = url.Replace("{codePackageName}", codePackageName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, DeployedNetworkCodePackageInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<PagedData<DeployedNetworkCodePackageInfo>> GetDeployedNetworkCodePackageInfoListAsync(
            NodeName nodeName,
            string networkName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            nodeName.ThrowIfNull(nameof(nodeName));
            networkName.ThrowIfNull(nameof(networkName));
            maxResults?.ThrowIfLessThan("maxResults", 0);
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Nodes/{nodeName}/$/GetNetworks/{networkName}/$/GetCodePackages";
            url = url.Replace("{nodeName}", Uri.EscapeDataString(nodeName.ToString()));
            url = url.Replace("{networkName}", networkName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            continuationToken?.AddToQueryParameters(queryParams, $"ContinuationToken={continuationToken.ToString()}");
            maxResults?.AddToQueryParameters(queryParams, $"MaxResults={maxResults}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponseAsPagedData(RequestFunc, url, DeployedNetworkCodePackageInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<PagedData<DeployedNetworkInfo>> GetDeployedNetworkInfoListAsync(
            NodeName nodeName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            nodeName.ThrowIfNull(nameof(nodeName));
            maxResults?.ThrowIfLessThan("maxResults", 0);
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Nodes/{nodeName}/$/GetNetworks";
            url = url.Replace("{nodeName}", Uri.EscapeDataString(nodeName.ToString()));
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            continuationToken?.AddToQueryParameters(queryParams, $"ContinuationToken={continuationToken.ToString()}");
            maxResults?.AddToQueryParameters(queryParams, $"MaxResults={maxResults}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponseAsPagedData(RequestFunc, url, DeployedNetworkInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<PagedData<ApplicationNetworkInfo>> GetApplicationNetworkInfoListAsync(
            string applicationId,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            applicationId.ThrowIfNull(nameof(applicationId));
            maxResults?.ThrowIfLessThan("maxResults", 0);
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Applications/{applicationId}/$/GetNetworks";
            url = url.Replace("{applicationId}", applicationId);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            continuationToken?.AddToQueryParameters(queryParams, $"ContinuationToken={continuationToken.ToString()}");
            maxResults?.AddToQueryParameters(queryParams, $"MaxResults={maxResults}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponseAsPagedData(RequestFunc, url, ApplicationNetworkInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task CreateOrUpdateMeshNetworkAsync(
            string networkName,
            NetworkDescription networkDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            networkName.ThrowIfNull(nameof(networkName));
            networkDescription.ThrowIfNull(nameof(networkDescription));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks/{networkName}";
            url = url.Replace("{networkName}", networkName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            string content;
            using (var sw = new StringWriter())
            {
                NetworkDescriptionConverter.Serialize(new JsonTextWriter(sw), networkDescription);
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
        public Task DeleteMeshNetworkAsync(
            string networkName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            networkName.ThrowIfNull(nameof(networkName));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks/{networkName}";
            url = url.Replace("{networkName}", networkName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
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
        public Task<NetworkDescription> GetMeshNetworkAsync(
            string networkName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            networkName.ThrowIfNull(nameof(networkName));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks/{networkName}";
            url = url.Replace("{networkName}", networkName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, NetworkDescriptionConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<NetworkApplicationInfo> GetMeshNetworkApplicationRefAsync(
            string networkName,
            string applicationId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            networkName.ThrowIfNull(nameof(networkName));
            applicationId.ThrowIfNull(nameof(applicationId));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks/{networkName}/ApplicationRefs/{applicationId}";
            url = url.Replace("{networkName}", networkName);
            url = url.Replace("{applicationId}", applicationId);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, NetworkApplicationInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<PagedData<NetworkApplicationInfo>> GetMeshNetworkApplicationRefListAsync(
            string networkName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            networkName.ThrowIfNull(nameof(networkName));
            maxResults?.ThrowIfLessThan("maxResults", 0);
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks/{networkName}/ApplicationRefs";
            url = url.Replace("{networkName}", networkName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            continuationToken?.AddToQueryParameters(queryParams, $"ContinuationToken={continuationToken.ToString()}");
            maxResults?.AddToQueryParameters(queryParams, $"MaxResults={maxResults}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponseAsPagedData(RequestFunc, url, NetworkApplicationInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<PagedData<NetworkDescription>> GetMeshNetworksAsync(
            int? networkStatusFilter = 0,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            maxResults?.ThrowIfLessThan("maxResults", 0);
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks";
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            networkStatusFilter?.AddToQueryParameters(queryParams, $"NetworkStatusFilter={networkStatusFilter}");
            continuationToken?.AddToQueryParameters(queryParams, $"ContinuationToken={continuationToken.ToString()}");
            maxResults?.AddToQueryParameters(queryParams, $"MaxResults={maxResults}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponseAsPagedData(RequestFunc, url, NetworkDescriptionConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<NetworkNodeInfo> GetMeshNetworkNodeInfoAsync(
            string networkName,
            NodeName nodeName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            networkName.ThrowIfNull(nameof(networkName));
            nodeName.ThrowIfNull(nameof(nodeName));
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks/{networkName}/DeployedNodes/{nodeName}";
            url = url.Replace("{networkName}", networkName);
            url = url.Replace("{nodeName}", Uri.EscapeDataString(nodeName.ToString()));
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, NetworkNodeInfoConverter.Deserialize, requestId, cancellationToken);
        }

        /// <inheritdoc />
        public Task<PagedData<NetworkNodeInfo>> GetMeshNetworkNodeInfoListAsync(
            string networkName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            networkName.ThrowIfNull(nameof(networkName));
            maxResults?.ThrowIfLessThan("maxResults", 0);
            serverTimeout?.ThrowIfOutOfInclusiveRange("serverTimeout", 1, 4294967295);
            var requestId = Guid.NewGuid().ToString();
            var url = "Resources/Networks/{networkName}/DeployedNodes";
            url = url.Replace("{networkName}", networkName);
            var queryParams = new List<string>();
            
            // Append to queryParams if not null.
            continuationToken?.AddToQueryParameters(queryParams, $"ContinuationToken={continuationToken.ToString()}");
            maxResults?.AddToQueryParameters(queryParams, $"MaxResults={maxResults}");
            serverTimeout?.AddToQueryParameters(queryParams, $"timeout={serverTimeout}");
            queryParams.Add("api-version=6.4-preview");
            url += "?" + string.Join("&", queryParams);
            
            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
                return request;
            }

            return this.httpClient.SendAsyncGetResponseAsPagedData(RequestFunc, url, NetworkNodeInfoConverter.Deserialize, requestId, cancellationToken);
        }
    }
}
