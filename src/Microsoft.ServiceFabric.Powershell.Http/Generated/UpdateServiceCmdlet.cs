// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Updates a Service Fabric service using the specified update description.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFService", DefaultParameterSetName = "UpdateService")]
    public partial class UpdateServiceCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Stateful flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "UpdateService")]
        public SwitchParameter Stateful
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Stateless flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "UpdateService")]
        public SwitchParameter Stateless
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceId. The identity of the service. This ID is typically the full name of the service without the
        /// 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be "myapp~app1~svc1" in
        /// 6.0+ and "myapp/app1/svc1" in previous versions.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, ParameterSetName = "UpdateService")]
        public string ServiceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Flags. Flags indicating whether other properties are set. Each of the associated properties
        /// corresponds to a flag, specified below, which, if set, indicate that the property is specified.
        /// This property can be a combination of those flags obtained using bitwise 'OR' operator.
        /// For example, if the provided value is 6 then the flags for ReplicaRestartWaitDuration (2) and
        /// QuorumLossWaitDuration (4) are set.
        /// 
        /// - None - Does not indicate any other properties are set. The value is zero.
        /// - TargetReplicaSetSize/InstanceCount - Indicates whether the TargetReplicaSetSize property (for Stateful services)
        /// or the InstanceCount property (for Stateless services) is set. The value is 1.
        /// - ReplicaRestartWaitDuration - Indicates the ReplicaRestartWaitDuration property is set. The value is  2.
        /// - QuorumLossWaitDuration - Indicates the QuorumLossWaitDuration property is set. The value is 4.
        /// - StandByReplicaKeepDuration - Indicates the StandByReplicaKeepDuration property is set. The value is 8.
        /// - MinReplicaSetSize - Indicates the MinReplicaSetSize property is set. The value is 16.
        /// - PlacementConstraints - Indicates the PlacementConstraints property is set. The value is 32.
        /// - PlacementPolicyList - Indicates the ServicePlacementPolicies property is set. The value is 64.
        /// - Correlation - Indicates the CorrelationScheme property is set. The value is 128.
        /// - Metrics - Indicates the ServiceLoadMetrics property is set. The value is 256.
        /// - DefaultMoveCost - Indicates the DefaultMoveCost property is set. The value is 512.
        /// - ScalingPolicy - Indicates the ScalingPolicies property is set. The value is 1024.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "UpdateService")]
        public string Flags { get; set; }

        /// <summary>
        /// Gets or sets PlacementConstraints. The placement constraints as a string. Placement constraints are boolean
        /// expressions on node properties and allow for restricting a service to particular nodes based on the service
        /// requirements. For example, to place a service on nodes where NodeType is blue specify the following: "NodeColor ==
        /// blue)".
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "UpdateService")]
        public string PlacementConstraints { get; set; }

        /// <summary>
        /// Gets or sets CorrelationScheme. The correlation scheme.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "UpdateService")]
        public IEnumerable<ServiceCorrelationDescription> CorrelationScheme { get; set; }

        /// <summary>
        /// Gets or sets LoadMetrics. The service load metrics.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "UpdateService")]
        public IEnumerable<ServiceLoadMetricDescription> LoadMetrics { get; set; }

        /// <summary>
        /// Gets or sets ServicePlacementPolicies. The service placement policies.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "UpdateService")]
        public IEnumerable<ServicePlacementPolicyDescription> ServicePlacementPolicies { get; set; }

        /// <summary>
        /// Gets or sets DefaultMoveCost. The move cost for the service. Possible values include: 'Zero', 'Low', 'Medium',
        /// 'High'
        /// 
        /// Specifies the move cost for the service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "UpdateService")]
        public MoveCost? DefaultMoveCost { get; set; }

        /// <summary>
        /// Gets or sets ScalingPolicies. Scaling policies for this service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "UpdateService")]
        public IEnumerable<ScalingPolicyDescription> ScalingPolicies { get; set; }

        /// <summary>
        /// Gets or sets TargetReplicaSetSize. The target replica set size as a number.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ParameterSetName = "UpdateService")]
        public int? TargetReplicaSetSize { get; set; }

        /// <summary>
        /// Gets or sets MinReplicaSetSize. The minimum replica set size as a number.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ParameterSetName = "UpdateService")]
        public int? MinReplicaSetSize { get; set; }

        /// <summary>
        /// Gets or sets ReplicaRestartWaitDurationSeconds. The duration, in seconds, between when a replica goes down and when
        /// a new replica is created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ParameterSetName = "UpdateService")]
        public string ReplicaRestartWaitDurationSeconds { get; set; }

        /// <summary>
        /// Gets or sets QuorumLossWaitDurationSeconds. The maximum duration, in seconds, for which a partition is allowed to
        /// be in a state of quorum loss.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ParameterSetName = "UpdateService")]
        public string QuorumLossWaitDurationSeconds { get; set; }

        /// <summary>
        /// Gets or sets StandByReplicaKeepDurationSeconds. The definition on how long StandBy replicas should be maintained
        /// before being removed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ParameterSetName = "UpdateService")]
        public string StandByReplicaKeepDurationSeconds { get; set; }

        /// <summary>
        /// Gets or sets InstanceCount. The instance count.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ParameterSetName = "UpdateService")]
        public int? InstanceCount { get; set; }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ParameterSetName = "UpdateService")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            ServiceUpdateDescription serviceUpdateDescription = null;
            if (this.Stateful.IsPresent)
            {
                serviceUpdateDescription = new StatefulServiceUpdateDescription(
                    flags: this.Flags,
                    placementConstraints: this.PlacementConstraints,
                    correlationScheme: this.CorrelationScheme,
                    loadMetrics: this.LoadMetrics,
                    servicePlacementPolicies: this.ServicePlacementPolicies,
                    defaultMoveCost: this.DefaultMoveCost,
                    scalingPolicies: this.ScalingPolicies,
                    targetReplicaSetSize: this.TargetReplicaSetSize,
                    minReplicaSetSize: this.MinReplicaSetSize,
                    replicaRestartWaitDurationSeconds: this.ReplicaRestartWaitDurationSeconds,
                    quorumLossWaitDurationSeconds: this.QuorumLossWaitDurationSeconds,
                    standByReplicaKeepDurationSeconds: this.StandByReplicaKeepDurationSeconds);
            }
            else if (this.Stateless.IsPresent)
            {
                serviceUpdateDescription = new StatelessServiceUpdateDescription(
                    flags: this.Flags,
                    placementConstraints: this.PlacementConstraints,
                    correlationScheme: this.CorrelationScheme,
                    loadMetrics: this.LoadMetrics,
                    servicePlacementPolicies: this.ServicePlacementPolicies,
                    defaultMoveCost: this.DefaultMoveCost,
                    scalingPolicies: this.ScalingPolicies,
                    instanceCount: this.InstanceCount);
            }

            this.ServiceFabricClient.Services.UpdateServiceAsync(
                serviceId: this.ServiceId,
                serviceUpdateDescription: serviceUpdateDescription,
                serverTimeout: this.ServerTimeout,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            Console.WriteLine("Success!");
        }
    }
}
