// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Exceptions;
    using Microsoft.ServiceFabric.Client.Exceptions;

    /// <summary>
    /// Interface containing methods for performing EventsStoreClient operataions.
    /// </summary>
    public partial interface IEventsStoreClient
    {
        /// <summary>
        /// Gets all Cluster-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of ClusterEvent objects.
        /// </remarks>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ClusterEvent>> GetClusterEventListAsync(
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all Containers-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of ContainerInstanceEvent objects.
        /// </remarks>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ContainerInstanceEvent>> GetContainersEventListAsync(
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a Node-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of NodeEvent objects.
        /// </remarks>
        /// <param name ="nodeName">Name of Service Fabric node.</param>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<NodeEvent>> GetNodeEventListAsync(
            NodeName nodeName,
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all Nodes-related Events.
        /// </summary>
        /// <remarks>
        /// The response is list of NodeEvent objects.
        /// </remarks>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<NodeEvent>> GetNodesEventListAsync(
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets an Application-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of ApplicationEvent objects.
        /// </remarks>
        /// <param name ="applicationName">Name of Service Fabric Application.</param>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ApplicationEvent>> GetApplicationEventListAsync(
            ApplicationName applicationName,
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all Applications-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of ApplicationEvent objects.
        /// </remarks>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ApplicationEvent>> GetApplicationsEventListAsync(
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a Service-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of ServiceEvent objects.
        /// </remarks>
        /// <param name ="serviceName">Name of Service Fabric Service.</param>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ServiceEvent>> GetServiceEventListAsync(
            ServiceName serviceName,
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all Services-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of ServiceEvent objects.
        /// </remarks>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ServiceEvent>> GetServicesEventListAsync(
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a Partition-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of PartitionEvent objects.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<PartitionEvent>> GetPartitionEventListAsync(
            PartitionId partitionId,
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all Partitions-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of PartitionEvent objects.
        /// </remarks>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<PartitionEvent>> GetPartitionsEventListAsync(
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a Partition Replica-related events.
        /// </summary>
        /// <remarks>
        /// The response is list of ReplicaEvent objects.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="replicaId">The identifier of the replica.</param>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ReplicaEvent>> GetPartitionReplicaEventListAsync(
            PartitionId partitionId,
            ReplicaId replicaId,
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all Replicas-related events for a Partition.
        /// </summary>
        /// <remarks>
        /// The response is list of ReplicaEvent objects.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="startTimeUtc">The start time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="endTimeUtc">The end time of a lookup query in ISO UTC yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="eventsTypesFilter">This is a comma separated string specifying the types of FabricEvents that should
        /// only be included in the response.</param>
        /// <param name ="excludeAnalysisEvents">This param disables the retrieval of AnalysisEvents if true is passed.
        /// </param>
        /// <param name ="skipCorrelationLookup">This param disables the search of CorrelatedEvents information if true is
        /// passed. otherwise the CorrelationEvents get processed and HasCorrelatedEvents field in every FabricEvent gets
        /// populated.
        /// </param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<ReplicaEvent>> GetPartitionReplicasEventListAsync(
            PartitionId partitionId,
            string startTimeUtc,
            string endTimeUtc,
            long? serverTimeout = 60,
            string eventsTypesFilter = default(string),
            bool? excludeAnalysisEvents = default(bool?),
            bool? skipCorrelationLookup = default(bool?),
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all correlated events for a given event.
        /// </summary>
        /// <remarks>
        /// The response is list of FabricEvents.
        /// </remarks>
        /// <param name ="eventInstanceId">The EventInstanceId.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This specifies the time
        /// duration that the client is willing to wait for the requested operation to complete. The default value for this
        /// parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<IEnumerable<FabricEvent>> GetCorrelatedEventListAsync(
            string eventInstanceId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
