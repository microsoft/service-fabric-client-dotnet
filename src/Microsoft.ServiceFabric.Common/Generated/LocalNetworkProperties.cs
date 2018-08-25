// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a Service Fabric container network local to a single Service Fabric cluster.
    /// </summary>
    public partial class LocalNetworkProperties : NetworkProperties
    {
        /// <summary>
        /// Initializes a new instance of the LocalNetworkProperties class.
        /// </summary>
        /// <param name="status">The status of a container network. Possible values include: 'Ready', 'Creating', 'Deleting',
        /// 'Failed'</param>
        /// <param name="statusDetails">Additional detailed information about the status of the network</param>
        /// <param name="addressPrefix">Address space for the local container network.</param>
        public LocalNetworkProperties(
            NetworkStatus? status = default(NetworkStatus?),
            string statusDetails = default(string),
            string addressPrefix = default(string))
            : base(
                Common.NetworkType.Local,
                status,
                statusDetails)
        {
            this.AddressPrefix = addressPrefix;
        }

        /// <summary>
        /// Gets address space for the local container network.
        /// </summary>
        public string AddressPrefix { get; }
    }
}
