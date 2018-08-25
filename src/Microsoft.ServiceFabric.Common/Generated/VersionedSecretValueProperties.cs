// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This type describes properties of a versioned value of a secret.
    /// </summary>
    public partial class VersionedSecretValueProperties
    {
        /// <summary>
        /// Initializes a new instance of the VersionedSecretValueProperties class.
        /// </summary>
        /// <param name="value">The value of the secret resource.</param>
        public VersionedSecretValueProperties(
            string value = default(string))
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value of the secret resource.
        /// </summary>
        public string Value { get; }
    }
}
