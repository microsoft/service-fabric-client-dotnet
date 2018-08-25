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
    /// Converter for <see cref="NodeLoadMetricInformation" />.
    /// </summary>
    internal class NodeLoadMetricInformationConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeLoadMetricInformation Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static NodeLoadMetricInformation GetFromJsonProperties(JsonReader reader)
        {
            var name = default(string);
            var nodeCapacity = default(string);
            var nodeLoad = default(string);
            var nodeRemainingCapacity = default(string);
            var isCapacityViolation = default(bool?);
            var nodeBufferedCapacity = default(string);
            var nodeRemainingBufferedCapacity = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("Name", propName, StringComparison.Ordinal) == 0)
                {
                    name = reader.ReadValueAsString();
                }
                else if (string.Compare("NodeCapacity", propName, StringComparison.Ordinal) == 0)
                {
                    nodeCapacity = reader.ReadValueAsString();
                }
                else if (string.Compare("NodeLoad", propName, StringComparison.Ordinal) == 0)
                {
                    nodeLoad = reader.ReadValueAsString();
                }
                else if (string.Compare("NodeRemainingCapacity", propName, StringComparison.Ordinal) == 0)
                {
                    nodeRemainingCapacity = reader.ReadValueAsString();
                }
                else if (string.Compare("IsCapacityViolation", propName, StringComparison.Ordinal) == 0)
                {
                    isCapacityViolation = reader.ReadValueAsBool();
                }
                else if (string.Compare("NodeBufferedCapacity", propName, StringComparison.Ordinal) == 0)
                {
                    nodeBufferedCapacity = reader.ReadValueAsString();
                }
                else if (string.Compare("NodeRemainingBufferedCapacity", propName, StringComparison.Ordinal) == 0)
                {
                    nodeRemainingBufferedCapacity = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NodeLoadMetricInformation(
                name: name,
                nodeCapacity: nodeCapacity,
                nodeLoad: nodeLoad,
                nodeRemainingCapacity: nodeRemainingCapacity,
                isCapacityViolation: isCapacityViolation,
                nodeBufferedCapacity: nodeBufferedCapacity,
                nodeRemainingBufferedCapacity: nodeRemainingBufferedCapacity);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NodeLoadMetricInformation obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.Name != null)
            {
                writer.WriteProperty(obj.Name, "Name", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.NodeCapacity != null)
            {
                writer.WriteProperty(obj.NodeCapacity, "NodeCapacity", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.NodeLoad != null)
            {
                writer.WriteProperty(obj.NodeLoad, "NodeLoad", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.NodeRemainingCapacity != null)
            {
                writer.WriteProperty(obj.NodeRemainingCapacity, "NodeRemainingCapacity", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.IsCapacityViolation != null)
            {
                writer.WriteProperty(obj.IsCapacityViolation, "IsCapacityViolation", JsonWriterExtensions.WriteBoolValue);
            }

            if (obj.NodeBufferedCapacity != null)
            {
                writer.WriteProperty(obj.NodeBufferedCapacity, "NodeBufferedCapacity", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.NodeRemainingBufferedCapacity != null)
            {
                writer.WriteProperty(obj.NodeRemainingBufferedCapacity, "NodeRemainingBufferedCapacity", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
