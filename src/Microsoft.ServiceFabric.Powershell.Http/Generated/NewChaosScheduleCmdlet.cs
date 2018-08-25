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
    /// Set the schedule used by Chaos.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFChaosSchedule", DefaultParameterSetName = "PostChaosSchedule")]
    public partial class NewChaosScheduleCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Version. The version number of the Schedule.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "PostChaosSchedule")]
        public int? Version
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Schedule. Defines the schedule used by Chaos.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "PostChaosSchedule")]
        public ChaosSchedule Schedule
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "PostChaosSchedule")]
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
                var chaosScheduleDescription = new ChaosScheduleDescription(
                version: this.Version,
                schedule: this.Schedule);

                this.ServiceFabricClient.ChaosClient.PostChaosScheduleAsync(
                    chaosSchedule: chaosScheduleDescription,
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
