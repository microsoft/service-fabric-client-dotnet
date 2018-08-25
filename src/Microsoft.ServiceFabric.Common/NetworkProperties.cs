// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a Service Fabric container network properties
    /// </summary>
    public abstract partial class NetworkProperties
    {
        /// <summary>
        /// Initializes a new instance of the NetworkProperties class.
        /// </summary>
        /// <param name="kind">The type of a Service Fabric container network.</param>
        /// <param name="status">The status of a container network. Possible values include: 'Ready', 'Creating', 'Deleting',
        /// 'Failed'</param>
        /// <param name="statusDetails">Additional detailed information about the status of the network</param>
        protected NetworkProperties(
            NetworkType? kind,
            NetworkStatus? status = default(NetworkStatus?),
            string statusDetails = default(string))
        {
            kind.ThrowIfNull(nameof(kind));
            this.Kind = kind;
            this.Status = status;
            this.StatusDetails = statusDetails;
        }

        /// <summary>
        /// Gets the status of a container network. Possible values include: 'Ready', 'Creating', 'Deleting', 'Failed'
        /// </summary>
        public NetworkStatus? Status { get; }

        /// <summary>
        /// Gets additional detailed information about the status of the network
        /// </summary>
        public string StatusDetails { get; }

        /// <summary>
        /// Gets the type of a Service Fabric container network.
        /// </summary>
        public NetworkType? Kind { get; }
    }
}
