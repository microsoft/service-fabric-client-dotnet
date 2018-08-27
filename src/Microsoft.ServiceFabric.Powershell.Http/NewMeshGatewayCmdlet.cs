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
    /// Creates mesh gateway resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFMeshGateway")]
    public class NewMeshGatewayCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets the json file containing the description of the gateway to be created.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string DescriptionFile { get; set; }

        /// <summary>
        /// Gets or sets Gateway name to create.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string GatewayResourceName { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var applicationResourceInfo = client.MeshGateways.GetMeshGatewayAsync(this.GatewayResourceName, this.CancellationToken).GetAwaiter().GetResult();

            if (applicationResourceInfo != null)
            {
                throw new InvalidOperationException("Specified mesh gateway already exists in cluster. If you want to update it use Update-SFMeshNetwork");
            }

            client.MeshGateways.CreateOrUpdateMeshGatewayAsync(
                gatewayResourceName: this.GatewayResourceName,
                descriptionFile: this.DescriptionFile,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
