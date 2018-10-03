// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for SecretKind.
    /// </summary>
    public enum SecretKind
    {
        /// <summary>
        /// A simple secret resource whose plaintext value is provided by the user.
        /// </summary>
        InlinedValue,
    }
}
