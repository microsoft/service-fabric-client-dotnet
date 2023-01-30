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
    /// Converter for <see cref="PartitionEventKind" />.
    /// </summary>
    internal class PartitionEventKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static PartitionEventKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(PartitionEventKind);

            if (string.Compare(value, "PartitionEvent", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.PartitionEvent;
            }
            else if (string.Compare(value, "PartitionAnalysisEvent", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.PartitionAnalysisEvent;
            }
            else if (string.Compare(value, "PartitionNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.PartitionNewHealthReport;
            }
            else if (string.Compare(value, "PartitionHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.PartitionHealthReportExpired;
            }
            else if (string.Compare(value, "PartitionReconfigured", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.PartitionReconfigured;
            }
            else if (string.Compare(value, "PartitionPrimaryMoveAnalysis", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.PartitionPrimaryMoveAnalysis;
            }
            else if (string.Compare(value, "ChaosPartitionSecondaryMoveScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.ChaosPartitionSecondaryMoveScheduled;
            }
            else if (string.Compare(value, "ChaosPartitionPrimaryMoveScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = PartitionEventKind.ChaosPartitionPrimaryMoveScheduled;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, PartitionEventKind? value)
        {
            switch (value)
            {
                case PartitionEventKind.PartitionEvent:
                    writer.WriteStringValue("PartitionEvent");
                    break;
                case PartitionEventKind.PartitionAnalysisEvent:
                    writer.WriteStringValue("PartitionAnalysisEvent");
                    break;
                case PartitionEventKind.PartitionNewHealthReport:
                    writer.WriteStringValue("PartitionNewHealthReport");
                    break;
                case PartitionEventKind.PartitionHealthReportExpired:
                    writer.WriteStringValue("PartitionHealthReportExpired");
                    break;
                case PartitionEventKind.PartitionReconfigured:
                    writer.WriteStringValue("PartitionReconfigured");
                    break;
                case PartitionEventKind.PartitionPrimaryMoveAnalysis:
                    writer.WriteStringValue("PartitionPrimaryMoveAnalysis");
                    break;
                case PartitionEventKind.ChaosPartitionSecondaryMoveScheduled:
                    writer.WriteStringValue("ChaosPartitionSecondaryMoveScheduled");
                    break;
                case PartitionEventKind.ChaosPartitionPrimaryMoveScheduled:
                    writer.WriteStringValue("ChaosPartitionPrimaryMoveScheduled");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type PartitionEventKind");
            }
        }
    }
}
