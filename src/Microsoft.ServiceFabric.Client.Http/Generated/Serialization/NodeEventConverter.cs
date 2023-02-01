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
    /// Converter for <see cref="NodeEvent" />.
    /// </summary>
    internal class NodeEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeEvent GetFromJsonProperties(JsonReader reader)
        {
            NodeEvent obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.OrdinalIgnoreCase))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("NodeAborted", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeAbortedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeAddedToCluster", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeAddedToClusterEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeClosed", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeClosedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDeactivateCompleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeDeactivateCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDeactivateStarted", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeDeactivateStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDown", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeDownEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeOpenSucceeded", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeOpenSucceededEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeOpenFailed", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeOpenFailedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeRemovedFromCluster", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeRemovedFromClusterEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeUp", StringComparison.OrdinalIgnoreCase))
            {
                obj = NodeUpEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosNodeRestartScheduled", StringComparison.OrdinalIgnoreCase))
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
        internal static void Serialize(JsonWriter writer, NodeEvent obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(NodeEventKind.NodeAborted))
            {
                NodeAbortedEventConverter.Serialize(writer, (NodeAbortedEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeAddedToCluster))
            {
                NodeAddedToClusterEventConverter.Serialize(writer, (NodeAddedToClusterEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeClosed))
            {
                NodeClosedEventConverter.Serialize(writer, (NodeClosedEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeDeactivateCompleted))
            {
                NodeDeactivateCompletedEventConverter.Serialize(writer, (NodeDeactivateCompletedEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeDeactivateStarted))
            {
                NodeDeactivateStartedEventConverter.Serialize(writer, (NodeDeactivateStartedEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeDown))
            {
                NodeDownEventConverter.Serialize(writer, (NodeDownEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeNewHealthReport))
            {
                NodeNewHealthReportEventConverter.Serialize(writer, (NodeNewHealthReportEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeHealthReportExpired))
            {
                NodeHealthReportExpiredEventConverter.Serialize(writer, (NodeHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeOpenSucceeded))
            {
                NodeOpenSucceededEventConverter.Serialize(writer, (NodeOpenSucceededEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeOpenFailed))
            {
                NodeOpenFailedEventConverter.Serialize(writer, (NodeOpenFailedEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeRemovedFromCluster))
            {
                NodeRemovedFromClusterEventConverter.Serialize(writer, (NodeRemovedFromClusterEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.NodeUp))
            {
                NodeUpEventConverter.Serialize(writer, (NodeUpEvent)obj);
            }
            else if (kind.Equals(NodeEventKind.ChaosNodeRestartScheduled))
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
