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
    /// Gets all the gateway resources in the application.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshGateways", DefaultParameterSetName = "GetMeshGateways")]
    public partial class GetMeshGatewaysCmdlet : CommonCmdletBase
    {
        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var result = this.ServiceFabricClient.MeshGateways.GetMeshGatewaysAsync().GetAwaiter().GetResult();

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
