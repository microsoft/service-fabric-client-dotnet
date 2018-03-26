// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
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
    /// Converter for <see cref="FabricEvent" />.
    /// </summary>
    internal class FabricEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static FabricEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static FabricEvent GetFromJsonProperties(JsonReader reader)
        {
            FabricEvent obj;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("ApplicationEvent", StringComparison.Ordinal))
            {
                obj = ApplicationEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterEvent", StringComparison.Ordinal))
            {
                obj = ClusterEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ContainerEvent", StringComparison.Ordinal))
            {
                obj = ContainerEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeEvent", StringComparison.Ordinal))
            {
                obj = NodeEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionAnalysisEvent", StringComparison.Ordinal))
            {
                obj = PartitionAnalysisEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionEvent", StringComparison.Ordinal))
            {
                obj = PartitionEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ReplicaEvent", StringComparison.Ordinal))
            {
                obj = ReplicaEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ServiceEvent", StringComparison.Ordinal))
            {
                obj = ServiceEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeUp", StringComparison.Ordinal))
            {
                obj = NodeUpEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NodeDown", StringComparison.Ordinal))
            {
                obj = NodeDownEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PartitionPrimaryMoveAnalysis", StringComparison.Ordinal))
            {
                obj = PartitionPrimaryMoveAnalysisEventConverter.GetFromJsonProperties(reader);
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
        internal static void Serialize(JsonWriter writer, FabricEvent obj)
        {
            var kind = obj.Kind;

            if (kind.Equals(FabricEventKind.ApplicationEvent))
            {
                ApplicationEventConverter.Serialize(writer, (ApplicationEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ClusterEvent))
            {
                ClusterEventConverter.Serialize(writer, (ClusterEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ContainerEvent))
            {
                ContainerEventConverter.Serialize(writer, (ContainerEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeEvent))
            {
                NodeEventConverter.Serialize(writer, (NodeEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionAnalysisEvent))
            {
                PartitionAnalysisEventConverter.Serialize(writer, (PartitionAnalysisEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionEvent))
            {
                PartitionEventConverter.Serialize(writer, (PartitionEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ReplicaEvent))
            {
                ReplicaEventConverter.Serialize(writer, (ReplicaEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.ServiceEvent))
            {
                ServiceEventConverter.Serialize(writer, (ServiceEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeUp))
            {
                NodeUpEventConverter.Serialize(writer, (NodeUpEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.NodeDown))
            {
                NodeDownEventConverter.Serialize(writer, (NodeDownEvent)obj);
            }
            else if (kind.Equals(FabricEventKind.PartitionPrimaryMoveAnalysis))
            {
                PartitionPrimaryMoveAnalysisEventConverter.Serialize(writer, (PartitionPrimaryMoveAnalysisEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
