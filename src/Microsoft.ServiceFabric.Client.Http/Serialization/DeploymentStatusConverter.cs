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
    /// Converter for <see cref="DeploymentStatus" />.
    /// </summary>
    internal class DeploymentStatusConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static DeploymentStatus? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(DeploymentStatus);

            if (string.Compare(value, "Invalid", StringComparison.Ordinal) == 0)
            {
                obj = DeploymentStatus.Invalid;
            }
            else if (string.Compare(value, "Downloading", StringComparison.Ordinal) == 0)
            {
                obj = DeploymentStatus.Downloading;
            }
            else if (string.Compare(value, "Activating", StringComparison.Ordinal) == 0)
            {
                obj = DeploymentStatus.Activating;
            }
            else if (string.Compare(value, "Active", StringComparison.Ordinal) == 0)
            {
                obj = DeploymentStatus.Active;
            }
            else if (string.Compare(value, "Upgrading", StringComparison.Ordinal) == 0)
            {
                obj = DeploymentStatus.Upgrading;
            }
            else if (string.Compare(value, "Deactivating", StringComparison.Ordinal) == 0)
            {
                obj = DeploymentStatus.Deactivating;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, DeploymentStatus? value)
        {
            switch (value)
            {
                case DeploymentStatus.Invalid:
                    writer.WriteStringValue("Invalid");
                    break;
                case DeploymentStatus.Downloading:
                    writer.WriteStringValue("Downloading");
                    break;
                case DeploymentStatus.Activating:
                    writer.WriteStringValue("Activating");
                    break;
                case DeploymentStatus.Active:
                    writer.WriteStringValue("Active");
                    break;
                case DeploymentStatus.Upgrading:
                    writer.WriteStringValue("Upgrading");
                    break;
                case DeploymentStatus.Deactivating:
                    writer.WriteStringValue("Deactivating");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type DeploymentStatus");
            }
        }
    }
}
