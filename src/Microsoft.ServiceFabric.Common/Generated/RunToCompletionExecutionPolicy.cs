// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The run to completion execution policy
    /// </summary>
    public partial class RunToCompletionExecutionPolicy : ExecutionPolicy
    {
        /// <summary>
        /// Initializes a new instance of the RunToCompletionExecutionPolicy class.
        /// </summary>
        /// <param name="restart">Enumerates the restart policy for RunToCompletionExecutionPolicy. Possible values include:
        /// 'onFailure', 'never'</param>
        public RunToCompletionExecutionPolicy(
            RestartPolicy? restart)
            : base(
                Common.ExecutionPolicyType.RunToCompletion)
        {
            restart.ThrowIfNull(nameof(restart));
            this.Restart = restart;
        }

        /// <summary>
        /// Gets enumerates the restart policy for RunToCompletionExecutionPolicy. Possible values include: 'onFailure',
        /// 'never'
        /// </summary>
        public RestartPolicy? Restart { get; }
    }
}
