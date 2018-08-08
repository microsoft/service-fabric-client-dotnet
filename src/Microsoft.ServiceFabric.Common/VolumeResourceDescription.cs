// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a service fabric volume resource.
    /// </summary>
    public partial class VolumeResourceDescription
    {
        /// <summary>
        /// Initializes a new instance of the VolumeResourceDescription class.
        /// </summary>
        /// <param name="properties">This type describes properties of a volume resource.</param>
        /// <param name="name">Volume resource name.</param>
        public VolumeResourceDescription(
            VolumeProperties properties,
            string name)
        {
            properties.ThrowIfNull(nameof(properties));
            name.ThrowIfNull(nameof(name));
            this.Properties = properties;
            this.Name = name;
        }

        /// <summary>
        /// Gets this type describes properties of a volume resource.
        /// </summary>
        public VolumeProperties Properties { get; }

        /// <summary>
        /// Gets volume resource name.
        /// </summary>
        public string Name { get; }
    }
}
