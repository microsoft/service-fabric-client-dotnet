// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This type describes a gateway resource.
    /// </summary>
    public partial class GatewayResourceDescription
    {
        /// <summary>
        /// Initializes a new instance of the GatewayResourceDescription class.
        /// </summary>
        /// <param name="properties">Describes properties of Gateway to bridge two networks.</param>
        /// <param name="name">Gateway resource name.
        /// </param>
        public GatewayResourceDescription(
            GatewayProperties properties,
            string name)
        {
            properties.ThrowIfNull(nameof(properties));
            name.ThrowIfNull(nameof(name));
            this.Properties = properties;
            this.Name = name;
        }

        /// <summary>
        /// Gets describes properties of Gateway to bridge two networks.
        /// </summary>
        public GatewayProperties Properties { get; }

        /// <summary>
        /// Gets gateway resource name.
        /// </summary>
        public string Name { get; }
    }
}
