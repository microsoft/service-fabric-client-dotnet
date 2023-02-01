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
    /// Converter for <see cref="ServiceEvent" />.
    /// </summary>
    internal class ServiceEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServiceEvent GetFromJsonProperties(JsonReader reader)
        {
            ServiceEvent obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.OrdinalIgnoreCase))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("ServiceCreated", StringComparison.OrdinalIgnoreCase))
            {
                obj = ServiceCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceDeleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ServiceDeletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = ServiceNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = ServiceHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }

            return obj;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ServiceEvent obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(ServiceEventKind.ServiceCreated))
            {
                ServiceCreatedEventConverter.Serialize(writer, (ServiceCreatedEvent)obj);
            }
            else if (kind.Equals(ServiceEventKind.ServiceDeleted))
            {
                ServiceDeletedEventConverter.Serialize(writer, (ServiceDeletedEvent)obj);
            }
            else if (kind.Equals(ServiceEventKind.ServiceNewHealthReport))
            {
                ServiceNewHealthReportEventConverter.Serialize(writer, (ServiceNewHealthReportEvent)obj);
            }
            else if (kind.Equals(ServiceEventKind.ServiceHealthReportExpired))
            {
                ServiceHealthReportExpiredEventConverter.Serialize(writer, (ServiceHealthReportExpiredEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
