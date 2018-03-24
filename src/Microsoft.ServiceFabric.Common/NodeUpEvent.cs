// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Node Up Event
    /// </summary>
    public partial class NodeUpEvent : NodeEvent
    {
        /// <summary>
        /// Initializes a new instance of the NodeUpEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        /// <param name="nodeInstance">Node Instance</param>
        /// <param name="lastNodeDownAt">Last Node Down At</param>
        /// <param name="hasCorrelatedEvents">Shows that there is existing related events available.</param>
        public NodeUpEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            NodeName nodeName,
            long? nodeInstance,
            DateTime? lastNodeDownAt,
            bool? hasCorrelatedEvents = default(bool?))
            : base(
                eventInstanceId,
                timeStamp,
                Common.FabricEventKind.NodeUp,
                nodeName,
                hasCorrelatedEvents)
        {
            nodeInstance.ThrowIfNull(nameof(nodeInstance));
            lastNodeDownAt.ThrowIfNull(nameof(lastNodeDownAt));
            this.NodeInstance = nodeInstance;
            this.LastNodeDownAt = lastNodeDownAt;
        }

        /// <summary>
        /// Gets node Instance
        /// </summary>
        public long? NodeInstance { get; }

        /// <summary>
        /// Gets last Node Down At
        /// </summary>
        public DateTime? LastNodeDownAt { get; }
    }
}
