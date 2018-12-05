// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Uploads application package to image store.
    /// </summary>
    [Cmdlet(VerbsCommon.Copy, "SFApplicationPackage")]
    public partial class CopyApplicationPackageCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets the application package path.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0)]
        public string ApplicationPackagePath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the application package path in image store.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string ApplicationPackagePathInImageStore
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                this.ServiceFabricClient.ImageStore.UploadApplicationPackageAsync(this.ApplicationPackagePath, false, this.ApplicationPackagePathInImageStore, this.CancellationToken).GetAwaiter().GetResult();
                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
