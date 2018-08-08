// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides statistics about the Service Fabric Replicator, when it is functioning in a ActiveSecondary role.
    /// </summary>
    public partial class SecondaryReplicatorStatus : ReplicatorStatus
    {
        /// <summary>
        /// Initializes a new instance of the SecondaryReplicatorStatus class.
        /// </summary>
        /// <param name="kind">The role of a replica of a stateful service.</param>
        /// <param name="replicationQueueStatus">Provides various statistics of the queue used in the service fabric
        /// replicator.
        /// Contains information about the service fabric replicator like the replication/copy queue utilization, last
        /// acknowledgement received timestamp, etc.
        /// Depending on the role of the replicator, the properties in this type imply different meanings.
        /// </param>
        /// <param name="lastReplicationOperationReceivedTimeUtc">The last time-stamp (UTC) at which a replication operation
        /// was received from the primary.
        /// UTC 0 represents an invalid value, indicating that a replication operation message was never received.
        /// </param>
        /// <param name="isInBuild">Value that indicates whether the replica is currently being built.</param>
        /// <param name="copyQueueStatus">Provides various statistics of the queue used in the service fabric replicator.
        /// Contains information about the service fabric replicator like the replication/copy queue utilization, last
        /// acknowledgement received timestamp, etc.
        /// Depending on the role of the replicator, the properties in this type imply different meanings.
        /// </param>
        /// <param name="lastCopyOperationReceivedTimeUtc">The last time-stamp (UTC) at which a copy operation was received
        /// from the primary.
        /// UTC 0 represents an invalid value, indicating that a copy operation message was never received.
        /// </param>
        /// <param name="lastAcknowledgementSentTimeUtc">The last time-stamp (UTC) at which an acknowledgment was sent to the
        /// primary replicator.
        /// UTC 0 represents an invalid value, indicating that an acknowledgment message was never sent.
        /// </param>
        public SecondaryReplicatorStatus(
            ReplicaRole? kind,
            ReplicatorQueueStatus replicationQueueStatus = default(ReplicatorQueueStatus),
            DateTime? lastReplicationOperationReceivedTimeUtc = default(DateTime?),
            bool? isInBuild = default(bool?),
            ReplicatorQueueStatus copyQueueStatus = default(ReplicatorQueueStatus),
            DateTime? lastCopyOperationReceivedTimeUtc = default(DateTime?),
            DateTime? lastAcknowledgementSentTimeUtc = default(DateTime?))
            : base(
                kind)
        {
            this.ReplicationQueueStatus = replicationQueueStatus;
            this.LastReplicationOperationReceivedTimeUtc = lastReplicationOperationReceivedTimeUtc;
            this.IsInBuild = isInBuild;
            this.CopyQueueStatus = copyQueueStatus;
            this.LastCopyOperationReceivedTimeUtc = lastCopyOperationReceivedTimeUtc;
            this.LastAcknowledgementSentTimeUtc = lastAcknowledgementSentTimeUtc;
        }

        /// <summary>
        /// Gets provides various statistics of the queue used in the service fabric replicator.
        /// Contains information about the service fabric replicator like the replication/copy queue utilization, last
        /// acknowledgement received timestamp, etc.
        /// Depending on the role of the replicator, the properties in this type imply different meanings.
        /// </summary>
        public ReplicatorQueueStatus ReplicationQueueStatus { get; }

        /// <summary>
        /// Gets the last time-stamp (UTC) at which a replication operation was received from the primary.
        /// UTC 0 represents an invalid value, indicating that a replication operation message was never received.
        /// </summary>
        public DateTime? LastReplicationOperationReceivedTimeUtc { get; }

        /// <summary>
        /// Gets value that indicates whether the replica is currently being built.
        /// </summary>
        public bool? IsInBuild { get; }

        /// <summary>
        /// Gets provides various statistics of the queue used in the service fabric replicator.
        /// Contains information about the service fabric replicator like the replication/copy queue utilization, last
        /// acknowledgement received timestamp, etc.
        /// Depending on the role of the replicator, the properties in this type imply different meanings.
        /// </summary>
        public ReplicatorQueueStatus CopyQueueStatus { get; }

        /// <summary>
        /// Gets the last time-stamp (UTC) at which a copy operation was received from the primary.
        /// UTC 0 represents an invalid value, indicating that a copy operation message was never received.
        /// </summary>
        public DateTime? LastCopyOperationReceivedTimeUtc { get; }

        /// <summary>
        /// Gets the last time-stamp (UTC) at which an acknowledgment was sent to the primary replicator.
        /// UTC 0 represents an invalid value, indicating that an acknowledgment message was never sent.
        /// </summary>
        public DateTime? LastAcknowledgementSentTimeUtc { get; }
    }
}
