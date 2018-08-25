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
    /// Converter for <see cref="LocalNetworkProperties" />.
    /// </summary>
    internal class LocalNetworkPropertiesConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static LocalNetworkProperties Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static LocalNetworkProperties GetFromJsonProperties(JsonReader reader)
        {
            var status = default(NetworkStatus?);
            var statusDetails = default(string);
            var addressPrefix = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("status", propName, StringComparison.Ordinal) == 0)
                {
                    status = NetworkStatusConverter.Deserialize(reader);
                }
                else if (string.Compare("statusDetails", propName, StringComparison.Ordinal) == 0)
                {
                    statusDetails = reader.ReadValueAsString();
                }
                else if (string.Compare("addressPrefix", propName, StringComparison.Ordinal) == 0)
                {
                    addressPrefix = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new LocalNetworkProperties(
                status: status,
                statusDetails: statusDetails,
                addressPrefix: addressPrefix);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, LocalNetworkProperties obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Status, "status", NetworkStatusConverter.Serialize);
            if (obj.StatusDetails != null)
            {
                writer.WriteProperty(obj.StatusDetails, "statusDetails", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.AddressPrefix != null)
            {
                writer.WriteProperty(obj.AddressPrefix, "addressPrefix", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
