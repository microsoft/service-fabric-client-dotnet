// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Exceptions;
    using Microsoft.ServiceFabric.Client.Exceptions;

    /// <summary>
    /// Interface containing methods for performing ClusterClient operataions.
    /// </summary>
    public partial interface IClusterClient
    {
        /// <summary>
        /// Gets the connection string for the image store on the current cluster
        /// </summary>
        /// <returns></returns>
        Task<string> GetImageStoreConnectionString();
    }
}
