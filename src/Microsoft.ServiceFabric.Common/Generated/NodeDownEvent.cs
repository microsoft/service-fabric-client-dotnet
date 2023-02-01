// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Node Down event.
    /// </summary>
    public partial class NodeDownEvent : NodeEvent
    {
        /// <summary>
        /// Initializes a new instance of the NodeDownEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        /// <param name="lastNodeUpAt">Time when Node was last up.</param>
        /// <param name="category">The category of event.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        /// <param name="nodeInstance">Id of Node instance.</param>
        public NodeDownEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            NodeName nodeName,
            DateTime? lastNodeUpAt,
            string category = default(string),
            bool? hasCorrelatedEvents = default(bool?),
            long? nodeInstance = default(long?))
            : base(
                eventInstanceId,
                timeStamp,
                nodeName,
                Common.NodeEventKind.NodeDown,
                category,
                hasCorrelatedEvents,
                nodeInstance)
        {
            lastNodeUpAt.ThrowIfNull(nameof(lastNodeUpAt));
            this.LastNodeUpAt = lastNodeUpAt;
        }

        /// <summary>
        /// Gets time when Node was last up.
        /// </summary>
        public DateTime? LastNodeUpAt { get; }
    }
}
