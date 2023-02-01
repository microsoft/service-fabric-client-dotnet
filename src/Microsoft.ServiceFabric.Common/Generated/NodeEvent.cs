// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the base for all Node Events.
    /// </summary>
    public abstract partial class NodeEvent
    {
        /// <summary>
        /// Initializes a new instance of the NodeEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        /// <param name="kind">The kind of FabricEvent.</param>
        /// <param name="category">The category of event.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        /// <param name="nodeInstance">Id of Node instance.</param>
        protected NodeEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            NodeName nodeName,
            NodeEventKind? kind,
            string category = default(string),
            bool? hasCorrelatedEvents = default(bool?),
            long? nodeInstance = default(long?))
        {
            eventInstanceId.ThrowIfNull(nameof(eventInstanceId));
            timeStamp.ThrowIfNull(nameof(timeStamp));
            nodeName.ThrowIfNull(nameof(nodeName));
            kind.ThrowIfNull(nameof(kind));
            this.EventInstanceId = eventInstanceId;
            this.TimeStamp = timeStamp;
            this.NodeName = nodeName;
            this.Kind = kind;
            this.Category = category;
            this.HasCorrelatedEvents = hasCorrelatedEvents;
            this.NodeInstance = nodeInstance;
        }

        /// <summary>
        /// Gets the identifier for the FabricEvent instance.
        /// </summary>
        public Guid? EventInstanceId { get; }

        /// <summary>
        /// Gets the category of event.
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// Gets the time event was logged.
        /// </summary>
        public DateTime? TimeStamp { get; }

        /// <summary>
        /// Gets shows there is existing related events available.
        /// </summary>
        public bool? HasCorrelatedEvents { get; }

        /// <summary>
        /// Gets id of Node instance.
        /// </summary>
        public long? NodeInstance { get; }

        /// <summary>
        /// Gets the name of a Service Fabric node.
        /// </summary>
        public NodeName NodeName { get; }

        /// <summary>
        /// Gets the kind of FabricEvent.
        /// </summary>
        public NodeEventKind? Kind { get; }
    }
}
