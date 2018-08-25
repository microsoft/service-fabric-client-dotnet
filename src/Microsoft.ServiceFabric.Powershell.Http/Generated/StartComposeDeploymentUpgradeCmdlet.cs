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
    /// Starts upgrading a compose deployment in the Service Fabric cluster.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SFComposeDeploymentUpgrade", DefaultParameterSetName = "StartComposeDeploymentUpgrade")]
    public partial class StartComposeDeploymentUpgradeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets DeploymentName. The identity of the deployment.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public string DeploymentName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ComposeFileContent. The content of the compose file that describes the deployment to create.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public string ComposeFileContent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpgradeKind. The kind of upgrade out of the following possible values. Possible values include:
        /// 'Invalid', 'Rolling'
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public UpgradeKind? UpgradeKind
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets RegistryCredential. Credential information to connect to container registry.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public RegistryCredential RegistryCredential
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets RollingUpgradeMode. The mode used to monitor health during a rolling upgrade. The values are
        /// UnmonitoredAuto, UnmonitoredManual, and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto',
        /// 'UnmonitoredManual', 'Monitored'
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "StartComposeDeploymentUpgrade")]
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
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public long? UpgradeReplicaSetCheckTimeoutInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ForceRestart. If true, then processes are forcefully restarted during upgrade even when the code
        /// version has not changed (the upgrade only changes configuration or data).
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public bool? ForceRestart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MonitoringPolicy. Describes the parameters for monitoring an upgrade in Monitored mode.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public MonitoringPolicyDescription MonitoringPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicy. Defines a health policy used to evaluate the health of an application or one
        /// of its children entities.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "StartComposeDeploymentUpgrade")]
        public ApplicationHealthPolicy ApplicationHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "StartComposeDeploymentUpgrade")]
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
                var composeDeploymentUpgradeDescription = new ComposeDeploymentUpgradeDescription(
                deploymentName: this.DeploymentName,
                composeFileContent: this.ComposeFileContent,
                upgradeKind: this.UpgradeKind,
                registryCredential: this.RegistryCredential,
                rollingUpgradeMode: this.RollingUpgradeMode,
                upgradeReplicaSetCheckTimeoutInSeconds: this.UpgradeReplicaSetCheckTimeoutInSeconds,
                forceRestart: this.ForceRestart,
                monitoringPolicy: this.MonitoringPolicy,
                applicationHealthPolicy: this.ApplicationHealthPolicy);

                this.ServiceFabricClient.ComposeDeployments.StartComposeDeploymentUpgradeAsync(
                    deploymentName: this.DeploymentName,
                    composeDeploymentUpgradeDescription: composeDeploymentUpgradeDescription,
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
