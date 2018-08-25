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
    /// Update the upgrade parameters of a Service Fabric cluster upgrade.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFClusterUpgrade", DefaultParameterSetName = "UpdateClusterUpgrade")]
    public partial class UpdateClusterUpgradeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets UpgradeKind. The type of upgrade out of the following possible values. Possible values include:
        /// 'Invalid', 'Rolling', 'Rolling_ForceRestart'
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "UpdateClusterUpgrade")]
        public UpgradeType? UpgradeKind
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpdateDescription. Describes the parameters for updating a rolling upgrade of application or cluster.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "UpdateClusterUpgrade")]
        public RollingUpgradeUpdateDescription UpdateDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ClusterHealthPolicy. Defines a health policy used to evaluate the health of the cluster or of a
        /// cluster node.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "UpdateClusterUpgrade")]
        public ClusterHealthPolicy ClusterHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets EnableDeltaHealthEvaluation. When true, enables delta health evaluation rather than absolute health
        /// evaluation after completion of each upgrade domain.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "UpdateClusterUpgrade")]
        public bool? EnableDeltaHealthEvaluation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ClusterUpgradeHealthPolicy. Defines a health policy used to evaluate the health of the cluster during
        /// a cluster upgrade.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "UpdateClusterUpgrade")]
        public ClusterUpgradeHealthPolicyObject ClusterUpgradeHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicyMap. Defines the application health policy map used to evaluate the health of
        /// an application or one of its children entities.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "UpdateClusterUpgrade")]
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
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "UpdateClusterUpgrade")]
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
                var updateClusterUpgradeDescription = new UpdateClusterUpgradeDescription(
                upgradeKind: this.UpgradeKind,
                updateDescription: this.UpdateDescription,
                clusterHealthPolicy: this.ClusterHealthPolicy,
                enableDeltaHealthEvaluation: this.EnableDeltaHealthEvaluation,
                clusterUpgradeHealthPolicy: this.ClusterUpgradeHealthPolicy,
                applicationHealthPolicyMap: this.ApplicationHealthPolicyMap);

                this.ServiceFabricClient.Cluster.UpdateClusterUpgradeAsync(
                    updateClusterUpgradeDescription: updateClusterUpgradeDescription,
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
