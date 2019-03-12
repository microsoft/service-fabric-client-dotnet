// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes the intent or reason for deactivating the node.
    /// </summary>
    public partial class DeactivationIntentDescription
    {
        /// <summary>
        /// Initializes a new instance of the DeactivationIntentDescription class.
        /// </summary>
        /// <param name="deactivationIntent">Describes the intent or reason for deactivating the node. The possible values are
        /// following.
        /// . Possible values include: 'Pause', 'Restart', 'RemoveData'</param>
        public DeactivationIntentDescription(
            DeactivationIntent? deactivationIntent = default(DeactivationIntent?))
        {
            this.DeactivationIntent = deactivationIntent;
        }

        /// <summary>
        /// Gets describes the intent or reason for deactivating the node. The possible values are following.
        /// . Possible values include: 'Pause', 'Restart', 'RemoveData'
        /// </summary>
        public DeactivationIntent? DeactivationIntent { get; }
    }
}
