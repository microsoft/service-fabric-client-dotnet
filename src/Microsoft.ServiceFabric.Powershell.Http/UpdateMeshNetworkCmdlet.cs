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
    /// Updates mesh network resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFMeshNetwork")]
    public class UpdateMeshNetworkCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets the json file containing the description of the network to be updated.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string DescriptionFile { get; set; }

        /// <summary>
        /// Gets or sets Network name to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string NetworkResourceName { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var applicationResourceInfo = client.MeshNetworks.GetMeshNetworkAsync(this.NetworkResourceName, cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            if (applicationResourceInfo == null)
            {
                throw new InvalidOperationException("Specified mesh network doesn't exists in cluster.");
            }

            client.MeshNetworks.CreateMeshNetworkAsync(
                networkResourceName: this.NetworkResourceName,
                descriptionFile: this.DescriptionFile,                
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
