// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a stateful service.
    /// </summary>
    public partial class StatefulServiceDescription : ServiceDescription
    {
        /// <summary>
        /// Initializes a new instance of the StatefulServiceDescription class.
        /// </summary>
        /// <param name="serviceName">The full name of the service with 'fabric:' URI scheme.</param>
        /// <param name="serviceTypeName">Name of the service type as specified in the service manifest.</param>
        /// <param name="partitionDescription">The partition description as an object.</param>
        /// <param name="targetReplicaSetSize">The target replica set size as a number.</param>
        /// <param name="minReplicaSetSize">The minimum replica set size as a number.</param>
        /// <param name="hasPersistedState">A flag indicating whether this is a persistent service which stores states on the
        /// local disk. If it is then the value of this property is true, if not it is false.</param>
        /// <param name="applicationName">The name of the application, including the 'fabric:' URI scheme.</param>
        /// <param name="initializationData">The initialization data as an array of bytes. Initialization data is passed to
        /// service instances or replicas when they are created.</param>
        /// <param name="placementConstraints">The placement constraints as a string. Placement constraints are boolean
        /// expressions on node properties and allow for restricting a service to particular nodes based on the service
        /// requirements. For example, to place a service on nodes where NodeType is blue specify the following: "NodeColor ==
        /// blue)".</param>
        /// <param name="correlationScheme">The correlation scheme.</param>
        /// <param name="serviceLoadMetrics">The service load metrics.</param>
        /// <param name="servicePlacementPolicies">The service placement policies.</param>
        /// <param name="defaultMoveCost">Specifies the move cost for the service. Possible values include: 'Zero', 'Low',
        /// 'Medium', 'High'</param>
        /// <param name="isDefaultMoveCostSpecified">Indicates if the DefaultMoveCost property is specified.</param>
        /// <param name="servicePackageActivationMode">The activation mode of service package to be used for a Service Fabric
        /// service. This is specified at the time of creating the Service. Possible values include: 'SharedProcess',
        /// 'ExclusiveProcess'</param>
        /// <param name="serviceDnsName">The DNS name of the service. It requires the DNS system service to be enabled in
        /// Service Fabric cluster.</param>
        /// <param name="scalingPolicies">Scaling policies for this service.</param>
        /// <param name="flags">Flags indicating whether other properties are set. Each of the associated properties
        /// corresponds to a flag, specified below, which, if set, indicate that the property is specified.
        /// This property can be a combination of those flags obtained using bitwise 'OR' operator.
        /// For example, if the provided value is 6 then the flags for QuorumLossWaitDuration (2) and
        /// StandByReplicaKeepDuration(4) are set.
        /// 
        /// - None - Does not indicate any other properties are set. The value is zero.
        /// - ReplicaRestartWaitDuration - Indicates the ReplicaRestartWaitDuration property is set. The value is 1.
        /// - QuorumLossWaitDuration - Indicates the QuorumLossWaitDuration property is set. The value is 2.
        /// - StandByReplicaKeepDuration - Indicates the StandByReplicaKeepDuration property is set. The value is 4.
        /// </param>
        /// <param name="replicaRestartWaitDurationSeconds">The duration, in seconds, between when a replica goes down and when
        /// a new replica is created.</param>
        /// <param name="quorumLossWaitDurationSeconds">The maximum duration, in seconds, for which a partition is allowed to
        /// be in a state of quorum loss.</param>
        /// <param name="standByReplicaKeepDurationSeconds">The definition on how long StandBy replicas should be maintained
        /// before being removed.</param>
        public StatefulServiceDescription(
            ServiceName serviceName,
            string serviceTypeName,
            PartitionSchemeDescription partitionDescription,
            int? targetReplicaSetSize,
            int? minReplicaSetSize,
            bool? hasPersistedState,
            ApplicationName applicationName = default(ApplicationName),
            byte[] initializationData = default(byte[]),
            string placementConstraints = default(string),
            IEnumerable<ServiceCorrelationDescription> correlationScheme = default(IEnumerable<ServiceCorrelationDescription>),
            IEnumerable<ServiceLoadMetricDescription> serviceLoadMetrics = default(IEnumerable<ServiceLoadMetricDescription>),
            IEnumerable<ServicePlacementPolicyDescription> servicePlacementPolicies = default(IEnumerable<ServicePlacementPolicyDescription>),
            MoveCost? defaultMoveCost = default(MoveCost?),
            bool? isDefaultMoveCostSpecified = default(bool?),
            ServicePackageActivationMode? servicePackageActivationMode = default(ServicePackageActivationMode?),
            string serviceDnsName = default(string),
            IEnumerable<ScalingPolicyDescription> scalingPolicies = default(IEnumerable<ScalingPolicyDescription>),
            int? flags = default(int?),
            long? replicaRestartWaitDurationSeconds = default(long?),
            long? quorumLossWaitDurationSeconds = default(long?),
            long? standByReplicaKeepDurationSeconds = default(long?))
            : base(
                serviceName,
                serviceTypeName,
                partitionDescription,
                Common.ServiceKind.Stateful,
                applicationName,
                initializationData,
                placementConstraints,
                correlationScheme,
                serviceLoadMetrics,
                servicePlacementPolicies,
                defaultMoveCost,
                isDefaultMoveCostSpecified,
                servicePackageActivationMode,
                serviceDnsName,
                scalingPolicies)
        {
            targetReplicaSetSize.ThrowIfNull(nameof(targetReplicaSetSize));
            minReplicaSetSize.ThrowIfNull(nameof(minReplicaSetSize));
            hasPersistedState.ThrowIfNull(nameof(hasPersistedState));
            targetReplicaSetSize?.ThrowIfLessThan("targetReplicaSetSize", 1);
            minReplicaSetSize?.ThrowIfLessThan("minReplicaSetSize", 1);
            replicaRestartWaitDurationSeconds?.ThrowIfOutOfInclusiveRange("replicaRestartWaitDurationSeconds", 0, 4294967295);
            quorumLossWaitDurationSeconds?.ThrowIfOutOfInclusiveRange("quorumLossWaitDurationSeconds", 0, 4294967295);
            standByReplicaKeepDurationSeconds?.ThrowIfOutOfInclusiveRange("standByReplicaKeepDurationSeconds", 0, 4294967295);
            this.TargetReplicaSetSize = targetReplicaSetSize;
            this.MinReplicaSetSize = minReplicaSetSize;
            this.HasPersistedState = hasPersistedState;
            this.Flags = flags;
            this.ReplicaRestartWaitDurationSeconds = replicaRestartWaitDurationSeconds;
            this.QuorumLossWaitDurationSeconds = quorumLossWaitDurationSeconds;
            this.StandByReplicaKeepDurationSeconds = standByReplicaKeepDurationSeconds;
        }

        /// <summary>
        /// Gets the target replica set size as a number.
        /// </summary>
        public int? TargetReplicaSetSize { get; }

        /// <summary>
        /// Gets the minimum replica set size as a number.
        /// </summary>
        public int? MinReplicaSetSize { get; }

        /// <summary>
        /// Gets a flag indicating whether this is a persistent service which stores states on the local disk. If it is then
        /// the value of this property is true, if not it is false.
        /// </summary>
        public bool? HasPersistedState { get; }

        /// <summary>
        /// Gets flags indicating whether other properties are set. Each of the associated properties corresponds to a flag,
        /// specified below, which, if set, indicate that the property is specified.
        /// This property can be a combination of those flags obtained using bitwise 'OR' operator.
        /// For example, if the provided value is 6 then the flags for QuorumLossWaitDuration (2) and
        /// StandByReplicaKeepDuration(4) are set.
        /// 
        /// - None - Does not indicate any other properties are set. The value is zero.
        /// - ReplicaRestartWaitDuration - Indicates the ReplicaRestartWaitDuration property is set. The value is 1.
        /// - QuorumLossWaitDuration - Indicates the QuorumLossWaitDuration property is set. The value is 2.
        /// - StandByReplicaKeepDuration - Indicates the StandByReplicaKeepDuration property is set. The value is 4.
        /// </summary>
        public int? Flags { get; }

        /// <summary>
        /// Gets the duration, in seconds, between when a replica goes down and when a new replica is created.
        /// </summary>
        public long? ReplicaRestartWaitDurationSeconds { get; }

        /// <summary>
        /// Gets the maximum duration, in seconds, for which a partition is allowed to be in a state of quorum loss.
        /// </summary>
        public long? QuorumLossWaitDurationSeconds { get; }

        /// <summary>
        /// Gets the definition on how long StandBy replicas should be maintained before being removed.
        /// </summary>
        public long? StandByReplicaKeepDurationSeconds { get; }
    }
}
