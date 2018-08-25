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
    /// Converter for <see cref="ApplicationEvent" />.
    /// </summary>
    internal class ApplicationEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationEvent GetFromJsonProperties(JsonReader reader)
        {
            var eventInstanceId = default(Guid?);
            var timeStamp = default(DateTime?);
            var hasCorrelatedEvents = default(bool?);
            var applicationId = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (propName.Equals("Kind", StringComparison.Ordinal))
                {
                    var propValue = reader.ReadValueAsString();

                    if (propValue.Equals("ApplicationCreated", StringComparison.Ordinal))
                    {
                        return ApplicationCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationDeleted", StringComparison.Ordinal))
                    {
                        return ApplicationDeletedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationHealthReportCreated", StringComparison.Ordinal))
                    {
                        return ApplicationHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationHealthReportExpired", StringComparison.Ordinal))
                    {
                        return ApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationUpgradeComplete", StringComparison.Ordinal))
                    {
                        return ApplicationUpgradeCompleteEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationUpgradeDomainComplete", StringComparison.Ordinal))
                    {
                        return ApplicationUpgradeDomainCompleteEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationUpgradeRollbackComplete", StringComparison.Ordinal))
                    {
                        return ApplicationUpgradeRollbackCompleteEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationUpgradeRollbackStart", StringComparison.Ordinal))
                    {
                        return ApplicationUpgradeRollbackStartEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationUpgradeStart", StringComparison.Ordinal))
                    {
                        return ApplicationUpgradeStartEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("DeployedApplicationHealthReportCreated", StringComparison.Ordinal))
                    {
                        return DeployedApplicationHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("DeployedApplicationHealthReportExpired", StringComparison.Ordinal))
                    {
                        return DeployedApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ProcessDeactivated", StringComparison.Ordinal))
                    {
                        return ProcessDeactivatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ContainerDeactivated", StringComparison.Ordinal))
                    {
                        return ContainerDeactivatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("DeployedServiceHealthReportCreated", StringComparison.Ordinal))
                    {
                        return DeployedServiceHealthReportCreatedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("DeployedServiceHealthReportExpired", StringComparison.Ordinal))
                    {
                        return DeployedServiceHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosRestartCodePackageFaultScheduled", StringComparison.Ordinal))
                    {
                        return ChaosRestartCodePackageFaultScheduledEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ChaosRestartCodePackageFaultCompleted", StringComparison.Ordinal))
                    {
                        return ChaosRestartCodePackageFaultCompletedEventConverter.GetFromJsonProperties(reader);
                    }
                    else if (propValue.Equals("ApplicationEvent", StringComparison.Ordinal))
                    {
                        // kind specified as same type, deserialize using properties.
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown Discriminator.");
                    }
                }
                else
                {
                    if (string.Compare("EventInstanceId", propName, StringComparison.Ordinal) == 0)
                    {
                        eventInstanceId = reader.ReadValueAsGuid();
                    }
                    else if (string.Compare("TimeStamp", propName, StringComparison.Ordinal) == 0)
                    {
                        timeStamp = reader.ReadValueAsDateTime();
                    }
                    else if (string.Compare("HasCorrelatedEvents", propName, StringComparison.Ordinal) == 0)
                    {
                        hasCorrelatedEvents = reader.ReadValueAsBool();
                    }
                    else if (string.Compare("ApplicationId", propName, StringComparison.Ordinal) == 0)
                    {
                        applicationId = reader.ReadValueAsString();
                    }
                    else
                    {
                        reader.SkipPropertyValue();
                    }
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationEvent(
                kind: Common.FabricEventKind.ApplicationEvent,
                eventInstanceId: eventInstanceId,
                timeStamp: timeStamp,
                hasCorrelatedEvents: hasCorrelatedEvents,
                applicationId: applicationId);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.EventInstanceId, "EventInstanceId", JsonWriterExtensions.WriteGuidValue);
            writer.WriteProperty(obj.TimeStamp, "TimeStamp", JsonWriterExtensions.WriteDateTimeValue);
            writer.WriteProperty(obj.ApplicationId, "ApplicationId", JsonWriterExtensions.WriteStringValue);
            if (obj.HasCorrelatedEvents != null)
            {
                writer.WriteProperty(obj.HasCorrelatedEvents, "HasCorrelatedEvents", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
