// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Node Deactivate Complete event.
    /// </summary>
    public partial class NodeDeactivateCompleteEvent : NodeEvent
    {
        /// <summary>
        /// Initializes a new instance of the NodeDeactivateCompleteEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        /// <param name="nodeInstance">Id of Node instance.</param>
        /// <param name="effectiveDeactivateIntent">Describes deactivate intent.</param>
        /// <param name="batchIdsWithDeactivateIntent">Batch Ids.</param>
        /// <param name="startTime">Start time.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        public NodeDeactivateCompleteEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            NodeName nodeName,
            long? nodeInstance,
            string effectiveDeactivateIntent,
            string batchIdsWithDeactivateIntent,
            DateTime? startTime,
            bool? hasCorrelatedEvents = default(bool?))
            : base(
                eventInstanceId,
                timeStamp,
                Common.FabricEventKind.NodeDeactivateComplete,
                nodeName,
                hasCorrelatedEvents)
        {
            nodeInstance.ThrowIfNull(nameof(nodeInstance));
            effectiveDeactivateIntent.ThrowIfNull(nameof(effectiveDeactivateIntent));
            batchIdsWithDeactivateIntent.ThrowIfNull(nameof(batchIdsWithDeactivateIntent));
            startTime.ThrowIfNull(nameof(startTime));
            this.NodeInstance = nodeInstance;
            this.EffectiveDeactivateIntent = effectiveDeactivateIntent;
            this.BatchIdsWithDeactivateIntent = batchIdsWithDeactivateIntent;
            this.StartTime = startTime;
        }

        /// <summary>
        /// Gets id of Node instance.
        /// </summary>
        public long? NodeInstance { get; }

        /// <summary>
        /// Gets describes deactivate intent.
        /// </summary>
        public string EffectiveDeactivateIntent { get; }

        /// <summary>
        /// Gets batch Ids.
        /// </summary>
        public string BatchIdsWithDeactivateIntent { get; }

        /// <summary>
        /// Gets start time.
        /// </summary>
        public DateTime? StartTime { get; }
    }
}
