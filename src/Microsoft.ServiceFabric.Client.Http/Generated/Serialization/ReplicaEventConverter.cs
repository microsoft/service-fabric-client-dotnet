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
    /// Converter for <see cref="ReplicaEvent" />.
    /// </summary>
    internal class ReplicaEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ReplicaEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ReplicaEvent GetFromJsonProperties(JsonReader reader)
        {
            ReplicaEvent obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.OrdinalIgnoreCase))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("StatefulReplicaNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = StatefulReplicaNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatefulReplicaHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = StatefulReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatelessReplicaNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = StatelessReplicaNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("StatelessReplicaHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = StatelessReplicaHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosReplicaRemovalScheduled", StringComparison.OrdinalIgnoreCase))
            {
                obj = ChaosReplicaRemovalScheduledEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosReplicaRestartScheduled", StringComparison.OrdinalIgnoreCase))
            {
                obj = ChaosReplicaRestartScheduledEventConverter.GetFromJsonProperties(reader);
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
        internal static void Serialize(JsonWriter writer, ReplicaEvent obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(ReplicaEventKind.StatefulReplicaNewHealthReport))
            {
                StatefulReplicaNewHealthReportEventConverter.Serialize(writer, (StatefulReplicaNewHealthReportEvent)obj);
            }
            else if (kind.Equals(ReplicaEventKind.StatefulReplicaHealthReportExpired))
            {
                StatefulReplicaHealthReportExpiredEventConverter.Serialize(writer, (StatefulReplicaHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(ReplicaEventKind.StatelessReplicaNewHealthReport))
            {
                StatelessReplicaNewHealthReportEventConverter.Serialize(writer, (StatelessReplicaNewHealthReportEvent)obj);
            }
            else if (kind.Equals(ReplicaEventKind.StatelessReplicaHealthReportExpired))
            {
                StatelessReplicaHealthReportExpiredEventConverter.Serialize(writer, (StatelessReplicaHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(ReplicaEventKind.ChaosReplicaRemovalScheduled))
            {
                ChaosReplicaRemovalScheduledEventConverter.Serialize(writer, (ChaosReplicaRemovalScheduledEvent)obj);
            }
            else if (kind.Equals(ReplicaEventKind.ChaosReplicaRestartScheduled))
            {
                ChaosReplicaRestartScheduledEventConverter.Serialize(writer, (ChaosReplicaRestartScheduledEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
