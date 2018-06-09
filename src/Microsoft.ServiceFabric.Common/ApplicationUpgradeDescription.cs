// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes the parameters for an application upgrade. Please note that upgrade description replaces the existing
    /// application description. This means that if the parameters are not specified, the existing parameters on the
    /// applications will be overwritten with the empty parameters list. This would results in application using the
    /// default value of the parameters from the application manifest. If you do not want to change any existing parameter
    /// values, please get the application parameters first using the GetApplicationInfo query and then supply those values
    /// as Parameters in this ApplicationUpgradeDescription.
    /// </summary>
    public partial class ApplicationUpgradeDescription
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationUpgradeDescription class.
        /// </summary>
        /// <param name="name">The name of the target application, including the 'fabric:' URI scheme.</param>
        /// <param name="targetApplicationTypeVersion">The target application type version (found in the application manifest)
        /// for the application upgrade.</param>
        /// <param name="parameters">List of application parameters with overridden values from their default values specified
        /// in the application manifest.</param>
        /// <param name="upgradeKind">The kind of upgrade out of the following possible values. Possible values include:
        /// 'Invalid', 'Rolling'</param>
        /// <param name="rollingUpgradeMode">The mode used to monitor health during a rolling upgrade. The values are
        /// UnmonitoredAuto, UnmonitoredManual, and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto',
        /// 'UnmonitoredManual', 'Monitored'</param>
        /// <param name="upgradeReplicaSetCheckTimeoutInSeconds">The maximum amount of time to block processing of an upgrade
        /// domain and prevent loss of availability when there are unexpected issues. When this timeout expires, processing of
        /// the upgrade domain will proceed regardless of availability loss issues. The timeout is reset at the start of each
        /// upgrade domain. Valid values are between 0 and 42949672925 inclusive. (unsigned 32-bit integer).</param>
        /// <param name="forceRestart">If true, then processes are forcefully restarted during upgrade even when the code
        /// version has not changed (the upgrade only changes configuration or data).</param>
        /// <param name="monitoringPolicy">Describes the parameters for monitoring an upgrade in Monitored mode.</param>
        /// <param name="applicationHealthPolicy">Defines a health policy used to evaluate the health of an application or one
        /// of its children entities.
        /// </param>
        public ApplicationUpgradeDescription(
            string name,
            string targetApplicationTypeVersion,
            IReadOnlyDictionary<string, string> parameters,
            UpgradeKind? upgradeKind = Common.UpgradeKind.Rolling,
            UpgradeMode? rollingUpgradeMode = Common.UpgradeMode.UnmonitoredAuto,
            long? upgradeReplicaSetCheckTimeoutInSeconds = default(long?),
            bool? forceRestart = default(bool?),
            MonitoringPolicyDescription monitoringPolicy = default(MonitoringPolicyDescription),
            ApplicationHealthPolicy applicationHealthPolicy = default(ApplicationHealthPolicy))
        {
            name.ThrowIfNull(nameof(name));
            targetApplicationTypeVersion.ThrowIfNull(nameof(targetApplicationTypeVersion));
            parameters.ThrowIfNull(nameof(parameters));
            upgradeKind.ThrowIfNull(nameof(upgradeKind));
            this.Name = name;
            this.TargetApplicationTypeVersion = targetApplicationTypeVersion;
            this.Parameters = parameters;
            this.UpgradeKind = upgradeKind;
            this.RollingUpgradeMode = rollingUpgradeMode;
            this.UpgradeReplicaSetCheckTimeoutInSeconds = upgradeReplicaSetCheckTimeoutInSeconds;
            this.ForceRestart = forceRestart;
            this.MonitoringPolicy = monitoringPolicy;
            this.ApplicationHealthPolicy = applicationHealthPolicy;
        }

        /// <summary>
        /// Gets the name of the target application, including the 'fabric:' URI scheme.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the target application type version (found in the application manifest) for the application upgrade.
        /// </summary>
        public string TargetApplicationTypeVersion { get; }

        /// <summary>
        /// Gets list of application parameters with overridden values from their default values specified in the application
        /// manifest.
        /// </summary>
        public IReadOnlyDictionary<string, string> Parameters { get; }

        /// <summary>
        /// Gets the kind of upgrade out of the following possible values. Possible values include: 'Invalid', 'Rolling'
        /// </summary>
        public UpgradeKind? UpgradeKind { get; }

        /// <summary>
        /// Gets the mode used to monitor health during a rolling upgrade. The values are UnmonitoredAuto, UnmonitoredManual,
        /// and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto', 'UnmonitoredManual', 'Monitored'
        /// </summary>
        public UpgradeMode? RollingUpgradeMode { get; }

        /// <summary>
        /// Gets the maximum amount of time to block processing of an upgrade domain and prevent loss of availability when
        /// there are unexpected issues. When this timeout expires, processing of the upgrade domain will proceed regardless of
        /// availability loss issues. The timeout is reset at the start of each upgrade domain. Valid values are between 0 and
        /// 42949672925 inclusive. (unsigned 32-bit integer).
        /// </summary>
        public long? UpgradeReplicaSetCheckTimeoutInSeconds { get; }

        /// <summary>
        /// Gets if true, then processes are forcefully restarted during upgrade even when the code version has not changed
        /// (the upgrade only changes configuration or data).
        /// </summary>
        public bool? ForceRestart { get; }

        /// <summary>
        /// Gets describes the parameters for monitoring an upgrade in Monitored mode.
        /// </summary>
        public MonitoringPolicyDescription MonitoringPolicy { get; }

        /// <summary>
        /// Gets defines a health policy used to evaluate the health of an application or one of its children entities.
        /// </summary>
        public ApplicationHealthPolicy ApplicationHealthPolicy { get; }
    }
}
