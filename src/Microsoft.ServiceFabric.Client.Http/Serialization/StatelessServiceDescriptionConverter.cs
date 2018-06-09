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
    /// Converter for <see cref="StatelessServiceDescription" />.
    /// </summary>
    internal class StatelessServiceDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static StatelessServiceDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static StatelessServiceDescription GetFromJsonProperties(JsonReader reader)
        {
            var applicationName = default(ApplicationName);
            var serviceName = default(ServiceName);
            var serviceTypeName = default(string);
            var initializationData = default(byte[]);
            var partitionDescription = default(PartitionSchemeDescription);
            var placementConstraints = default(string);
            var correlationScheme = default(IEnumerable<ServiceCorrelationDescription>);
            var serviceLoadMetrics = default(IEnumerable<ServiceLoadMetricDescription>);
            var servicePlacementPolicies = default(IEnumerable<ServicePlacementPolicyDescription>);
            var defaultMoveCost = default(MoveCost?);
            var isDefaultMoveCostSpecified = default(bool?);
            var servicePackageActivationMode = default(ServicePackageActivationMode?);
            var serviceDnsName = default(string);
            var scalingPolicies = default(IEnumerable<ScalingPolicyDescription>);
            var instanceCount = default(int?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("ApplicationName", propName, StringComparison.Ordinal) == 0)
                {
                    applicationName = ApplicationNameConverter.Deserialize(reader);
                }
                else if (string.Compare("ServiceName", propName, StringComparison.Ordinal) == 0)
                {
                    serviceName = ServiceNameConverter.Deserialize(reader);
                }
                else if (string.Compare("ServiceTypeName", propName, StringComparison.Ordinal) == 0)
                {
                    serviceTypeName = reader.ReadValueAsString();
                }
                else if (string.Compare("InitializationData", propName, StringComparison.Ordinal) == 0)
                {
                    initializationData = ByteArrayConverter.Deserialize(reader);
                }
                else if (string.Compare("PartitionDescription", propName, StringComparison.Ordinal) == 0)
                {
                    partitionDescription = PartitionSchemeDescriptionConverter.Deserialize(reader);
                }
                else if (string.Compare("PlacementConstraints", propName, StringComparison.Ordinal) == 0)
                {
                    placementConstraints = reader.ReadValueAsString();
                }
                else if (string.Compare("CorrelationScheme", propName, StringComparison.Ordinal) == 0)
                {
                    correlationScheme = reader.ReadList(ServiceCorrelationDescriptionConverter.Deserialize);
                }
                else if (string.Compare("ServiceLoadMetrics", propName, StringComparison.Ordinal) == 0)
                {
                    serviceLoadMetrics = reader.ReadList(ServiceLoadMetricDescriptionConverter.Deserialize);
                }
                else if (string.Compare("ServicePlacementPolicies", propName, StringComparison.Ordinal) == 0)
                {
                    servicePlacementPolicies = reader.ReadList(ServicePlacementPolicyDescriptionConverter.Deserialize);
                }
                else if (string.Compare("DefaultMoveCost", propName, StringComparison.Ordinal) == 0)
                {
                    defaultMoveCost = MoveCostConverter.Deserialize(reader);
                }
                else if (string.Compare("IsDefaultMoveCostSpecified", propName, StringComparison.Ordinal) == 0)
                {
                    isDefaultMoveCostSpecified = reader.ReadValueAsBool();
                }
                else if (string.Compare("ServicePackageActivationMode", propName, StringComparison.Ordinal) == 0)
                {
                    servicePackageActivationMode = ServicePackageActivationModeConverter.Deserialize(reader);
                }
                else if (string.Compare("ServiceDnsName", propName, StringComparison.Ordinal) == 0)
                {
                    serviceDnsName = reader.ReadValueAsString();
                }
                else if (string.Compare("ScalingPolicies", propName, StringComparison.Ordinal) == 0)
                {
                    scalingPolicies = reader.ReadList(ScalingPolicyDescriptionConverter.Deserialize);
                }
                else if (string.Compare("InstanceCount", propName, StringComparison.Ordinal) == 0)
                {
                    instanceCount = reader.ReadValueAsInt();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new StatelessServiceDescription(
                applicationName: applicationName,
                serviceName: serviceName,
                serviceTypeName: serviceTypeName,
                initializationData: initializationData,
                partitionDescription: partitionDescription,
                placementConstraints: placementConstraints,
                correlationScheme: correlationScheme,
                serviceLoadMetrics: serviceLoadMetrics,
                servicePlacementPolicies: servicePlacementPolicies,
                defaultMoveCost: defaultMoveCost,
                isDefaultMoveCostSpecified: isDefaultMoveCostSpecified,
                servicePackageActivationMode: servicePackageActivationMode,
                serviceDnsName: serviceDnsName,
                scalingPolicies: scalingPolicies,
                instanceCount: instanceCount);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, StatelessServiceDescription obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.ServiceKind.ToString(), "ServiceKind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.ServiceName, "ServiceName", ServiceNameConverter.Serialize);
            writer.WriteProperty(obj.ServiceTypeName, "ServiceTypeName", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.PartitionDescription, "PartitionDescription", PartitionSchemeDescriptionConverter.Serialize);
            writer.WriteProperty(obj.InstanceCount, "InstanceCount", JsonWriterExtensions.WriteIntValue);
            writer.WriteProperty(obj.DefaultMoveCost, "DefaultMoveCost", MoveCostConverter.Serialize);
            writer.WriteProperty(obj.ServicePackageActivationMode, "ServicePackageActivationMode", ServicePackageActivationModeConverter.Serialize);
            if (obj.ApplicationName != null)
            {
                writer.WriteProperty(obj.ApplicationName, "ApplicationName", ApplicationNameConverter.Serialize);
            }

            if (obj.InitializationData != null)
            {
                writer.WriteProperty(obj.InitializationData, "InitializationData", ByteArrayConverter.Serialize);
            }

            if (obj.PlacementConstraints != null)
            {
                writer.WriteProperty(obj.PlacementConstraints, "PlacementConstraints", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.CorrelationScheme != null)
            {
                writer.WriteEnumerableProperty(obj.CorrelationScheme, "CorrelationScheme", ServiceCorrelationDescriptionConverter.Serialize);
            }

            if (obj.ServiceLoadMetrics != null)
            {
                writer.WriteEnumerableProperty(obj.ServiceLoadMetrics, "ServiceLoadMetrics", ServiceLoadMetricDescriptionConverter.Serialize);
            }

            if (obj.ServicePlacementPolicies != null)
            {
                writer.WriteEnumerableProperty(obj.ServicePlacementPolicies, "ServicePlacementPolicies", ServicePlacementPolicyDescriptionConverter.Serialize);
            }

            if (obj.IsDefaultMoveCostSpecified != null)
            {
                writer.WriteProperty(obj.IsDefaultMoveCostSpecified, "IsDefaultMoveCostSpecified", JsonWriterExtensions.WriteBoolValue);
            }

            if (obj.ServiceDnsName != null)
            {
                writer.WriteProperty(obj.ServiceDnsName, "ServiceDnsName", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.ScalingPolicies != null)
            {
                writer.WriteEnumerableProperty(obj.ScalingPolicies, "ScalingPolicies", ScalingPolicyDescriptionConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
