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
    /// Converter for <see cref="ServiceProperties" />.
    /// </summary>
    internal class ServicePropertiesConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceProperties Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceProperties GetFromJsonProperties(JsonReader reader)
        {
            var description = default(string);
            var replicaCount = default(int?);
            var executionPolicy = default(ExecutionPolicy);
            var autoScalingPolicies = default(IEnumerable<AutoScalingPolicy>);
            var status = default(ResourceStatus?);
            var statusDetails = default(string);
            var healthState = default(HealthState?);
            var unhealthyEvaluation = default(string);
            var identityRefs = default(IEnumerable<ServiceIdentity>);
            var dnsName = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("description", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    description = reader.ReadValueAsString();
                }
                else if (string.Compare("replicaCount", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    replicaCount = reader.ReadValueAsInt();
                }
                else if (string.Compare("executionPolicy", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    executionPolicy = ExecutionPolicyConverter.Deserialize(reader);
                }
                else if (string.Compare("autoScalingPolicies", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    autoScalingPolicies = reader.ReadList(AutoScalingPolicyConverter.Deserialize);
                }
                else if (string.Compare("status", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    status = ResourceStatusConverter.Deserialize(reader);
                }
                else if (string.Compare("statusDetails", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    statusDetails = reader.ReadValueAsString();
                }
                else if (string.Compare("healthState", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    healthState = HealthStateConverter.Deserialize(reader);
                }
                else if (string.Compare("unhealthyEvaluation", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    unhealthyEvaluation = reader.ReadValueAsString();
                }
                else if (string.Compare("identityRefs", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    identityRefs = reader.ReadList(ServiceIdentityConverter.Deserialize);
                }
                else if (string.Compare("dnsName", propName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    dnsName = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            var serviceProperties = new ServiceProperties(
                description: description,
                replicaCount: replicaCount,
                executionPolicy: executionPolicy,
                autoScalingPolicies: autoScalingPolicies,
                identityRefs: identityRefs,
                dnsName: dnsName);

            serviceProperties.Status = status;
            serviceProperties.StatusDetails = statusDetails;
            serviceProperties.HealthState = healthState;
            serviceProperties.UnhealthyEvaluation = unhealthyEvaluation;
            return serviceProperties;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ServiceProperties obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Status, "status", ResourceStatusConverter.Serialize);
            writer.WriteProperty(obj.HealthState, "healthState", HealthStateConverter.Serialize);
            if (obj.Description != null)
            {
                writer.WriteProperty(obj.Description, "description", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ReplicaCount != null)
            {
                writer.WriteProperty(obj.ReplicaCount, "replicaCount", JsonWriterExtensions.WriteIntValue);
            }

            if (obj.ExecutionPolicy != null)
            {
                writer.WriteProperty(obj.ExecutionPolicy, "executionPolicy", ExecutionPolicyConverter.Serialize);
            }

            if (obj.AutoScalingPolicies != null)
            {
                writer.WriteEnumerableProperty(obj.AutoScalingPolicies, "autoScalingPolicies", AutoScalingPolicyConverter.Serialize);
            }

            if (obj.StatusDetails != null)
            {
                writer.WriteProperty(obj.StatusDetails, "statusDetails", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.UnhealthyEvaluation != null)
            {
                writer.WriteProperty(obj.UnhealthyEvaluation, "unhealthyEvaluation", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.IdentityRefs != null)
            {
                writer.WriteEnumerableProperty(obj.IdentityRefs, "identityRefs", ServiceIdentityConverter.Serialize);
            }

            if (obj.DnsName != null)
            {
                writer.WriteProperty(obj.DnsName, "dnsName", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
