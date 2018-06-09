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
    /// Converter for <see cref="ChaosRestartCodePackageFaultScheduledEvent" />.
    /// </summary>
    internal class ChaosRestartCodePackageFaultScheduledEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ChaosRestartCodePackageFaultScheduledEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ChaosRestartCodePackageFaultScheduledEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var applicationId = default(string);
            var faultGroupId = default(Guid?);
            var faultId = default(Guid?);
            var nodeName = default(NodeName);
            var serviceManifestName = default(string);
            var codePackageName = default(string);
            var servicePackageActivationId = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("EventInstanceId", propName, StringComparison.Ordinal) == 0)
                {
                    eventInstanceId = reader.ReadValueAsGuid();
                }
                else if (string.Compare("TimeStamp", propName, StringComparison.Ordinal) == 0)
                {
                    timeStamp = reader.ReadValueAsDateTime();
                }
                else if (string.Compare("HasCorrelatedEvents", propName, StringComparison.Ordinal) == 0)
                {
                    hasCorrelatedEvents = reader.ReadValueAsBool();
                }
                else if (string.Compare("ApplicationId", propName, StringComparison.Ordinal) == 0)
                {
                    applicationId = reader.ReadValueAsString();
                }
                else if (string.Compare("FaultGroupId", propName, StringComparison.Ordinal) == 0)
                {
                    faultGroupId = reader.ReadValueAsGuid();
                }
                else if (string.Compare("FaultId", propName, StringComparison.Ordinal) == 0)
                {
                    faultId = reader.ReadValueAsGuid();
                }
                else if (string.Compare("NodeName", propName, StringComparison.Ordinal) == 0)
                {
                    nodeName = NodeNameConverter.Deserialize(reader);
                }
                else if (string.Compare("ServiceManifestName", propName, StringComparison.Ordinal) == 0)
                {
                    serviceManifestName = reader.ReadValueAsString();
                }
                else if (string.Compare("CodePackageName", propName, StringComparison.Ordinal) == 0)
                {
                    codePackageName = reader.ReadValueAsString();
                }
                else if (string.Compare("ServicePackageActivationId", propName, StringComparison.Ordinal) == 0)
                {
                    servicePackageActivationId = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ChaosRestartCodePackageFaultScheduledEvent(
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                applicationId: applicationId,
                faultGroupId: faultGroupId,
                faultId: faultId,
                nodeName: nodeName,
                serviceManifestName: serviceManifestName,
                codePackageName: codePackageName,
                servicePackageActivationId: servicePackageActivationId);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ChaosRestartCodePackageFaultScheduledEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.ApplicationId, "ApplicationId", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.FaultGroupId, "FaultGroupId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.FaultId, "FaultId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.NodeName, "NodeName", NodeNameConverter.Serialize);
            writer.WriteProperty(obj.ServiceManifestName, "ServiceManifestName", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.CodePackageName, "CodePackageName", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.ServicePackageActivationId, "ServicePackageActivationId", JsonWriterExtensions.WriteStringValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
