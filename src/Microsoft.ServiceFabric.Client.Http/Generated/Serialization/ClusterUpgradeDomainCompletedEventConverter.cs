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
    /// Converter for <see cref="ClusterUpgradeDomainCompletedEvent" />.
    /// </summary>
    internal class ClusterUpgradeDomainCompletedEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterUpgradeDomainCompletedEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterUpgradeDomainCompletedEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var category = default(string);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var targetClusterVersion = default(string);
            var upgradeState = default(string);
            var upgradeDomains = default(string);
            var upgradeDomainElapsedTimeInMs = default(double?);

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
                else if (string.Compare("TargetClusterVersion", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    targetClusterVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeState", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeState = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeDomains", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeDomains = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeDomainElapsedTimeInMs", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    upgradeDomainElapsedTimeInMs = reader.ReadValueAsDouble();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ClusterUpgradeDomainCompletedEvent(
                eventInstanceId: eventInstanceId,
                category: category,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                targetClusterVersion: targetClusterVersion,
                upgradeState: upgradeState,
                upgradeDomains: upgradeDomains,
                upgradeDomainElapsedTimeInMs: upgradeDomainElapsedTimeInMs);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ClusterUpgradeDomainCompletedEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind, "Kind", ClusterEventKindConverter.Serialize);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.TargetClusterVersion, "TargetClusterVersion", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.UpgradeState, "UpgradeState", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.UpgradeDomains, "UpgradeDomains", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.UpgradeDomainElapsedTimeInMs, "UpgradeDomainElapsedTimeInMs", JsonWriterExtensions.WriteDoubleValue);
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
