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
    /// Disables periodic backup of Service Fabric partition which was previously enabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "SFPartitionBackup", DefaultParameterSetName = "DisablePartitionBackup")]
    public partial class DisablePartitionBackupCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets PartitionId. The identity of the partition.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "DisablePartitionBackup")]
        public PartitionId PartitionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "DisablePartitionBackup")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the force flag. If provided, then the destructive action will be performed without asking for
        /// confirmation prompt.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "DisablePartitionBackup")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                if (((this.Force != null) && this.Force) || this.ShouldContinue(string.Empty, string.Empty))
                {
                    this.ServiceFabricClient.BackupRestore.DisablePartitionBackupAsync(
                        partitionId: this.PartitionId,
                        serverTimeout: this.ServerTimeout,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                    Console.WriteLine("Success!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
