// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes properties of a service resource.
    /// </summary>
    public partial class ServiceProperties
    {
        /// <summary>
        /// Initializes a new instance of the ServiceProperties class.
        /// </summary>
        /// <param name="description">User readable description of the service.</param>
        /// <param name="replicaCount">The number of replicas of the service to create. Defaults to 1 if not specified.</param>
        /// <param name="autoScalingPolicies">Auto scaling policies</param>
        public ServiceProperties(
            string description = default(string),
            int? replicaCount = default(int?),
            IEnumerable<AutoScalingPolicy> autoScalingPolicies = default(IEnumerable<AutoScalingPolicy>))
        {
            this.Description = description;
            this.ReplicaCount = replicaCount;
            this.AutoScalingPolicies = autoScalingPolicies;
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
        /// Gets status of the service. Possible values include: 'Unknown', 'Ready', 'Upgrading', 'Creating', 'Deleting',
        /// 'Failed'
        /// 
        /// Status of the resource.
        /// </summary>
        public ResourceStatus? Status { get; internal set; }

        /// <summary>
        /// Gets additional information about the current status of the service.
        /// </summary>
        public string StatusDetails { get; internal set; }

        /// <summary>
        /// Gets the health state of an application resource. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error',
        /// 'Unknown'
        /// 
        /// The health state of a Service Fabric entity such as Cluster, Node, Application, Service, Partition, Replica etc.
        /// </summary>
        public HealthState? HealthState { get; internal set; }

        /// <summary>
        /// Gets when the service's health state is not 'Ok', this additional details from service fabric Health Manager for
        /// the user to know why the service is marked unhealthy.
        /// </summary>
        public string UnhealthyEvaluation { get; internal set; }
    }
}
