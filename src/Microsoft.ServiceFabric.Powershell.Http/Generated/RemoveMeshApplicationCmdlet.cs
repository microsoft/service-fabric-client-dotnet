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
    /// Deletes the specified application.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "SFMeshApplication", DefaultParameterSetName = "DeleteMeshApplication")]
    public partial class RemoveMeshApplicationCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ApplicationResourceName. Service Fabric application resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "DeleteMeshApplication")]
        public string ApplicationResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the force flag. If provided, then the destructive action will be performed without asking for
        /// confirmation prompt.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "DeleteMeshApplication")]
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
                this.ServiceFabricClient.MeshApplications.DeleteMeshApplicationAsync(
                    applicationResourceName: this.ApplicationResourceName,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
        }
    }
}
