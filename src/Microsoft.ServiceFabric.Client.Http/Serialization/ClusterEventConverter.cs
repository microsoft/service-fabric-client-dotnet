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
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (propName.Equals("Kind", StringComparison.Ordinal))
                {
                    var propValue = reader.ReadValueAsString();

                    if (propValue.Equals("ClusterHealthReportCreated", StringComparison.Ordinal))
                    {
                        return ClusterHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterHealthReportExpired", StringComparison.Ordinal))
                    {
                        return ClusterHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeComplete", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeCompleteEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeDomainComplete", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeDomainCompleteEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeRollbackComplete", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeRollbackCompleteEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeRollbackStart", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeRollbackStartEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ClusterUpgradeStart", StringComparison.Ordinal))
                    {
                        return ClusterUpgradeStartEventConverter.GetFromJsonProperties(reader);
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
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
