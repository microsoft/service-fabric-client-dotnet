// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This type describes properties of a versioned value of a secret resource.
    /// </summary>
    public partial class VersionedSecretValueResourceProperties : VersionedSecretValueProperties
    {
        /// <summary>
        /// Initializes a new instance of the VersionedSecretValueResourceProperties class.
        /// </summary>
        /// <param name="value">The value of the secret resource.</param>
        public VersionedSecretValueResourceProperties(
            string value = default(string))
            : base(
                value)
        {
        }
    }
}
