// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for FabricEventKind.
    /// </summary>
    public enum FabricEventKind
    {
        /// <summary>
        /// ClusterEvent.
        /// </summary>
        ClusterEvent,

        /// <summary>
        /// ContainerEvent.
        /// </summary>
        ContainerEvent,

        /// <summary>
        /// NodeEvent.
        /// </summary>
        NodeEvent,

        /// <summary>
        /// ApplicationEvent.
        /// </summary>
        ApplicationEvent,

        /// <summary>
        /// ServiceEvent.
        /// </summary>
        ServiceEvent,

        /// <summary>
        /// PartitionEvent.
        /// </summary>
        PartitionEvent,

        /// <summary>
        /// ReplicaEvent.
        /// </summary>
        ReplicaEvent,

        /// <summary>
        /// PartitionAnalysisEvent.
        /// </summary>
        PartitionAnalysisEvent,

        /// <summary>
        /// NodeUp.
        /// </summary>
        NodeUp,

        /// <summary>
        /// NodeDown.
        /// </summary>
        NodeDown,

        /// <summary>
        /// PartitionPrimaryMoveAnalysis.
        /// </summary>
        PartitionPrimaryMoveAnalysis
    }
}
