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
    /// Gets the gateway resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshGateway", DefaultParameterSetName = "GetMeshGateway")]
    public partial class GetMeshGatewayCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets GatewayResourceName. The identity of the gateway.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshGateway")]
        public string GatewayResourceName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var result = this.ServiceFabricClient.MeshGateways.GetMeshGatewayAsync(
                    gatewayResourceName: this.GatewayResourceName,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
