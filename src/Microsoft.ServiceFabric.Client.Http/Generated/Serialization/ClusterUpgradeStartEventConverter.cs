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
    /// Converter for <see cref="ClusterUpgradeStartEvent" />.
    /// </summary>
    internal class ClusterUpgradeStartEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterUpgradeStartEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterUpgradeStartEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var currentClusterVersion = default(string);
            var targetClusterVersion = default(string);
            var upgradeType = default(string);
            var rollingUpgradeMode = default(string);
            var failureAction = default(string);

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
                else if (string.Compare("CurrentClusterVersion", propName, StringComparison.Ordinal) == 0)
                {
                    currentClusterVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("TargetClusterVersion", propName, StringComparison.Ordinal) == 0)
                {
                    targetClusterVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeType", propName, StringComparison.Ordinal) == 0)
                {
                    upgradeType = reader.ReadValueAsString();
                }
                else if (string.Compare("RollingUpgradeMode", propName, StringComparison.Ordinal) == 0)
                {
                    rollingUpgradeMode = reader.ReadValueAsString();
                }
                else if (string.Compare("FailureAction", propName, StringComparison.Ordinal) == 0)
                {
                    failureAction = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ClusterUpgradeStartEvent(
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                currentClusterVersion: currentClusterVersion,
                targetClusterVersion: targetClusterVersion,
                upgradeType: upgradeType,
                rollingUpgradeMode: rollingUpgradeMode,
                failureAction: failureAction);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ClusterUpgradeStartEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.CurrentClusterVersion, "CurrentClusterVersion", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.TargetClusterVersion, "TargetClusterVersion", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.UpgradeType, "UpgradeType", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.RollingUpgradeMode, "RollingUpgradeMode", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.FailureAction, "FailureAction", JsonWriterExtensions.WriteStringValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
