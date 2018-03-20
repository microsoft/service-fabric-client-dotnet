// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
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
    /// Converter for <see cref="BackupScheduleIntervalType" />.
    /// </summary>
    internal class BackupScheduleIntervalTypeConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static BackupScheduleIntervalType? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(BackupScheduleIntervalType);

            if (string.Compare(value, "Invalid", StringComparison.Ordinal) == 0)
            {
                obj = BackupScheduleIntervalType.Invalid;
            }
            else if (string.Compare(value, "Hours", StringComparison.Ordinal) == 0)
            {
                obj = BackupScheduleIntervalType.Hours;
            }
            else if (string.Compare(value, "Minutes", StringComparison.Ordinal) == 0)
            {
                obj = BackupScheduleIntervalType.Minutes;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, BackupScheduleIntervalType? value)
        {
            switch (value)
            {
                case BackupScheduleIntervalType.Invalid:
                    writer.WriteStringValue("Invalid");
                    break;
                case BackupScheduleIntervalType.Hours:
                    writer.WriteStringValue("Hours");
                    break;
                case BackupScheduleIntervalType.Minutes:
                    writer.WriteStringValue("Minutes");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type BackupScheduleIntervalType");
            }
        }
    }
}
