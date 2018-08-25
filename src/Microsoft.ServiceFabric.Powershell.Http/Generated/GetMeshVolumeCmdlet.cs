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
    /// Gets the volume resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshVolume", DefaultParameterSetName = "GetMeshVolume")]
    public partial class GetMeshVolumeCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets VolumeResourceName. Service Fabric volume resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshVolume")]
        public string VolumeResourceName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var result = this.ServiceFabricClient.MeshVolumes.GetMeshVolumeAsync(
                    volumeResourceName: this.VolumeResourceName,
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
