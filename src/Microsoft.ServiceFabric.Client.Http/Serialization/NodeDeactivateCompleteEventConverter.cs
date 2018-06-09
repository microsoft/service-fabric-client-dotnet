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
    /// Converter for <see cref="NodeDeactivateCompleteEvent" />.
    /// </summary>
    internal class NodeDeactivateCompleteEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeDeactivateCompleteEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static NodeDeactivateCompleteEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var nodeName = default(NodeName);
            var nodeInstance = default(long?);
            var effectiveDeactivateIntent = default(string);
            var batchIdsWithDeactivateIntent = default(string);
            var startTime = default(DateTime?);

            do
            {
                var propName = reader.ReadPropertyName();
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
                else if (string.Compare("NodeInstance", propName, StringComparison.Ordinal) == 0)
                {
                    nodeInstance = reader.ReadValueAsLong();
                }
                else if (string.Compare("EffectiveDeactivateIntent", propName, StringComparison.Ordinal) == 0)
                {
                    effectiveDeactivateIntent = reader.ReadValueAsString();
                }
                else if (string.Compare("BatchIdsWithDeactivateIntent", propName, StringComparison.Ordinal) == 0)
                {
                    batchIdsWithDeactivateIntent = reader.ReadValueAsString();
                }
                else if (string.Compare("StartTime", propName, StringComparison.Ordinal) == 0)
                {
                    startTime = reader.ReadValueAsDateTime();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NodeDeactivateCompleteEvent(
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                nodeName: nodeName,
                nodeInstance: nodeInstance,
                effectiveDeactivateIntent: effectiveDeactivateIntent,
                batchIdsWithDeactivateIntent: batchIdsWithDeactivateIntent,
                startTime: startTime);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NodeDeactivateCompleteEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            writer.WriteProperty(obj.NodeInstance, "NodeInstance", JsonWriterExtensions.WriteLongValue);
            writer.WriteProperty(obj.EffectiveDeactivateIntent, "EffectiveDeactivateIntent", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.BatchIdsWithDeactivateIntent, "BatchIdsWithDeactivateIntent", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.StartTime, "StartTime", JsonWriterExtensions.WriteDateTimeValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
