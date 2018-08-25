// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a Service Fabric container network that a Service Fabric application is a member of.
    /// </summary>
    public partial class ApplicationNetworkInfo : NetworkRef
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationNetworkInfo class.
        /// </summary>
        /// <param name="name">Name of the network.</param>
        /// <param name="endpoint">The endpoint associated with the network</param>
        public ApplicationNetworkInfo(
            string name = default(string),
            string endpoint = default(string))
            : base(
                name,
                endpoint)
        {
        }
    }
}
