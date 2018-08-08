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
    /// Converter for <see cref="BackupEpoch" />.
    /// </summary>
    internal class BackupEpochConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static BackupEpoch Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static BackupEpoch GetFromJsonProperties(JsonReader reader)
        {
            var configurationNumber = default(string);
            var dataLossNumber = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("ConfigurationNumber", propName, StringComparison.Ordinal) == 0)
                {
                    configurationNumber = reader.ReadValueAsString();
                }
                else if (string.Compare("DataLossNumber", propName, StringComparison.Ordinal) == 0)
                {
                    dataLossNumber = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new BackupEpoch(
                configurationNumber: configurationNumber,
                dataLossNumber: dataLossNumber);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, BackupEpoch obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.ConfigurationNumber != null)
            {
                writer.WriteProperty(obj.ConfigurationNumber, "ConfigurationNumber", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.DataLossNumber != null)
            {
                writer.WriteProperty(obj.DataLossNumber, "DataLossNumber", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
