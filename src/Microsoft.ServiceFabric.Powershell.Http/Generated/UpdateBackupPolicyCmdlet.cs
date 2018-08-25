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
    /// Updates the backup policy.
    /// </summary>
    [Cmdlet(VerbsData.Update, "SFBackupPolicy", DefaultParameterSetName = "UpdateBackupPolicy")]
    public partial class UpdateBackupPolicyCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Name. The unique name identifying this backup policy.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "UpdateBackupPolicy")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets AutoRestoreOnDataLoss. Specifies whether to trigger restore automatically using the latest available
        /// backup in case the partition experiences a data loss event.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "UpdateBackupPolicy")]
        public bool? AutoRestoreOnDataLoss
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxIncrementalBackups. Defines the maximum number of incremental backups to be taken between two full
        /// backups. This is just the upper limit. A full backup may be taken before specified number of incremental backups
        /// are completed in one of the following conditions
        /// - The replica has never taken a full backup since it has become primary,
        /// - Some of the log records since the last backup has been truncated, or
        /// - Replica passed the MaxAccumulatedBackupLogSizeInMB limit.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "UpdateBackupPolicy")]
        public int? MaxIncrementalBackups
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Schedule. Describes the backup schedule parameters.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "UpdateBackupPolicy")]
        public BackupScheduleDescription Schedule
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Storage. Describes the details of backup storage where to store the periodic backups.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ParameterSetName = "UpdateBackupPolicy")]
        public BackupStorageDescription Storage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupPolicyName. The name of the backup policy.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5, ParameterSetName = "UpdateBackupPolicy")]
        public string BackupPolicyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "UpdateBackupPolicy")]
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
                var backupPolicyDescription = new BackupPolicyDescription(
                name: this.Name,
                autoRestoreOnDataLoss: this.AutoRestoreOnDataLoss,
                maxIncrementalBackups: this.MaxIncrementalBackups,
                schedule: this.Schedule,
                storage: this.Storage);

                this.ServiceFabricClient.BackupRestore.UpdateBackupPolicyAsync(
                    backupPolicyDescription: backupPolicyDescription,
                    backupPolicyName: this.BackupPolicyName,
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
