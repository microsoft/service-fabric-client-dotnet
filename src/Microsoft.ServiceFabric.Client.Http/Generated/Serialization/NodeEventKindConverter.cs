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
    /// Converter for <see cref="NodeEventKind" />.
    /// </summary>
    internal class NodeEventKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static NodeEventKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(NodeEventKind);

            if (string.Compare(value, "NodeEvent", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeEvent;
            }
            else if (string.Compare(value, "NodeAborted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeAborted;
            }
            else if (string.Compare(value, "NodeAddedToCluster", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeAddedToCluster;
            }
            else if (string.Compare(value, "NodeClosed", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeClosed;
            }
            else if (string.Compare(value, "NodeDeactivateCompleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeDeactivateCompleted;
            }
            else if (string.Compare(value, "NodeDeactivateStarted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeDeactivateStarted;
            }
            else if (string.Compare(value, "NodeDown", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeDown;
            }
            else if (string.Compare(value, "NodeNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeNewHealthReport;
            }
            else if (string.Compare(value, "NodeHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeHealthReportExpired;
            }
            else if (string.Compare(value, "NodeOpenSucceeded", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeOpenSucceeded;
            }
            else if (string.Compare(value, "NodeOpenFailed", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeOpenFailed;
            }
            else if (string.Compare(value, "NodeRemovedFromCluster", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeRemovedFromCluster;
            }
            else if (string.Compare(value, "NodeUp", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.NodeUp;
            }
            else if (string.Compare(value, "ChaosNodeRestartScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = NodeEventKind.ChaosNodeRestartScheduled;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, NodeEventKind? value)
        {
            switch (value)
            {
                case NodeEventKind.NodeEvent:
                    writer.WriteStringValue("NodeEvent");
                    break;
                case NodeEventKind.NodeAborted:
                    writer.WriteStringValue("NodeAborted");
                    break;
                case NodeEventKind.NodeAddedToCluster:
                    writer.WriteStringValue("NodeAddedToCluster");
                    break;
                case NodeEventKind.NodeClosed:
                    writer.WriteStringValue("NodeClosed");
                    break;
                case NodeEventKind.NodeDeactivateCompleted:
                    writer.WriteStringValue("NodeDeactivateCompleted");
                    break;
                case NodeEventKind.NodeDeactivateStarted:
                    writer.WriteStringValue("NodeDeactivateStarted");
                    break;
                case NodeEventKind.NodeDown:
                    writer.WriteStringValue("NodeDown");
                    break;
                case NodeEventKind.NodeNewHealthReport:
                    writer.WriteStringValue("NodeNewHealthReport");
                    break;
                case NodeEventKind.NodeHealthReportExpired:
                    writer.WriteStringValue("NodeHealthReportExpired");
                    break;
                case NodeEventKind.NodeOpenSucceeded:
                    writer.WriteStringValue("NodeOpenSucceeded");
                    break;
                case NodeEventKind.NodeOpenFailed:
                    writer.WriteStringValue("NodeOpenFailed");
                    break;
                case NodeEventKind.NodeRemovedFromCluster:
                    writer.WriteStringValue("NodeRemovedFromCluster");
                    break;
                case NodeEventKind.NodeUp:
                    writer.WriteStringValue("NodeUp");
                    break;
                case NodeEventKind.ChaosNodeRestartScheduled:
                    writer.WriteStringValue("ChaosNodeRestartScheduled");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type NodeEventKind");
            }
        }
    }
}
