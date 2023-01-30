// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ApplicationEventKind.
    /// </summary>
    public enum ApplicationEventKind
    {
        /// <summary>
        /// ApplicationEvent.
        /// </summary>
        ApplicationEvent,

        /// <summary>
        /// ApplicationCreated.
        /// </summary>
        ApplicationCreated,

        /// <summary>
        /// ApplicationDeleted.
        /// </summary>
        ApplicationDeleted,

        /// <summary>
        /// ApplicationNewHealthReport.
        /// </summary>
        ApplicationNewHealthReport,

        /// <summary>
        /// ApplicationHealthReportExpired.
        /// </summary>
        ApplicationHealthReportExpired,

        /// <summary>
        /// ApplicationUpgradeCompleted.
        /// </summary>
        ApplicationUpgradeCompleted,

        /// <summary>
        /// ApplicationUpgradeDomainCompleted.
        /// </summary>
        ApplicationUpgradeDomainCompleted,

        /// <summary>
        /// ApplicationUpgradeRollbackCompleted.
        /// </summary>
        ApplicationUpgradeRollbackCompleted,

        /// <summary>
        /// ApplicationUpgradeRollbackStarted.
        /// </summary>
        ApplicationUpgradeRollbackStarted,

        /// <summary>
        /// ApplicationUpgradeStarted.
        /// </summary>
        ApplicationUpgradeStarted,

        /// <summary>
        /// DeployedApplicationNewHealthReport.
        /// </summary>
        DeployedApplicationNewHealthReport,

        /// <summary>
        /// DeployedApplicationHealthReportExpired.
        /// </summary>
        DeployedApplicationHealthReportExpired,

        /// <summary>
        /// ApplicationProcessExited.
        /// </summary>
        ApplicationProcessExited,

        /// <summary>
        /// ApplicationContainerInstanceExited.
        /// </summary>
        ApplicationContainerInstanceExited,

        /// <summary>
        /// DeployedServicePackageHealthReportExpired.
        /// </summary>
        DeployedServicePackageHealthReportExpired,

        /// <summary>
        /// ChaosCodePackageRestartScheduled.
        /// </summary>
        ChaosCodePackageRestartScheduled,

        /// <summary>
        /// DeployedServicePackageNewHealthReport.
        /// </summary>
        DeployedServicePackageNewHealthReport,
    }
}
