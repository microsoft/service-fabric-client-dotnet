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
    /// Gets the list of replicas deployed on a Service Fabric node.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFDeployedServiceReplicaInfoList", DefaultParameterSetName = "GetDeployedServiceReplicaInfoList")]
    public partial class GetDeployedServiceReplicaInfoListCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NodeName. The name of the node.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "GetDeployedServiceReplicaInfoList")]
        public NodeName NodeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationId. The identity of the application. This is typically the full name of the application
        /// without the 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the application name is "fabric:/myapp/app1", the application identity would be "myapp~app1" in
        /// 6.0+ and "myapp/app1" in previous versions.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = "GetDeployedServiceReplicaInfoList")]
        public string ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets PartitionId. The identity of the partition.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "GetDeployedServiceReplicaInfoList")]
        public PartitionId PartitionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServiceManifestName. The name of a service manifest registered as part of an application type in a
        /// Service Fabric cluster.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "GetDeployedServiceReplicaInfoList")]
        public string ServiceManifestName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "GetDeployedServiceReplicaInfoList")]
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
                var result = this.ServiceFabricClient.Replicas.GetDeployedServiceReplicaInfoListAsync(
                    nodeName: this.NodeName,
                    applicationId: this.ApplicationId,
                    partitionId: this.PartitionId,
                    serviceManifestName: this.ServiceManifestName,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                foreach (var item in result)
                {
                    this.WriteObject(this.FormatOutput(item));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
