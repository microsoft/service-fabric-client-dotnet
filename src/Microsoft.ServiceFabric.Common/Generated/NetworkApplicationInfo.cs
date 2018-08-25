// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a Service Fabric application that is associated with a Service Fabric container network.
    /// </summary>
    public partial class NetworkApplicationInfo
    {
        /// <summary>
        /// Initializes a new instance of the NetworkApplicationInfo class.
        /// </summary>
        /// <param name="applicationName">The name of the application, including the 'fabric:' URI scheme.</param>
        public NetworkApplicationInfo(
            ApplicationName applicationName = default(ApplicationName))
        {
            this.ApplicationName = applicationName;
        }

        /// <summary>
        /// Gets the name of the application, including the 'fabric:' URI scheme.
        /// </summary>
        public ApplicationName ApplicationName { get; }
    }
}
