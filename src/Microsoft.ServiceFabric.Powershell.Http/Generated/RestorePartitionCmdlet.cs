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
    /// Triggers restore of the state of the partition using the specified restore partition description.
    /// </summary>
    [Cmdlet(VerbsData.Restore, "SFPartition", DefaultParameterSetName = "RestorePartition")]
    public partial class RestorePartitionCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets PartitionId. The identity of the partition.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "RestorePartition")]
        public PartitionId PartitionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupId. Unique backup ID.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "RestorePartition")]
        public Guid? BackupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupLocation. Location of the backup relative to the backup storage specified/ configured.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "RestorePartition")]
        public string BackupLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupStorage. Location of the backup from where the partition will be restored.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "RestorePartition")]
        public BackupStorageDescription BackupStorage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets RestoreTimeout. Specifies the maximum amount of time to wait, in minutes, for the restore operation to
        /// complete. Post that, the operation returns back with timeout error. However, in certain corner cases it could be
        /// that the restore operation goes through even though it completes with timeout. In case of timeout error, its
        /// recommended to invoke this operation again with a greater timeout value. the default value for the same is 10
        /// minutes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "RestorePartition")]
        public int? RestoreTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "RestorePartition")]
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
                var restorePartitionDescription = new RestorePartitionDescription(
                backupId: this.BackupId,
                backupLocation: this.BackupLocation,
                backupStorage: this.BackupStorage);

                this.ServiceFabricClient.BackupRestore.RestorePartitionAsync(
                    partitionId: this.PartitionId,
                    restorePartitionDescription: restorePartitionDescription,
                    restoreTimeout: this.RestoreTimeout,
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
