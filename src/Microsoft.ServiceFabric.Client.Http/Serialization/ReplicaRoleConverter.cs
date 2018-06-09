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
    /// Converter for <see cref="ReplicaRole" />.
    /// </summary>
    internal class ReplicaRoleConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ReplicaRole? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ReplicaRole);

            if (string.Compare(value, "Unknown", StringComparison.Ordinal) == 0)
            {
                obj = ReplicaRole.Unknown;
            }
            else if (string.Compare(value, "None", StringComparison.Ordinal) == 0)
            {
                obj = ReplicaRole.None;
            }
            else if (string.Compare(value, "Primary", StringComparison.Ordinal) == 0)
            {
                obj = ReplicaRole.Primary;
            }
            else if (string.Compare(value, "IdleSecondary", StringComparison.Ordinal) == 0)
            {
                obj = ReplicaRole.IdleSecondary;
            }
            else if (string.Compare(value, "ActiveSecondary", StringComparison.Ordinal) == 0)
            {
                obj = ReplicaRole.ActiveSecondary;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ReplicaRole? value)
        {
            switch (value)
            {
                case ReplicaRole.Unknown:
                    writer.WriteStringValue("Unknown");
                    break;
                case ReplicaRole.None:
                    writer.WriteStringValue("None");
                    break;
                case ReplicaRole.Primary:
                    writer.WriteStringValue("Primary");
                    break;
                case ReplicaRole.IdleSecondary:
                    writer.WriteStringValue("IdleSecondary");
                    break;
                case ReplicaRole.ActiveSecondary:
                    writer.WriteStringValue("ActiveSecondary");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ReplicaRole");
            }
        }
    }
}
