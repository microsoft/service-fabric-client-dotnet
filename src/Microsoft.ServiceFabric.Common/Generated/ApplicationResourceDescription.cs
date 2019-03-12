// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a service fabric application resource.
    /// </summary>
    public partial class ApplicationResourceDescription
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationResourceDescription class.
        /// </summary>
        /// <param name="properties">This type describes properties of an application resource.</param>
        /// <param name="name">Application resource name.
        /// </param>
        public ApplicationResourceDescription(
            ApplicationProperties properties,
            string name)
        {
            properties.ThrowIfNull(nameof(properties));
            name.ThrowIfNull(nameof(name));
            this.Properties = properties;
            this.Name = name;
        }

        /// <summary>
        /// Gets this type describes properties of an application resource.
        /// </summary>
        public ApplicationProperties Properties { get; }

        /// <summary>
        /// Gets application resource name.
        /// </summary>
        public string Name { get; }
    }
}
