// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Node Added event.
    /// </summary>
    public partial class NodeAddedToClusterEvent : NodeEvent
    {
        /// <summary>
        /// Initializes a new instance of the NodeAddedToClusterEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        /// <param name="nodeId">Id of Node.</param>
        /// <param name="nodeType">Type of Node.</param>
        /// <param name="fabricVersion">Fabric version.</param>
        /// <param name="ipAddressOrFQDN">IP address or FQDN.</param>
        /// <param name="nodeCapacities">Capacities.</param>
        /// <param name="category">The category of event.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        /// <param name="nodeInstance">Id of Node instance.</param>
        public NodeAddedToClusterEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            NodeName nodeName,
            string nodeId,
            string nodeType,
            string fabricVersion,
            string ipAddressOrFQDN,
            string nodeCapacities,
            string category = default(string),
            bool? hasCorrelatedEvents = default(bool?),
            long? nodeInstance = default(long?))
            : base(
                eventInstanceId,
                timeStamp,
                nodeName,
                Common.NodeEventKind.NodeAddedToCluster,
                category,
                hasCorrelatedEvents,
                nodeInstance)
        {
            nodeId.ThrowIfNull(nameof(nodeId));
            nodeType.ThrowIfNull(nameof(nodeType));
            fabricVersion.ThrowIfNull(nameof(fabricVersion));
            ipAddressOrFQDN.ThrowIfNull(nameof(ipAddressOrFQDN));
            nodeCapacities.ThrowIfNull(nameof(nodeCapacities));
            this.NodeId = nodeId;
            this.NodeType = nodeType;
            this.FabricVersion = fabricVersion;
            this.IpAddressOrFQDN = ipAddressOrFQDN;
            this.NodeCapacities = nodeCapacities;
        }

        /// <summary>
        /// Gets id of Node.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets type of Node.
        /// </summary>
        public string NodeType { get; }

        /// <summary>
        /// Gets fabric version.
        /// </summary>
        public string FabricVersion { get; }

        /// <summary>
        /// Gets IP address or FQDN.
        /// </summary>
        public string IpAddressOrFQDN { get; }

        /// <summary>
        /// Gets capacities.
        /// </summary>
        public string NodeCapacities { get; }
    }
}
