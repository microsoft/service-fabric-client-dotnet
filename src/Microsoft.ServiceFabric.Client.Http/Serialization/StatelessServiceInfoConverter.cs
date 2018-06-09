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
    /// Converter for <see cref="StatelessServiceInfo" />.
    /// </summary>
    internal class StatelessServiceInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static StatelessServiceInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static StatelessServiceInfo GetFromJsonProperties(JsonReader reader)
        {
            var id = default(string);
            var name = default(ServiceName);
            var typeName = default(string);
            var manifestVersion = default(string);
            var healthState = default(HealthState?);
            var serviceStatus = default(ServiceStatus?);
            var isServiceGroup = default(bool?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("Id", propName, StringComparison.Ordinal) == 0)
                {
                    id = reader.ReadValueAsString();
                }
                else if (string.Compare("Name", propName, StringComparison.Ordinal) == 0)
                {
                    name = ServiceNameConverter.Deserialize(reader);
                }
                else if (string.Compare("TypeName", propName, StringComparison.Ordinal) == 0)
                {
                    typeName = reader.ReadValueAsString();
                }
                else if (string.Compare("ManifestVersion", propName, StringComparison.Ordinal) == 0)
                {
                    manifestVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("HealthState", propName, StringComparison.Ordinal) == 0)
                {
                    healthState = HealthStateConverter.Deserialize(reader);
                }
                else if (string.Compare("ServiceStatus", propName, StringComparison.Ordinal) == 0)
                {
                    serviceStatus = ServiceStatusConverter.Deserialize(reader);
                }
                else if (string.Compare("IsServiceGroup", propName, StringComparison.Ordinal) == 0)
                {
                    isServiceGroup = reader.ReadValueAsBool();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new StatelessServiceInfo(
                id: id,
                name: name,
                typeName: typeName,
                manifestVersion: manifestVersion,
                healthState: healthState,
                serviceStatus: serviceStatus,
                isServiceGroup: isServiceGroup);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, StatelessServiceInfo obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.ServiceKind.ToString(), "ServiceKind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.HealthState, "HealthState", HealthStateConverter.Serialize);
            writer.WriteProperty(obj.ServiceStatus, "ServiceStatus", ServiceStatusConverter.Serialize);
            if (obj.Id != null)
            {
                writer.WriteProperty(obj.Id, "Id", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.Name != null)
            {
                writer.WriteProperty(obj.Name, "Name", ServiceNameConverter.Serialize);
            }

            if (obj.TypeName != null)
            {
                writer.WriteProperty(obj.TypeName, "TypeName", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ManifestVersion != null)
            {
                writer.WriteProperty(obj.ManifestVersion, "ManifestVersion", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.IsServiceGroup != null)
            {
                writer.WriteProperty(obj.IsServiceGroup, "IsServiceGroup", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
