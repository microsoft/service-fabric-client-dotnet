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
    /// Converter for <see cref="NodeDeactivateCompletedEvent" />.
    /// </summary>
    internal class NodeDeactivateCompletedEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeDeactivateCompletedEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static NodeDeactivateCompletedEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var category = default(string);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var nodeInstance = default(long?);
            var nodeName = default(NodeName);
            var effectiveDeactivateIntent = default(string);
            var batchIdsWithDeactivateIntent = default(string);
            var startTime = default(DateTime?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("EventInstanceId", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    eventInstanceId = reader.ReadValueAsGuid();
                }
                else if (string.Compare("Category", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    category = reader.ReadValueAsString();
                }
                else if (string.Compare("TimeStamp", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    timeStamp = reader.ReadValueAsDateTime();
                }
                else if (string.Compare("HasCorrelatedEvents", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    hasCorrelatedEvents = reader.ReadValueAsBool();
                }
                else if (string.Compare("NodeInstance", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    nodeInstance = reader.ReadValueAsLong();
                }
                else if (string.Compare("NodeName", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    nodeName = NodeNameConverter.Deserialize(reader);
                }
                else if (string.Compare("EffectiveDeactivateIntent", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    effectiveDeactivateIntent = reader.ReadValueAsString();
                }
                else if (string.Compare("BatchIdsWithDeactivateIntent", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    batchIdsWithDeactivateIntent = reader.ReadValueAsString();
                }
                else if (string.Compare("StartTime", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    startTime = reader.ReadValueAsDateTime();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NodeDeactivateCompletedEvent(
                eventInstanceId: eventInstanceId,
                category: category,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                nodeInstance: nodeInstance,
                nodeName: nodeName,
                effectiveDeactivateIntent: effectiveDeactivateIntent,
                batchIdsWithDeactivateIntent: batchIdsWithDeactivateIntent,
                startTime: startTime);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NodeDeactivateCompletedEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind, "Kind", NodeEventKindConverter.Serialize);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            writer.WriteProperty(obj.EffectiveDeactivateIntent, "EffectiveDeactivateIntent", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.BatchIdsWithDeactivateIntent, "BatchIdsWithDeactivateIntent", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.StartTime, "StartTime", JsonWriterExtensions.WriteDateTimeValue);
            if (obj.Category != null)
            {
                writer.WriteProperty(obj.Category, "Category", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            if (obj.NodeInstance != null)
            {
                writer.WriteProperty(obj.NodeInstance, "NodeInstance", JsonWriterExtensions.WriteLongValue);
            }

            writer.WriteEndObject();
        }
    }
}
