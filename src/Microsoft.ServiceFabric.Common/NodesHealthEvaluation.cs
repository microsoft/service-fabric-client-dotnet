// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents health evaluation for nodes, containing health evaluations for each unhealthy node that impacted current
    /// aggregated health state. Can be returned when evaluating cluster health and the aggregated health state is either
    /// Error or Warning.
    /// </summary>
    public partial class NodesHealthEvaluation : HealthEvaluation
    {
        /// <summary>
        /// Initializes a new instance of the NodesHealthEvaluation class.
        /// </summary>
        /// <param name="aggregatedHealthState">The health state of a Service Fabric entity such as Cluster, Node, Application,
        /// Service, Partition, Replica etc. Possible values include: 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'</param>
        /// <param name="description">Description of the health evaluation, which represents a summary of the evaluation
        /// process.</param>
        /// <param name="maxPercentUnhealthyNodes">Maximum allowed percentage of unhealthy nodes from the
        /// ClusterHealthPolicy.</param>
        /// <param name="totalCount">Total number of nodes found in the health store.</param>
        /// <param name="unhealthyEvaluations">List of unhealthy evaluations that led to the aggregated health state. Includes
        /// all the unhealthy NodeHealthEvaluation that impacted the aggregated health.</param>
        public NodesHealthEvaluation(
            HealthState? aggregatedHealthState = default(HealthState?),
            string description = default(string),
            int? maxPercentUnhealthyNodes = default(int?),
            long? totalCount = default(long?),
            IEnumerable<HealthEvaluationWrapper> unhealthyEvaluations = default(IEnumerable<HealthEvaluationWrapper>))
            : base(
                Common.HealthEvaluationKind.Nodes,
                aggregatedHealthState,
                description)
        {
            this.MaxPercentUnhealthyNodes = maxPercentUnhealthyNodes;
            this.TotalCount = totalCount;
            this.UnhealthyEvaluations = unhealthyEvaluations;
        }

        /// <summary>
        /// Gets maximum allowed percentage of unhealthy nodes from the ClusterHealthPolicy.
        /// </summary>
        public int? MaxPercentUnhealthyNodes { get; }

        /// <summary>
        /// Gets total number of nodes found in the health store.
        /// </summary>
        public long? TotalCount { get; }

        /// <summary>
        /// Gets list of unhealthy evaluations that led to the aggregated health state. Includes all the unhealthy
        /// NodeHealthEvaluation that impacted the aggregated health.
        /// </summary>
        public IEnumerable<HealthEvaluationWrapper> UnhealthyEvaluations { get; }
    }
}
