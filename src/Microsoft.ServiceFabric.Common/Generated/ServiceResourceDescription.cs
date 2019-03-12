// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a service fabric service resource.
    /// </summary>
    public partial class ServiceResourceDescription
    {
        /// <summary>
        /// Initializes a new instance of the ServiceResourceDescription class.
        /// </summary>
        /// <param name="properties">This type describes properties of a service resource.</param>
        /// <param name="name">Service resource name.
        /// </param>
        public ServiceResourceDescription(
            ServiceResourceProperties properties,
            string name)
        {
            properties.ThrowIfNull(nameof(properties));
            name.ThrowIfNull(nameof(name));
            this.Properties = properties;
            this.Name = name;
        }

        /// <summary>
        /// Gets this type describes properties of a service resource.
        /// </summary>
        public ServiceResourceProperties Properties { get; }

        /// <summary>
        /// Gets service resource name.
        /// </summary>
        public string Name { get; }
    }
}
