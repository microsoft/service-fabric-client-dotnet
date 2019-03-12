// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents data structure that contains load information for a certain metric on a node.
    /// </summary>
    public partial class NodeLoadMetricInformation
    {
        /// <summary>
        /// Initializes a new instance of the NodeLoadMetricInformation class.
        /// </summary>
        /// <param name="name">Name of the metric for which this load information is provided.</param>
        /// <param name="nodeCapacity">Total capacity on the node for this metric.</param>
        /// <param name="nodeLoad">Current load on the node for this metric.</param>
        /// <param name="nodeRemainingCapacity">The remaining capacity on the node for this metric.</param>
        /// <param name="isCapacityViolation">Indicates if there is a capacity violation for this metric on the node.</param>
        /// <param name="nodeBufferedCapacity">The value that indicates the reserved capacity for this metric on the
        /// node.</param>
        /// <param name="nodeRemainingBufferedCapacity">The remaining reserved capacity for this metric on the node.</param>
        public NodeLoadMetricInformation(
            string name = default(string),
            string nodeCapacity = default(string),
            string nodeLoad = default(string),
            string nodeRemainingCapacity = default(string),
            bool? isCapacityViolation = default(bool?),
            string nodeBufferedCapacity = default(string),
            string nodeRemainingBufferedCapacity = default(string))
        {
            this.Name = name;
            this.NodeCapacity = nodeCapacity;
            this.NodeLoad = nodeLoad;
            this.NodeRemainingCapacity = nodeRemainingCapacity;
            this.IsCapacityViolation = isCapacityViolation;
            this.NodeBufferedCapacity = nodeBufferedCapacity;
            this.NodeRemainingBufferedCapacity = nodeRemainingBufferedCapacity;
        }

        /// <summary>
        /// Gets name of the metric for which this load information is provided.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets total capacity on the node for this metric.
        /// </summary>
        public string NodeCapacity { get; }

        /// <summary>
        /// Gets current load on the node for this metric.
        /// </summary>
        public string NodeLoad { get; }

        /// <summary>
        /// Gets the remaining capacity on the node for this metric.
        /// </summary>
        public string NodeRemainingCapacity { get; }

        /// <summary>
        /// Gets indicates if there is a capacity violation for this metric on the node.
        /// </summary>
        public bool? IsCapacityViolation { get; }

        /// <summary>
        /// Gets the value that indicates the reserved capacity for this metric on the node.
        /// </summary>
        public string NodeBufferedCapacity { get; }

        /// <summary>
        /// Gets the remaining reserved capacity for this metric on the node.
        /// </summary>
        public string NodeRemainingBufferedCapacity { get; }
    }
}
