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
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var nodeName = default(NodeName);

            do
            {
                var propName = reader.ReadPropertyName();
                if (propName.Equals("Kind", StringComparison.Ordinal))
                {
                    var propValue = reader.ReadValueAsString();

                    if (propValue.Equals("NodeAborted", StringComparison.Ordinal))
                    {
                        return NodeAbortedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeAborting", StringComparison.Ordinal))
                    {
                        return NodeAbortingEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeAdded", StringComparison.Ordinal))
                    {
                        return NodeAddedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeClose", StringComparison.Ordinal))
                    {
                        return NodeCloseEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeClosing", StringComparison.Ordinal))
                    {
                        return NodeClosingEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeDeactivateComplete", StringComparison.Ordinal))
                    {
                        return NodeDeactivateCompleteEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeDeactivateStart", StringComparison.Ordinal))
                    {
                        return NodeDeactivateStartEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeDown", StringComparison.Ordinal))
                    {
                        return NodeDownEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeHealthReportCreated", StringComparison.Ordinal))
                    {
                        return NodeHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeHealthReportExpired", StringComparison.Ordinal))
                    {
                        return NodeHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeOpenedSuccess", StringComparison.Ordinal))
                    {
                        return NodeOpenedSuccessEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeOpenFailed", StringComparison.Ordinal))
                    {
                        return NodeOpenFailedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeOpening", StringComparison.Ordinal))
                    {
                        return NodeOpeningEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeRemoved", StringComparison.Ordinal))
                    {
                        return NodeRemovedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeUp", StringComparison.Ordinal))
                    {
                        return NodeUpEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosRestartNodeFaultCompleted", StringComparison.Ordinal))
                    {
                        return ChaosRestartNodeFaultCompletedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosRestartNodeFaultScheduled", StringComparison.Ordinal))
                    {
                        return ChaosRestartNodeFaultScheduledEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("NodeEvent", StringComparison.Ordinal))
                    {
                        // kind specified as same type, deserialize using properties.
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown Discriminator.");
                    }
                }
                else
                {
                    if (string.Compare("EventInstanceId", propName, StringComparison.Ordinal) == 0)
                    {
                        eventInstanceId = reader.ReadValueAsGuid();
                    }
                    else if (string.Compare("TimeStamp", propName, StringComparison.Ordinal) == 0)
                    {
                        timeStamp = reader.ReadValueAsDateTime();
                    }
                    else if (string.Compare("HasCorrelatedEvents", propName, StringComparison.Ordinal) == 0)
                    {
                        hasCorrelatedEvents = reader.ReadValueAsBool();
                    }
                    else if (string.Compare("NodeName", propName, StringComparison.Ordinal) == 0)
                    {
                        nodeName = NodeNameConverter.Deserialize(reader);
                    }
                    else
                    {
                        reader.SkipPropertyValue();
                    }
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NodeEvent(
                kind: Common.FabricEventKind.NodeEvent,
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                nodeName: nodeName);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NodeEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
