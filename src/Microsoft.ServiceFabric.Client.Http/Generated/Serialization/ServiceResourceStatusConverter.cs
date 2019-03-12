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
    /// Converter for <see cref="ServiceResourceStatus" />.
    /// </summary>
    internal class ServiceResourceStatusConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ServiceResourceStatus? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ServiceResourceStatus);

            if (string.Compare(value, "Unknown", StringComparison.Ordinal) == 0)
            {
                obj = ServiceResourceStatus.Unknown;
            }
            else if (string.Compare(value, "Active", StringComparison.Ordinal) == 0)
            {
                obj = ServiceResourceStatus.Active;
            }
            else if (string.Compare(value, "Upgrading", StringComparison.Ordinal) == 0)
            {
                obj = ServiceResourceStatus.Upgrading;
            }
            else if (string.Compare(value, "Deleting", StringComparison.Ordinal) == 0)
            {
                obj = ServiceResourceStatus.Deleting;
            }
            else if (string.Compare(value, "Creating", StringComparison.Ordinal) == 0)
            {
                obj = ServiceResourceStatus.Creating;
            }
            else if (string.Compare(value, "Failed", StringComparison.Ordinal) == 0)
            {
                obj = ServiceResourceStatus.Failed;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ServiceResourceStatus? value)
        {
            switch (value)
            {
                case ServiceResourceStatus.Unknown:
                    writer.WriteStringValue("Unknown");
                    break;
                case ServiceResourceStatus.Active:
                    writer.WriteStringValue("Active");
                    break;
                case ServiceResourceStatus.Upgrading:
                    writer.WriteStringValue("Upgrading");
                    break;
                case ServiceResourceStatus.Deleting:
                    writer.WriteStringValue("Deleting");
                    break;
                case ServiceResourceStatus.Creating:
                    writer.WriteStringValue("Creating");
                    break;
                case ServiceResourceStatus.Failed:
                    writer.WriteStringValue("Failed");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ServiceResourceStatus");
            }
        }
    }
}
