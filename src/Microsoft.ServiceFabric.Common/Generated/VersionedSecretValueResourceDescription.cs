// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This type describes a versioned value of a secret resource. The name of this resource is the version identifier
    /// corresponding to this secret value.
    /// </summary>
    public partial class VersionedSecretValueResourceDescription
    {
        /// <summary>
        /// Initializes a new instance of the VersionedSecretValueResourceDescription class.
        /// </summary>
        /// <param name="name">Version identifier of the secret value.</param>
        /// <param name="properties">This type describes properties of a versioned value of a secret resource.</param>
        public VersionedSecretValueResourceDescription(
            string name,
            VersionedSecretValueResourceProperties properties)
        {
            name.ThrowIfNull(nameof(name));
            properties.ThrowIfNull(nameof(properties));
            this.Name = name;
            this.Properties = properties;
        }

        /// <summary>
        /// Gets version identifier of the secret value.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets this type describes properties of a versioned value of a secret resource.
        /// </summary>
        public VersionedSecretValueResourceProperties Properties { get; }
    }
}
