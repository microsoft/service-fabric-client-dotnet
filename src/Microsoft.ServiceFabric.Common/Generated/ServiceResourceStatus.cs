// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ServiceResourceStatus.
    /// </summary>
    public enum ServiceResourceStatus
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// Active.
        /// </summary>
        Active,

        /// <summary>
        /// Upgrading.
        /// </summary>
        Upgrading,

        /// <summary>
        /// Deleting.
        /// </summary>
        Deleting,

        /// <summary>
        /// Creating.
        /// </summary>
        Creating,

        /// <summary>
        /// Failed.
        /// </summary>
        Failed,
    }
}
