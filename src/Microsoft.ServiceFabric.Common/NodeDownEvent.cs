// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Node Down Event
    /// </summary>
    public partial class NodeDownEvent : NodeEvent
    {
        /// <summary>
        /// Initializes a new instance of the NodeDownEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        /// <param name="nodeInstance">Node Instance</param>
        /// <param name="lastNodeUpAt">Last Node Up At</param>
        /// <param name="hasCorrelatedEvents">Shows that there is existing related events available.</param>
        public NodeDownEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            NodeName nodeName,
            long? nodeInstance,
            DateTime? lastNodeUpAt,
            bool? hasCorrelatedEvents = default(bool?))
            : base(
                eventInstanceId,
                timeStamp,
                Common.FabricEventKind.NodeDown,
                nodeName,
                hasCorrelatedEvents)
        {
            nodeInstance.ThrowIfNull(nameof(nodeInstance));
            lastNodeUpAt.ThrowIfNull(nameof(lastNodeUpAt));
            this.NodeInstance = nodeInstance;
            this.LastNodeUpAt = lastNodeUpAt;
        }

        /// <summary>
        /// Gets node Instance
        /// </summary>
        public long? NodeInstance { get; }

        /// <summary>
        /// Gets last Node Up At
        /// </summary>
        public DateTime? LastNodeUpAt { get; }
    }
}
