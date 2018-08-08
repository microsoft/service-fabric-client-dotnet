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
    /// Converter for <see cref="ApplicationResourceStatus" />.
    /// </summary>
    internal class ApplicationResourceStatusConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ApplicationResourceStatus? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ApplicationResourceStatus);

            if (string.Compare(value, "Invalid", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationResourceStatus.Invalid;
            }
            else if (string.Compare(value, "Ready", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationResourceStatus.Ready;
            }
            else if (string.Compare(value, "Upgrading", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationResourceStatus.Upgrading;
            }
            else if (string.Compare(value, "Creating", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationResourceStatus.Creating;
            }
            else if (string.Compare(value, "Deleting", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationResourceStatus.Deleting;
            }
            else if (string.Compare(value, "Failed", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationResourceStatus.Failed;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ApplicationResourceStatus? value)
        {
            switch (value)
            {
                case ApplicationResourceStatus.Invalid:
                    writer.WriteStringValue("Invalid");
                    break;
                case ApplicationResourceStatus.Ready:
                    writer.WriteStringValue("Ready");
                    break;
                case ApplicationResourceStatus.Upgrading:
                    writer.WriteStringValue("Upgrading");
                    break;
                case ApplicationResourceStatus.Creating:
                    writer.WriteStringValue("Creating");
                    break;
                case ApplicationResourceStatus.Deleting:
                    writer.WriteStringValue("Deleting");
                    break;
                case ApplicationResourceStatus.Failed:
                    writer.WriteStringValue("Failed");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ApplicationResourceStatus");
            }
        }
    }
}
