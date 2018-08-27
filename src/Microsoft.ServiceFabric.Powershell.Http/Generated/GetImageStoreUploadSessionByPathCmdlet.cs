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
    /// Get the image store upload session by relative path.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFImageStoreUploadSessionByPath", DefaultParameterSetName = "GetImageStoreUploadSessionByPath")]
    public partial class GetImageStoreUploadSessionByPathCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ContentPath. Relative path to file or folder in the image store from its root.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetImageStoreUploadSessionByPath")]
        public string ContentPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "GetImageStoreUploadSessionByPath")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var result = this.ServiceFabricClient.ImageStore.GetImageStoreUploadSessionByPathAsync(
                    contentPath: this.ContentPath,
                    serverTimeout: this.ServerTimeout,
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