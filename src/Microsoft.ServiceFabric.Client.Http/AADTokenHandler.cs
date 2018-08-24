// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client.Http.Resources;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Security;

    /// <summary>
    /// Token Handler for AzureActiveDirectorySecuritySettings
    /// </summary>
    internal class AADTokenHandler : ClaimsTokenHandler
    {
        private readonly AadMetadata aadMetaData;

        public AADTokenHandler()
        {
        }

        public AADTokenHandler(AadMetadata aadMetaData)
        {
            this.aadMetaData = aadMetaData;
        }

        /// <inheritdoc />
        public override async Task InitializeTokenAsync(SecuritySettings securitySettings, CancellationToken cancellationToken)
        {
            if (securitySettings is AzureActiveDirectorySecuritySettings aadSecuritySettings)
            {
                // Use ClaimsToken if provided by the user directly else use the delegate to get the ClaimsToken from user.
                if (aadSecuritySettings.ClaimsToken != null)
                {
                    this.Token = aadSecuritySettings.ClaimsToken;
                }
                else if (aadSecuritySettings.GetClaimsToken != null && this.aadMetaData != null)
                {
                    this.Token = await aadSecuritySettings.GetClaimsToken.Invoke(this.aadMetaData, cancellationToken);
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format(SR.ErrorAADTokenHandlerIncorrectSecuritySettings, securitySettings.GetType().Name));
            }
        }

        /// <inheritdoc />
        public override async Task RefreshTokenAsync(SecuritySettings securitySettings, CancellationToken cancellationToken)
        {
            if (securitySettings is AzureActiveDirectorySecuritySettings aadSecuritySettings)
            {
                // Use ClaimsToken if provided by the user directly else use the delegate to get the ClaimsToken from user.
                if (aadSecuritySettings.ClaimsToken != null)
                {
                    this.Token = aadSecuritySettings.ClaimsToken;
                }
                else if (aadSecuritySettings.GetClaimsToken != null && this.aadMetaData != null)
                {
                    this.Token = await aadSecuritySettings.GetClaimsToken.Invoke(this.aadMetaData, cancellationToken);
                }
            }
        }
    }
}
