// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ReplicaEventKind.
    /// </summary>
    public enum ReplicaEventKind
    {
        /// <summary>
        /// ReplicaEvent.
        /// </summary>
        ReplicaEvent,

        /// <summary>
        /// StatefulReplicaNewHealthReport.
        /// </summary>
        StatefulReplicaNewHealthReport,

        /// <summary>
        /// StatefulReplicaHealthReportExpired.
        /// </summary>
        StatefulReplicaHealthReportExpired,

        /// <summary>
        /// StatelessReplicaNewHealthReport.
        /// </summary>
        StatelessReplicaNewHealthReport,

        /// <summary>
        /// StatelessReplicaHealthReportExpired.
        /// </summary>
        StatelessReplicaHealthReportExpired,

        /// <summary>
        /// ChaosStopped.
        /// </summary>
        ChaosStopped,

        /// <summary>
        /// ChaosStarted.
        /// </summary>
        ChaosStarted,

        /// <summary>
        /// ChaosCodePackageRestartScheduled.
        /// </summary>
        ChaosCodePackageRestartScheduled,

        /// <summary>
        /// ChaosReplicaRemovalScheduled.
        /// </summary>
        ChaosReplicaRemovalScheduled,

        /// <summary>
        /// ChaosReplicaRestartScheduled.
        /// </summary>
        ChaosReplicaRestartScheduled,
    }
}
