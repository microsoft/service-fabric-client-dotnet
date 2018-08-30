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
    /// Creates the specified Service Fabric service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFService", DefaultParameterSetName = "CreateService")]
    public partial class NewServiceCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Named flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "CreateService")]
        public SwitchParameter Named
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Singleton flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "CreateService")]
        public SwitchParameter Singleton
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UniformInt64Range flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "CreateService")]
        public SwitchParameter UniformInt64Range
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Stateful flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "CreateService")]
        public SwitchParameter Stateful
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Stateless flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "CreateService")]
        public SwitchParameter Stateless
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationId. The identity of the application. This is typically the full name of the application
        /// without the 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the application name is "fabric:/myapp/app1", the application identity would be "myapp~app1" in
        /// 6.0+ and "myapp/app1" in previous versions.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, ParameterSetName = "CreateService")]
        public string ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceName. The full name of the service with 'fabric:' URI scheme.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "CreateService")]
        public ServiceName ServiceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceTypeName. Name of the service type as specified in the service manifest.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = "CreateService")]
        public string ServiceTypeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Count. The number of partitions.
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, ParameterSetName = "CreateService")]
        [Parameter(Mandatory = true, Position = 5, ParameterSetName = "CreateService")]
        public int? Count
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Names. Array of size specified by the ‘Count’ parameter, for the names of the partitions.
        /// </summary>
        [Parameter(Mandatory = true, Position = 6, ParameterSetName = "CreateService")]
        public IEnumerable<string> Names
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets LowKey. String indicating the lower bound of the partition key range that
        /// should be split between the partitions.
        /// </summary>
        [Parameter(Mandatory = true, Position = 7, ParameterSetName = "CreateService")]
        public string LowKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets HighKey. String indicating the upper bound of the partition key range that
        /// should be split between the partitions.
        /// </summary>
        [Parameter(Mandatory = true, Position = 8, ParameterSetName = "CreateService")]
        public string HighKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets TargetReplicaSetSize. The target replica set size as a number.
        /// </summary>
        [Parameter(Mandatory = true, Position = 9, ParameterSetName = "CreateService")]
        public int? TargetReplicaSetSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MinReplicaSetSize. The minimum replica set size as a number.
        /// </summary>
        [Parameter(Mandatory = true, Position = 10, ParameterSetName = "CreateService")]
        public int? MinReplicaSetSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets HasPersistedState. A flag indicating whether this is a persistent service which stores states on the
        /// local disk. If it is then the value of this property is true, if not it is false.
        /// </summary>
        [Parameter(Mandatory = true, Position = 11, ParameterSetName = "CreateService")]
        public bool? HasPersistedState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets InstanceCount. The instance count.
        /// </summary>
        [Parameter(Mandatory = true, Position = 12, ParameterSetName = "CreateService")]
        public int? InstanceCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationName. The name of the application, including the 'fabric:' URI scheme.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ParameterSetName = "CreateService")]
        public ApplicationName ApplicationName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets InitializationData. The initialization data as an array of bytes. Initialization data is passed to
        /// service instances or replicas when they are created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ParameterSetName = "CreateService")]
        public byte[] InitializationData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets PlacementConstraints. The placement constraints as a string. Placement constraints are boolean
        /// expressions on node properties and allow for restricting a service to particular nodes based on the service
        /// requirements. For example, to place a service on nodes where NodeType is blue specify the following: "NodeColor ==
        /// blue)".
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ParameterSetName = "CreateService")]
        public string PlacementConstraints
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets CorrelationScheme. The correlation scheme.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ParameterSetName = "CreateService")]
        public IEnumerable<ServiceCorrelationDescription> CorrelationScheme
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceLoadMetrics. The service load metrics.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ParameterSetName = "CreateService")]
        public IEnumerable<ServiceLoadMetricDescription> ServiceLoadMetrics
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServicePlacementPolicies. The service placement policies.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ParameterSetName = "CreateService")]
        public IEnumerable<ServicePlacementPolicyDescription> ServicePlacementPolicies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets DefaultMoveCost. The move cost for the service. Possible values include: 'Zero', 'Low', 'Medium',
        /// 'High'
        /// 
        /// Specifies the move cost for the service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ParameterSetName = "CreateService")]
        public MoveCost? DefaultMoveCost
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets IsDefaultMoveCostSpecified. Indicates if the DefaultMoveCost property is specified.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ParameterSetName = "CreateService")]
        public bool? IsDefaultMoveCostSpecified
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServicePackageActivationMode. The activation mode of service package to be used for a service.
        /// Possible values include: 'SharedProcess', 'ExclusiveProcess'
        /// 
        /// The activation mode of service package to be used for a Service Fabric service. This is specified at the time of
        /// creating the Service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ParameterSetName = "CreateService")]
        public ServicePackageActivationMode? ServicePackageActivationMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceDnsName. The DNS name of the service. It requires the DNS system service to be enabled in
        /// Service Fabric cluster.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ParameterSetName = "CreateService")]
        public string ServiceDnsName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ScalingPolicies. Scaling policies for this service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ParameterSetName = "CreateService")]
        public IEnumerable<ScalingPolicyDescription> ScalingPolicies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Flags. Flags indicating whether other properties are set. Each of the associated properties
        /// corresponds to a flag, specified below, which, if set, indicate that the property is specified.
        /// This property can be a combination of those flags obtained using bitwise 'OR' operator.
        /// For example, if the provided value is 6 then the flags for QuorumLossWaitDuration (2) and
        /// StandByReplicaKeepDuration(4) are set.
        /// 
        /// - None - Does not indicate any other properties are set. The value is zero.
        /// - ReplicaRestartWaitDuration - Indicates the ReplicaRestartWaitDuration property is set. The value is 1.
        /// - QuorumLossWaitDuration - Indicates the QuorumLossWaitDuration property is set. The value is 2.
        /// - StandByReplicaKeepDuration - Indicates the StandByReplicaKeepDuration property is set. The value is 4.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ParameterSetName = "CreateService")]
        public int? Flags
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ReplicaRestartWaitDurationSeconds. The duration, in seconds, between when a replica goes down and when
        /// a new replica is created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ParameterSetName = "CreateService")]
        public long? ReplicaRestartWaitDurationSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets QuorumLossWaitDurationSeconds. The maximum duration, in seconds, for which a partition is allowed to
        /// be in a state of quorum loss.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ParameterSetName = "CreateService")]
        public long? QuorumLossWaitDurationSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets StandByReplicaKeepDurationSeconds. The definition on how long StandBy replicas should be maintained
        /// before being removed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ParameterSetName = "CreateService")]
        public long? StandByReplicaKeepDurationSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ParameterSetName = "CreateService")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                PartitionSchemeDescription partitionSchemeDescription = null;
                if (this.Named.IsPresent)
                {
                    partitionSchemeDescription = new NamedPartitionSchemeDescription(
                        count: this.Count,
                        names: this.Names);
                }
                else if (this.Singleton.IsPresent)
                {
                    partitionSchemeDescription = new SingletonPartitionSchemeDescription();
                }
                else if (this.UniformInt64Range.IsPresent)
                {
                    partitionSchemeDescription = new UniformInt64RangePartitionSchemeDescription(
                        count: this.Count,
                        lowKey: this.LowKey,
                        highKey: this.HighKey);
                }

                ServiceDescription serviceDescription = null;
                if (this.Stateful.IsPresent)
                {
                    serviceDescription = new StatefulServiceDescription(
                        serviceName: this.ServiceName,
                        serviceTypeName: this.ServiceTypeName,
                        partitionDescription: partitionSchemeDescription,
                        targetReplicaSetSize: this.TargetReplicaSetSize,
                        minReplicaSetSize: this.MinReplicaSetSize,
                        hasPersistedState: this.HasPersistedState,
                        applicationName: this.ApplicationName,
                        initializationData: this.InitializationData,
                        placementConstraints: this.PlacementConstraints,
                        correlationScheme: this.CorrelationScheme,
                        serviceLoadMetrics: this.ServiceLoadMetrics,
                        servicePlacementPolicies: this.ServicePlacementPolicies,
                        defaultMoveCost: this.DefaultMoveCost,
                        isDefaultMoveCostSpecified: this.IsDefaultMoveCostSpecified,
                        servicePackageActivationMode: this.ServicePackageActivationMode,
                        serviceDnsName: this.ServiceDnsName,
                        scalingPolicies: this.ScalingPolicies,
                        flags: this.Flags,
                        replicaRestartWaitDurationSeconds: this.ReplicaRestartWaitDurationSeconds,
                        quorumLossWaitDurationSeconds: this.QuorumLossWaitDurationSeconds,
                        standByReplicaKeepDurationSeconds: this.StandByReplicaKeepDurationSeconds);
                }
                else if (this.Stateless.IsPresent)
                {
                    serviceDescription = new StatelessServiceDescription(
                        serviceName: this.ServiceName,
                        serviceTypeName: this.ServiceTypeName,
                        partitionDescription: partitionSchemeDescription,
                        instanceCount: this.InstanceCount,
                        applicationName: this.ApplicationName,
                        initializationData: this.InitializationData,
                        placementConstraints: this.PlacementConstraints,
                        correlationScheme: this.CorrelationScheme,
                        serviceLoadMetrics: this.ServiceLoadMetrics,
                        servicePlacementPolicies: this.ServicePlacementPolicies,
                        defaultMoveCost: this.DefaultMoveCost,
                        isDefaultMoveCostSpecified: this.IsDefaultMoveCostSpecified,
                        servicePackageActivationMode: this.ServicePackageActivationMode,
                        serviceDnsName: this.ServiceDnsName,
                        scalingPolicies: this.ScalingPolicies);
                }

                this.ServiceFabricClient.Services.CreateServiceAsync(
                    applicationId: this.ApplicationId,
                    serviceDescription: serviceDescription,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
