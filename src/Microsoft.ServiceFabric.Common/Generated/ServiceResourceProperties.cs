// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This type describes properties of a service resource.
    /// </summary>
    public partial class ServiceResourceProperties : ServiceReplicaProperties
    {
        /// <summary>
        /// Initializes a new instance of the ServiceResourceProperties class.
        /// </summary>
        /// <param name="osType">The Operating system type required by the code in service.
        /// . Possible values include: 'Linux', 'Windows'</param>
        /// <param name="codePackages">Describes the set of code packages that forms the service. A code package describes the
        /// container and the properties for running it. All the code packages are started together on the same host and share
        /// the same context (network, process etc.).
        /// </param>
        /// <param name="networkRefs">The names of the private networks that this service needs to be part of.</param>
        /// <param name="diagnostics">Reference to sinks in DiagnosticsDescription.</param>
        /// <param name="description">User readable description of the service.</param>
        /// <param name="replicaCount">The number of replicas of the service to create. Defaults to 1 if not specified.</param>
        /// <param name="autoScalingPolicies">Auto scaling policies</param>
        /// <param name="healthState">Describes the health state of an services resource. Possible values include: 'Invalid',
        /// 'Ok', 'Warning', 'Error', 'Unknown'
        /// 
        /// The health state of a Service Fabric entity such as Cluster, Node, Application, Service, Partition, Replica etc.
        /// </param>
        /// <param name="status">Represents the status of the service. Possible values include: 'Unknown', 'Active',
        /// 'Upgrading', 'Deleting', 'Creating', 'Failed'</param>
        public ServiceResourceProperties(
            OperatingSystemTypes? osType,
            IEnumerable<ContainerCodePackageProperties> codePackages,
            IEnumerable<NetworkRef> networkRefs = default(IEnumerable<NetworkRef>),
            DiagnosticsRef diagnostics = default(DiagnosticsRef),
            string description = default(string),
            int? replicaCount = default(int?),
            IEnumerable<AutoScalingPolicy> autoScalingPolicies = default(IEnumerable<AutoScalingPolicy>),
            HealthState? healthState = default(HealthState?),
            ServiceResourceStatus? status = default(ServiceResourceStatus?))
            : base(
                osType,
                codePackages,
                networkRefs,
                diagnostics)
        {
            this.Description = description;
            this.ReplicaCount = replicaCount;
            this.AutoScalingPolicies = autoScalingPolicies;
            this.HealthState = healthState;
            this.Status = status;
        }

        /// <summary>
        /// Gets user readable description of the service.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the number of replicas of the service to create. Defaults to 1 if not specified.
        /// </summary>
        public int? ReplicaCount { get; }

        /// <summary>
        /// Gets auto scaling policies
        /// </summary>
        public IEnumerable<AutoScalingPolicy> AutoScalingPolicies { get; }

        /// <summary>
        /// Gets describes the health state of an services resource. Possible values include: 'Invalid', 'Ok', 'Warning',
        /// 'Error', 'Unknown'
        /// 
        /// The health state of a Service Fabric entity such as Cluster, Node, Application, Service, Partition, Replica etc.
        /// </summary>
        public HealthState? HealthState { get; }

        /// <summary>
        /// Gets represents the status of the service. Possible values include: 'Unknown', 'Active', 'Upgrading', 'Deleting',
        /// 'Creating', 'Failed'
        /// </summary>
        public ServiceResourceStatus? Status { get; }
    }
}
