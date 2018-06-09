// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes the parameters for an application upgrade.
    /// </summary>
    public partial class ApplicationUpgradeProgressInfo
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationUpgradeProgressInfo class.
        /// </summary>
        /// <param name="name">The name of the target application, including the 'fabric:' URI scheme.</param>
        /// <param name="typeName">The application type name as defined in the application manifest.</param>
        /// <param name="targetApplicationTypeVersion">The target application type version (found in the application manifest)
        /// for the application upgrade.</param>
        /// <param name="upgradeDomains">List of upgrade domains and their statuses.</param>
        /// <param name="upgradeState">The state of the upgrade domain. Possible values include: 'Invalid',
        /// 'RollingBackInProgress', 'RollingBackCompleted', 'RollingForwardPending', 'RollingForwardInProgress',
        /// 'RollingForwardCompleted', 'Failed'</param>
        /// <param name="nextUpgradeDomain">The name of the next upgrade domain to be processed.</param>
        /// <param name="rollingUpgradeMode">The mode used to monitor health during a rolling upgrade. The values are
        /// UnmonitoredAuto, UnmonitoredManual, and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto',
        /// 'UnmonitoredManual', 'Monitored'</param>
        /// <param name="upgradeDescription">Describes the parameters for an application upgrade. Please note that upgrade
        /// description replaces the existing application description. This means that if the parameters are not specified, the
        /// existing parameters on the applications will be overwritten with the empty parameters list. This would results in
        /// application using the default value of the parameters from the application manifest. If you do not want to change
        /// any existing parameter values, please get the application parameters first using the GetApplicationInfo query and
        /// then supply those values as Parameters in this ApplicationUpgradeDescription.</param>
        /// <param name="upgradeDurationInMilliseconds">The estimated total amount of time spent processing the overall
        /// upgrade.</param>
        /// <param name="upgradeDomainDurationInMilliseconds">The estimated total amount of time spent processing the current
        /// upgrade domain.</param>
        /// <param name="unhealthyEvaluations">List of health evaluations that resulted in the current aggregated health
        /// state.</param>
        /// <param name="currentUpgradeDomainProgress">Information about the current in-progress upgrade domain.</param>
        /// <param name="startTimestampUtc">The estimated UTC datetime when the upgrade started.</param>
        /// <param name="failureTimestampUtc">The estimated UTC datetime when the upgrade failed and FailureAction was
        /// executed.</param>
        /// <param name="failureReason">The cause of an upgrade failure that resulted in FailureAction being executed. Possible
        /// values include: 'None', 'Interrupted', 'HealthCheck', 'UpgradeDomainTimeout', 'OverallUpgradeTimeout'</param>
        /// <param name="upgradeDomainProgressAtFailure">Information about the upgrade domain progress at the time of upgrade
        /// failure.</param>
        /// <param name="upgradeStatusDetails">Additional detailed information about the status of the pending upgrade.</param>
        public ApplicationUpgradeProgressInfo(
            string name = default(string),
            string typeName = default(string),
            string targetApplicationTypeVersion = default(string),
            IEnumerable<UpgradeDomainInfo> upgradeDomains = default(IEnumerable<UpgradeDomainInfo>),
            UpgradeState? upgradeState = default(UpgradeState?),
            string nextUpgradeDomain = default(string),
            UpgradeMode? rollingUpgradeMode = Common.UpgradeMode.UnmonitoredAuto,
            ApplicationUpgradeDescription upgradeDescription = default(ApplicationUpgradeDescription),
            string upgradeDurationInMilliseconds = default(string),
            string upgradeDomainDurationInMilliseconds = default(string),
            IEnumerable<HealthEvaluationWrapper> unhealthyEvaluations = default(IEnumerable<HealthEvaluationWrapper>),
            CurrentUpgradeDomainProgressInfo currentUpgradeDomainProgress = default(CurrentUpgradeDomainProgressInfo),
            string startTimestampUtc = default(string),
            string failureTimestampUtc = default(string),
            FailureReason? failureReason = default(FailureReason?),
            FailureUpgradeDomainProgressInfo upgradeDomainProgressAtFailure = default(FailureUpgradeDomainProgressInfo),
            string upgradeStatusDetails = default(string))
        {
            this.Name = name;
            this.TypeName = typeName;
            this.TargetApplicationTypeVersion = targetApplicationTypeVersion;
            this.UpgradeDomains = upgradeDomains;
            this.UpgradeState = upgradeState;
            this.NextUpgradeDomain = nextUpgradeDomain;
            this.RollingUpgradeMode = rollingUpgradeMode;
            this.UpgradeDescription = upgradeDescription;
            this.UpgradeDurationInMilliseconds = upgradeDurationInMilliseconds;
            this.UpgradeDomainDurationInMilliseconds = upgradeDomainDurationInMilliseconds;
            this.UnhealthyEvaluations = unhealthyEvaluations;
            this.CurrentUpgradeDomainProgress = currentUpgradeDomainProgress;
            this.StartTimestampUtc = startTimestampUtc;
            this.FailureTimestampUtc = failureTimestampUtc;
            this.FailureReason = failureReason;
            this.UpgradeDomainProgressAtFailure = upgradeDomainProgressAtFailure;
            this.UpgradeStatusDetails = upgradeStatusDetails;
        }

        /// <summary>
        /// Gets the name of the target application, including the 'fabric:' URI scheme.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the application type name as defined in the application manifest.
        /// </summary>
        public string TypeName { get; }

        /// <summary>
        /// Gets the target application type version (found in the application manifest) for the application upgrade.
        /// </summary>
        public string TargetApplicationTypeVersion { get; }

        /// <summary>
        /// Gets list of upgrade domains and their statuses.
        /// </summary>
        public IEnumerable<UpgradeDomainInfo> UpgradeDomains { get; }

        /// <summary>
        /// Gets the state of the upgrade domain. Possible values include: 'Invalid', 'RollingBackInProgress',
        /// 'RollingBackCompleted', 'RollingForwardPending', 'RollingForwardInProgress', 'RollingForwardCompleted', 'Failed'
        /// </summary>
        public UpgradeState? UpgradeState { get; }

        /// <summary>
        /// Gets the name of the next upgrade domain to be processed.
        /// </summary>
        public string NextUpgradeDomain { get; }

        /// <summary>
        /// Gets the mode used to monitor health during a rolling upgrade. The values are UnmonitoredAuto, UnmonitoredManual,
        /// and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto', 'UnmonitoredManual', 'Monitored'
        /// </summary>
        public UpgradeMode? RollingUpgradeMode { get; }

        /// <summary>
        /// Gets describes the parameters for an application upgrade. Please note that upgrade description replaces the
        /// existing application description. This means that if the parameters are not specified, the existing parameters on
        /// the applications will be overwritten with the empty parameters list. This would results in application using the
        /// default value of the parameters from the application manifest. If you do not want to change any existing parameter
        /// values, please get the application parameters first using the GetApplicationInfo query and then supply those values
        /// as Parameters in this ApplicationUpgradeDescription.
        /// </summary>
        public ApplicationUpgradeDescription UpgradeDescription { get; }

        /// <summary>
        /// Gets the estimated total amount of time spent processing the overall upgrade.
        /// </summary>
        public string UpgradeDurationInMilliseconds { get; }

        /// <summary>
        /// Gets the estimated total amount of time spent processing the current upgrade domain.
        /// </summary>
        public string UpgradeDomainDurationInMilliseconds { get; }

        /// <summary>
        /// Gets list of health evaluations that resulted in the current aggregated health state.
        /// </summary>
        public IEnumerable<HealthEvaluationWrapper> UnhealthyEvaluations { get; }

        /// <summary>
        /// Gets information about the current in-progress upgrade domain.
        /// </summary>
        public CurrentUpgradeDomainProgressInfo CurrentUpgradeDomainProgress { get; }

        /// <summary>
        /// Gets the estimated UTC datetime when the upgrade started.
        /// </summary>
        public string StartTimestampUtc { get; }

        /// <summary>
        /// Gets the estimated UTC datetime when the upgrade failed and FailureAction was executed.
        /// </summary>
        public string FailureTimestampUtc { get; }

        /// <summary>
        /// Gets the cause of an upgrade failure that resulted in FailureAction being executed. Possible values include:
        /// 'None', 'Interrupted', 'HealthCheck', 'UpgradeDomainTimeout', 'OverallUpgradeTimeout'
        /// </summary>
        public FailureReason? FailureReason { get; }

        /// <summary>
        /// Gets information about the upgrade domain progress at the time of upgrade failure.
        /// </summary>
        public FailureUpgradeDomainProgressInfo UpgradeDomainProgressAtFailure { get; }

        /// <summary>
        /// Gets additional detailed information about the status of the pending upgrade.
        /// </summary>
        public string UpgradeStatusDetails { get; }
    }
}
