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
    /// Converter for <see cref="ClusterEvent" />.
    /// </summary>
    internal class ClusterEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var category = default(string);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (propName.Equals("Kind", StringComparison.Ordinal))
                {
                    var propValue = reader.ReadValueAsString();

                    if (propValue.Equals("ClusterNewHealthReport", StringComparison.Ordinal))
                    {
                        return ClusterNewHealthReportEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterHealthReportExpired", StringComparison.Ordinal))
                    {
                        return ClusterHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeCompleted", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeCompletedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeDomainCompleted", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeDomainCompletedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeRollbackCompleted", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeRollbackCompletedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeRollbackStarted", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeRollbackStartedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeStarted", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeStartedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosStopped", StringComparison.Ordinal))
                    {
                        return ChaosStoppedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosStarted", StringComparison.Ordinal))
                    {
                        return ChaosStartedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterEvent", StringComparison.Ordinal))
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
                    else if (string.Compare("Category", propName, StringComparison.Ordinal) == 0)
                    {
                        category = reader.ReadValueAsString();
                    }
                    else if (string.Compare("TimeStamp", propName, StringComparison.Ordinal) == 0)
                    {
                        timeStamp = reader.ReadValueAsDateTime();
                    }
                    else if (string.Compare("HasCorrelatedEvents", propName, StringComparison.Ordinal) == 0)
                    {
                        hasCorrelatedEvents = reader.ReadValueAsBool();
                    }
                    else
                    {
                        reader.SkipPropertyValue();
                    }
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ClusterEvent(
                kind: Common.FabricEventKind.ClusterEvent,
                eventInstanceId: eventInstanceId,
                category: category,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ClusterEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind, "Kind", FabricEventKindConverter.Serialize);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            if (obj.Category != null)
            {
                writer.WriteProperty(obj.Category, "Category", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
