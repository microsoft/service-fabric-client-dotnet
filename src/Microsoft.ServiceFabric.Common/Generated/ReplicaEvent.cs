// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the base for all Replica Events.
    /// </summary>
    public abstract partial class ReplicaEvent
    {
        /// <summary>
        /// Initializes a new instance of the ReplicaEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="partitionId">An internal ID used by Service Fabric to uniquely identify a partition. This is a
        /// randomly generated GUID when the service was created. The partition ID is unique and does not change for the
        /// lifetime of the service. If the same service was deleted and recreated the IDs of its partitions would be
        /// different.</param>
        /// <param name="replicaId">Id of a stateful service replica. ReplicaId is used by Service Fabric to uniquely identify
        /// a replica of a partition. It is unique within a partition and does not change for the lifetime of the replica. If a
        /// replica gets dropped and another replica gets created on the same node for the same partition, it will get a
        /// different value for the id. Sometimes the id of a stateless service instance is also referred as a replica
        /// id.</param>
        /// <param name="kind">The kind of FabricEvent.</param>
        /// <param name="category">The category of event.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        protected ReplicaEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            PartitionId partitionId,
            ReplicaId replicaId,
            ReplicaEventKind? kind,
            string category = default(string),
            bool? hasCorrelatedEvents = default(bool?))
        {
            eventInstanceId.ThrowIfNull(nameof(eventInstanceId));
            timeStamp.ThrowIfNull(nameof(timeStamp));
            partitionId.ThrowIfNull(nameof(partitionId));
            replicaId.ThrowIfNull(nameof(replicaId));
            kind.ThrowIfNull(nameof(kind));
            this.EventInstanceId = eventInstanceId;
            this.TimeStamp = timeStamp;
            this.PartitionId = partitionId;
            this.ReplicaId = replicaId;
            this.Kind = kind;
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

        /// <summary>
        /// Gets an internal ID used by Service Fabric to uniquely identify a partition. This is a randomly generated GUID when
        /// the service was created. The partition ID is unique and does not change for the lifetime of the service. If the
        /// same service was deleted and recreated the IDs of its partitions would be different.
        /// </summary>
        public PartitionId PartitionId { get; }

        /// <summary>
        /// Gets id of a stateful service replica. ReplicaId is used by Service Fabric to uniquely identify a replica of a
        /// partition. It is unique within a partition and does not change for the lifetime of the replica. If a replica gets
        /// dropped and another replica gets created on the same node for the same partition, it will get a different value for
        /// the id. Sometimes the id of a stateless service instance is also referred as a replica id.
        /// </summary>
        public ReplicaId ReplicaId { get; }

        /// <summary>
        /// Gets the kind of FabricEvent.
        /// </summary>
        public ReplicaEventKind? Kind { get; }
    }
}
