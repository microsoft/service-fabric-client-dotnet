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
    /// Converter for <see cref="NetworkStatus" />.
    /// </summary>
    internal class NetworkStatusConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static NetworkStatus? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(NetworkStatus);

            if (string.Compare(value, "Ready", StringComparison.Ordinal) == 0)
            {
                obj = NetworkStatus.Ready;
            }
            else if (string.Compare(value, "Creating", StringComparison.Ordinal) == 0)
            {
                obj = NetworkStatus.Creating;
            }
            else if (string.Compare(value, "Deleting", StringComparison.Ordinal) == 0)
            {
                obj = NetworkStatus.Deleting;
            }
            else if (string.Compare(value, "Failed", StringComparison.Ordinal) == 0)
            {
                obj = NetworkStatus.Failed;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, NetworkStatus? value)
        {
            switch (value)
            {
                case NetworkStatus.Ready:
                    writer.WriteStringValue("Ready");
                    break;
                case NetworkStatus.Creating:
                    writer.WriteStringValue("Creating");
                    break;
                case NetworkStatus.Deleting:
                    writer.WriteStringValue("Deleting");
                    break;
                case NetworkStatus.Failed:
                    writer.WriteStringValue("Failed");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type NetworkStatus");
            }
        }
    }
}
