// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="FabricEvent" />.
    /// </summary>
    internal class FabricEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static FabricEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static FabricEvent GetFromJsonProperties(JsonReader reader)
        {
            FabricEvent obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("ApplicationEvent", StringComparison.Ordinal))
            {
                obj = ApplicationEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterEvent", StringComparison.Ordinal))
            {
                obj = ClusterEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ContainerInstanceEvent", StringComparison.Ordinal))
            {
                obj = ContainerInstanceEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeEvent", StringComparison.Ordinal))
            {
                obj = NodeEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionAnalysisEvent", StringComparison.Ordinal))
            {
                obj = PartitionAnalysisEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionEvent", StringComparison.Ordinal))
            {
                obj = PartitionEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ReplicaEvent", StringComparison.Ordinal))
            {
                obj = ReplicaEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceEvent", StringComparison.Ordinal))
            {
                obj = ServiceEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationCreated", StringComparison.Ordinal))
            {
                obj = ApplicationCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationDeleted", StringComparison.Ordinal))
            {
                obj = ApplicationDeletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationNewHealthReport", StringComparison.Ordinal))
            {
                obj = ApplicationNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationHealthReportExpired", StringComparison.Ordinal))
            {
                obj = ApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeCompleted", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeDomainCompleted", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeDomainCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeRollbackCompleted", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeRollbackCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeRollbackStarted", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeRollbackStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeStarted", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplicationNewHealthReport", StringComparison.Ordinal))
            {
                obj = DeployedApplicationNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplicationHealthReportExpired", StringComparison.Ordinal))
            {
                obj = DeployedApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationProcessExited", StringComparison.Ordinal))
            {
                obj = ApplicationProcessExitedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationContainerInstanceExited", StringComparison.Ordinal))
            {
                obj = ApplicationContainerInstanceExitedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeAborted", StringComparison.Ordinal))
            {
                obj = NodeAbortedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeAddedToCluster", StringComparison.Ordinal))
            {
                obj = NodeAddedToClusterEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeClosed", StringComparison.Ordinal))
            {
                obj = NodeClosedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDeactivateCompleted", StringComparison.Ordinal))
            {
                obj = NodeDeactivateCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDeactivateStarted", StringComparison.Ordinal))
            {
                obj = NodeDeactivateStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDown", StringComparison.Ordinal))
            {
                obj = NodeDownEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeNewHealthReport", StringComparison.Ordinal))
            {
                obj = NodeNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeHealthReportExpired", StringComparison.Ordinal))
            {
                obj = NodeHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeOpenSucceeded", StringComparison.Ordinal))
            {
                obj = NodeOpenSucceededEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeOpenFailed", StringComparison.Ordinal))
            {
                obj = NodeOpenFailedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeRemovedFromCluster", StringComparison.Ordinal))
            {
                obj = NodeRemovedFromClusterEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeUp", StringComparison.Ordinal))
            {
                obj = NodeUpEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionNewHealthReport", StringComparison.Ordinal))
            {
                obj = PartitionNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionHealthReportExpired", StringComparison.Ordinal))
            {
                obj = PartitionHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionReconfigured", StringComparison.Ordinal))
            {
                obj = PartitionReconfiguredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionPrimaryMoveAnalysis", StringComparison.Ordinal))
            {
                obj = PartitionPrimaryMoveAnalysisEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceCreated", StringComparison.Ordinal))
            {
                obj = ServiceCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceDeleted", StringComparison.Ordinal))
            {
                obj = ServiceDeletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceNewHealthReport", StringComparison.Ordinal))
            {
                obj = ServiceNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceHealthReportExpired", StringComparison.Ordinal))
            {
                obj = ServiceHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServicePackageNewHealthReport", StringComparison.Ordinal))
            {
                obj = DeployedServicePackageNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServicePackageHealthReportExpired", StringComparison.Ordinal))
            {
                obj = DeployedServicePackageHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatefulReplicaNewHealthReport", StringComparison.Ordinal))
            {
                obj = StatefulReplicaNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatefulReplicaHealthReportExpired", StringComparison.Ordinal))
            {
                obj = StatefulReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatelessReplicaNewHealthReport", StringComparison.Ordinal))
            {
                obj = StatelessReplicaNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatelessReplicaHealthReportExpired", StringComparison.Ordinal))
            {
                obj = StatelessReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterNewHealthReport", StringComparison.Ordinal))
            {
                obj = ClusterNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterHealthReportExpired", StringComparison.Ordinal))
            {
                obj = ClusterHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeCompleted", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeDomainCompleted", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeDomainCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeRollbackCompleted", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeRollbackCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeRollbackStarted", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeRollbackStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeStarted", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosStopped", StringComparison.Ordinal))
            {
                obj = ChaosStoppedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosStarted", StringComparison.Ordinal))
            {
                obj = ChaosStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosCodePackageRestartScheduled", StringComparison.Ordinal))
            {
                obj = ChaosCodePackageRestartScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosReplicaRemovalScheduled", StringComparison.Ordinal))
            {
                obj = ChaosReplicaRemovalScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosPartitionSecondaryMoveScheduled", StringComparison.Ordinal))
            {
                obj = ChaosPartitionSecondaryMoveScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosPartitionPrimaryMoveScheduled", StringComparison.Ordinal))
            {
                obj = ChaosPartitionPrimaryMoveScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosReplicaRestartScheduled", StringComparison.Ordinal))
            {
                obj = ChaosReplicaRestartScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosNodeRestartScheduled", StringComparison.Ordinal))
            {
                obj = ChaosNodeRestartScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }

            return obj;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, FabricEvent obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(FabricEventKind.ApplicationEvent))
            {
                ApplicationEventConverter.Serialize(writer, (ApplicationEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterEvent))
            {
                ClusterEventConverter.Serialize(writer, (ClusterEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ContainerInstanceEvent))
            {
                ContainerInstanceEventConverter.Serialize(writer, (ContainerInstanceEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeEvent))
            {
                NodeEventConverter.Serialize(writer, (NodeEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionAnalysisEvent))
            {
                PartitionAnalysisEventConverter.Serialize(writer, (PartitionAnalysisEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionEvent))
            {
                PartitionEventConverter.Serialize(writer, (PartitionEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ReplicaEvent))
            {
                ReplicaEventConverter.Serialize(writer, (ReplicaEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ServiceEvent))
            {
                ServiceEventConverter.Serialize(writer, (ServiceEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationCreated))
            {
                ApplicationCreatedEventConverter.Serialize(writer, (ApplicationCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationDeleted))
            {
                ApplicationDeletedEventConverter.Serialize(writer, (ApplicationDeletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationNewHealthReport))
            {
                ApplicationNewHealthReportEventConverter.Serialize(writer, (ApplicationNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationHealthReportExpired))
            {
                ApplicationHealthReportExpiredEventConverter.Serialize(writer, (ApplicationHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeCompleted))
            {
                ApplicationUpgradeCompletedEventConverter.Serialize(writer, (ApplicationUpgradeCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeDomainCompleted))
            {
                ApplicationUpgradeDomainCompletedEventConverter.Serialize(writer, (ApplicationUpgradeDomainCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeRollbackCompleted))
            {
                ApplicationUpgradeRollbackCompletedEventConverter.Serialize(writer, (ApplicationUpgradeRollbackCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeRollbackStarted))
            {
                ApplicationUpgradeRollbackStartedEventConverter.Serialize(writer, (ApplicationUpgradeRollbackStartedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeStarted))
            {
                ApplicationUpgradeStartedEventConverter.Serialize(writer, (ApplicationUpgradeStartedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedApplicationNewHealthReport))
            {
                DeployedApplicationNewHealthReportEventConverter.Serialize(writer, (DeployedApplicationNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedApplicationHealthReportExpired))
            {
                DeployedApplicationHealthReportExpiredEventConverter.Serialize(writer, (DeployedApplicationHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationProcessExited))
            {
                ApplicationProcessExitedEventConverter.Serialize(writer, (ApplicationProcessExitedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationContainerInstanceExited))
            {
                ApplicationContainerInstanceExitedEventConverter.Serialize(writer, (ApplicationContainerInstanceExitedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeAborted))
            {
                NodeAbortedEventConverter.Serialize(writer, (NodeAbortedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeAddedToCluster))
            {
                NodeAddedToClusterEventConverter.Serialize(writer, (NodeAddedToClusterEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeClosed))
            {
                NodeClosedEventConverter.Serialize(writer, (NodeClosedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeDeactivateCompleted))
            {
                NodeDeactivateCompletedEventConverter.Serialize(writer, (NodeDeactivateCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeDeactivateStarted))
            {
                NodeDeactivateStartedEventConverter.Serialize(writer, (NodeDeactivateStartedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeDown))
            {
                NodeDownEventConverter.Serialize(writer, (NodeDownEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeNewHealthReport))
            {
                NodeNewHealthReportEventConverter.Serialize(writer, (NodeNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeHealthReportExpired))
            {
                NodeHealthReportExpiredEventConverter.Serialize(writer, (NodeHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeOpenSucceeded))
            {
                NodeOpenSucceededEventConverter.Serialize(writer, (NodeOpenSucceededEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeOpenFailed))
            {
                NodeOpenFailedEventConverter.Serialize(writer, (NodeOpenFailedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeRemovedFromCluster))
            {
                NodeRemovedFromClusterEventConverter.Serialize(writer, (NodeRemovedFromClusterEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeUp))
            {
                NodeUpEventConverter.Serialize(writer, (NodeUpEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionNewHealthReport))
            {
                PartitionNewHealthReportEventConverter.Serialize(writer, (PartitionNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionHealthReportExpired))
            {
                PartitionHealthReportExpiredEventConverter.Serialize(writer, (PartitionHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionReconfigured))
            {
                PartitionReconfiguredEventConverter.Serialize(writer, (PartitionReconfiguredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionPrimaryMoveAnalysis))
            {
                PartitionPrimaryMoveAnalysisEventConverter.Serialize(writer, (PartitionPrimaryMoveAnalysisEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ServiceCreated))
            {
                ServiceCreatedEventConverter.Serialize(writer, (ServiceCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ServiceDeleted))
            {
                ServiceDeletedEventConverter.Serialize(writer, (ServiceDeletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ServiceNewHealthReport))
            {
                ServiceNewHealthReportEventConverter.Serialize(writer, (ServiceNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ServiceHealthReportExpired))
            {
                ServiceHealthReportExpiredEventConverter.Serialize(writer, (ServiceHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedServicePackageNewHealthReport))
            {
                DeployedServicePackageNewHealthReportEventConverter.Serialize(writer, (DeployedServicePackageNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedServicePackageHealthReportExpired))
            {
                DeployedServicePackageHealthReportExpiredEventConverter.Serialize(writer, (DeployedServicePackageHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatefulReplicaNewHealthReport))
            {
                StatefulReplicaNewHealthReportEventConverter.Serialize(writer, (StatefulReplicaNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatefulReplicaHealthReportExpired))
            {
                StatefulReplicaHealthReportExpiredEventConverter.Serialize(writer, (StatefulReplicaHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatelessReplicaNewHealthReport))
            {
                StatelessReplicaNewHealthReportEventConverter.Serialize(writer, (StatelessReplicaNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatelessReplicaHealthReportExpired))
            {
                StatelessReplicaHealthReportExpiredEventConverter.Serialize(writer, (StatelessReplicaHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterNewHealthReport))
            {
                ClusterNewHealthReportEventConverter.Serialize(writer, (ClusterNewHealthReportEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterHealthReportExpired))
            {
                ClusterHealthReportExpiredEventConverter.Serialize(writer, (ClusterHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeCompleted))
            {
                ClusterUpgradeCompletedEventConverter.Serialize(writer, (ClusterUpgradeCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeDomainCompleted))
            {
                ClusterUpgradeDomainCompletedEventConverter.Serialize(writer, (ClusterUpgradeDomainCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeRollbackCompleted))
            {
                ClusterUpgradeRollbackCompletedEventConverter.Serialize(writer, (ClusterUpgradeRollbackCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeRollbackStarted))
            {
                ClusterUpgradeRollbackStartedEventConverter.Serialize(writer, (ClusterUpgradeRollbackStartedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeStarted))
            {
                ClusterUpgradeStartedEventConverter.Serialize(writer, (ClusterUpgradeStartedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosStopped))
            {
                ChaosStoppedEventConverter.Serialize(writer, (ChaosStoppedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosStarted))
            {
                ChaosStartedEventConverter.Serialize(writer, (ChaosStartedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosCodePackageRestartScheduled))
            {
                ChaosCodePackageRestartScheduledEventConverter.Serialize(writer, (ChaosCodePackageRestartScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosReplicaRemovalScheduled))
            {
                ChaosReplicaRemovalScheduledEventConverter.Serialize(writer, (ChaosReplicaRemovalScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosPartitionSecondaryMoveScheduled))
            {
                ChaosPartitionSecondaryMoveScheduledEventConverter.Serialize(writer, (ChaosPartitionSecondaryMoveScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosPartitionPrimaryMoveScheduled))
            {
                ChaosPartitionPrimaryMoveScheduledEventConverter.Serialize(writer, (ChaosPartitionPrimaryMoveScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosReplicaRestartScheduled))
            {
                ChaosReplicaRestartScheduledEventConverter.Serialize(writer, (ChaosReplicaRestartScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosNodeRestartScheduled))
            {
                ChaosNodeRestartScheduledEventConverter.Serialize(writer, (ChaosNodeRestartScheduledEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
