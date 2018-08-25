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
    /// Forces the approval of the given repair task.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFApproveRepairTask", DefaultParameterSetName = "ForceApproveRepairTask")]
    public partial class NewApproveRepairTaskCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets TaskId. The ID of the repair task.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ForceApproveRepairTask")]
        public string TaskId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Version. The current version number of the repair task. If non-zero, then the request will only
        /// succeed if this value matches the actual current version of the repair task. If zero, then no version check is
        /// performed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "ForceApproveRepairTask")]
        public string Version
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var repairTaskApproveDescription = new RepairTaskApproveDescription(
                taskId: this.TaskId,
                version: this.Version);

                var result = this.ServiceFabricClient.Repairs.ForceApproveRepairTaskAsync(
                    repairTaskApproveDescription: repairTaskApproveDescription,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
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
