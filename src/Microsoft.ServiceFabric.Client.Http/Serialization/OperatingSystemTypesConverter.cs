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
    /// Converter for <see cref="OperatingSystemTypes" />.
    /// </summary>
    internal class OperatingSystemTypesConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static OperatingSystemTypes? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(OperatingSystemTypes);

            if (string.Compare(value, "Linux", StringComparison.Ordinal) == 0)
            {
                obj = OperatingSystemTypes.Linux;
            }
            else if (string.Compare(value, "Windows", StringComparison.Ordinal) == 0)
            {
                obj = OperatingSystemTypes.Windows;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, OperatingSystemTypes? value)
        {
            switch (value)
            {
                case OperatingSystemTypes.Linux:
                    writer.WriteStringValue("Linux");
                    break;
                case OperatingSystemTypes.Windows:
                    writer.WriteStringValue("Windows");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type OperatingSystemTypes");
            }
        }
    }
}
