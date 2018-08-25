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
    /// Gets replicas of a given service in an applciation resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshReplica", DefaultParameterSetName = "GetMeshReplicas")]
    public partial class GetMeshReplicaCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets ApplicationResourceName. Service Fabric application resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshReplicas")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshReplica")]
        public string ApplicationResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceResourceName. Service Fabric service resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "GetMeshReplicas")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "GetMeshReplica")]
        public string ServiceResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ReplicaName. Service Fabric replica name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "GetMeshReplica")]
        public string ReplicaName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                if (this.ParameterSetName.Equals("GetMeshReplicas"))
                {
                    var continuationToken = ContinuationToken.Empty;
                    do
                    {
                        var result = this.ServiceFabricClient.MeshApplications.GetMeshReplicasAsync(
                            applicationResourceName: this.ApplicationResourceName,
                            serviceResourceName: this.ServiceResourceName,
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
                else if (this.ParameterSetName.Equals("GetMeshReplica"))
                {
                    var result = this.ServiceFabricClient.MeshApplications.GetMeshReplicaAsync(
                        applicationResourceName: this.ApplicationResourceName,
                        serviceResourceName: this.ServiceResourceName,
                        replicaName: this.ReplicaName,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                    this.WriteObject(this.FormatOutput(result));
                }
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
