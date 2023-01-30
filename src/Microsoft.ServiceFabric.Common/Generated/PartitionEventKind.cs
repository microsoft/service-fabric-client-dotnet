// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for PartitionEventKind.
    /// </summary>
    public enum PartitionEventKind
    {
        /// <summary>
        /// PartitionEvent.
        /// </summary>
        PartitionEvent,

        /// <summary>
        /// PartitionAnalysisEvent.
        /// </summary>
        PartitionAnalysisEvent,

        /// <summary>
        /// PartitionNewHealthReport.
        /// </summary>
        PartitionNewHealthReport,

        /// <summary>
        /// PartitionHealthReportExpired.
        /// </summary>
        PartitionHealthReportExpired,

        /// <summary>
        /// PartitionReconfigured.
        /// </summary>
        PartitionReconfigured,

        /// <summary>
        /// PartitionPrimaryMoveAnalysis.
        /// </summary>
        PartitionPrimaryMoveAnalysis,

        /// <summary>
        /// ChaosPartitionSecondaryMoveScheduled.
        /// </summary>
        ChaosPartitionSecondaryMoveScheduled,

        /// <summary>
        /// ChaosPartitionPrimaryMoveScheduled.
        /// </summary>
        ChaosPartitionPrimaryMoveScheduled,
    }
}
