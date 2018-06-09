// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a partition of a stateless Service Fabric service.
    /// </summary>
    public partial class StatelessServicePartitionInfo : ServicePartitionInfo
    {
        /// <summary>
        /// Initializes a new instance of the StatelessServicePartitionInfo class.
        /// </summary>
        /// <param name="healthState">The health state of a Service Fabric entity such as Cluster, Node, Application, Service,
        /// Partition, Replica etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'</param>
        /// <param name="partitionStatus">The status of the service fabric service partition. Possible values include:
        /// 'Invalid', 'Ready', 'NotReady', 'InQuorumLoss', 'Reconfiguring', 'Deleting'</param>
        /// <param name="partitionInformation">Information about the partition identity, partitioning scheme and keys supported
        /// by it.</param>
        /// <param name="instanceCount">Number of instances of this partition.</param>
        public StatelessServicePartitionInfo(
            HealthState? healthState = default(HealthState?),
            ServicePartitionStatus? partitionStatus = default(ServicePartitionStatus?),
            PartitionInformation partitionInformation = default(PartitionInformation),
            long? instanceCount = default(long?))
            : base(
                Common.ServiceKind.Stateless,
                healthState,
                partitionStatus,
                partitionInformation)
        {
            this.InstanceCount = instanceCount;
        }

        /// <summary>
        /// Gets number of instances of this partition.
        /// </summary>
        public long? InstanceCount { get; }
    }
}
