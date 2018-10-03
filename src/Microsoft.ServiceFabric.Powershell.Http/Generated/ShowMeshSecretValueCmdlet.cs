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
    /// Lists the specified value of the secret resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "SFMeshSecretValue", DefaultParameterSetName = "Show")]
    public partial class ShowMeshSecretValueCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets SecretResourceName. The name of the secret resource.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Show")]
        public string SecretResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets SecretValueResourceName. The name of the secret resource value which is typically the version
        /// identifier for the value.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Show")]
        public string SecretValueResourceName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            var result = this.ServiceFabricClient.MeshSecretValues.ShowAsync(
                secretResourceName: this.SecretResourceName,
                secretValueResourceName: this.SecretValueResourceName,
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
