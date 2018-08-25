// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Start upgrading the code or configuration version of a Service Fabric cluster.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SFClusterUpgrade", DefaultParameterSetName = "StartClusterUpgrade")]
    public partial class StartClusterUpgradeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets CodeVersion. The cluster code version.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "StartClusterUpgrade")]
        public string CodeVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ConfigVersion. The cluster configuration version.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "StartClusterUpgrade")]
        public string ConfigVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpgradeKind. The kind of upgrade out of the following possible values. Possible values include:
        /// 'Invalid', 'Rolling'
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "StartClusterUpgrade")]
        public UpgradeKind? UpgradeKind
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets RollingUpgradeMode. The mode used to monitor health during a rolling upgrade. The values are
        /// UnmonitoredAuto, UnmonitoredManual, and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto',
        /// 'UnmonitoredManual', 'Monitored'
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "StartClusterUpgrade")]
        public UpgradeMode? RollingUpgradeMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpgradeReplicaSetCheckTimeoutInSeconds. The maximum amount of time to block processing of an upgrade
        /// domain and prevent loss of availability when there are unexpected issues. When this timeout expires, processing of
        /// the upgrade domain will proceed regardless of availability loss issues. The timeout is reset at the start of each
        /// upgrade domain. Valid values are between 0 and 42949672925 inclusive. (unsigned 32-bit integer).
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "StartClusterUpgrade")]
        public long? UpgradeReplicaSetCheckTimeoutInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ForceRestart. If true, then processes are forcefully restarted during upgrade even when the code
        /// version has not changed (the upgrade only changes configuration or data).
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "StartClusterUpgrade")]
        public bool? ForceRestart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MonitoringPolicy. Describes the parameters for monitoring an upgrade in Monitored mode.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "StartClusterUpgrade")]
        public MonitoringPolicyDescription MonitoringPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ClusterHealthPolicy. Defines a health policy used to evaluate the health of the cluster or of a
        /// cluster node.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "StartClusterUpgrade")]
        public ClusterHealthPolicy ClusterHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets EnableDeltaHealthEvaluation. When true, enables delta health evaluation rather than absolute health
        /// evaluation after completion of each upgrade domain.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "StartClusterUpgrade")]
        public bool? EnableDeltaHealthEvaluation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ClusterUpgradeHealthPolicy. Defines a health policy used to evaluate the health of the cluster during
        /// a cluster upgrade.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "StartClusterUpgrade")]
        public ClusterUpgradeHealthPolicyObject ClusterUpgradeHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicyMap. Defines the application health policy map used to evaluate the health of
        /// an application or one of its children entities.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ParameterSetName = "StartClusterUpgrade")]
        public ApplicationHealthPolicies ApplicationHealthPolicyMap
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ParameterSetName = "StartClusterUpgrade")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var startClusterUpgradeDescription = new StartClusterUpgradeDescription(
                codeVersion: this.CodeVersion,
                configVersion: this.ConfigVersion,
                upgradeKind: this.UpgradeKind,
                rollingUpgradeMode: this.RollingUpgradeMode,
                upgradeReplicaSetCheckTimeoutInSeconds: this.UpgradeReplicaSetCheckTimeoutInSeconds,
                forceRestart: this.ForceRestart,
                monitoringPolicy: this.MonitoringPolicy,
                clusterHealthPolicy: this.ClusterHealthPolicy,
                enableDeltaHealthEvaluation: this.EnableDeltaHealthEvaluation,
                clusterUpgradeHealthPolicy: this.ClusterUpgradeHealthPolicy,
                applicationHealthPolicyMap: this.ApplicationHealthPolicyMap);

                this.ServiceFabricClient.Cluster.StartClusterUpgradeAsync(
                    startClusterUpgradeDescription: startClusterUpgradeDescription,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
