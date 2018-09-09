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
    /// Gets the application with the given name.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshApplication", DefaultParameterSetName = "GetMeshApplication")]
    public partial class GetMeshApplicationCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ApplicationResourceName. Service Fabric application resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshApplication")]
        public string ApplicationResourceName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            var result = this.ServiceFabricClient.MeshApplications.GetMeshApplicationAsync(
                applicationResourceName: this.ApplicationResourceName,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            this.WriteObject(this.FormatOutput(result));
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
