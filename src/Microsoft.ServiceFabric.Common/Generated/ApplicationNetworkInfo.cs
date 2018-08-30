// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a Service Fabric container network that a Service Fabric application is associated with.
    /// </summary>
    public partial class ApplicationNetworkInfo
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationNetworkInfo class.
        /// </summary>
        /// <param name="networkName">The name of a Service Fabric container network.</param>
        public ApplicationNetworkInfo(
            string networkName = default(string))
        {
            this.NetworkName = networkName;
        }

        /// <summary>
        /// Gets the name of a Service Fabric container network.
        /// </summary>
        public string NetworkName { get; }
    }
}
