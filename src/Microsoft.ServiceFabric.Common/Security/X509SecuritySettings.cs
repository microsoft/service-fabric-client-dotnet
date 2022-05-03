// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common.Security
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.ServiceFabric.Common.Resources;

    /// <summary>
    /// Specifies the security settings that are based upon X509 certificates.
    /// </summary>
    public sealed class X509SecuritySettings : SecuritySettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="X509SecuritySettings" /> class.
        /// </summary>
        /// <param name="clientCertificate">The client certificate for the communication with server.</param>
        /// <param name="remoteX509SecuritySettings">Security settings to verify remote X509 certificate.</param>
        /// <param name="clientCertificates">Optional list of client certificates</param>
        public X509SecuritySettings(X509Certificate2 clientCertificate, RemoteX509SecuritySettings remoteX509SecuritySettings, X509Certificate2[] clientCertificates = null)
            : base(SecurityType.X509)
        {
            if (clientCertificates == null)
            {
                clientCertificate.ThrowIfNull(nameof(clientCertificate));
                this.ClientCertificates = new X509Certificate2[] { clientCertificate };
            }
            else
            {
                this.ClientCertificates = clientCertificates;
            }

            remoteX509SecuritySettings.ThrowIfNull(nameof(remoteX509SecuritySettings));

            if (!clientCertificate.HasPrivateKey)
            {
                throw new InvalidOperationException(SR.ClientCertDoesntContainPrivateKey);
            }

            // this.ClientCertificate = clientCertificate;
            this.RemoteX509SecuritySettings = remoteX509SecuritySettings;
        }

        /// <summary>
        /// Gets The list of client certificates to be used for communcation with the server.
        /// </summary>
        public X509Certificate2[] ClientCertificates { get; }

        /// <summary>
        /// Gets the settings to validate remote certificate.
        /// </summary>
        /// <value>
        /// <see cref="RemoteX509SecuritySettings"/> to validate remote certificate.
        /// </value>
        public RemoteX509SecuritySettings RemoteX509SecuritySettings { get; }
    }
}
