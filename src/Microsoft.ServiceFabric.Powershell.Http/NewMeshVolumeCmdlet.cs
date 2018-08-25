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
    /// Creates mesh volume resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFVolumeResource")]
    public class NewMeshVolumeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets volume name to create.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string VolumeResourceName { get; set; }

        /// <summary>
        /// Gets or sets the json file containing the description of the volume to be created.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string DescriptionFile { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var volumeResourceInfo = client.MeshVolumes.GetMeshVolumeAsync(this.VolumeResourceName, cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            if (volumeResourceInfo != null)
            {
                throw new InvalidOperationException("Specified volume resource already exists in cluster. If you want to update it use Update-ServiceFabricVolumeResource");
            }

            client.MeshVolumes.CreateMeshVolumeAsync(
                volumeResourceName: this.VolumeResourceName,
                descriptionFile: this.DescriptionFile,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}
