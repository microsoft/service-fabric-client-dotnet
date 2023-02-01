// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the base for all Fabric Events.
    /// </summary>
    public partial class FabricEvent
    {
        /// <summary>
        /// Initializes a new instance of the FabricEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="category">The category of event.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        public FabricEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            string category = default(string),
            bool? hasCorrelatedEvents = default(bool?))
        {
            eventInstanceId.ThrowIfNull(nameof(eventInstanceId));
            timeStamp.ThrowIfNull(nameof(timeStamp));
            this.EventInstanceId = eventInstanceId;
            this.TimeStamp = timeStamp;
            this.Category = category;
            this.HasCorrelatedEvents = hasCorrelatedEvents;
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
    }
}
