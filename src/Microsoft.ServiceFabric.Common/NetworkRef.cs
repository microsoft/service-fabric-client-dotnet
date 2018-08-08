// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a network reference in a service.
    /// </summary>
    public partial class NetworkRef
    {
        /// <summary>
        /// Initializes a new instance of the NetworkRef class.
        /// </summary>
        /// <param name="name">Name of the network.</param>
        public NetworkRef(
            string name = default(string))
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets name of the network.
        /// </summary>
        public string Name { get; }
    }
}
