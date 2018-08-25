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
    /// Deletes the volume resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "SFMeshVolume", DefaultParameterSetName = "DeleteMeshVolume")]
    public partial class RemoveMeshVolumeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets VolumeResourceName. Service Fabric volume resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "DeleteMeshVolume")]
        public string VolumeResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the force flag. If provided, then the destructive action will be performed without asking for
        /// confirmation prompt.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "DeleteMeshVolume")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                if (((this.Force != null) && this.Force) || this.ShouldContinue(string.Empty, string.Empty))
                {
                    this.ServiceFabricClient.MeshVolumes.DeleteMeshVolumeAsync(
                        volumeResourceName: this.VolumeResourceName,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                    Console.WriteLine("Success!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
