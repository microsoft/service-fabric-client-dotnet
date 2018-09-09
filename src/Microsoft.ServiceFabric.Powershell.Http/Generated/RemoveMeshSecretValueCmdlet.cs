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
    /// Deletes the specified  value of the named secret resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "SFMeshSecretValue", DefaultParameterSetName = "DeleteMeshSecretValue")]
    public partial class RemoveMeshSecretValueCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets SecretResourceName. The name of the secret resource.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "DeleteMeshSecretValue")]
        public string SecretResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets SecretValueResourceName. The name of the secret resource value which is typically the version
        /// identifier for the value.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "DeleteMeshSecretValue")]
        public string SecretValueResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the force flag. If provided, then the destructive action will be performed without asking for
        /// confirmation prompt.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "DeleteMeshSecretValue")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            if (((this.Force != null) && this.Force) || this.ShouldContinue(string.Empty, string.Empty))
            {
                this.ServiceFabricClient.MeshSecretValues.DeleteMeshSecretValueAsync(
                    secretResourceName: this.SecretResourceName,
                    secretValueResourceName: this.SecretValueResourceName,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
        }
    }
}
