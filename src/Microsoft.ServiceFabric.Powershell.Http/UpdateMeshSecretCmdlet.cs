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
    /// Updates mesh secret resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFMeshSecret")]
    public class UpdateMeshSecretCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Secret name to update.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string SecretResourceName { get; set; }

        /// <summary>
        /// Gets or sets the json containing the description of the secret to be updated.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string JsonDescription { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var applicationResourceInfo = client.MeshSecrets.GetMeshSecretAsync(this.SecretResourceName, this.CancellationToken).GetAwaiter().GetResult();

            if (applicationResourceInfo == null)
            {
                throw new InvalidOperationException("Specified mesh secret doesn't exists in cluster.");
            }

            client.MeshSecrets.CreateOrUpdateMeshSecretAsync(
                secretResourceName: this.SecretResourceName,
                jsonDescription: this.JsonDescription,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
