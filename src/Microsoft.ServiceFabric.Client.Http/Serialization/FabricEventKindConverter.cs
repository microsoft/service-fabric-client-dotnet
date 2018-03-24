// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
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
            else if (string.Compare(value, "ContainerEvent", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.ContainerEvent;
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
            else if (string.Compare(value, "NodeUp", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeUp;
            }
            else if (string.Compare(value, "NodeDown", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.NodeDown;
            }
            else if (string.Compare(value, "PartitionPrimaryMoveAnalysis", StringComparison.Ordinal) == 0)
            {
                obj = FabricEventKind.PartitionPrimaryMoveAnalysis;
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
                case FabricEventKind.ContainerEvent:
                    writer.WriteStringValue("ContainerEvent");
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
                case FabricEventKind.NodeUp:
                    writer.WriteStringValue("NodeUp");
                    break;
                case FabricEventKind.NodeDown:
                    writer.WriteStringValue("NodeDown");
                    break;
                case FabricEventKind.PartitionPrimaryMoveAnalysis:
                    writer.WriteStringValue("PartitionPrimaryMoveAnalysis");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type FabricEventKind");
            }
        }
    }
}
