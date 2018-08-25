// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a Service Fabric container network.
    /// </summary>
    public partial class NetworkDescription
    {
        /// <summary>
        /// Initializes a new instance of the NetworkDescription class.
        /// </summary>
        /// <param name="name">The name of a Service Fabric container network.</param>
        /// <param name="properties">Describes a Service Fabric container network properties</param>
        public NetworkDescription(
            string name,
            NetworkProperties properties)
        {
            name.ThrowIfNull(nameof(name));
            properties.ThrowIfNull(nameof(properties));
            this.Name = name;
            this.Properties = properties;
        }

        /// <summary>
        /// Gets the name of a Service Fabric container network.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets describes a Service Fabric container network properties
        /// </summary>
        public NetworkProperties Properties { get; }
    }
}
