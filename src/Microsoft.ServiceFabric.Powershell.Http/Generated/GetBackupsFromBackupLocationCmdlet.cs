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
    /// Gets the list of backups available for the specified backed up entity at the specified backup location.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFBackupsFromBackupLocation", DefaultParameterSetName = "GetBackupsFromBackupLocation")]
    public partial class GetBackupsFromBackupLocationCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Storage. Describes the parameters for the backup storage from where to enumerate backups. This is
        /// optional and by default backups are enumerated from the backup storage where this backup entity is currently being
        /// backed up (as specified in backup policy). This parameter is useful to be able to enumerate backups from another
        /// cluster where you may intend to restore.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetBackupsFromBackupLocation")]
        public BackupStorageDescription Storage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets BackupEntity. Indicates the entity for which to enumerate backups.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "GetBackupsFromBackupLocation")]
        public BackupEntity BackupEntity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets StartDateTimeFilter. Specifies the start date time in ISO8601 from which to enumerate backups. If not
        /// specified, backups are enumerated from the beginning.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "GetBackupsFromBackupLocation")]
        public DateTime? StartDateTimeFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets EndDateTimeFilter. Specifies the end date time in ISO8601 till which to enumerate backups. If not
        /// specified, backups are enumerated till the end.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "GetBackupsFromBackupLocation")]
        public DateTime? EndDateTimeFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Latest. If specified as true, gets the most recent backup (within the specified time range) for every
        /// partition under the specified backup entity.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "GetBackupsFromBackupLocation")]
        public bool? Latest
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "GetBackupsFromBackupLocation")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxResults. The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "GetBackupsFromBackupLocation")]
        public long? MaxResults
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var getBackupByStorageQueryDescription = new GetBackupByStorageQueryDescription(
                storage: this.Storage,
                backupEntity: this.BackupEntity,
                startDateTimeFilter: this.StartDateTimeFilter,
                endDateTimeFilter: this.EndDateTimeFilter,
                latest: this.Latest);

                var continuationToken = ContinuationToken.Empty;
                do
                {
                    var result = this.ServiceFabricClient.BackupRestore.GetBackupsFromBackupLocationAsync(
                        getBackupByStorageQueryDescription: getBackupByStorageQueryDescription,
                        serverTimeout: this.ServerTimeout,
                        continuationToken: continuationToken,
                        maxResults: this.MaxResults,
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
