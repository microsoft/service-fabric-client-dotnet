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
    /// Converter for <see cref="PartitionEvent" />.
    /// </summary>
    internal class PartitionEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static PartitionEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static PartitionEvent GetFromJsonProperties(JsonReader reader)
        {
            PartitionEvent obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.OrdinalIgnoreCase))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("PartitionAnalysisEvent", StringComparison.OrdinalIgnoreCase))
            {
                obj = PartitionAnalysisEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = PartitionNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = PartitionHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionReconfigured", StringComparison.OrdinalIgnoreCase))
            {
                obj = PartitionReconfiguredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionPrimaryMoveAnalysis", StringComparison.OrdinalIgnoreCase))
            {
                obj = PartitionPrimaryMoveAnalysisEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosPartitionSecondaryMoveScheduled", StringComparison.OrdinalIgnoreCase))
            {
                obj = ChaosPartitionSecondaryMoveScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosPartitionPrimaryMoveScheduled", StringComparison.OrdinalIgnoreCase))
            {
                obj = ChaosPartitionPrimaryMoveScheduledEventConverter.GetFromJsonProperties(reader);
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
        internal static void Serialize(JsonWriter writer, PartitionEvent obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(PartitionEventKind.PartitionAnalysisEvent))
            {
                PartitionAnalysisEventConverter.Serialize(writer, (PartitionAnalysisEvent)obj);
            }
            else if (kind.Equals(PartitionEventKind.PartitionNewHealthReport))
            {
                PartitionNewHealthReportEventConverter.Serialize(writer, (PartitionNewHealthReportEvent)obj);
            }
            else if (kind.Equals(PartitionEventKind.PartitionHealthReportExpired))
            {
                PartitionHealthReportExpiredEventConverter.Serialize(writer, (PartitionHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(PartitionEventKind.PartitionReconfigured))
            {
                PartitionReconfiguredEventConverter.Serialize(writer, (PartitionReconfiguredEvent)obj);
            }
            else if (kind.Equals(PartitionEventKind.PartitionPrimaryMoveAnalysis))
            {
                PartitionPrimaryMoveAnalysisEventConverter.Serialize(writer, (PartitionPrimaryMoveAnalysisEvent)obj);
            }
            else if (kind.Equals(PartitionEventKind.ChaosPartitionSecondaryMoveScheduled))
            {
                ChaosPartitionSecondaryMoveScheduledEventConverter.Serialize(writer, (ChaosPartitionSecondaryMoveScheduledEvent)obj);
            }
            else if (kind.Equals(PartitionEventKind.ChaosPartitionPrimaryMoveScheduled))
            {
                ChaosPartitionPrimaryMoveScheduledEventConverter.Serialize(writer, (ChaosPartitionPrimaryMoveScheduledEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
