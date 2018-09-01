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
        /// Gets or sets AzureBlobStore flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "RestorePartition")]
        public SwitchParameter AzureBlobStore
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets FileShare flag
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "RestorePartition")]
        public SwitchParameter FileShare
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets PartitionId. The identity of the partition.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, ParameterSetName = "RestorePartition")]
        public PartitionId PartitionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupId. Unique backup ID.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "RestorePartition")]
        public Guid? BackupId { get; set; }

        /// <summary>
        /// Gets or sets BackupLocation. Location of the backup relative to the backup storage specified/ configured.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "RestorePartition")]
        public string BackupLocation { get; set; }

        /// <summary>
        /// Gets or sets ConnectionString. The connection string to connect to the Azure blob store.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = "RestorePartition")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets ContainerName. The name of the container in the blob store to store and enumerate backups from.
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, ParameterSetName = "RestorePartition")]
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets Path. UNC path of the file share where to store or enumerate backups from.
        /// </summary>
        [Parameter(Mandatory = true, Position = 6, ParameterSetName = "RestorePartition")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets FriendlyName. Friendly name for this backup storage.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "RestorePartition")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets PrimaryUserName. Primary user name to access the file share.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "RestorePartition")]
        public string PrimaryUserName { get; set; }

        /// <summary>
        /// Gets or sets PrimaryPassword. Primary password to access the share location.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "RestorePartition")]
        public string PrimaryPassword { get; set; }

        /// <summary>
        /// Gets or sets SecondaryUserName. Secondary user name to access the file share.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ParameterSetName = "RestorePartition")]
        public string SecondaryUserName { get; set; }

        /// <summary>
        /// Gets or sets SecondaryPassword. Secondary password to access the share location
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ParameterSetName = "RestorePartition")]
        public string SecondaryPassword { get; set; }

        /// <summary>
        /// Gets or sets RestoreTimeout. Specifies the maximum amount of time to wait, in minutes, for the restore operation to
        /// complete. Post that, the operation returns back with timeout error. However, in certain corner cases it could be
        /// that the restore operation goes through even though it completes with timeout. In case of timeout error, its
        /// recommended to invoke this operation again with a greater timeout value. the default value for the same is 10
        /// minutes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ParameterSetName = "RestorePartition")]
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
        [Parameter(Mandatory = false, Position = 13, ParameterSetName = "RestorePartition")]
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
                BackupStorageDescription backupStorageDescription = null;
                if (this.AzureBlobStore.IsPresent)
                {
                    backupStorageDescription = new AzureBlobBackupStorageDescription(
                        connectionString: this.ConnectionString,
                        containerName: this.ContainerName,
                        friendlyName: this.FriendlyName);
                }
                else if (this.FileShare.IsPresent)
                {
                    backupStorageDescription = new FileShareBackupStorageDescription(
                        path: this.Path,
                        friendlyName: this.FriendlyName,
                        primaryUserName: this.PrimaryUserName,
                        primaryPassword: this.PrimaryPassword,
                        secondaryUserName: this.SecondaryUserName,
                        secondaryPassword: this.SecondaryPassword);
                }

                var restorePartitionDescription = new RestorePartitionDescription(
                backupId: this.BackupId,
                backupLocation: this.BackupLocation,
                backupStorage: backupStorageDescription);

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
