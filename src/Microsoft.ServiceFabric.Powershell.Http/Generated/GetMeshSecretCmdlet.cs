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
    /// Gets the secret resource with the specified name.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshSecret", DefaultParameterSetName = "GetMeshSecret")]
    public partial class GetMeshSecretCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets SecretResourceName. The name of the secret resource.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshSecret")]
        public string SecretResourceName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            var result = this.ServiceFabricClient.MeshSecrets.GetMeshSecretAsync(
                secretResourceName: this.SecretResourceName,
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
