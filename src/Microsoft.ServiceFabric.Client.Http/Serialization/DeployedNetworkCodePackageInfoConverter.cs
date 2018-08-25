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
    /// Converter for <see cref="DeployedNetworkCodePackageInfo" />.
    /// </summary>
    internal class DeployedNetworkCodePackageInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static DeployedNetworkCodePackageInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static DeployedNetworkCodePackageInfo GetFromJsonProperties(JsonReader reader)
        {
            var applicationName = default(ApplicationName);
            var networkName = default(string);
            var codePackageName = default(string);
            var codePackageVersion = default(string);
            var serviceManifestName = default(string);
            var servicePackageActivationId = default(string);
            var containerAddress = default(string);
            var containerId = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("ApplicationName", propName, StringComparison.Ordinal) == 0)
                {
                    applicationName = ApplicationNameConverter.Deserialize(reader);
                }
                else if (string.Compare("NetworkName", propName, StringComparison.Ordinal) == 0)
                {
                    networkName = reader.ReadValueAsString();
                }
                else if (string.Compare("CodePackageName", propName, StringComparison.Ordinal) == 0)
                {
                    codePackageName = reader.ReadValueAsString();
                }
                else if (string.Compare("CodePackageVersion", propName, StringComparison.Ordinal) == 0)
                {
                    codePackageVersion = reader.ReadValueAsString();
                }
                else if (string.Compare("ServiceManifestName", propName, StringComparison.Ordinal) == 0)
                {
                    serviceManifestName = reader.ReadValueAsString();
                }
                else if (string.Compare("ServicePackageActivationId", propName, StringComparison.Ordinal) == 0)
                {
                    servicePackageActivationId = reader.ReadValueAsString();
                }
                else if (string.Compare("ContainerAddress", propName, StringComparison.Ordinal) == 0)
                {
                    containerAddress = reader.ReadValueAsString();
                }
                else if (string.Compare("ContainerId", propName, StringComparison.Ordinal) == 0)
                {
                    containerId = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new DeployedNetworkCodePackageInfo(
                applicationName: applicationName,
                networkName: networkName,
                codePackageName: codePackageName,
                codePackageVersion: codePackageVersion,
                serviceManifestName: serviceManifestName,
                servicePackageActivationId: servicePackageActivationId,
                containerAddress: containerAddress,
                containerId: containerId);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, DeployedNetworkCodePackageInfo obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.ApplicationName != null)
            {
                writer.WriteProperty(obj.ApplicationName, "ApplicationName", ApplicationNameConverter.Serialize);
            }

            if (obj.NetworkName != null)
            {
                writer.WriteProperty(obj.NetworkName, "NetworkName", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.CodePackageName != null)
            {
                writer.WriteProperty(obj.CodePackageName, "CodePackageName", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.CodePackageVersion != null)
            {
                writer.WriteProperty(obj.CodePackageVersion, "CodePackageVersion", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ServiceManifestName != null)
            {
                writer.WriteProperty(obj.ServiceManifestName, "ServiceManifestName", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ServicePackageActivationId != null)
            {
                writer.WriteProperty(obj.ServicePackageActivationId, "ServicePackageActivationId", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ContainerAddress != null)
            {
                writer.WriteProperty(obj.ContainerAddress, "ContainerAddress", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ContainerId != null)
            {
                writer.WriteProperty(obj.ContainerId, "ContainerId", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
