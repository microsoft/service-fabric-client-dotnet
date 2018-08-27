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
    /// Interface containing methods for performing MeshApplicationsClient operations.
    /// </summary>
    public partial interface IMeshApplicationsClient
    {
        /// <summary>
        /// Creates or updates an application resource.
        /// </summary>
        /// <remarks>
        /// Creates an application with the specified name and description. If an application with the same name already
        /// exists, then its description are updated to the one indicated in this request.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="applicationResourceDescription">Description for creating an application resource.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task CreateOrUpdateMeshApplicationAsync(
            string applicationResourceName,
            ApplicationResourceDescription applicationResourceDescription,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the application with the given name.
        /// </summary>
        /// <remarks>
        /// Gets the application with the given name. This includes the information about the application's services and other
        /// runtime information.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<ApplicationResourceDescription> GetMeshApplicationAsync(
            string applicationResourceName,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified application.
        /// </summary>
        /// <remarks>
        /// Deletes the application identified by the name.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task DeleteMeshApplicationAsync(
            string applicationResourceName,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all the services in the application resource.
        /// </summary>
        /// <remarks>
        /// The operation returns the service descriptions of all the services in the application resource.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<ServiceResourceDescription>> GetMeshServicesAsync(
            string applicationResourceName,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the description of the specified service in an application resource.
        /// </summary>
        /// <remarks>
        /// Gets the description of the service resource.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="serviceResourceName">Service Fabric service resource name.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<ServiceResourceDescription> GetMeshServiceAsync(
            string applicationResourceName,
            string serviceResourceName,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets replicas of a given service in an applciation resource.
        /// </summary>
        /// <remarks>
        /// Gets the information about all replicas of a given service of an application. The information includes the runtime
        /// properties of the replica instance.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="serviceResourceName">Service Fabric service resource name.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<ServiceReplicaDescription>> GetMeshReplicasAsync(
            string applicationResourceName,
            string serviceResourceName,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a specific replica of a given service in an application resource.
        /// </summary>
        /// <remarks>
        /// Gets the information about the specified replica of a given service of an application. The information includes the
        /// runtime properties of the replica instance.
        /// </remarks>
        /// <param name ="applicationResourceName">Service Fabric application resource name.
        /// </param>
        /// <param name ="serviceResourceName">Service Fabric service resource name.
        /// </param>
        /// <param name ="replicaName">Service Fabric replica name.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<ServiceReplicaDescription> GetMeshReplicaAsync(
            string applicationResourceName,
            string serviceResourceName,
            string replicaName,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
