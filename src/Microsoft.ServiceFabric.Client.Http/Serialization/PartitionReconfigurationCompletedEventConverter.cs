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
    /// Converter for <see cref="PartitionReconfigurationCompletedEvent" />.
    /// </summary>
    internal class PartitionReconfigurationCompletedEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static PartitionReconfigurationCompletedEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static PartitionReconfigurationCompletedEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var partitionId = default(PartitionId);
            var nodeName = default(NodeName);
            var nodeInstanceId = default(string);
            var serviceType = default(string);
            var ccEpochDataLossVersion = default(long?);
            var ccEpochConfigVersion = default(long?);
            var reconfigType = default(string);
            var result = default(string);
            var phase0DurationMs = default(double?);
            var phase1DurationMs = default(double?);
            var phase2DurationMs = default(double?);
            var phase3DurationMs = default(double?);
            var phase4DurationMs = default(double?);
            var totalDurationMs = default(double?);

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
                else if (string.Compare("PartitionId", propName, StringComparison.Ordinal) == 0)
                {
                    partitionId = PartitionIdConverter.Deserialize(reader);
                }
                else if (string.Compare("NodeName", propName, StringComparison.Ordinal) == 0)
                {
                    nodeName = NodeNameConverter.Deserialize(reader);
                }
                else if (string.Compare("NodeInstanceId", propName, StringComparison.Ordinal) == 0)
                {
                    nodeInstanceId = reader.ReadValueAsString();
                }
                else if (string.Compare("ServiceType", propName, StringComparison.Ordinal) == 0)
                {
                    serviceType = reader.ReadValueAsString();
                }
                else if (string.Compare("CcEpochDataLossVersion", propName, StringComparison.Ordinal) == 0)
                {
                    ccEpochDataLossVersion = reader.ReadValueAsLong();
                }
                else if (string.Compare("CcEpochConfigVersion", propName, StringComparison.Ordinal) == 0)
                {
                    ccEpochConfigVersion = reader.ReadValueAsLong();
                }
                else if (string.Compare("ReconfigType", propName, StringComparison.Ordinal) == 0)
                {
                    reconfigType = reader.ReadValueAsString();
                }
                else if (string.Compare("Result", propName, StringComparison.Ordinal) == 0)
                {
                    result = reader.ReadValueAsString();
                }
                else if (string.Compare("Phase0DurationMs", propName, StringComparison.Ordinal) == 0)
                {
                    phase0DurationMs = reader.ReadValueAsDouble();
                }
                else if (string.Compare("Phase1DurationMs", propName, StringComparison.Ordinal) == 0)
                {
                    phase1DurationMs = reader.ReadValueAsDouble();
                }
                else if (string.Compare("Phase2DurationMs", propName, StringComparison.Ordinal) == 0)
                {
                    phase2DurationMs = reader.ReadValueAsDouble();
                }
                else if (string.Compare("Phase3DurationMs", propName, StringComparison.Ordinal) == 0)
                {
                    phase3DurationMs = reader.ReadValueAsDouble();
                }
                else if (string.Compare("Phase4DurationMs", propName, StringComparison.Ordinal) == 0)
                {
                    phase4DurationMs = reader.ReadValueAsDouble();
                }
                else if (string.Compare("TotalDurationMs", propName, StringComparison.Ordinal) == 0)
                {
                    totalDurationMs = reader.ReadValueAsDouble();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new PartitionReconfigurationCompletedEvent(
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                partitionId: partitionId,
                nodeName: nodeName,
                nodeInstanceId: nodeInstanceId,
                serviceType: serviceType,
                ccEpochDataLossVersion: ccEpochDataLossVersion,
                ccEpochConfigVersion: ccEpochConfigVersion,
                reconfigType: reconfigType,
                result: result,
                phase0DurationMs: phase0DurationMs,
                phase1DurationMs: phase1DurationMs,
                phase2DurationMs: phase2DurationMs,
                phase3DurationMs: phase3DurationMs,
                phase4DurationMs: phase4DurationMs,
                totalDurationMs: totalDurationMs);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, PartitionReconfigurationCompletedEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.PartitionId, "PartitionId", PartitionIdConverter.Serialize);
            writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            writer.WriteProperty(obj.NodeInstanceId, "NodeInstanceId", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.ServiceType, "ServiceType", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.CcEpochDataLossVersion, "CcEpochDataLossVersion", JsonWriterExtensions.WriteLongValue);
            writer.WriteProperty(obj.CcEpochConfigVersion, "CcEpochConfigVersion", JsonWriterExtensions.WriteLongValue);
            writer.WriteProperty(obj.ReconfigType, "ReconfigType", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Result, "Result", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Phase0DurationMs, "Phase0DurationMs", JsonWriterExtensions.WriteDoubleValue);
            writer.WriteProperty(obj.Phase1DurationMs, "Phase1DurationMs", JsonWriterExtensions.WriteDoubleValue);
            writer.WriteProperty(obj.Phase2DurationMs, "Phase2DurationMs", JsonWriterExtensions.WriteDoubleValue);
            writer.WriteProperty(obj.Phase3DurationMs, "Phase3DurationMs", JsonWriterExtensions.WriteDoubleValue);
            writer.WriteProperty(obj.Phase4DurationMs, "Phase4DurationMs", JsonWriterExtensions.WriteDoubleValue);
            writer.WriteProperty(obj.TotalDurationMs, "TotalDurationMs", JsonWriterExtensions.WriteDoubleValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
