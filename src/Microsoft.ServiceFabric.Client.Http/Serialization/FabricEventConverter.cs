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
            FabricEvent obj;
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
            else if (propValue.Equals("ApplicationHealthReportCreated", StringComparison.Ordinal))
            {
                obj = ApplicationHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationHealthReportExpired", StringComparison.Ordinal))
            {
                obj = ApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeComplete", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeCompleteEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeDomainComplete", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeDomainCompleteEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeRollbackComplete", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeRollbackCompleteEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeRollbackStart", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeRollbackStartEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeStart", StringComparison.Ordinal))
            {
                obj = ApplicationUpgradeStartEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplicationHealthReportCreated", StringComparison.Ordinal))
            {
                obj = DeployedApplicationHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplicationHealthReportExpired", StringComparison.Ordinal))
            {
                obj = DeployedApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ProcessDeactivated", StringComparison.Ordinal))
            {
                obj = ProcessDeactivatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ContainerDeactivated", StringComparison.Ordinal))
            {
                obj = ContainerDeactivatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeAborted", StringComparison.Ordinal))
            {
                obj = NodeAbortedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeAborting", StringComparison.Ordinal))
            {
                obj = NodeAbortingEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeAdded", StringComparison.Ordinal))
            {
                obj = NodeAddedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeClose", StringComparison.Ordinal))
            {
                obj = NodeCloseEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeClosing", StringComparison.Ordinal))
            {
                obj = NodeClosingEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDeactivateComplete", StringComparison.Ordinal))
            {
                obj = NodeDeactivateCompleteEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDeactivateStart", StringComparison.Ordinal))
            {
                obj = NodeDeactivateStartEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDown", StringComparison.Ordinal))
            {
                obj = NodeDownEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeHealthReportCreated", StringComparison.Ordinal))
            {
                obj = NodeHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeHealthReportExpired", StringComparison.Ordinal))
            {
                obj = NodeHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeOpenedSuccess", StringComparison.Ordinal))
            {
                obj = NodeOpenedSuccessEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeOpenFailed", StringComparison.Ordinal))
            {
                obj = NodeOpenFailedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeOpening", StringComparison.Ordinal))
            {
                obj = NodeOpeningEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeRemoved", StringComparison.Ordinal))
            {
                obj = NodeRemovedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeUp", StringComparison.Ordinal))
            {
                obj = NodeUpEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionHealthReportCreated", StringComparison.Ordinal))
            {
                obj = PartitionHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionHealthReportExpired", StringComparison.Ordinal))
            {
                obj = PartitionHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionReconfigurationCompleted", StringComparison.Ordinal))
            {
                obj = PartitionReconfigurationCompletedEventConverter.GetFromJsonProperties(reader);
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
            else if (propValue.Equals("ServiceHealthReportCreated", StringComparison.Ordinal))
            {
                obj = ServiceHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceHealthReportExpired", StringComparison.Ordinal))
            {
                obj = ServiceHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServiceHealthReportCreated", StringComparison.Ordinal))
            {
                obj = DeployedServiceHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServiceHealthReportExpired", StringComparison.Ordinal))
            {
                obj = DeployedServiceHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatefulReplicaHealthReportCreated", StringComparison.Ordinal))
            {
                obj = StatefulReplicaHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatefulReplicaHealthReportExpired", StringComparison.Ordinal))
            {
                obj = StatefulReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatelessReplicaHealthReportCreated", StringComparison.Ordinal))
            {
                obj = StatelessReplicaHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatelessReplicaHealthReportExpired", StringComparison.Ordinal))
            {
                obj = StatelessReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterHealthReportCreated", StringComparison.Ordinal))
            {
                obj = ClusterHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterHealthReportExpired", StringComparison.Ordinal))
            {
                obj = ClusterHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeComplete", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeCompleteEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeDomainComplete", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeDomainCompleteEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeRollbackComplete", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeRollbackCompleteEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeRollbackStart", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeRollbackStartEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeStart", StringComparison.Ordinal))
            {
                obj = ClusterUpgradeStartEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosStopped", StringComparison.Ordinal))
            {
                obj = ChaosStoppedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosStarted", StringComparison.Ordinal))
            {
                obj = ChaosStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosRestartNodeFaultCompleted", StringComparison.Ordinal))
            {
                obj = ChaosRestartNodeFaultCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosRestartCodePackageFaultScheduled", StringComparison.Ordinal))
            {
                obj = ChaosRestartCodePackageFaultScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosRestartCodePackageFaultCompleted", StringComparison.Ordinal))
            {
                obj = ChaosRestartCodePackageFaultCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosRemoveReplicaFaultScheduled", StringComparison.Ordinal))
            {
                obj = ChaosRemoveReplicaFaultScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosRemoveReplicaFaultCompleted", StringComparison.Ordinal))
            {
                obj = ChaosRemoveReplicaFaultCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosMoveSecondaryFaultScheduled", StringComparison.Ordinal))
            {
                obj = ChaosMoveSecondaryFaultScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosMovePrimaryFaultScheduled", StringComparison.Ordinal))
            {
                obj = ChaosMovePrimaryFaultScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosRestartReplicaFaultScheduled", StringComparison.Ordinal))
            {
                obj = ChaosRestartReplicaFaultScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosRestartNodeFaultScheduled", StringComparison.Ordinal))
            {
                obj = ChaosRestartNodeFaultScheduledEventConverter.GetFromJsonProperties(reader);
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
            else if (kind.Equals(FabricEventKind.ApplicationHealthReportCreated))
            {
                ApplicationHealthReportCreatedEventConverter.Serialize(writer, (ApplicationHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationHealthReportExpired))
            {
                ApplicationHealthReportExpiredEventConverter.Serialize(writer, (ApplicationHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeComplete))
            {
                ApplicationUpgradeCompleteEventConverter.Serialize(writer, (ApplicationUpgradeCompleteEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeDomainComplete))
            {
                ApplicationUpgradeDomainCompleteEventConverter.Serialize(writer, (ApplicationUpgradeDomainCompleteEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeRollbackComplete))
            {
                ApplicationUpgradeRollbackCompleteEventConverter.Serialize(writer, (ApplicationUpgradeRollbackCompleteEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeRollbackStart))
            {
                ApplicationUpgradeRollbackStartEventConverter.Serialize(writer, (ApplicationUpgradeRollbackStartEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ApplicationUpgradeStart))
            {
                ApplicationUpgradeStartEventConverter.Serialize(writer, (ApplicationUpgradeStartEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedApplicationHealthReportCreated))
            {
                DeployedApplicationHealthReportCreatedEventConverter.Serialize(writer, (DeployedApplicationHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedApplicationHealthReportExpired))
            {
                DeployedApplicationHealthReportExpiredEventConverter.Serialize(writer, (DeployedApplicationHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ProcessDeactivated))
            {
                ProcessDeactivatedEventConverter.Serialize(writer, (ProcessDeactivatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ContainerDeactivated))
            {
                ContainerDeactivatedEventConverter.Serialize(writer, (ContainerDeactivatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeAborted))
            {
                NodeAbortedEventConverter.Serialize(writer, (NodeAbortedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeAborting))
            {
                NodeAbortingEventConverter.Serialize(writer, (NodeAbortingEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeAdded))
            {
                NodeAddedEventConverter.Serialize(writer, (NodeAddedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeClose))
            {
                NodeCloseEventConverter.Serialize(writer, (NodeCloseEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeClosing))
            {
                NodeClosingEventConverter.Serialize(writer, (NodeClosingEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeDeactivateComplete))
            {
                NodeDeactivateCompleteEventConverter.Serialize(writer, (NodeDeactivateCompleteEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeDeactivateStart))
            {
                NodeDeactivateStartEventConverter.Serialize(writer, (NodeDeactivateStartEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeDown))
            {
                NodeDownEventConverter.Serialize(writer, (NodeDownEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeHealthReportCreated))
            {
                NodeHealthReportCreatedEventConverter.Serialize(writer, (NodeHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeHealthReportExpired))
            {
                NodeHealthReportExpiredEventConverter.Serialize(writer, (NodeHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeOpenedSuccess))
            {
                NodeOpenedSuccessEventConverter.Serialize(writer, (NodeOpenedSuccessEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeOpenFailed))
            {
                NodeOpenFailedEventConverter.Serialize(writer, (NodeOpenFailedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeOpening))
            {
                NodeOpeningEventConverter.Serialize(writer, (NodeOpeningEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeRemoved))
            {
                NodeRemovedEventConverter.Serialize(writer, (NodeRemovedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeUp))
            {
                NodeUpEventConverter.Serialize(writer, (NodeUpEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionHealthReportCreated))
            {
                PartitionHealthReportCreatedEventConverter.Serialize(writer, (PartitionHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionHealthReportExpired))
            {
                PartitionHealthReportExpiredEventConverter.Serialize(writer, (PartitionHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionReconfigurationCompleted))
            {
                PartitionReconfigurationCompletedEventConverter.Serialize(writer, (PartitionReconfigurationCompletedEvent)obj);
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
            else if (kind.Equals(FabricEventKind.ServiceHealthReportCreated))
            {
                ServiceHealthReportCreatedEventConverter.Serialize(writer, (ServiceHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ServiceHealthReportExpired))
            {
                ServiceHealthReportExpiredEventConverter.Serialize(writer, (ServiceHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedServiceHealthReportCreated))
            {
                DeployedServiceHealthReportCreatedEventConverter.Serialize(writer, (DeployedServiceHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.DeployedServiceHealthReportExpired))
            {
                DeployedServiceHealthReportExpiredEventConverter.Serialize(writer, (DeployedServiceHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatefulReplicaHealthReportCreated))
            {
                StatefulReplicaHealthReportCreatedEventConverter.Serialize(writer, (StatefulReplicaHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatefulReplicaHealthReportExpired))
            {
                StatefulReplicaHealthReportExpiredEventConverter.Serialize(writer, (StatefulReplicaHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatelessReplicaHealthReportCreated))
            {
                StatelessReplicaHealthReportCreatedEventConverter.Serialize(writer, (StatelessReplicaHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.StatelessReplicaHealthReportExpired))
            {
                StatelessReplicaHealthReportExpiredEventConverter.Serialize(writer, (StatelessReplicaHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterHealthReportCreated))
            {
                ClusterHealthReportCreatedEventConverter.Serialize(writer, (ClusterHealthReportCreatedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterHealthReportExpired))
            {
                ClusterHealthReportExpiredEventConverter.Serialize(writer, (ClusterHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeComplete))
            {
                ClusterUpgradeCompleteEventConverter.Serialize(writer, (ClusterUpgradeCompleteEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeDomainComplete))
            {
                ClusterUpgradeDomainCompleteEventConverter.Serialize(writer, (ClusterUpgradeDomainCompleteEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeRollbackComplete))
            {
                ClusterUpgradeRollbackCompleteEventConverter.Serialize(writer, (ClusterUpgradeRollbackCompleteEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeRollbackStart))
            {
                ClusterUpgradeRollbackStartEventConverter.Serialize(writer, (ClusterUpgradeRollbackStartEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterUpgradeStart))
            {
                ClusterUpgradeStartEventConverter.Serialize(writer, (ClusterUpgradeStartEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosStopped))
            {
                ChaosStoppedEventConverter.Serialize(writer, (ChaosStoppedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosStarted))
            {
                ChaosStartedEventConverter.Serialize(writer, (ChaosStartedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosRestartNodeFaultCompleted))
            {
                ChaosRestartNodeFaultCompletedEventConverter.Serialize(writer, (ChaosRestartNodeFaultCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosRestartCodePackageFaultScheduled))
            {
                ChaosRestartCodePackageFaultScheduledEventConverter.Serialize(writer, (ChaosRestartCodePackageFaultScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosRestartCodePackageFaultCompleted))
            {
                ChaosRestartCodePackageFaultCompletedEventConverter.Serialize(writer, (ChaosRestartCodePackageFaultCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosRemoveReplicaFaultScheduled))
            {
                ChaosRemoveReplicaFaultScheduledEventConverter.Serialize(writer, (ChaosRemoveReplicaFaultScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosRemoveReplicaFaultCompleted))
            {
                ChaosRemoveReplicaFaultCompletedEventConverter.Serialize(writer, (ChaosRemoveReplicaFaultCompletedEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosMoveSecondaryFaultScheduled))
            {
                ChaosMoveSecondaryFaultScheduledEventConverter.Serialize(writer, (ChaosMoveSecondaryFaultScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosMovePrimaryFaultScheduled))
            {
                ChaosMovePrimaryFaultScheduledEventConverter.Serialize(writer, (ChaosMovePrimaryFaultScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosRestartReplicaFaultScheduled))
            {
                ChaosRestartReplicaFaultScheduledEventConverter.Serialize(writer, (ChaosRestartReplicaFaultScheduledEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ChaosRestartNodeFaultScheduled))
            {
                ChaosRestartNodeFaultScheduledEventConverter.Serialize(writer, (ChaosRestartNodeFaultScheduledEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
