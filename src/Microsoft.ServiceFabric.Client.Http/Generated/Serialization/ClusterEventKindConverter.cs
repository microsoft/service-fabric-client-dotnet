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
    /// Converter for <see cref="ClusterEventKind" />.
    /// </summary>
    internal class ClusterEventKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ClusterEventKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ClusterEventKind);

            if (string.Compare(value, "ClusterEvent", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterEvent;
            }
            else if (string.Compare(value, "ClusterNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterNewHealthReport;
            }
            else if (string.Compare(value, "ClusterHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterHealthReportExpired;
            }
            else if (string.Compare(value, "ClusterUpgradeCompleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterUpgradeCompleted;
            }
            else if (string.Compare(value, "ClusterUpgradeDomainCompleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterUpgradeDomainCompleted;
            }
            else if (string.Compare(value, "ClusterUpgradeRollbackCompleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterUpgradeRollbackCompleted;
            }
            else if (string.Compare(value, "ClusterUpgradeRollbackStarted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterUpgradeRollbackStarted;
            }
            else if (string.Compare(value, "ClusterUpgradeStarted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ClusterUpgradeStarted;
            }
            else if (string.Compare(value, "ChaosStopped", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ChaosStopped;
            }
            else if (string.Compare(value, "ChaosStarted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ChaosStarted;
            }
            else if (string.Compare(value, "ChaosReplicaRemovalScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ChaosReplicaRemovalScheduled;
            }
            else if (string.Compare(value, "ChaosPartitionSecondaryMoveScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ChaosPartitionSecondaryMoveScheduled;
            }
            else if (string.Compare(value, "ChaosPartitionPrimaryMoveScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ChaosPartitionPrimaryMoveScheduled;
            }
            else if (string.Compare(value, "ChaosReplicaRestartScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ClusterEventKind.ChaosReplicaRestartScheduled;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ClusterEventKind? value)
        {
            switch (value)
            {
                case ClusterEventKind.ClusterEvent:
                    writer.WriteStringValue("ClusterEvent");
                    break;
                case ClusterEventKind.ClusterNewHealthReport:
                    writer.WriteStringValue("ClusterNewHealthReport");
                    break;
                case ClusterEventKind.ClusterHealthReportExpired:
                    writer.WriteStringValue("ClusterHealthReportExpired");
                    break;
                case ClusterEventKind.ClusterUpgradeCompleted:
                    writer.WriteStringValue("ClusterUpgradeCompleted");
                    break;
                case ClusterEventKind.ClusterUpgradeDomainCompleted:
                    writer.WriteStringValue("ClusterUpgradeDomainCompleted");
                    break;
                case ClusterEventKind.ClusterUpgradeRollbackCompleted:
                    writer.WriteStringValue("ClusterUpgradeRollbackCompleted");
                    break;
                case ClusterEventKind.ClusterUpgradeRollbackStarted:
                    writer.WriteStringValue("ClusterUpgradeRollbackStarted");
                    break;
                case ClusterEventKind.ClusterUpgradeStarted:
                    writer.WriteStringValue("ClusterUpgradeStarted");
                    break;
                case ClusterEventKind.ChaosStopped:
                    writer.WriteStringValue("ChaosStopped");
                    break;
                case ClusterEventKind.ChaosStarted:
                    writer.WriteStringValue("ChaosStarted");
                    break;
                case ClusterEventKind.ChaosReplicaRemovalScheduled:
                    writer.WriteStringValue("ChaosReplicaRemovalScheduled");
                    break;
                case ClusterEventKind.ChaosPartitionSecondaryMoveScheduled:
                    writer.WriteStringValue("ChaosPartitionSecondaryMoveScheduled");
                    break;
                case ClusterEventKind.ChaosPartitionPrimaryMoveScheduled:
                    writer.WriteStringValue("ChaosPartitionPrimaryMoveScheduled");
                    break;
                case ClusterEventKind.ChaosReplicaRestartScheduled:
                    writer.WriteStringValue("ChaosReplicaRestartScheduled");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ClusterEventKind");
            }
        }
    }
}
