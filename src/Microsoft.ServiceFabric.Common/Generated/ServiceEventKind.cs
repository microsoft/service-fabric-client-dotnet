// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ServiceEventKind.
    /// </summary>
    public enum ServiceEventKind
    {
        /// <summary>
        /// ServiceEvent.
        /// </summary>
        ServiceEvent,

        /// <summary>
        /// ServiceCreated.
        /// </summary>
        ServiceCreated,

        /// <summary>
        /// ServiceDeleted.
        /// </summary>
        ServiceDeleted,

        /// <summary>
        /// ServiceNewHealthReport.
        /// </summary>
        ServiceNewHealthReport,

        /// <summary>
        /// ServiceHealthReportExpired.
        /// </summary>
        ServiceHealthReportExpired,
    }
}
