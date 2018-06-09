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
    /// Converter for <see cref="BackupPolicyDescription" />.
    /// </summary>
    internal class BackupPolicyDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static BackupPolicyDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static BackupPolicyDescription GetFromJsonProperties(JsonReader reader)
        {
            var name = default(string);
            var autoRestoreOnDataLoss = default(bool?);
            var maxIncrementalBackups = default(int?);
            var schedule = default(BackupScheduleDescription);
            var storage = default(BackupStorageDescription);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("Name", propName, StringComparison.Ordinal) == 0)
                {
                    name = reader.ReadValueAsString();
                }
                else if (string.Compare("AutoRestoreOnDataLoss", propName, StringComparison.Ordinal) == 0)
                {
                    autoRestoreOnDataLoss = reader.ReadValueAsBool();
                }
                else if (string.Compare("MaxIncrementalBackups", propName, StringComparison.Ordinal) == 0)
                {
                    maxIncrementalBackups = reader.ReadValueAsInt();
                }
                else if (string.Compare("Schedule", propName, StringComparison.Ordinal) == 0)
                {
                    schedule = BackupScheduleDescriptionConverter.Deserialize(reader);
                }
                else if (string.Compare("Storage", propName, StringComparison.Ordinal) == 0)
                {
                    storage = BackupStorageDescriptionConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new BackupPolicyDescription(
                name: name,
                autoRestoreOnDataLoss: autoRestoreOnDataLoss,
                maxIncrementalBackups: maxIncrementalBackups,
                schedule: schedule,
                storage: storage);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, BackupPolicyDescription obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Name, "Name", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.AutoRestoreOnDataLoss, "AutoRestoreOnDataLoss", JsonWriterExtensions.WriteBoolValue);
            writer.WriteProperty(obj.MaxIncrementalBackups, "MaxIncrementalBackups", JsonWriterExtensions.WriteIntValue);
            writer.WriteProperty(obj.Schedule, "Schedule", BackupScheduleDescriptionConverter.Serialize);
            writer.WriteProperty(obj.Storage, "Storage", BackupStorageDescriptionConverter.Serialize);
            writer.WriteEndObject();
        }
    }
}
