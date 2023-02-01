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
            ApplicationEvent obj = null;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.OrdinalIgnoreCase))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("ApplicationCreated", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationCreatedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationDeleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationDeletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeCompleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationUpgradeCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeDomainCompleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationUpgradeDomainCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeRollbackCompleted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationUpgradeRollbackCompletedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeRollbackStarted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationUpgradeRollbackStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationUpgradeStarted", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationUpgradeStartedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplicationNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = DeployedApplicationNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplicationHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = DeployedApplicationHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationProcessExited", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationProcessExitedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationContainerInstanceExited", StringComparison.OrdinalIgnoreCase))
            {
                obj = ApplicationContainerInstanceExitedEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServicePackageNewHealthReport", StringComparison.OrdinalIgnoreCase))
            {
                obj = DeployedServicePackageNewHealthReportEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServicePackageHealthReportExpired", StringComparison.OrdinalIgnoreCase))
            {
                obj = DeployedServicePackageHealthReportExpiredEventConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ChaosCodePackageRestartScheduled", StringComparison.OrdinalIgnoreCase))
            {
                obj = ChaosCodePackageRestartScheduledEventConverter.GetFromJsonProperties(reader);
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
        internal static void Serialize(JsonWriter writer, ApplicationEvent obj)
        {
            var kind = obj.Kind;
            if (kind.Equals(ApplicationEventKind.ApplicationCreated))
            {
                ApplicationCreatedEventConverter.Serialize(writer, (ApplicationCreatedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationDeleted))
            {
                ApplicationDeletedEventConverter.Serialize(writer, (ApplicationDeletedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationNewHealthReport))
            {
                ApplicationNewHealthReportEventConverter.Serialize(writer, (ApplicationNewHealthReportEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationHealthReportExpired))
            {
                ApplicationHealthReportExpiredEventConverter.Serialize(writer, (ApplicationHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationUpgradeCompleted))
            {
                ApplicationUpgradeCompletedEventConverter.Serialize(writer, (ApplicationUpgradeCompletedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationUpgradeDomainCompleted))
            {
                ApplicationUpgradeDomainCompletedEventConverter.Serialize(writer, (ApplicationUpgradeDomainCompletedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationUpgradeRollbackCompleted))
            {
                ApplicationUpgradeRollbackCompletedEventConverter.Serialize(writer, (ApplicationUpgradeRollbackCompletedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationUpgradeRollbackStarted))
            {
                ApplicationUpgradeRollbackStartedEventConverter.Serialize(writer, (ApplicationUpgradeRollbackStartedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationUpgradeStarted))
            {
                ApplicationUpgradeStartedEventConverter.Serialize(writer, (ApplicationUpgradeStartedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.DeployedApplicationNewHealthReport))
            {
                DeployedApplicationNewHealthReportEventConverter.Serialize(writer, (DeployedApplicationNewHealthReportEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.DeployedApplicationHealthReportExpired))
            {
                DeployedApplicationHealthReportExpiredEventConverter.Serialize(writer, (DeployedApplicationHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationProcessExited))
            {
                ApplicationProcessExitedEventConverter.Serialize(writer, (ApplicationProcessExitedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ApplicationContainerInstanceExited))
            {
                ApplicationContainerInstanceExitedEventConverter.Serialize(writer, (ApplicationContainerInstanceExitedEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.DeployedServicePackageNewHealthReport))
            {
                DeployedServicePackageNewHealthReportEventConverter.Serialize(writer, (DeployedServicePackageNewHealthReportEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.DeployedServicePackageHealthReportExpired))
            {
                DeployedServicePackageHealthReportExpiredEventConverter.Serialize(writer, (DeployedServicePackageHealthReportExpiredEvent)obj);
            }
            else if (kind.Equals(ApplicationEventKind.ChaosCodePackageRestartScheduled))
            {
                ChaosCodePackageRestartScheduledEventConverter.Serialize(writer, (ChaosCodePackageRestartScheduledEvent)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
