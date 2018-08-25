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
    /// Triggers backup of the partition's state.
    /// </summary>
    [Cmdlet(VerbsData.Backup, "SFPartition", DefaultParameterSetName = "BackupPartition")]
    public partial class BackupPartitionCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets PartitionId. The identity of the partition.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "BackupPartition")]
        public PartitionId PartitionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupStorage. Specifies the details of the backup storage where to save the backup.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "BackupPartition")]
        public BackupStorageDescription BackupStorage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupTimeout. Specifies the maximum amount of time, in minutes, to wait for the backup operation to
        /// complete. Post that, the operation completes with timeout error. However, in certain corner cases it could be that
        /// though the operation returns back timeout, the backup actually goes through. In case of timeout error, its
        /// recommended to invoke this operation again with a greater timeout value. The default value for the same is 10
        /// minutes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "BackupPartition")]
        public int? BackupTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "BackupPartition")]
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
                var backupPartitionDescription = new BackupPartitionDescription(
                backupStorage: this.BackupStorage);

                this.ServiceFabricClient.BackupRestore.BackupPartitionAsync(
                    partitionId: this.PartitionId,
                    backupPartitionDescription: backupPartitionDescription,
                    backupTimeout: this.BackupTimeout,
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
