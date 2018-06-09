// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for FabricEventKind.
    /// </summary>
    public enum FabricEventKind
    {
        /// <summary>
        /// ClusterEvent.
        /// </summary>
        ClusterEvent,

        /// <summary>
        /// ContainerInstanceEvent.
        /// </summary>
        ContainerInstanceEvent,

        /// <summary>
        /// NodeEvent.
        /// </summary>
        NodeEvent,

        /// <summary>
        /// ApplicationEvent.
        /// </summary>
        ApplicationEvent,

        /// <summary>
        /// ServiceEvent.
        /// </summary>
        ServiceEvent,

        /// <summary>
        /// PartitionEvent.
        /// </summary>
        PartitionEvent,

        /// <summary>
        /// ReplicaEvent.
        /// </summary>
        ReplicaEvent,

        /// <summary>
        /// PartitionAnalysisEvent.
        /// </summary>
        PartitionAnalysisEvent,

        /// <summary>
        /// ApplicationCreated.
        /// </summary>
        ApplicationCreated,

        /// <summary>
        /// ApplicationDeleted.
        /// </summary>
        ApplicationDeleted,

        /// <summary>
        /// ApplicationHealthReportCreated.
        /// </summary>
        ApplicationHealthReportCreated,

        /// <summary>
        /// ApplicationHealthReportExpired.
        /// </summary>
        ApplicationHealthReportExpired,

        /// <summary>
        /// ApplicationUpgradeComplete.
        /// </summary>
        ApplicationUpgradeComplete,

        /// <summary>
        /// ApplicationUpgradeDomainComplete.
        /// </summary>
        ApplicationUpgradeDomainComplete,

        /// <summary>
        /// ApplicationUpgradeRollbackComplete.
        /// </summary>
        ApplicationUpgradeRollbackComplete,

        /// <summary>
        /// ApplicationUpgradeRollbackStart.
        /// </summary>
        ApplicationUpgradeRollbackStart,

        /// <summary>
        /// ApplicationUpgradeStart.
        /// </summary>
        ApplicationUpgradeStart,

        /// <summary>
        /// DeployedApplicationHealthReportCreated.
        /// </summary>
        DeployedApplicationHealthReportCreated,

        /// <summary>
        /// DeployedApplicationHealthReportExpired.
        /// </summary>
        DeployedApplicationHealthReportExpired,

        /// <summary>
        /// ProcessDeactivated.
        /// </summary>
        ProcessDeactivated,

        /// <summary>
        /// ContainerDeactivated.
        /// </summary>
        ContainerDeactivated,

        /// <summary>
        /// NodeAborted.
        /// </summary>
        NodeAborted,

        /// <summary>
        /// NodeAborting.
        /// </summary>
        NodeAborting,

        /// <summary>
        /// NodeAdded.
        /// </summary>
        NodeAdded,

        /// <summary>
        /// NodeClose.
        /// </summary>
        NodeClose,

        /// <summary>
        /// NodeClosing.
        /// </summary>
        NodeClosing,

        /// <summary>
        /// NodeDeactivateComplete.
        /// </summary>
        NodeDeactivateComplete,

        /// <summary>
        /// NodeDeactivateStart.
        /// </summary>
        NodeDeactivateStart,

        /// <summary>
        /// NodeDown.
        /// </summary>
        NodeDown,

        /// <summary>
        /// NodeHealthReportCreated.
        /// </summary>
        NodeHealthReportCreated,

        /// <summary>
        /// NodeHealthReportExpired.
        /// </summary>
        NodeHealthReportExpired,

        /// <summary>
        /// NodeOpenedSuccess.
        /// </summary>
        NodeOpenedSuccess,

        /// <summary>
        /// NodeOpenFailed.
        /// </summary>
        NodeOpenFailed,

        /// <summary>
        /// NodeOpening.
        /// </summary>
        NodeOpening,

        /// <summary>
        /// NodeRemoved.
        /// </summary>
        NodeRemoved,

        /// <summary>
        /// NodeUp.
        /// </summary>
        NodeUp,

        /// <summary>
        /// PartitionHealthReportCreated.
        /// </summary>
        PartitionHealthReportCreated,

        /// <summary>
        /// PartitionHealthReportExpired.
        /// </summary>
        PartitionHealthReportExpired,

        /// <summary>
        /// PartitionReconfigurationCompleted.
        /// </summary>
        PartitionReconfigurationCompleted,

        /// <summary>
        /// PartitionPrimaryMoveAnalysis.
        /// </summary>
        PartitionPrimaryMoveAnalysis,

        /// <summary>
        /// ServiceCreated.
        /// </summary>
        ServiceCreated,

        /// <summary>
        /// ServiceDeleted.
        /// </summary>
        ServiceDeleted,

        /// <summary>
        /// ServiceHealthReportCreated.
        /// </summary>
        ServiceHealthReportCreated,

        /// <summary>
        /// ServiceHealthReportExpired.
        /// </summary>
        ServiceHealthReportExpired,

        /// <summary>
        /// DeployedServiceHealthReportCreated.
        /// </summary>
        DeployedServiceHealthReportCreated,

        /// <summary>
        /// DeployedServiceHealthReportExpired.
        /// </summary>
        DeployedServiceHealthReportExpired,

        /// <summary>
        /// StatefulReplicaHealthReportCreated.
        /// </summary>
        StatefulReplicaHealthReportCreated,

        /// <summary>
        /// StatefulReplicaHealthReportExpired.
        /// </summary>
        StatefulReplicaHealthReportExpired,

        /// <summary>
        /// StatelessReplicaHealthReportCreated.
        /// </summary>
        StatelessReplicaHealthReportCreated,

        /// <summary>
        /// StatelessReplicaHealthReportExpired.
        /// </summary>
        StatelessReplicaHealthReportExpired,

        /// <summary>
        /// ClusterHealthReportCreated.
        /// </summary>
        ClusterHealthReportCreated,

        /// <summary>
        /// ClusterHealthReportExpired.
        /// </summary>
        ClusterHealthReportExpired,

        /// <summary>
        /// ClusterUpgradeComplete.
        /// </summary>
        ClusterUpgradeComplete,

        /// <summary>
        /// ClusterUpgradeDomainComplete.
        /// </summary>
        ClusterUpgradeDomainComplete,

        /// <summary>
        /// ClusterUpgradeRollbackComplete.
        /// </summary>
        ClusterUpgradeRollbackComplete,

        /// <summary>
        /// ClusterUpgradeRollbackStart.
        /// </summary>
        ClusterUpgradeRollbackStart,

        /// <summary>
        /// ClusterUpgradeStart.
        /// </summary>
        ClusterUpgradeStart,

        /// <summary>
        /// ChaosStopped.
        /// </summary>
        ChaosStopped,

        /// <summary>
        /// ChaosStarted.
        /// </summary>
        ChaosStarted,

        /// <summary>
        /// ChaosRestartNodeFaultCompleted.
        /// </summary>
        ChaosRestartNodeFaultCompleted,

        /// <summary>
        /// ChaosRestartCodePackageFaultScheduled.
        /// </summary>
        ChaosRestartCodePackageFaultScheduled,

        /// <summary>
        /// ChaosRestartCodePackageFaultCompleted.
        /// </summary>
        ChaosRestartCodePackageFaultCompleted,

        /// <summary>
        /// ChaosRemoveReplicaFaultScheduled.
        /// </summary>
        ChaosRemoveReplicaFaultScheduled,

        /// <summary>
        /// ChaosRemoveReplicaFaultCompleted.
        /// </summary>
        ChaosRemoveReplicaFaultCompleted,

        /// <summary>
        /// ChaosMoveSecondaryFaultScheduled.
        /// </summary>
        ChaosMoveSecondaryFaultScheduled,

        /// <summary>
        /// ChaosMovePrimaryFaultScheduled.
        /// </summary>
        ChaosMovePrimaryFaultScheduled,

        /// <summary>
        /// ChaosRestartReplicaFaultScheduled.
        /// </summary>
        ChaosRestartReplicaFaultScheduled,

        /// <summary>
        /// ChaosRestartNodeFaultScheduled.
        /// </summary>
        ChaosRestartNodeFaultScheduled,
    }
}
