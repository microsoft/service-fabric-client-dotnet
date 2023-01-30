// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ClusterEventKind.
    /// </summary>
    public enum ClusterEventKind
    {
        /// <summary>
        /// ClusterEvent.
        /// </summary>
        ClusterEvent,

        /// <summary>
        /// ClusterNewHealthReport.
        /// </summary>
        ClusterNewHealthReport,

        /// <summary>
        /// ClusterHealthReportExpired.
        /// </summary>
        ClusterHealthReportExpired,

        /// <summary>
        /// ClusterUpgradeCompleted.
        /// </summary>
        ClusterUpgradeCompleted,

        /// <summary>
        /// ClusterUpgradeDomainCompleted.
        /// </summary>
        ClusterUpgradeDomainCompleted,

        /// <summary>
        /// ClusterUpgradeRollbackCompleted.
        /// </summary>
        ClusterUpgradeRollbackCompleted,

        /// <summary>
        /// ClusterUpgradeRollbackStarted.
        /// </summary>
        ClusterUpgradeRollbackStarted,

        /// <summary>
        /// ClusterUpgradeStarted.
        /// </summary>
        ClusterUpgradeStarted,

        /// <summary>
        /// ChaosStopped.
        /// </summary>
        ChaosStopped,

        /// <summary>
        /// ChaosStarted.
        /// </summary>
        ChaosStarted,

        /// <summary>
        /// ChaosReplicaRemovalScheduled.
        /// </summary>
        ChaosReplicaRemovalScheduled,

        /// <summary>
        /// ChaosPartitionSecondaryMoveScheduled.
        /// </summary>
        ChaosPartitionSecondaryMoveScheduled,

        /// <summary>
        /// ChaosPartitionPrimaryMoveScheduled.
        /// </summary>
        ChaosPartitionPrimaryMoveScheduled,

        /// <summary>
        /// ChaosReplicaRestartScheduled.
        /// </summary>
        ChaosReplicaRestartScheduled,
    }
}
