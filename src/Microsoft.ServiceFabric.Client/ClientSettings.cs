// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using Microsoft.ServiceFabric.Common.Security;

    /// <summary>
    /// Represents connection settings for <see cref="ServiceFabricClient"/>
    /// </summary>
    public class ClientSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientSettings"/> class.
        /// </summary>
        /// <param name="securitySettings">Delegate to create security settings for connecting to cluster.
        /// Default value is null which means that cluster is not secured.</param>
        /// <param name="clientTimeout">Timespan to wait before the request times out for the client.</param>
        /// <remarks>
        /// Security Settings for connecting to a secured cluster are created by calling the delegate <paramref name="securitySettings"/>.
        /// The delegate will be used to refresh security settings if needed by implementaions of <see cref="IServiceFabricClient"/>.
        /// If client request fails because of Authentication, the delegate is invoked once again to get security settings, if the client call fails again because of Authentication after getting 
        /// security settings, the exception is thrown to the user. This allows applications to refresh Claims an X509 security credentials without restarting.
        /// </remarks>
        public ClientSettings(
            Func<SecuritySettings> securitySettings = null,
            TimeSpan? clientTimeout = null)
        {
            this.SecuritySettings = securitySettings;
            this.ClientTimeout = clientTimeout;
        }

        /// <summary>
        /// Gets the delegate to create security settings for connecting to cluster.
        /// </summary>
        /// <value><see cref="SecuritySettings"/> for connecting to cluster.</value>
        public Func<SecuritySettings> SecuritySettings { get; }

        /// <summary>
        /// Gets the Timespan to wait before the request times out for the client.
        /// </summary>
        public TimeSpan? ClientTimeout { get; }
    }
}
