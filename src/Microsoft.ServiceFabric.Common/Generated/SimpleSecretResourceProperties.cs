// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes the properties of a secret resource whose value is provided explicitly as plaintext. The secret resource
    /// may have multiple values, each being uniquely versioned. The secret value of each version is stored encrypted, and
    /// delivered as plaintext into the context of applications referencing it.
    /// </summary>
    public partial class SimpleSecretResourceProperties : SecretResourceProperties
    {
        /// <summary>
        /// Initializes a new instance of the SimpleSecretResourceProperties class.
        /// </summary>
        /// <param name="description">User readable description of the secret.</param>
        /// <param name="status">Status of the resource. Possible values include: 'Unknown', 'Ready', 'Upgrading', 'Creating',
        /// 'Deleting', 'Failed'</param>
        /// <param name="contentType">The type of the content stored in the secret value. The value of this property is opaque
        /// to Service Fabric. Once set, the value of this property cannot be changed.</param>
        public SimpleSecretResourceProperties(
            string description = default(string),
            ResourceStatus? status = default(ResourceStatus?),
            string contentType = default(string))
            : base(
                Common.SecretKind.InlinedValue,
                description,
                status,
                contentType)
        {
        }
    }
}
