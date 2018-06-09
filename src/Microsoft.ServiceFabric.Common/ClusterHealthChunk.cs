// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the health chunk of the cluster.
    /// Contains the cluster aggregated health state, and the cluster entities that respect the input filter.
    /// </summary>
    public partial class ClusterHealthChunk
    {
        /// <summary>
        /// Initializes a new instance of the ClusterHealthChunk class.
        /// </summary>
        /// <param name="healthState">The health state of a Service Fabric entity such as Cluster, Node, Application, Service,
        /// Partition, Replica etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'</param>
        /// <param name="nodeHealthStateChunks">The list of node health state chunks in the cluster that respect the filters in
        /// the cluster health chunk query description.
        /// </param>
        /// <param name="applicationHealthStateChunks">The list of application health state chunks in the cluster that respect
        /// the filters in the cluster health chunk query description.
        /// </param>
        public ClusterHealthChunk(
            HealthState? healthState = default(HealthState?),
            NodeHealthStateChunkList nodeHealthStateChunks = default(NodeHealthStateChunkList),
            ApplicationHealthStateChunkList applicationHealthStateChunks = default(ApplicationHealthStateChunkList))
        {
            this.HealthState = healthState;
            this.NodeHealthStateChunks = nodeHealthStateChunks;
            this.ApplicationHealthStateChunks = applicationHealthStateChunks;
        }

        /// <summary>
        /// Gets the health state of a Service Fabric entity such as Cluster, Node, Application, Service, Partition, Replica
        /// etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'
        /// </summary>
        public HealthState? HealthState { get; }

        /// <summary>
        /// Gets the list of node health state chunks in the cluster that respect the filters in the cluster health chunk query
        /// description.
        /// </summary>
        public NodeHealthStateChunkList NodeHealthStateChunks { get; }

        /// <summary>
        /// Gets the list of application health state chunks in the cluster that respect the filters in the cluster health
        /// chunk query description.
        /// </summary>
        public ApplicationHealthStateChunkList ApplicationHealthStateChunks { get; }
    }
}
