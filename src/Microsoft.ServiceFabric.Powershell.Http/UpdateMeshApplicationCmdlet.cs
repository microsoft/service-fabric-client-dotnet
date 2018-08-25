// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Client;

    /// <summary>
    /// Updates mesh application resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFMeshApplication")]
    public class UpdateMeshApplicationCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets the json file containing the description of the application to be updated.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string DescriptionFile { get; set; }

        /// <summary>
        /// Gets or sets Application name to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string ApplicationResourceName { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var applicationResourceInfo = client.MeshApplications.GetMeshApplicationAsync(this.ApplicationResourceName, this.CancellationToken).GetAwaiter().GetResult();

            if (applicationResourceInfo == null)
            {
                throw new InvalidOperationException("Specified mesh application doesn't exist in cluster.");
            }

            client.MeshApplications.CreateMeshApplicationAsync(
                applicationResourceName: this.ApplicationResourceName,
                descriptionFile: this.DescriptionFile,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
