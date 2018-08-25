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
    /// Gets the health of a Service Fabric cluster using health chunks.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFClusterHealthChunkUsingPolicyAndAdvancedFilters", DefaultParameterSetName = "GetClusterHealthChunkUsingPolicyAndAdvancedFilters")]
    public partial class GetClusterHealthChunkUsingPolicyAndAdvancedFiltersCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NodeFilters. Defines a list of filters that specify which nodes to be included in the returned cluster
        /// health chunk.
        /// If no filters are specified, no nodes are returned. All the nodes are used to evaluate the cluster's aggregated
        /// health state, regardless of the input filters.
        /// The cluster health chunk query may specify multiple node filters.
        /// For example, it can specify a filter to return all nodes with health state Error and another filter to always
        /// include a node identified by its NodeName.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "GetClusterHealthChunkUsingPolicyAndAdvancedFilters")]
        public IEnumerable<NodeHealthStateFilter> NodeFilters
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationFilters. Defines a list of filters that specify which applications to be included in the
        /// returned cluster health chunk.
        /// If no filters are specified, no applications are returned. All the applications are used to evaluate the cluster's
        /// aggregated health state, regardless of the input filters.
        /// The cluster health chunk query may specify multiple application filters.
        /// For example, it can specify a filter to return all applications with health state Error and another filter to
        /// always include applications of a specified application type.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "GetClusterHealthChunkUsingPolicyAndAdvancedFilters")]
        public IEnumerable<ApplicationHealthStateFilter> ApplicationFilters
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ClusterHealthPolicy. Defines a health policy used to evaluate the health of the cluster or of a
        /// cluster node.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "GetClusterHealthChunkUsingPolicyAndAdvancedFilters")]
        public ClusterHealthPolicy ClusterHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicies. Defines the application health policy map used to evaluate the health of an
        /// application or one of its children entities.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "GetClusterHealthChunkUsingPolicyAndAdvancedFilters")]
        public ApplicationHealthPolicies ApplicationHealthPolicies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "GetClusterHealthChunkUsingPolicyAndAdvancedFilters")]
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
                var clusterHealthChunkQueryDescription = new ClusterHealthChunkQueryDescription(
                nodeFilters: this.NodeFilters,
                applicationFilters: this.ApplicationFilters,
                clusterHealthPolicy: this.ClusterHealthPolicy,
                applicationHealthPolicies: this.ApplicationHealthPolicies);

                var result = this.ServiceFabricClient.Cluster.GetClusterHealthChunkUsingPolicyAndAdvancedFiltersAsync(
                    clusterHealthChunkQueryDescription: clusterHealthChunkQueryDescription,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
