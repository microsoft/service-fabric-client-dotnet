// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a Service Fabric container network deployed to a Service Fabric node.
    /// </summary>
    public partial class DeployedNetworkInfo : NetworkRef
    {
        /// <summary>
        /// Initializes a new instance of the DeployedNetworkInfo class.
        /// </summary>
        /// <param name="name">Name of the network.</param>
        /// <param name="endpoint">The endpoint associated with the network</param>
        public DeployedNetworkInfo(
            string name = default(string),
            string endpoint = default(string))
            : base(
                name,
                endpoint)
        {
        }
    }
}
