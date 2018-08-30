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
    /// Creates mesh network resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFMeshNetwork")]
    public class NewMeshNetworkCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Network name to create.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string NetworkResourceName { get; set; }

        /// <summary>
        /// Gets or sets the json containing the description of the network to be created.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string JsonDescription { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var applicationResourceInfo = client.MeshNetworks.GetMeshNetworkAsync(this.NetworkResourceName, cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            if (applicationResourceInfo != null)
            {
                throw new InvalidOperationException("Specified mesh network already exists in cluster. If you want to update it use Update-SFMeshNetwork");
            }

            client.MeshNetworks.CreateOrUpdateMeshNetworkAsync(
                networkResourceName: this.NetworkResourceName,
                jsonDescription: this.JsonDescription,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
