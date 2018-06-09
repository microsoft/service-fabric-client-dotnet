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
    /// Converter for <see cref="ClusterHealthPolicy" />.
    /// </summary>
    internal class ClusterHealthPolicyConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterHealthPolicy Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterHealthPolicy GetFromJsonProperties(JsonReader reader)
        {
            var considerWarningAsError = default(bool?);
            var maxPercentUnhealthyNodes = default(int?);
            var maxPercentUnhealthyApplications = default(int?);
            var applicationTypeHealthPolicyMap = default(IEnumerable<ApplicationTypeHealthPolicyMapItem>);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("ConsiderWarningAsError", propName, StringComparison.Ordinal) == 0)
                {
                    considerWarningAsError = reader.ReadValueAsBool();
                }
                else if (string.Compare("MaxPercentUnhealthyNodes", propName, StringComparison.Ordinal) == 0)
                {
                    maxPercentUnhealthyNodes = reader.ReadValueAsInt();
                }
                else if (string.Compare("MaxPercentUnhealthyApplications", propName, StringComparison.Ordinal) == 0)
                {
                    maxPercentUnhealthyApplications = reader.ReadValueAsInt();
                }
                else if (string.Compare("ApplicationTypeHealthPolicyMap", propName, StringComparison.Ordinal) == 0)
                {
                    applicationTypeHealthPolicyMap = reader.ReadList(ApplicationTypeHealthPolicyMapItemConverter.Deserialize);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ClusterHealthPolicy(
                considerWarningAsError: considerWarningAsError,
                maxPercentUnhealthyNodes: maxPercentUnhealthyNodes,
                maxPercentUnhealthyApplications: maxPercentUnhealthyApplications,
                applicationTypeHealthPolicyMap: applicationTypeHealthPolicyMap);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ClusterHealthPolicy obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.ConsiderWarningAsError != null)
            {
                writer.WriteProperty(obj.ConsiderWarningAsError, "ConsiderWarningAsError", JsonWriterExtensions.WriteBoolValue);
            }

            if (obj.MaxPercentUnhealthyNodes != null)
            {
                writer.WriteProperty(obj.MaxPercentUnhealthyNodes, "MaxPercentUnhealthyNodes", JsonWriterExtensions.WriteIntValue);
            }

            if (obj.MaxPercentUnhealthyApplications != null)
            {
                writer.WriteProperty(obj.MaxPercentUnhealthyApplications, "MaxPercentUnhealthyApplications", JsonWriterExtensions.WriteIntValue);
            }

            if (obj.ApplicationTypeHealthPolicyMap != null)
            {
                writer.WriteEnumerableProperty(obj.ApplicationTypeHealthPolicyMap, "ApplicationTypeHealthPolicyMap", ApplicationTypeHealthPolicyMapItemConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
