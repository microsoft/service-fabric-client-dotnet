// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a stateless service.
    /// </summary>
    public partial class StatelessServiceDescription : ServiceDescription
    {
        /// <summary>
        /// Initializes a new instance of the StatelessServiceDescription class.
        /// </summary>
        /// <param name="serviceName">The full name of the service with 'fabric:' URI scheme.</param>
        /// <param name="serviceTypeName">Name of the service type as specified in the service manifest.</param>
        /// <param name="partitionDescription">The partition description as an object.</param>
        /// <param name="instanceCount">The instance count.</param>
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
        public StatelessServiceDescription(
            ServiceName serviceName,
            string serviceTypeName,
            PartitionSchemeDescription partitionDescription,
            int? instanceCount,
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
            IEnumerable<ScalingPolicyDescription> scalingPolicies = default(IEnumerable<ScalingPolicyDescription>))
            : base(
                serviceName,
                serviceTypeName,
                partitionDescription,
                Common.ServiceKind.Stateless,
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
            instanceCount.ThrowIfNull(nameof(instanceCount));
            instanceCount?.ThrowIfLessThan("instanceCount", -1);
            this.InstanceCount = instanceCount;
        }

        /// <summary>
        /// Gets the instance count.
        /// </summary>
        public int? InstanceCount { get; }
    }
}
