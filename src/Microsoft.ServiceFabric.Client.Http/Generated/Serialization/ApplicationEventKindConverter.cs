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
    /// Converter for <see cref="ApplicationEventKind" />.
    /// </summary>
    internal class ApplicationEventKindConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ApplicationEventKind? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ApplicationEventKind);

            if (string.Compare(value, "ApplicationEvent", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationEvent;
            }
            else if (string.Compare(value, "ApplicationCreated", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationCreated;
            }
            else if (string.Compare(value, "ApplicationDeleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationDeleted;
            }
            else if (string.Compare(value, "ApplicationNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationNewHealthReport;
            }
            else if (string.Compare(value, "ApplicationHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationHealthReportExpired;
            }
            else if (string.Compare(value, "ApplicationUpgradeCompleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationUpgradeCompleted;
            }
            else if (string.Compare(value, "ApplicationUpgradeDomainCompleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationUpgradeDomainCompleted;
            }
            else if (string.Compare(value, "ApplicationUpgradeRollbackCompleted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationUpgradeRollbackCompleted;
            }
            else if (string.Compare(value, "ApplicationUpgradeRollbackStarted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationUpgradeRollbackStarted;
            }
            else if (string.Compare(value, "ApplicationUpgradeStarted", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationUpgradeStarted;
            }
            else if (string.Compare(value, "DeployedApplicationNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.DeployedApplicationNewHealthReport;
            }
            else if (string.Compare(value, "DeployedApplicationHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.DeployedApplicationHealthReportExpired;
            }
            else if (string.Compare(value, "ApplicationProcessExited", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationProcessExited;
            }
            else if (string.Compare(value, "ApplicationContainerInstanceExited", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ApplicationContainerInstanceExited;
            }
            else if (string.Compare(value, "DeployedServicePackageHealthReportExpired", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.DeployedServicePackageHealthReportExpired;
            }
            else if (string.Compare(value, "ChaosCodePackageRestartScheduled", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.ChaosCodePackageRestartScheduled;
            }
            else if (string.Compare(value, "DeployedServicePackageNewHealthReport", StringComparison.OrdinalIgnoreCase) == 0)
            {
                obj = ApplicationEventKind.DeployedServicePackageNewHealthReport;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ApplicationEventKind? value)
        {
            switch (value)
            {
                case ApplicationEventKind.ApplicationEvent:
                    writer.WriteStringValue("ApplicationEvent");
                    break;
                case ApplicationEventKind.ApplicationCreated:
                    writer.WriteStringValue("ApplicationCreated");
                    break;
                case ApplicationEventKind.ApplicationDeleted:
                    writer.WriteStringValue("ApplicationDeleted");
                    break;
                case ApplicationEventKind.ApplicationNewHealthReport:
                    writer.WriteStringValue("ApplicationNewHealthReport");
                    break;
                case ApplicationEventKind.ApplicationHealthReportExpired:
                    writer.WriteStringValue("ApplicationHealthReportExpired");
                    break;
                case ApplicationEventKind.ApplicationUpgradeCompleted:
                    writer.WriteStringValue("ApplicationUpgradeCompleted");
                    break;
                case ApplicationEventKind.ApplicationUpgradeDomainCompleted:
                    writer.WriteStringValue("ApplicationUpgradeDomainCompleted");
                    break;
                case ApplicationEventKind.ApplicationUpgradeRollbackCompleted:
                    writer.WriteStringValue("ApplicationUpgradeRollbackCompleted");
                    break;
                case ApplicationEventKind.ApplicationUpgradeRollbackStarted:
                    writer.WriteStringValue("ApplicationUpgradeRollbackStarted");
                    break;
                case ApplicationEventKind.ApplicationUpgradeStarted:
                    writer.WriteStringValue("ApplicationUpgradeStarted");
                    break;
                case ApplicationEventKind.DeployedApplicationNewHealthReport:
                    writer.WriteStringValue("DeployedApplicationNewHealthReport");
                    break;
                case ApplicationEventKind.DeployedApplicationHealthReportExpired:
                    writer.WriteStringValue("DeployedApplicationHealthReportExpired");
                    break;
                case ApplicationEventKind.ApplicationProcessExited:
                    writer.WriteStringValue("ApplicationProcessExited");
                    break;
                case ApplicationEventKind.ApplicationContainerInstanceExited:
                    writer.WriteStringValue("ApplicationContainerInstanceExited");
                    break;
                case ApplicationEventKind.DeployedServicePackageHealthReportExpired:
                    writer.WriteStringValue("DeployedServicePackageHealthReportExpired");
                    break;
                case ApplicationEventKind.ChaosCodePackageRestartScheduled:
                    writer.WriteStringValue("ChaosCodePackageRestartScheduled");
                    break;
                case ApplicationEventKind.DeployedServicePackageNewHealthReport:
                    writer.WriteStringValue("DeployedServicePackageNewHealthReport");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ApplicationEventKind");
            }
        }
    }
}
