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
    /// Converter for <see cref="ClusterEvent" />.
    /// </summary>
    internal class ClusterEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ClusterEvent GetFromJsonProperties(JsonReader reader)
        {
            ClusterEvent obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.OrdinalIgnoreCase))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("ClusterNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = ClusterNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = ClusterHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeCompleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ClusterUpgradeCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeDomainCompleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ClusterUpgradeDomainCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeRollbackCompleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ClusterUpgradeRollbackCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeRollbackStarted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ClusterUpgradeRollbackStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ClusterUpgradeStarted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ClusterUpgradeStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosStopped", StringComparison.OrdinalIgnoreCase))
            {
                obj = ChaosStoppedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosStarted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ChaosStartedEventConverter.GetFromJsonProperties(reader);
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
        internal static void Serialize(JsonWriter writer, ClusterEvent obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(ClusterEventKind.ClusterNewHealthReport))
            {
                ClusterNewHealthReportEventConverter.Serialize(writer, (ClusterNewHealthReportEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ClusterHealthReportExpired))
            {
                ClusterHealthReportExpiredEventConverter.Serialize(writer, (ClusterHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ClusterUpgradeCompleted))
            {
                ClusterUpgradeCompletedEventConverter.Serialize(writer, (ClusterUpgradeCompletedEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ClusterUpgradeDomainCompleted))
            {
                ClusterUpgradeDomainCompletedEventConverter.Serialize(writer, (ClusterUpgradeDomainCompletedEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ClusterUpgradeRollbackCompleted))
            {
                ClusterUpgradeRollbackCompletedEventConverter.Serialize(writer, (ClusterUpgradeRollbackCompletedEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ClusterUpgradeRollbackStarted))
            {
                ClusterUpgradeRollbackStartedEventConverter.Serialize(writer, (ClusterUpgradeRollbackStartedEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ClusterUpgradeStarted))
            {
                ClusterUpgradeStartedEventConverter.Serialize(writer, (ClusterUpgradeStartedEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ChaosStopped))
            {
                ChaosStoppedEventConverter.Serialize(writer, (ChaosStoppedEvent)obj);
            }
            else if (kind.Equals(ClusterEventKind.ChaosStarted))
            {
                ChaosStartedEventConverter.Serialize(writer, (ChaosStartedEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
