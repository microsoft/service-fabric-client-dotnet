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
    /// Updates an ongoing application upgrade in the Service Fabric cluster.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFApplicationUpgrade", DefaultParameterSetName = "UpdateApplicationUpgrade")]
    public partial class UpdateApplicationUpgradeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ApplicationId. The identity of the application. This is typically the full name of the application
        /// without the 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the application name is "fabric:/myapp/app1", the application identity would be "myapp~app1" in
        /// 6.0+ and "myapp/app1" in previous versions.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "UpdateApplicationUpgrade")]
        public string ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Name. The name of the application, including the 'fabric:' URI scheme.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "UpdateApplicationUpgrade")]
        public ApplicationName Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpgradeKind. The kind of upgrade out of the following possible values. Possible values include:
        /// 'Invalid', 'Rolling'
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "UpdateApplicationUpgrade")]
        public UpgradeKind? UpgradeKind
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicy. Defines a health policy used to evaluate the health of an application or one
        /// of its children entities.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "UpdateApplicationUpgrade")]
        public ApplicationHealthPolicy ApplicationHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets UpdateDescription. Describes the parameters for updating a rolling upgrade of application or cluster.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "UpdateApplicationUpgrade")]
        public RollingUpgradeUpdateDescription UpdateDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "UpdateApplicationUpgrade")]
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
                var applicationUpgradeUpdateDescription = new ApplicationUpgradeUpdateDescription(
                name: this.Name,
                upgradeKind: this.UpgradeKind,
                applicationHealthPolicy: this.ApplicationHealthPolicy,
                updateDescription: this.UpdateDescription);

                this.ServiceFabricClient.Applications.UpdateApplicationUpgradeAsync(
                    applicationId: this.ApplicationId,
                    applicationUpgradeUpdateDescription: applicationUpgradeUpdateDescription,
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
