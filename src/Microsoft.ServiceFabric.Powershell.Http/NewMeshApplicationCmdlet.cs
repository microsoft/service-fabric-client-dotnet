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
    /// Creates mesh application resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFMeshApplication")]
    public class NewMeshApplicationCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Application resource name to create.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string ApplicationResourceName { get; set; }

        /// <summary>
        /// Gets or sets the json containing the description of the application to be created.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string JsonDescription { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var applicationResourceInfo = client.MeshApplications.GetMeshApplicationAsync(this.ApplicationResourceName, this.CancellationToken).GetAwaiter().GetResult();

            if (applicationResourceInfo != null)
            {
                throw new InvalidOperationException("Specified mesh application already exists in cluster. If you want to update it use Update-SFMeshApplication");
            }

            client.MeshApplications.CreateOrUpdateMeshApplicationAsync(
                applicationResourceName: this.ApplicationResourceName,
                jsonDescription: this.JsonDescription,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
