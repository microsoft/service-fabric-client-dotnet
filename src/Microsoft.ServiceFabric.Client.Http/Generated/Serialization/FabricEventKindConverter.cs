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
    /// Converter for <see cref="FabricEventKind" />.
    /// </summary>
    internal class FabricEventKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static FabricEventKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(FabricEventKind);

            if (string.Compare(value, "ClusterEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterEvent;
            }
            else if (string.Compare(value, "ContainerInstanceEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ContainerInstanceEvent;
            }
            else if (string.Compare(value, "NodeEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeEvent;
            }
            else if (string.Compare(value, "ApplicationEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationEvent;
            }
            else if (string.Compare(value, "ServiceEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ServiceEvent;
            }
            else if (string.Compare(value, "PartitionEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.PartitionEvent;
            }
            else if (string.Compare(value, "ReplicaEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ReplicaEvent;
            }
            else if (string.Compare(value, "PartitionAnalysisEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.PartitionAnalysisEvent;
            }
            else if (string.Compare(value, "ApplicationCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationCreated;
            }
            else if (string.Compare(value, "ApplicationDeleted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationDeleted;
            }
            else if (string.Compare(value, "ApplicationHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationHealthReportCreated;
            }
            else if (string.Compare(value, "ApplicationHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationHealthReportExpired;
            }
            else if (string.Compare(value, "ApplicationUpgradeComplete", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationUpgradeComplete;
            }
            else if (string.Compare(value, "ApplicationUpgradeDomainComplete", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationUpgradeDomainComplete;
            }
            else if (string.Compare(value, "ApplicationUpgradeRollbackComplete", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationUpgradeRollbackComplete;
            }
            else if (string.Compare(value, "ApplicationUpgradeRollbackStart", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationUpgradeRollbackStart;
            }
            else if (string.Compare(value, "ApplicationUpgradeStart", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ApplicationUpgradeStart;
            }
            else if (string.Compare(value, "DeployedApplicationHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.DeployedApplicationHealthReportCreated;
            }
            else if (string.Compare(value, "DeployedApplicationHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.DeployedApplicationHealthReportExpired;
            }
            else if (string.Compare(value, "ProcessDeactivated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ProcessDeactivated;
            }
            else if (string.Compare(value, "ContainerDeactivated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ContainerDeactivated;
            }
            else if (string.Compare(value, "NodeAborted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeAborted;
            }
            else if (string.Compare(value, "NodeAborting", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeAborting;
            }
            else if (string.Compare(value, "NodeAdded", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeAdded;
            }
            else if (string.Compare(value, "NodeClose", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeClose;
            }
            else if (string.Compare(value, "NodeClosing", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeClosing;
            }
            else if (string.Compare(value, "NodeDeactivateComplete", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeDeactivateComplete;
            }
            else if (string.Compare(value, "NodeDeactivateStart", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeDeactivateStart;
            }
            else if (string.Compare(value, "NodeDown", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeDown;
            }
            else if (string.Compare(value, "NodeHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeHealthReportCreated;
            }
            else if (string.Compare(value, "NodeHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeHealthReportExpired;
            }
            else if (string.Compare(value, "NodeOpenedSuccess", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeOpenedSuccess;
            }
            else if (string.Compare(value, "NodeOpenFailed", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeOpenFailed;
            }
            else if (string.Compare(value, "NodeOpening", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeOpening;
            }
            else if (string.Compare(value, "NodeRemoved", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeRemoved;
            }
            else if (string.Compare(value, "NodeUp", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeUp;
            }
            else if (string.Compare(value, "PartitionHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.PartitionHealthReportCreated;
            }
            else if (string.Compare(value, "PartitionHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.PartitionHealthReportExpired;
            }
            else if (string.Compare(value, "PartitionReconfigurationCompleted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.PartitionReconfigurationCompleted;
            }
            else if (string.Compare(value, "PartitionPrimaryMoveAnalysis", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.PartitionPrimaryMoveAnalysis;
            }
            else if (string.Compare(value, "ServiceCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ServiceCreated;
            }
            else if (string.Compare(value, "ServiceDeleted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ServiceDeleted;
            }
            else if (string.Compare(value, "ServiceHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ServiceHealthReportCreated;
            }
            else if (string.Compare(value, "ServiceHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ServiceHealthReportExpired;
            }
            else if (string.Compare(value, "DeployedServiceHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.DeployedServiceHealthReportCreated;
            }
            else if (string.Compare(value, "DeployedServiceHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.DeployedServiceHealthReportExpired;
            }
            else if (string.Compare(value, "StatefulReplicaHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.StatefulReplicaHealthReportCreated;
            }
            else if (string.Compare(value, "StatefulReplicaHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.StatefulReplicaHealthReportExpired;
            }
            else if (string.Compare(value, "StatelessReplicaHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.StatelessReplicaHealthReportCreated;
            }
            else if (string.Compare(value, "StatelessReplicaHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.StatelessReplicaHealthReportExpired;
            }
            else if (string.Compare(value, "ClusterHealthReportCreated", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterHealthReportCreated;
            }
            else if (string.Compare(value, "ClusterHealthReportExpired", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterHealthReportExpired;
            }
            else if (string.Compare(value, "ClusterUpgradeComplete", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterUpgradeComplete;
            }
            else if (string.Compare(value, "ClusterUpgradeDomainComplete", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterUpgradeDomainComplete;
            }
            else if (string.Compare(value, "ClusterUpgradeRollbackComplete", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterUpgradeRollbackComplete;
            }
            else if (string.Compare(value, "ClusterUpgradeRollbackStart", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterUpgradeRollbackStart;
            }
            else if (string.Compare(value, "ClusterUpgradeStart", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ClusterUpgradeStart;
            }
            else if (string.Compare(value, "ChaosStopped", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosStopped;
            }
            else if (string.Compare(value, "ChaosStarted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosStarted;
            }
            else if (string.Compare(value, "ChaosRestartNodeFaultCompleted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosRestartNodeFaultCompleted;
            }
            else if (string.Compare(value, "ChaosRestartCodePackageFaultScheduled", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosRestartCodePackageFaultScheduled;
            }
            else if (string.Compare(value, "ChaosRestartCodePackageFaultCompleted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosRestartCodePackageFaultCompleted;
            }
            else if (string.Compare(value, "ChaosRemoveReplicaFaultScheduled", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosRemoveReplicaFaultScheduled;
            }
            else if (string.Compare(value, "ChaosRemoveReplicaFaultCompleted", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosRemoveReplicaFaultCompleted;
            }
            else if (string.Compare(value, "ChaosMoveSecondaryFaultScheduled", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosMoveSecondaryFaultScheduled;
            }
            else if (string.Compare(value, "ChaosMovePrimaryFaultScheduled", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosMovePrimaryFaultScheduled;
            }
            else if (string.Compare(value, "ChaosRestartReplicaFaultScheduled", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosRestartReplicaFaultScheduled;
            }
            else if (string.Compare(value, "ChaosRestartNodeFaultScheduled", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ChaosRestartNodeFaultScheduled;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, FabricEventKind? value)
        {
            switch (value)
            {
                case FabricEventKind.ClusterEvent:
                    writer.WriteStringValue("ClusterEvent");
                    break;
                case FabricEventKind.ContainerInstanceEvent:
                    writer.WriteStringValue("ContainerInstanceEvent");
                    break;
                case FabricEventKind.NodeEvent:
                    writer.WriteStringValue("NodeEvent");
                    break;
                case FabricEventKind.ApplicationEvent:
                    writer.WriteStringValue("ApplicationEvent");
                    break;
                case FabricEventKind.ServiceEvent:
                    writer.WriteStringValue("ServiceEvent");
                    break;
                case FabricEventKind.PartitionEvent:
                    writer.WriteStringValue("PartitionEvent");
                    break;
                case FabricEventKind.ReplicaEvent:
                    writer.WriteStringValue("ReplicaEvent");
                    break;
                case FabricEventKind.PartitionAnalysisEvent:
                    writer.WriteStringValue("PartitionAnalysisEvent");
                    break;
                case FabricEventKind.ApplicationCreated:
                    writer.WriteStringValue("ApplicationCreated");
                    break;
                case FabricEventKind.ApplicationDeleted:
                    writer.WriteStringValue("ApplicationDeleted");
                    break;
                case FabricEventKind.ApplicationHealthReportCreated:
                    writer.WriteStringValue("ApplicationHealthReportCreated");
                    break;
                case FabricEventKind.ApplicationHealthReportExpired:
                    writer.WriteStringValue("ApplicationHealthReportExpired");
                    break;
                case FabricEventKind.ApplicationUpgradeComplete:
                    writer.WriteStringValue("ApplicationUpgradeComplete");
                    break;
                case FabricEventKind.ApplicationUpgradeDomainComplete:
                    writer.WriteStringValue("ApplicationUpgradeDomainComplete");
                    break;
                case FabricEventKind.ApplicationUpgradeRollbackComplete:
                    writer.WriteStringValue("ApplicationUpgradeRollbackComplete");
                    break;
                case FabricEventKind.ApplicationUpgradeRollbackStart:
                    writer.WriteStringValue("ApplicationUpgradeRollbackStart");
                    break;
                case FabricEventKind.ApplicationUpgradeStart:
                    writer.WriteStringValue("ApplicationUpgradeStart");
                    break;
                case FabricEventKind.DeployedApplicationHealthReportCreated:
                    writer.WriteStringValue("DeployedApplicationHealthReportCreated");
                    break;
                case FabricEventKind.DeployedApplicationHealthReportExpired:
                    writer.WriteStringValue("DeployedApplicationHealthReportExpired");
                    break;
                case FabricEventKind.ProcessDeactivated:
                    writer.WriteStringValue("ProcessDeactivated");
                    break;
                case FabricEventKind.ContainerDeactivated:
                    writer.WriteStringValue("ContainerDeactivated");
                    break;
                case FabricEventKind.NodeAborted:
                    writer.WriteStringValue("NodeAborted");
                    break;
                case FabricEventKind.NodeAborting:
                    writer.WriteStringValue("NodeAborting");
                    break;
                case FabricEventKind.NodeAdded:
                    writer.WriteStringValue("NodeAdded");
                    break;
                case FabricEventKind.NodeClose:
                    writer.WriteStringValue("NodeClose");
                    break;
                case FabricEventKind.NodeClosing:
                    writer.WriteStringValue("NodeClosing");
                    break;
                case FabricEventKind.NodeDeactivateComplete:
                    writer.WriteStringValue("NodeDeactivateComplete");
                    break;
                case FabricEventKind.NodeDeactivateStart:
                    writer.WriteStringValue("NodeDeactivateStart");
                    break;
                case FabricEventKind.NodeDown:
                    writer.WriteStringValue("NodeDown");
                    break;
                case FabricEventKind.NodeHealthReportCreated:
                    writer.WriteStringValue("NodeHealthReportCreated");
                    break;
                case FabricEventKind.NodeHealthReportExpired:
                    writer.WriteStringValue("NodeHealthReportExpired");
                    break;
                case FabricEventKind.NodeOpenedSuccess:
                    writer.WriteStringValue("NodeOpenedSuccess");
                    break;
                case FabricEventKind.NodeOpenFailed:
                    writer.WriteStringValue("NodeOpenFailed");
                    break;
                case FabricEventKind.NodeOpening:
                    writer.WriteStringValue("NodeOpening");
                    break;
                case FabricEventKind.NodeRemoved:
                    writer.WriteStringValue("NodeRemoved");
                    break;
                case FabricEventKind.NodeUp:
                    writer.WriteStringValue("NodeUp");
                    break;
                case FabricEventKind.PartitionHealthReportCreated:
                    writer.WriteStringValue("PartitionHealthReportCreated");
                    break;
                case FabricEventKind.PartitionHealthReportExpired:
                    writer.WriteStringValue("PartitionHealthReportExpired");
                    break;
                case FabricEventKind.PartitionReconfigurationCompleted:
                    writer.WriteStringValue("PartitionReconfigurationCompleted");
                    break;
                case FabricEventKind.PartitionPrimaryMoveAnalysis:
                    writer.WriteStringValue("PartitionPrimaryMoveAnalysis");
                    break;
                case FabricEventKind.ServiceCreated:
                    writer.WriteStringValue("ServiceCreated");
                    break;
                case FabricEventKind.ServiceDeleted:
                    writer.WriteStringValue("ServiceDeleted");
                    break;
                case FabricEventKind.ServiceHealthReportCreated:
                    writer.WriteStringValue("ServiceHealthReportCreated");
                    break;
                case FabricEventKind.ServiceHealthReportExpired:
                    writer.WriteStringValue("ServiceHealthReportExpired");
                    break;
                case FabricEventKind.DeployedServiceHealthReportCreated:
                    writer.WriteStringValue("DeployedServiceHealthReportCreated");
                    break;
                case FabricEventKind.DeployedServiceHealthReportExpired:
                    writer.WriteStringValue("DeployedServiceHealthReportExpired");
                    break;
                case FabricEventKind.StatefulReplicaHealthReportCreated:
                    writer.WriteStringValue("StatefulReplicaHealthReportCreated");
                    break;
                case FabricEventKind.StatefulReplicaHealthReportExpired:
                    writer.WriteStringValue("StatefulReplicaHealthReportExpired");
                    break;
                case FabricEventKind.StatelessReplicaHealthReportCreated:
                    writer.WriteStringValue("StatelessReplicaHealthReportCreated");
                    break;
                case FabricEventKind.StatelessReplicaHealthReportExpired:
                    writer.WriteStringValue("StatelessReplicaHealthReportExpired");
                    break;
                case FabricEventKind.ClusterHealthReportCreated:
                    writer.WriteStringValue("ClusterHealthReportCreated");
                    break;
                case FabricEventKind.ClusterHealthReportExpired:
                    writer.WriteStringValue("ClusterHealthReportExpired");
                    break;
                case FabricEventKind.ClusterUpgradeComplete:
                    writer.WriteStringValue("ClusterUpgradeComplete");
                    break;
                case FabricEventKind.ClusterUpgradeDomainComplete:
                    writer.WriteStringValue("ClusterUpgradeDomainComplete");
                    break;
                case FabricEventKind.ClusterUpgradeRollbackComplete:
                    writer.WriteStringValue("ClusterUpgradeRollbackComplete");
                    break;
                case FabricEventKind.ClusterUpgradeRollbackStart:
                    writer.WriteStringValue("ClusterUpgradeRollbackStart");
                    break;
                case FabricEventKind.ClusterUpgradeStart:
                    writer.WriteStringValue("ClusterUpgradeStart");
                    break;
                case FabricEventKind.ChaosStopped:
                    writer.WriteStringValue("ChaosStopped");
                    break;
                case FabricEventKind.ChaosStarted:
                    writer.WriteStringValue("ChaosStarted");
                    break;
                case FabricEventKind.ChaosRestartNodeFaultCompleted:
                    writer.WriteStringValue("ChaosRestartNodeFaultCompleted");
                    break;
                case FabricEventKind.ChaosRestartCodePackageFaultScheduled:
                    writer.WriteStringValue("ChaosRestartCodePackageFaultScheduled");
                    break;
                case FabricEventKind.ChaosRestartCodePackageFaultCompleted:
                    writer.WriteStringValue("ChaosRestartCodePackageFaultCompleted");
                    break;
                case FabricEventKind.ChaosRemoveReplicaFaultScheduled:
                    writer.WriteStringValue("ChaosRemoveReplicaFaultScheduled");
                    break;
                case FabricEventKind.ChaosRemoveReplicaFaultCompleted:
                    writer.WriteStringValue("ChaosRemoveReplicaFaultCompleted");
                    break;
                case FabricEventKind.ChaosMoveSecondaryFaultScheduled:
                    writer.WriteStringValue("ChaosMoveSecondaryFaultScheduled");
                    break;
                case FabricEventKind.ChaosMovePrimaryFaultScheduled:
                    writer.WriteStringValue("ChaosMovePrimaryFaultScheduled");
                    break;
                case FabricEventKind.ChaosRestartReplicaFaultScheduled:
                    writer.WriteStringValue("ChaosRestartReplicaFaultScheduled");
                    break;
                case FabricEventKind.ChaosRestartNodeFaultScheduled:
                    writer.WriteStringValue("ChaosRestartNodeFaultScheduled");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type FabricEventKind");
            }
        }
    }
}
