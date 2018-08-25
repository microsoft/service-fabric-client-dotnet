// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for NetworkStatus.
    /// </summary>
    public enum NetworkStatus
    {
        /// <summary>
        /// Indicates the network status is ready. The value is 1..
        /// </summary>
        Ready,

        /// <summary>
        /// Indicates the network status is creating. The value is 2..
        /// </summary>
        Creating,

        /// <summary>
        /// Indicates the network status is deleting. The value is 3..
        /// </summary>
        Deleting,

        /// <summary>
        /// Indicates the network is in a failed state. The value is 8..
        /// </summary>
        Failed,
    }
}
