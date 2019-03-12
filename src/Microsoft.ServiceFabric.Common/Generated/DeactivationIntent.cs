// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for DeactivationIntent.
    /// </summary>
    public enum DeactivationIntent
    {
        /// <summary>
        /// Indicates that the node should be paused. The value is 1..
        /// </summary>
        Pause,

        /// <summary>
        /// Indicates that the intent is for the node to be restarted after a short period of time. The value is 2..
        /// </summary>
        Restart,

        /// <summary>
        /// Indicates the intent is for the node to remove data. The value is 3..
        /// </summary>
        RemoveData,
    }
}
