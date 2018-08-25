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
    /// Starts upgrading an application in the Service Fabric cluster.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SFApplicationUpgrade", DefaultParameterSetName = "StartApplicationUpgrade")]
    public partial class StartApplicationUpgradeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ApplicationId. The identity of the application. This is typically the full name of the application
        /// without the 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the application name is "fabric:/myapp/app1", the application identity would be "myapp~app1" in
        /// 6.0+ and "myapp/app1" in previous versions.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "StartApplicationUpgrade")]
        public string ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Name. The name of the target application, including the 'fabric:' URI scheme.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "StartApplicationUpgrade")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets TargetApplicationTypeVersion. The target application type version (found in the application manifest)
        /// for the application upgrade.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "StartApplicationUpgrade")]
        public string TargetApplicationTypeVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Parameters. List of application parameters with overridden values from their default values specified
        /// in the application manifest.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "StartApplicationUpgrade")]
        public IReadOnlyDictionary<string, string> Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpgradeKind. The kind of upgrade out of the following possible values. Possible values include:
        /// 'Invalid', 'Rolling'
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = "StartApplicationUpgrade")]
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
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "StartApplicationUpgrade")]
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
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "StartApplicationUpgrade")]
        public long? UpgradeReplicaSetCheckTimeoutInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ForceRestart. If true, then processes are forcefully restarted during upgrade even when the code
        /// version has not changed (the upgrade only changes configuration or data).
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "StartApplicationUpgrade")]
        public bool? ForceRestart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MonitoringPolicy. Describes the parameters for monitoring an upgrade in Monitored mode.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "StartApplicationUpgrade")]
        public MonitoringPolicyDescription MonitoringPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicy. Defines a health policy used to evaluate the health of an application or one
        /// of its children entities.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "StartApplicationUpgrade")]
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
        [Parameter(Mandatory = false, Position = 10, ParameterSetName = "StartApplicationUpgrade")]
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
                var applicationUpgradeDescription = new ApplicationUpgradeDescription(
                name: this.Name,
                targetApplicationTypeVersion: this.TargetApplicationTypeVersion,
                parameters: this.Parameters,
                upgradeKind: this.UpgradeKind,
                rollingUpgradeMode: this.RollingUpgradeMode,
                upgradeReplicaSetCheckTimeoutInSeconds: this.UpgradeReplicaSetCheckTimeoutInSeconds,
                forceRestart: this.ForceRestart,
                monitoringPolicy: this.MonitoringPolicy,
                applicationHealthPolicy: this.ApplicationHealthPolicy);

                this.ServiceFabricClient.Applications.StartApplicationUpgradeAsync(
                    applicationId: this.ApplicationId,
                    applicationUpgradeDescription: applicationUpgradeDescription,
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
