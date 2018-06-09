// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a backup policy for configuring periodic backup.
    /// </summary>
    public partial class BackupPolicyDescription
    {
        /// <summary>
        /// Initializes a new instance of the BackupPolicyDescription class.
        /// </summary>
        /// <param name="name">The unique name identifying this backup policy.</param>
        /// <param name="autoRestoreOnDataLoss">Specifies whether to trigger restore automatically using the latest available
        /// backup in case the partition experiences a data loss event.</param>
        /// <param name="maxIncrementalBackups">Defines the maximum number of incremental backups to be taken between two full
        /// backups. This is just the upper limit. A full backup may be taken before specified number of incremental backups
        /// are completed in one of the following conditions
        /// - The replica has never taken a full backup since it has become primary,
        /// - Some of the log records since the last backup has been truncated, or
        /// - Replica passed the MaxAccumulatedBackupLogSizeInMB limit.
        /// </param>
        /// <param name="schedule">Describes the backup schedule parameters.</param>
        /// <param name="storage">Describes the details of backup storage where to store the periodic backups.</param>
        public BackupPolicyDescription(
            string name,
            bool? autoRestoreOnDataLoss,
            int? maxIncrementalBackups,
            BackupScheduleDescription schedule,
            BackupStorageDescription storage)
        {
            name.ThrowIfNull(nameof(name));
            autoRestoreOnDataLoss.ThrowIfNull(nameof(autoRestoreOnDataLoss));
            maxIncrementalBackups.ThrowIfNull(nameof(maxIncrementalBackups));
            schedule.ThrowIfNull(nameof(schedule));
            storage.ThrowIfNull(nameof(storage));
            maxIncrementalBackups?.ThrowIfOutOfInclusiveRange("maxIncrementalBackups", 0, 255);
            this.Name = name;
            this.AutoRestoreOnDataLoss = autoRestoreOnDataLoss;
            this.MaxIncrementalBackups = maxIncrementalBackups;
            this.Schedule = schedule;
            this.Storage = storage;
        }

        /// <summary>
        /// Gets the unique name identifying this backup policy.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets specifies whether to trigger restore automatically using the latest available backup in case the partition
        /// experiences a data loss event.
        /// </summary>
        public bool? AutoRestoreOnDataLoss { get; }

        /// <summary>
        /// Gets defines the maximum number of incremental backups to be taken between two full backups. This is just the upper
        /// limit. A full backup may be taken before specified number of incremental backups are completed in one of the
        /// following conditions
        /// - The replica has never taken a full backup since it has become primary,
        /// - Some of the log records since the last backup has been truncated, or
        /// - Replica passed the MaxAccumulatedBackupLogSizeInMB limit.
        /// </summary>
        public int? MaxIncrementalBackups { get; }

        /// <summary>
        /// Gets describes the backup schedule parameters.
        /// </summary>
        public BackupScheduleDescription Schedule { get; }

        /// <summary>
        /// Gets describes the details of backup storage where to store the periodic backups.
        /// </summary>
        public BackupStorageDescription Storage { get; }
    }
}
