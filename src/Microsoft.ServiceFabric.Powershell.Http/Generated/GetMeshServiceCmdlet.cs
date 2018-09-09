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
    /// Gets all the services in the application resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshService", DefaultParameterSetName = "GetMeshServices")]
    public partial class GetMeshServiceCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ApplicationResourceName. Service Fabric application resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshServices")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshService")]
        public string ApplicationResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceResourceName. Service Fabric service resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "GetMeshService")]
        public string ServiceResourceName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            if (this.ParameterSetName.Equals("GetMeshServices"))
            {
                var continuationToken = ContinuationToken.Empty;
                do
                {
                    var result = this.ServiceFabricClient.MeshApplications.GetMeshServicesAsync(
                        applicationResourceName: this.ApplicationResourceName,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                    var count = 0;
                    foreach (var item in result.Data)
                    {
                        count++;
                        this.WriteObject(this.FormatOutput(item));
                    }

                    continuationToken = result.ContinuationToken;
                    this.WriteDebug(string.Format(Resource.MsgCountAndContinuationToken, count, continuationToken));
                }
                while (continuationToken.Next);
            }
            else if (this.ParameterSetName.Equals("GetMeshService"))
            {
                var result = this.ServiceFabricClient.MeshApplications.GetMeshServiceAsync(
                    applicationResourceName: this.ApplicationResourceName,
                    serviceResourceName: this.ServiceResourceName,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
            }
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
