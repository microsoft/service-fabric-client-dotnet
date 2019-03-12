// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Node Close event.
    /// </summary>
    public partial class NodeCloseEvent : NodeEvent
    {
        /// <summary>
        /// Initializes a new instance of the NodeCloseEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        /// <param name="nodeId">Id of Node.</param>
        /// <param name="nodeInstance">Id of Node instance.</param>
        /// <param name="error">Describes error.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        public NodeCloseEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            NodeName nodeName,
            string nodeId,
            string nodeInstance,
            string error,
            bool? hasCorrelatedEvents = default(bool?))
            : base(
                eventInstanceId,
                timeStamp,
                Common.FabricEventKind.NodeClose,
                nodeName,
                hasCorrelatedEvents)
        {
            nodeId.ThrowIfNull(nameof(nodeId));
            nodeInstance.ThrowIfNull(nameof(nodeInstance));
            error.ThrowIfNull(nameof(error));
            this.NodeId = nodeId;
            this.NodeInstance = nodeInstance;
            this.Error = error;
        }

        /// <summary>
        /// Gets id of Node.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets id of Node instance.
        /// </summary>
        public string NodeInstance { get; }

        /// <summary>
        /// Gets describes error.
        /// </summary>
        public string Error { get; }
    }
}
