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
    /// Updates mesh gateway resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFMeshGateway")]
    public class UpdateMeshGatewayCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Gateway name to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string GatewayResourceName { get; set; }

        /// <summary>
        /// Gets or sets the json containing the description of the gateway to be updated.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string JsonDescription { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var applicationResourceInfo = client.MeshGateways.GetMeshGatewayAsync(this.GatewayResourceName, this.CancellationToken).GetAwaiter().GetResult();

            if (applicationResourceInfo == null)
            {
                throw new InvalidOperationException("Specified mesh gateway doesn't exists in cluster.");
            }

            client.MeshGateways.CreateOrUpdateMeshGatewayAsync(
                gatewayResourceName: this.GatewayResourceName,
                jsonDescription: this.JsonDescription,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
