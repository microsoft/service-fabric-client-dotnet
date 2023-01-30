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
    /// Converter for <see cref="ReplicaEventKind" />.
    /// </summary>
    internal class ReplicaEventKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ReplicaEventKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ReplicaEventKind);

            if (string.Compare(value, "ReplicaEvent", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.ReplicaEvent;
            }
            else if (string.Compare(value, "StatefulReplicaNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.StatefulReplicaNewHealthReport;
            }
            else if (string.Compare(value, "StatefulReplicaHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.StatefulReplicaHealthReportExpired;
            }
            else if (string.Compare(value, "StatelessReplicaNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.StatelessReplicaNewHealthReport;
            }
            else if (string.Compare(value, "StatelessReplicaHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.StatelessReplicaHealthReportExpired;
            }
            else if (string.Compare(value, "ChaosStopped", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.ChaosStopped;
            }
            else if (string.Compare(value, "ChaosStarted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.ChaosStarted;
            }
            else if (string.Compare(value, "ChaosCodePackageRestartScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.ChaosCodePackageRestartScheduled;
            }
            else if (string.Compare(value, "ChaosReplicaRemovalScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.ChaosReplicaRemovalScheduled;
            }
            else if (string.Compare(value, "ChaosReplicaRestartScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ReplicaEventKind.ChaosReplicaRestartScheduled;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ReplicaEventKind? value)
        {
            switch (value)
            {
                case ReplicaEventKind.ReplicaEvent:
                    writer.WriteStringValue("ReplicaEvent");
                    break;
                case ReplicaEventKind.StatefulReplicaNewHealthReport:
                    writer.WriteStringValue("StatefulReplicaNewHealthReport");
                    break;
                case ReplicaEventKind.StatefulReplicaHealthReportExpired:
                    writer.WriteStringValue("StatefulReplicaHealthReportExpired");
                    break;
                case ReplicaEventKind.StatelessReplicaNewHealthReport:
                    writer.WriteStringValue("StatelessReplicaNewHealthReport");
                    break;
                case ReplicaEventKind.StatelessReplicaHealthReportExpired:
                    writer.WriteStringValue("StatelessReplicaHealthReportExpired");
                    break;
                case ReplicaEventKind.ChaosStopped:
                    writer.WriteStringValue("ChaosStopped");
                    break;
                case ReplicaEventKind.ChaosStarted:
                    writer.WriteStringValue("ChaosStarted");
                    break;
                case ReplicaEventKind.ChaosCodePackageRestartScheduled:
                    writer.WriteStringValue("ChaosCodePackageRestartScheduled");
                    break;
                case ReplicaEventKind.ChaosReplicaRemovalScheduled:
                    writer.WriteStringValue("ChaosReplicaRemovalScheduled");
                    break;
                case ReplicaEventKind.ChaosReplicaRestartScheduled:
                    writer.WriteStringValue("ChaosReplicaRestartScheduled");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ReplicaEventKind");
            }
        }
    }
}
