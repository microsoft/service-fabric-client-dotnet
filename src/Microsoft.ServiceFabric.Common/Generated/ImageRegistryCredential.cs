// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Image registry credential.
    /// </summary>
    public partial class ImageRegistryCredential
    {
        /// <summary>
        /// Initializes a new instance of the ImageRegistryCredential class.
        /// </summary>
        /// <param name="server">Docker image registry server, without protocol such as `http` and `https`.</param>
        /// <param name="username">The username for the private registry.</param>
        /// <param name="password">The password for the private registry. The password is required for create or update
        /// operations, however it is not returned in the get or list operations.</param>
        public ImageRegistryCredential(
            string server,
            string username,
            string password = default(string))
        {
            server.ThrowIfNull(nameof(server));
            username.ThrowIfNull(nameof(username));
            this.Server = server;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// Gets docker image registry server, without protocol such as `http` and `https`.
        /// </summary>
        public string Server { get; }

        /// <summary>
        /// Gets the username for the private registry.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the password for the private registry. The password is required for create or update operations, however it is
        /// not returned in the get or list operations.
        /// </summary>
        public string Password { get; }
    }
}
