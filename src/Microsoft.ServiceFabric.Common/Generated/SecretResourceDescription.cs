// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This type describes a secret resource.
    /// </summary>
    public partial class SecretResourceDescription
    {
        /// <summary>
        /// Initializes a new instance of the SecretResourceDescription class.
        /// </summary>
        /// <param name="properties">This type describes the properties of a secret resource, including its kind.</param>
        /// <param name="name">Secret resource name.</param>
        public SecretResourceDescription(
            SecretResourcePropertiesBase properties,
            string name)
        {
            properties.ThrowIfNull(nameof(properties));
            name.ThrowIfNull(nameof(name));
            this.Properties = properties;
            this.Name = name;
        }

        /// <summary>
        /// Gets this type describes the properties of a secret resource, including its kind.
        /// </summary>
        public SecretResourcePropertiesBase Properties { get; }

        /// <summary>
        /// Gets secret resource name.
        /// </summary>
        public string Name { get; }
    }
}
