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
    using System.Net;
    using System.Net.Http;
    using System.Security.Authentication;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Client.Exceptions;
    using Microsoft.ServiceFabric.Client.Http.Serialization;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Exceptions;
    using Microsoft.ServiceFabric.Common.Security;
    using Newtonsoft.Json;
    using Resources;

    /// <summary>
    /// Represents a Service Fabric Client to the Http management endpoint (or HttpGatewayEndpoint) of Service Fabric cluster.
    /// </summary>
    public class ServiceFabricHttpClient : ServiceFabricClient, IDisposable
    {   
        private const int MaxTryCount = 2;
        private readonly RandomizedList<Uri> randomizedEndpoints;
        private readonly Func<SecuritySettings> refreshSecuritySettingsFunc = null;
        private readonly SemaphoreSlim lockObj = new SemaphoreSlim(1, 1);
        private readonly HttpClientHandler innerHandler;
        private readonly Random rand = new Random();
        private readonly TimeSpan maxRetryInterval = TimeSpan.FromSeconds(2);
        private readonly HttpClientHandlerWrapper httpClientHandlerWrapper;
        private readonly SecurityType securityType = SecurityType.None;
        private HttpClient httpClient = null;
        private bool disposed = false;
        private SecuritySettings securitySettings = null;

        /// <summary>
        /// Used to synchronize refresh of security settings.
        /// </summary>
        private object syncObj = new object();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFabricHttpClient"/> class.
        /// </summary>
        /// <param name="clusterEndpoint">Uri for Service Cluster management endpoint.</param>
        /// <param name="clientSettings">Client settings for connecting to cluster. Default value is null which means connecting to unsecured cluster.</param>
        /// <param name="innerHandler">The inner handler which is responsible for processing the HTTP response messages. When null or not provided, <see cref="System.Net.Http.HttpClientHandler"/> will be used as last handler in channel.</param>
        /// <param name="delegateHandlers">An ordered list of <see cref="System.Net.Http.DelegatingHandler"/> instances to be invoked in HTTP message channel as message flows to and from the last handler in the channel.
        /// Last handler in the channel is created using <paramref name="innerHandler"/>.</param>
        public ServiceFabricHttpClient(
            Uri clusterEndpoint,
            ClientSettings clientSettings = null,
            HttpClientHandler innerHandler = null,
            params DelegatingHandler[] delegateHandlers) 
            : this(new List<Uri>() { clusterEndpoint }, clientSettings, innerHandler, delegateHandlers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFabricHttpClient"/> class.
        /// </summary>
        /// <param name="clusterEndpoints">Uris for Service Cluster management endpoint.</param>
        /// <param name="clientSettings">Client settings for connecting to cluster. Default value is null which means connecting to unsecured cluster.</param>
        /// <param name="innerHandler">The inner handler which is responsible for processing the HTTP response messages. When null or not provided, <see cref="System.Net.Http.HttpClientHandler"/> will be used as last handler in channel.</param>
        /// <param name="delegateHandlers">An ordered list of <see cref="System.Net.Http.DelegatingHandler"/> instances to be invoked in HTTP message channel as message flows to and from the final handler in the channel.
        /// Last handler in the channel is <paramref name="innerHandler"/>.</param>
        public ServiceFabricHttpClient(
            IReadOnlyList<Uri> clusterEndpoints,
            ClientSettings clientSettings = null,
            HttpClientHandler innerHandler = null,
            params DelegatingHandler[] delegateHandlers)
            : base(clusterEndpoints, clientSettings)
        {
            this.CreateManagementClients();
            var scheme = Uri.UriSchemeHttp;

            // setup security settings
            this.securitySettings = this.ClientSettings?.SecuritySettings?.Invoke();
            this.refreshSecuritySettingsFunc = this.ClientSettings?.SecuritySettings;
            this.securityType = this.securitySettings?.SecurityType ?? SecurityType.None;

            // validate Uri schema.
            if (this.securityType == SecurityType.X509 ||
                this.securityType == SecurityType.Claims)
            {
                scheme = Uri.UriSchemeHttps;
            }

            var invalidClusterEndpoint = this.ClusterEndpoints.FirstOrDefault(url => !string.Equals(url.Scheme, scheme, StringComparison.OrdinalIgnoreCase));

            if (invalidClusterEndpoint != null)
            {
                throw new ArgumentException(string.Format(SR.ErrorUrlScheme, invalidClusterEndpoint.Scheme, scheme));
            }

            if (delegateHandlers.Any(handler => handler == null))
            {
                throw new ArgumentException(SR.ErrorNullDelegateHandler);
            }

            var seed = (int)DateTime.Now.Ticks;
            this.randomizedEndpoints = new RandomizedList<Uri>(this.ClusterEndpoints, new Random(seed));
            this.ClientId = Guid.NewGuid().ToString();
            this.innerHandler = innerHandler ?? new HttpClientHandler();
            this.httpClientHandlerWrapper = new HttpClientHandlerWrapper(this.innerHandler);
            this.httpClient = this.CreateHttpClient(delegateHandlers);

            if (this.ClientSettings?.ClientTimeout != null)
            {
                this.httpClient.Timeout = (TimeSpan)this.ClientSettings.ClientTimeout;
            }
        }

        /// <summary>
        /// Gets the clientId used for tracing.
        /// </summary>
        internal string ClientId { get; }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Sends an HTTP get request to cluster http gateway and deserializes the result.
        /// </summary>
        /// <param name="requestFunc">Func to create HttpRequest to send.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="requestId">Request Id for corelation</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The payload of the GET response.</returns>
        /// <exception cref="ServiceFabricException">When the response is not a success.</exception>
        internal async Task SendAsync(
            Func<HttpRequestMessage> requestFunc,
            string relativeUri,
            string requestId,
            CancellationToken cancellationToken)
        {
            await this.SendAsyncHandleUnsuccessfulResponse(requestFunc, relativeUri, requestId, cancellationToken);
        }

        /// <summary>
        /// Sends an HTTP get request to cluster http gateway and deserializes the result.
        /// </summary>
        /// <typeparam name="T">The type of the response payload.</typeparam>
        /// <param name="requestFunc">Func to create HttpRequest to send.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="deserializeFunc">Func to deserialize T.</param>
        /// <param name="requestId">Request Id for corelation</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The payload of the GET response as T.</returns>
        /// <exception cref="ServiceFabricException">When the response is not a success.</exception>
        internal async Task<T> SendAsyncGetResponse<T>(
            Func<HttpRequestMessage> requestFunc,
            string relativeUri, 
            Func<JsonReader, T> deserializeFunc,
            string requestId,
            CancellationToken cancellationToken)
            where T : class
        {
            var response = await this.SendAsyncHandleUnsuccessfulResponse(requestFunc, relativeUri, requestId, cancellationToken);
            var retValue = default(T);

            if (response.Content != null)
            {
                try
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(contentStream))
                    {
                        using (var reader = new JsonTextReader(streamReader))
                        {
                            retValue = deserializeFunc.Invoke(reader);
                        }
                    }
                }
                catch (JsonReaderException)
                {
                    ServiceFabricHttpClientEventSource.Current.WarningMessage($"{this.ClientId}:{requestId}", SR.ErrorInvalidJsonInResponse);
                }
            }

            return retValue;
        }

        /// <summary>
        /// Sends an HTTP get request to cluster http gateway and deserializes the result.
        /// </summary>
        /// <typeparam name="T">The type of the object in List returned as response payload.</typeparam>
        /// <param name="requestFunc">Func to create HttpRequest to send.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="deserializeFunc">Func to deserialize T.</param>
        /// <param name="requestId">Request Id for corelation</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The payload of the GET response as List of T.</returns>
        /// <exception cref="ServiceFabricException">When the response is not a success.</exception>
        internal async Task<IEnumerable<T>> SendAsyncGetResponseAsList<T>(
            Func<HttpRequestMessage> requestFunc,
            string relativeUri,
            Func<JsonReader, T> deserializeFunc,
            string requestId,
            CancellationToken cancellationToken)
        {
            var response = await this.SendAsyncHandleUnsuccessfulResponse(requestFunc, relativeUri, requestId, cancellationToken);
            var retValue = default(IEnumerable<T>);

            if (response.Content != null)
            {
                try
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(contentStream))
                    {
                        using (var reader = new JsonTextReader(streamReader))
                        {
                            retValue = reader.ReadList(deserializeFunc);
                        }
                    }
                }
                catch (JsonReaderException)
                {
                    ServiceFabricHttpClientEventSource.Current.WarningMessage($"{this.ClientId}:{requestId}", SR.ErrorInvalidJsonInResponse);
                }
            }

            return retValue;
        }

        /// <summary>
        /// Sends an HTTP get request to cluster http gateway and deserializes the result.
        /// </summary>
        /// <typeparam name="T">The type of the object in List returned as response payload.</typeparam>
        /// <param name="requestFunc">Func to create HttpRequest to send.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="deserializeFunc">Func to deserialize T.</param>
        /// <param name="requestId">Request Id for corelation</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The payload of the GET response as List of T.</returns>
        /// <exception cref="ServiceFabricException">When the response is not a success.</exception>
        internal async Task<PagedData<T>> SendAsyncGetResponseAsPagedData<T>(
            Func<HttpRequestMessage> requestFunc,
            string relativeUri,
            Func<JsonReader, T> deserializeFunc,
            string requestId,
            CancellationToken cancellationToken)
        {
            var response = await this.SendAsyncHandleUnsuccessfulResponse(requestFunc, relativeUri, requestId, cancellationToken);
            var retValue = default(PagedData<T>);

            if (response.Content != null)
            {
                try
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(contentStream))
                    {
                        using (var reader = new JsonTextReader(streamReader))
                        {
                            retValue = PagedDataConverter<T>.Deserialize(reader, deserializeFunc);
                        }
                    }
                }
                catch (JsonReaderException)
                {
                    ServiceFabricHttpClientEventSource.Current.WarningMessage($"{this.ClientId}:{requestId}", SR.ErrorInvalidJsonInResponse);
                }
            }

            return retValue;
        }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        /// <param name="disposing">False values indicates the method is being called by the runtime, true value indicates the method is called by the user code.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.httpClient.Dispose();
                    this.httpClient = null;
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Sends an HTTP get request to cluster http gateway.
        /// </summary>
        /// <param name="requestFunc">Func to create HttpRequest to send.</param>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="requestId">Request Id for corelation</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The payload of the GET response.</returns>
        /// <exception cref="ServiceFabricException">When the response is not a success.</exception>
        private async Task<HttpResponseMessage> SendAsyncHandleUnsuccessfulResponse(
            Func<HttpRequestMessage> requestFunc,
            string relativeUri,
            string requestId,
            CancellationToken cancellationToken)
        {
            var response = await this.SendAsyncHandleSecurityExceptions(relativeUri, requestId, requestFunc, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            var message = string.Format(
                SR.ErrorHttpOperationUnsuccessfulFormatString,
                relativeUri,
                response.StatusCode,
                response.ReasonPhrase,
                response.RequestMessage);

            ServiceFabricHttpClientEventSource.Current.ErrorResponse($"{this.ClientId}:{requestId}", message);

            if (response.Content != null)
            {
                FabricError error = null;

                try
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    using (var streamReader = new StreamReader(contentStream))
                    {
                        using (var reader = new JsonTextReader(streamReader))
                        {
                            error = FabricErrorConverter.Deserialize(reader);
                        }
                    }
                }
                catch (JsonReaderException)
                {
                    throw new ServiceFabricException(
                        $"Server returned error while processing the request but did not provide a meaningful error response. Response Error Code {response.StatusCode}");
                }

                if (error != null)
                {
                    throw new ServiceFabricException($"{error.Error.Code.ToString()}. {error.Error.Message}");
                }
            }
            else
            {
                throw new ServiceFabricException(
                    $"Server returned error while processing the request but did not provide a meaningful error response. Response Error Code {response.StatusCode}");
            }

            return response;
        }

        /// <summary>
        /// Send an HTTP request as an asynchronous operation using HttpClient and refreshes security settings if needed.
        /// </summary>
        /// <param name="relativeUri">The relative URI.</param>
        /// <param name="requestId">Request Id.</param>
        /// <param name="requestFunc">Delegate to get HTTP request message to send.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        private async Task<HttpResponseMessage> SendAsyncHandleSecurityExceptions(string relativeUri, string requestId, Func<HttpRequestMessage> requestFunc, CancellationToken cancellationToken)
        {
            // pick a random Uri from endpoints(if more than 1) to send request to.
            var endpoint = this.randomizedEndpoints.GetElement();
            var requestUri = new Uri(endpoint, relativeUri);
            var clientRequestId = $"{this.ClientId}:{requestId}";

            // use corelationId if available in CallContext, this can be added by consumers of this library for further corelation.
            if (ServiceFabricHttpClientCallContext.TryGetCorrelationId(out var correlationId))
            {
                clientRequestId = $"{clientRequestId}:External:{correlationId}";
            }

            HttpRequestMessage FinalRequestFunc()
            {
                var request = requestFunc.Invoke();
                request.RequestUri = requestUri;

                // Add claims token to request if needed.
                if (this.securityType == SecurityType.Claims &&
                    this.securitySettings is ClaimsSecuritySettings claimsSecuritySettings)
                {
                    request.Headers.Add("Authorization", $"Bearer {claimsSecuritySettings.ClaimsToken}");
                }

                // Add client request id to header for corelation on server.
                request.Headers.Add(Constants.ServiceFabricHttpRequestIdHeaderName, $"{clientRequestId}");
                return request;
            }

            // Sends request, if Exception is thrown because Server Cert is not validated OR its Forbidden because of invalid client creds,
            // refreshes security settings by calling the func and retires request one more time. If it faisl again Excpetion is thrown.
            var tryCount = 1;

            while (tryCount <= MaxTryCount)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var serverCertValid = true;

                // wait if other thread is refreshing security settings.
                var obj = await this.WaitToUseHttpClient(cancellationToken);
                HttpResponseMessage response = null;

                try
                {
                    // Get the request using the Func as same request cannot be resent.
                    var request = FinalRequestFunc();
                    ServiceFabricHttpClientEventSource.Current.Send($"{this.ClientId}:{requestId}", $"{request.Method.Method} Request Url: {requestUri}");
                    response = await this.httpClient.SendAsync(request, cancellationToken);                    
                }
                catch (AuthenticationException ex)
                {
                    // Retry on Server cert validation Security error, this check is for dotnet core as AuthentocationException is thrown from
                    // ServerCertificateValidatorHttpWrapper.ValidateServerCertificate 
                    if (tryCount == MaxTryCount)
                    {
                        ServiceFabricHttpClientEventSource.Current.ErrorResponse(
                            $"{this.ClientId}:{requestId}",
                            ex.ToString());
                        throw new InvalidCredentialsException(SR.ErrorRemoteServerCertValidation);
                    }

                    serverCertValid = false;
                    ServiceFabricHttpClientEventSource.Current.RemoteCertValidationError(
                        $"{this.ClientId}:{requestId}",
                        SR.ErrorRemoteCertValidationFailureRetryMessage);
                }
                catch (HttpRequestException ex)
                {        
                    // Retry on Server cert validation Security error, this check is for full dotnet framework as AuthentocationException thrown from
                    // ServerCertificateValidatorHttpWrapper.ValidateServerCertificate is wrapped inside a HttpRequestException
                    if (ex.InnerException?.InnerException is AuthenticationException)                        
                    {
                        if (tryCount == MaxTryCount)
                        {
                            ServiceFabricHttpClientEventSource.Current.ErrorResponse(
                                $"{this.ClientId}:{requestId}",
                                ex.ToString());
                            throw new InvalidCredentialsException(SR.ErrorRemoteServerCertValidation);
                        }

                        serverCertValid = false;
                        ServiceFabricHttpClientEventSource.Current.RemoteCertValidationError(
                            $"{this.ClientId}:{requestId}",
                            SR.ErrorRemoteCertValidationFailureRetryMessage);
                    }
                    else
                    {
                        ServiceFabricHttpClientEventSource.Current.ErrorResponse($"{this.ClientId}:{requestId}", ex.ToString());
                        throw new ServiceFabricRequestException(ex.Message, ex);
                    }
                }

                if (serverCertValid)
                {
                    // server cert was validated, check if client credentials were valid.
                    if (!response.IsSuccessStatusCode)
                    {
                        // RefreshSecurity Settings and try again,
                        if (response.StatusCode == HttpStatusCode.Forbidden && this.refreshSecuritySettingsFunc != null)
                        {
                            if (tryCount == MaxTryCount)
                            {
                                ServiceFabricHttpClientEventSource.Current.ErrorResponse(
                                    $"{this.ClientId}:{requestId}",
                                    SR.ErrorClientCredentialsInvalid);
                                throw new InvalidCredentialsException(SR.ErrorClientCredentialsInvalid);
                            }

                            ServiceFabricHttpClientEventSource.Current.ClientCertInvalid(
                                $"{this.ClientId}:{requestId}",
                                SR.ErrorInvalidClientCredentialsRetryMessage);
                        }
                        else
                        {
                            return response;
                        }
                    }
                    else
                    {
                        return response;
                    }
                }

                // refresh security settings.
                await this.RefreshSecuritySettings(obj, cancellationToken);

                // wait before retry
                await Task.Delay(new TimeSpan((long)(this.rand.NextDouble() * this.maxRetryInterval.Ticks)), cancellationToken);
                tryCount++;
            }

            return null;
        }

        private async Task<object> WaitToUseHttpClient(CancellationToken cancellationToken)
        {
            await this.lockObj.WaitAsync(cancellationToken);
            try
            {
                return this.syncObj;
            }
            finally
            {
                this.lockObj.Release();
            }
        }

        private async Task RefreshSecuritySettings(object obj, CancellationToken cancellationToken)
        {
            await this.lockObj.WaitAsync(cancellationToken);
            try
            {
                // only refresh if syncObj is same as the object acquired by thread from WaitToUseHttpClient().
                // If its not same, that means that some other thread has refreshed.
                if (object.ReferenceEquals(obj, this.syncObj))
                {
                    if (this.refreshSecuritySettingsFunc != null)
                    {
                        var newSecuritySettings = this.refreshSecuritySettingsFunc.Invoke();

                        if (newSecuritySettings.SecurityType != this.securityType)
                        {
                            throw new InvalidOperationException(SR.ErrorCannotChangeSecurityType);
                        }

                        // Refresh settings for HttpClientHandler.
                        this.securitySettings = newSecuritySettings;
                        this.httpClientHandlerWrapper.RefreshSecuritySettings(newSecuritySettings);
                    }
                    
                    this.syncObj = new object();
                }
            }
            finally
            {
                this.lockObj.Release();
            }
        }
        
        private HttpClient CreateHttpClient(DelegatingHandler[] delegateHandlers)
        {
            if (this.securitySettings != null)
            {
                this.httpClientHandlerWrapper.ConfigureSecuritySettings(this.securitySettings);
            }

            HttpMessageHandler pipeline = this.innerHandler;
            for (var i = delegateHandlers.Length - 1; i >= 0; i--)
            {
                var handler = delegateHandlers[i];
                handler.InnerHandler = pipeline;
                pipeline = handler;
            }

            return new HttpClient(pipeline, true);
        }

        private void CreateManagementClients()
        {
            this.Applications = new ApplicationClient(this);
            this.ApplicationTypes = new ApplicationTypeClient(this);
            this.BackupRestore = new BackupRestoreClient(this);
            this.ChaosClient = new ChaosClient(this);
            this.Cluster = new ClusterClient(this);
            this.CodePackages = new CodePackageClient(this);
            this.ComposeDeployments = new ComposeDeploymentClient(this);
            this.Faults = new FaultsClient(this);
            this.ImageStore = new ImageStoreClient(this);
            this.Infrastructure = new InfrastructureClient(this);
            this.Nodes = new NodeClient(this);
            this.Partitions = new PartitionClient(this);
            this.Properties = new PropertyManagementClient(this);
            this.Replicas = new ReplicaClient(this);
            this.Repairs = new RepairManagementClient(this);
            this.Services = new ServiceClient(this);
            this.ServicePackages = new ServicePackageClient(this);
            this.ServiceTypes = new ServiceTypeClient(this);
            this.EventsStore = new EventsStoreClient(this);
        }
    }
}
