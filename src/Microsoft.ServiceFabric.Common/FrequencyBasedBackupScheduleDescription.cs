// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes the frequency based backup schedule.
    /// </summary>
    public partial class FrequencyBasedBackupScheduleDescription : BackupScheduleDescription
    {
        /// <summary>
        /// Initializes a new instance of the FrequencyBasedBackupScheduleDescription class.
        /// </summary>
        /// <param name="intervalType">Describes the backup schedule interval type with which to take periodic backups.
        /// . Possible values include: 'Invalid', 'Hours', 'Minutes'</param>
        /// <param name="interval">Defines the interval with which backups are periodically taken.</param>
        public FrequencyBasedBackupScheduleDescription(
            BackupScheduleIntervalType? intervalType,
            int? interval)
            : base(
                Common.BackupScheduleKind.FrequencyBased)
        {
            intervalType.ThrowIfNull(nameof(intervalType));
            interval.ThrowIfNull(nameof(interval));
            interval?.ThrowIfOutOfInclusiveRange("interval", 1, 2147483647);
            this.IntervalType = intervalType;
            this.Interval = interval;
        }

        /// <summary>
        /// Gets describes the backup schedule interval type with which to take periodic backups.
        /// . Possible values include: 'Invalid', 'Hours', 'Minutes'
        /// </summary>
        public BackupScheduleIntervalType? IntervalType { get; }

        /// <summary>
        /// Gets defines the interval with which backups are periodically taken.
        /// </summary>
        public int? Interval { get; }
    }
}
