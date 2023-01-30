// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for NodeEventKind.
    /// </summary>
    public enum NodeEventKind
    {
        /// <summary>
        /// NodeEvent.
        /// </summary>
        NodeEvent,

        /// <summary>
        /// NodeAborted.
        /// </summary>
        NodeAborted,

        /// <summary>
        /// NodeAddedToCluster.
        /// </summary>
        NodeAddedToCluster,

        /// <summary>
        /// NodeClosed.
        /// </summary>
        NodeClosed,

        /// <summary>
        /// NodeDeactivateCompleted.
        /// </summary>
        NodeDeactivateCompleted,

        /// <summary>
        /// NodeDeactivateStarted.
        /// </summary>
        NodeDeactivateStarted,

        /// <summary>
        /// NodeDown.
        /// </summary>
        NodeDown,

        /// <summary>
        /// NodeNewHealthReport.
        /// </summary>
        NodeNewHealthReport,

        /// <summary>
        /// NodeHealthReportExpired.
        /// </summary>
        NodeHealthReportExpired,

        /// <summary>
        /// NodeOpenSucceeded.
        /// </summary>
        NodeOpenSucceeded,

        /// <summary>
        /// NodeOpenFailed.
        /// </summary>
        NodeOpenFailed,

        /// <summary>
        /// NodeRemovedFromCluster.
        /// </summary>
        NodeRemovedFromCluster,

        /// <summary>
        /// NodeUp.
        /// </summary>
        NodeUp,

        /// <summary>
        /// ChaosNodeRestartScheduled.
        /// </summary>
        ChaosNodeRestartScheduled,
    }
}
