// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a Service Fabric node that a Service Fabric container network is deployed to.
    /// </summary>
    public partial class NetworkNodeInfo
    {
        /// <summary>
        /// Initializes a new instance of the NetworkNodeInfo class.
        /// </summary>
        /// <param name="nodeName">The name of a Service Fabric node.</param>
        public NetworkNodeInfo(
            NodeName nodeName = default(NodeName))
        {
            this.NodeName = nodeName;
        }

        /// <summary>
        /// Gets the name of a Service Fabric node.
        /// </summary>
        public NodeName NodeName { get; }
    }
}
