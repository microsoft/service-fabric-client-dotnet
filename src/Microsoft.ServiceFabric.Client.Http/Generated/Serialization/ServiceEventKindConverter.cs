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
    /// Converter for <see cref="ServiceEventKind" />.
    /// </summary>
    internal class ServiceEventKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ServiceEventKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ServiceEventKind);

            if (string.Compare(value, "ServiceEvent", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ServiceEventKind.ServiceEvent;
            }
            else if (string.Compare(value, "ServiceCreated", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ServiceEventKind.ServiceCreated;
            }
            else if (string.Compare(value, "ServiceDeleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ServiceEventKind.ServiceDeleted;
            }
            else if (string.Compare(value, "ServiceNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ServiceEventKind.ServiceNewHealthReport;
            }
            else if (string.Compare(value, "ServiceHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ServiceEventKind.ServiceHealthReportExpired;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ServiceEventKind? value)
        {
            switch (value)
            {
                case ServiceEventKind.ServiceEvent:
                    writer.WriteStringValue("ServiceEvent");
                    break;
                case ServiceEventKind.ServiceCreated:
                    writer.WriteStringValue("ServiceCreated");
                    break;
                case ServiceEventKind.ServiceDeleted:
                    writer.WriteStringValue("ServiceDeleted");
                    break;
                case ServiceEventKind.ServiceNewHealthReport:
                    writer.WriteStringValue("ServiceNewHealthReport");
                    break;
                case ServiceEventKind.ServiceHealthReportExpired:
                    writer.WriteStringValue("ServiceHealthReportExpired");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ServiceEventKind");
            }
        }
    }
}
