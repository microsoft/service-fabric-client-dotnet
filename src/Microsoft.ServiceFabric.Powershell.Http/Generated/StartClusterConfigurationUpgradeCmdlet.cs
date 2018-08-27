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
    /// Start upgrading the configuration of a Service Fabric standalone cluster.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SFClusterConfigurationUpgrade", DefaultParameterSetName = "StartClusterConfigurationUpgrade")]
    public partial class StartClusterConfigurationUpgradeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ClusterConfig. The cluster configuration.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public string ClusterConfig
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets HealthCheckRetryTimeout. The length of time between attempts to perform a health checks if the
        /// application or cluster is not healthy.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public TimeSpan? HealthCheckRetryTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets HealthCheckWaitDurationInSeconds. The length of time to wait after completing an upgrade domain before
        /// starting the health checks process.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public TimeSpan? HealthCheckWaitDurationInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets HealthCheckStableDurationInSeconds. The length of time that the application or cluster must remain
        /// healthy.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public TimeSpan? HealthCheckStableDurationInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpgradeDomainTimeoutInSeconds. The timeout for the upgrade domain.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public TimeSpan? UpgradeDomainTimeoutInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpgradeTimeoutInSeconds. The upgrade timeout.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public TimeSpan? UpgradeTimeoutInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxPercentUnhealthyApplications. The maximum allowed percentage of unhealthy applications during the
        /// upgrade. Allowed values are integer values from zero to 100.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public int? MaxPercentUnhealthyApplications
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxPercentUnhealthyNodes. The maximum allowed percentage of unhealthy nodes during the upgrade.
        /// Allowed values are integer values from zero to 100.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public int? MaxPercentUnhealthyNodes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxPercentDeltaUnhealthyNodes. The maximum allowed percentage of delta health degradation during the
        /// upgrade. Allowed values are integer values from zero to 100.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public int? MaxPercentDeltaUnhealthyNodes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxPercentUpgradeDomainDeltaUnhealthyNodes. The maximum allowed percentage of upgrade domain delta
        /// health degradation during the upgrade. Allowed values are integer values from zero to 100.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public int? MaxPercentUpgradeDomainDeltaUnhealthyNodes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicies. Defines the application health policy map used to evaluate the health of an
        /// application or one of its children entities.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ParameterSetName = "StartClusterConfigurationUpgrade")]
        public ApplicationHealthPolicies ApplicationHealthPolicies
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ParameterSetName = "StartClusterConfigurationUpgrade")]
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
                var clusterConfigurationUpgradeDescription = new ClusterConfigurationUpgradeDescription(
                clusterConfig: this.ClusterConfig,
                healthCheckRetryTimeout: this.HealthCheckRetryTimeout,
                healthCheckWaitDurationInSeconds: this.HealthCheckWaitDurationInSeconds,
                healthCheckStableDurationInSeconds: this.HealthCheckStableDurationInSeconds,
                upgradeDomainTimeoutInSeconds: this.UpgradeDomainTimeoutInSeconds,
                upgradeTimeoutInSeconds: this.UpgradeTimeoutInSeconds,
                maxPercentUnhealthyApplications: this.MaxPercentUnhealthyApplications,
                maxPercentUnhealthyNodes: this.MaxPercentUnhealthyNodes,
                maxPercentDeltaUnhealthyNodes: this.MaxPercentDeltaUnhealthyNodes,
                maxPercentUpgradeDomainDeltaUnhealthyNodes: this.MaxPercentUpgradeDomainDeltaUnhealthyNodes,
                applicationHealthPolicies: this.ApplicationHealthPolicies);

                this.ServiceFabricClient.Cluster.StartClusterConfigurationUpgradeAsync(
                    clusterConfigurationUpgradeDescription: clusterConfigurationUpgradeDescription,
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