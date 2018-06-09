// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a base class for stateful service replica or stateless service instance health state.
    /// </summary>
    public partial class ReplicaHealthState : EntityHealthState
    {
        /// <summary>
        /// Initializes a new instance of the ReplicaHealthState class.
        /// </summary>
        /// <param name="aggregatedHealthState">The health state of a Service Fabric entity such as Cluster, Node, Application,
        /// Service, Partition, Replica etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'</param>
        /// <param name="partitionId">The ID of the partition to which this replica belongs.</param>
        public ReplicaHealthState(
            HealthState? aggregatedHealthState = default(HealthState?),
            PartitionId partitionId = default(PartitionId))
            : base(
                aggregatedHealthState)
        {
            this.PartitionId = partitionId;
        }

        /// <summary>
        /// Gets the ID of the partition to which this replica belongs.
        /// </summary>
        public PartitionId PartitionId { get; }
    }
}
