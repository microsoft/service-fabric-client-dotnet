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
    /// Restarts a service replica of a persisted service running on a node.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Restart, "SFReplica", DefaultParameterSetName = "RestartReplica")]
    public partial class RestartReplicaCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NodeName. The name of the node.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "RestartReplica")]
        public NodeName NodeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets PartitionId. The identity of the partition.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = "RestartReplica")]
        public PartitionId PartitionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ReplicaId. The identifier of the replica.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, ParameterSetName = "RestartReplica")]
        public ReplicaId ReplicaId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "RestartReplica")]
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
                this.ServiceFabricClient.Replicas.RestartReplicaAsync(
                    nodeName: this.NodeName,
                    partitionId: this.PartitionId,
                    replicaId: this.ReplicaId,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
