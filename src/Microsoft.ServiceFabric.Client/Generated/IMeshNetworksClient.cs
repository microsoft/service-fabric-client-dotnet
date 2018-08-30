// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client.Exceptions;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Exceptions;

    /// <summary>
    /// Interface containing methods for performing MeshNetworksClient operations.
    /// </summary>
    public partial interface IMeshNetworksClient
    {
        /// <summary>
        /// Gets information about a Service Fabric code package deployed to a Service Fabric node associated with a Service
        /// Fabric container network.
        /// </summary>
        /// <remarks>
        /// Gets the information about a code package
        /// 1) whose name matches the one specified as the code package name parameter
        /// 2) that is deployed to a node whose name matches the one specified as the node name parameter
        /// 3) that is a member of a container network whose name matches the one specified as the network name parameter
        /// 
        /// The response includes the application name, network name, code package name, code package version, service manifest
        /// name,
        /// service package activation id, container address and container id of the code package.
        /// </remarks>
        /// <param name ="nodeName">The name of the node.</param>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="codePackageName">The name of a Service Fabric code package defined in the service manifest.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<DeployedNetworkCodePackageInfo> GetDeployedNetworkCodePackageInfoAsync(
            NodeName nodeName,
            string networkName,
            string codePackageName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of Service Fabric code packages deployed to a Service Fabric node associated with a Service Fabric
        /// container network.
        /// </summary>
        /// <remarks>
        /// Gets the information about the code packages that are
        /// 1) deployed to a node whose name matches the one specified as the node name parameter
        /// 2) are members of a container network whose name matches the one specified as the network name parameter
        /// 
        /// The response includes the application name, network name, code package name, code package version, service manifest
        /// name,
        /// service package activation id, container address and container id of the code packages.
        /// 
        /// If the code packages do not fit in a page, one page of results is returned as well as a continuation token, which
        /// can be used to get the next page.
        /// </remarks>
        /// <param name ="nodeName">The name of the node.</param>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="continuationToken">The continuation token to obtain next set of results</param>
        /// <param name ="maxResults">The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<DeployedNetworkCodePackageInfo>> GetDeployedNetworkCodePackageInfoListAsync(
            NodeName nodeName,
            string networkName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of Service Fabric container networks deployed to a Service Fabric node.
        /// </summary>
        /// <remarks>
        /// Gets the information about the container networks deployed to a node whose name matches the one specified as the
        /// node name parameter.
        /// 
        /// The response includes the names of the container networks.
        /// 
        /// If the container networks do not fit in a page, one page of results is returned as well as a continuation token,
        /// which can be used to get the next page.
        /// </remarks>
        /// <param name ="nodeName">The name of the node.</param>
        /// <param name ="continuationToken">The continuation token to obtain next set of results</param>
        /// <param name ="maxResults">The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<DeployedNetworkInfo>> GetDeployedNetworkInfoListAsync(
            NodeName nodeName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of Service Fabric container networks that a Service Fabric application is associated with.
        /// </summary>
        /// <remarks>
        /// Gets the information about the container networks a Service Fabric application whose name matches the one specified
        /// as the application id parameter is a member of.
        /// 
        /// The response includes the names of the container networks.
        /// 
        /// If the container networks do not fit in a page, one page of results is returned as well as a continuation token,
        /// which can be used to get the next page.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="continuationToken">The continuation token to obtain next set of results</param>
        /// <param name ="maxResults">The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<ApplicationNetworkInfo>> GetApplicationNetworkInfoListAsync(
            string applicationResourceName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates or updates a Service Fabric container network.
        /// </summary>
        /// <remarks>
        /// Create a container network for container based Service Fabric applications.
        /// Once created, a container network allows container based applications to join and communicate to other applications
        /// on the same network.
        /// If a network with the same name already exists, then its description is updated to the one indicated in this
        /// request.
        /// 
        /// Specifically, containers of member applications would be assigned logical IPs from the container network's address
        /// space and those containers can then communicate with each other using the logical IPs.
        /// The logical IPs are not reachable from outside the container network. To reach containers inside a container
        /// network, use dual-homed containers exposing endpoints both inside and outside the container network.
        /// </remarks>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="networkDescription">Description for creating a container network.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task CreateOrUpdateMeshNetworkAsync(
            string networkName,
            NetworkDescription networkDescription,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes an existing Service Fabric container network.
        /// </summary>
        /// <remarks>
        /// A container network must be created before it can be deleted.
        /// 
        /// A container network with any application member cannot be deleted. Remove all member applications from a container
        /// network before deleting it.
        /// </remarks>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task DeleteMeshNetworkAsync(
            string networkName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets information about a Service Fabric container network.
        /// </summary>
        /// <remarks>
        /// Returns the information about the container network that was created in the Service Fabric cluster whose network
        /// name matches the one specified as the network name parameter.
        /// 
        /// The response includes the name, type, status of the container network as well as type-specific information.
        /// </remarks>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<NetworkDescription> GetMeshNetworkAsync(
            string networkName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets information about a Service Fabric application that is associated with a Service Fabric container network.
        /// </summary>
        /// <remarks>
        /// Gets the information about an application
        /// 1) whose name matches the one specified as application name parameter
        /// 2) is a member of the container network whose network name matches the one specified as the network name parameter.
        /// 
        /// The response includes the name of the application.
        /// </remarks>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<NetworkApplicationInfo> GetMeshNetworkApplicationRefAsync(
            string networkName,
            string applicationResourceName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of Service Fabric applications that are associated wtih a Service Fabric container network.
        /// </summary>
        /// <remarks>
        /// Gets the information about the applications that are members of the container network whose network name matches
        /// the one specified as the parameter.
        /// 
        /// The response includes the names of the applications.
        /// 
        /// If the applications do not fit in a page, one page of results is returned as well as a continuation token, which
        /// can be used to get the next page.
        /// </remarks>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="continuationToken">The continuation token to obtain next set of results</param>
        /// <param name ="maxResults">The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<NetworkApplicationInfo>> GetMeshNetworkApplicationRefListAsync(
            string networkName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of Service Fabric container networks created in the Service Fabric cluster that match the specified
        /// filters.
        /// </summary>
        /// <remarks>
        /// Gets the information about the container networks that were created in the Service Fabric cluster that match the
        /// specified filters.
        /// 
        /// The response includes the name, type, status of the container networks as well as network type specific information
        /// like network address prefix of local container networks.
        /// 
        /// If the container networks do not fit in a page, one page of results is returned as well as a continuation token,
        /// which can be used to get the next page.
        /// </remarks>
        /// <param name ="networkStatusFilter">Allow filtering of container network state objects returned by
        /// GetNetworkInfoList query based on the container networks' status.
        /// - Default - Default value, which performs the same function as selecting "all". The value is 0.
        /// - All - Filter that matches input with any NetworkStatus value. The value is 65535.
        /// - Ready - Filter that matches input with NetworkStatus value ready. The value is 1.
        /// - Creating - Filter that matches input with NetworkStatus value creating. The value is 2.
        /// - Deleting - Filter that matches input with NetworkStatus value deleting. The value is 4.
        /// - Updating - Filter that matches input with NetworkStatus value updating. The value is 8.
        /// - Stopping - Filter that matches input with NetworkStatus value stopping. The value is 16.
        /// - Stopped - Filter that matches input with NetworkStatus value stopped. The value is 32.
        /// - Starting - Filter that matches input with NetworkStatus value starting. The value is 64.
        /// - Failed - Filter that matches input with NetworkStatus value failed. The value is 128.
        /// </param>
        /// <param name ="continuationToken">The continuation token to obtain next set of results</param>
        /// <param name ="maxResults">The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<NetworkDescription>> GetMeshNetworksAsync(
            int? networkStatusFilter = 0,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the information about a Service Fabric node that a Service Fabric container network is deployed to.
        /// </summary>
        /// <remarks>
        /// Gets the information about a node
        /// 1) Whose name matches the one specified as the node name parameter
        /// 2) That a container network whose network name matches the one specified as the network name parameter is deployed
        /// to.
        /// 
        /// The response includes the name of the node.
        /// </remarks>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="nodeName">The name of the node.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<NetworkNodeInfo> GetMeshNetworkNodeInfoAsync(
            string networkName,
            NodeName nodeName,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the list of Service Fabric nodes a Service Fabric container network is deployed to.
        /// </summary>
        /// <remarks>
        /// Gets the information about the nodes a container network whose network name matches the one specified as the
        /// network name parameter is deployed to.
        /// 
        /// The response includes the names of the nodes.
        /// 
        /// If the nodes do not fit in a page, one page of results is returned as well as a continuation token, which can be
        /// used to get the next page.
        /// </remarks>
        /// <param name ="networkName">The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </param>
        /// <param name ="continuationToken">The continuation token to obtain next set of results</param>
        /// <param name ="maxResults">The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<NetworkNodeInfo>> GetMeshNetworkNodeInfoListAsync(
            string networkName,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? maxResults = 0,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
