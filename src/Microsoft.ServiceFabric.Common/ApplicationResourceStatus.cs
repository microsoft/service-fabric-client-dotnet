// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ApplicationResourceStatus.
    /// </summary>
    public enum ApplicationResourceStatus
    {
        /// <summary>
        /// Invalid.
        /// </summary>
        Invalid,

        /// <summary>
        /// Ready.
        /// </summary>
        Ready,

        /// <summary>
        /// Upgrading.
        /// </summary>
        Upgrading,

        /// <summary>
        /// Creating.
        /// </summary>
        Creating,

        /// <summary>
        /// Deleting.
        /// </summary>
        Deleting,

        /// <summary>
        /// Failed.
        /// </summary>
        Failed,
    }
}
