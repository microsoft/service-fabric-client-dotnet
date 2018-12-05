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
    using Microsoft.ServiceFabric.Common.Security;

    /// <summary>
    /// Bearer Token Handler for ClaimsSecuritySettings
    /// </summary>
    internal class ClaimsTokenHandler : IBearerTokenHandler
    {
        private const string BearerPrefix = "Bearer ";
        private string token;

        protected string Token
        {
            get
            {
                return this.token;
            }

            set
            {
                this.token = value.StartsWith(BearerPrefix) ? value.Remove(0, BearerPrefix.Length) : value;
            }
        }

        /// <inheritdoc />
        public virtual Task InitializeTokenAsync(SecuritySettings securitySettings, CancellationToken cancellationToken)
        {
            if (securitySettings is ClaimsSecuritySettings claimsSecuritySettings)
            {
                this.Token = claimsSecuritySettings.ClaimsToken;
            }
            else
            {
                throw new InvalidOperationException(string.Format(SR.ErrorClaimsTokenHandlerIncorrectSecuritySettings, securitySettings.GetType().Name));
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public virtual Task RefreshTokenAsync(SecuritySettings securitySettings, CancellationToken cancellationToken)
        {
            if (securitySettings is ClaimsSecuritySettings claimsSecuritySettings)
            {
                this.Token = claimsSecuritySettings.ClaimsToken;
            }
            else
            {
                throw new InvalidOperationException(string.Format(SR.ErrorClaimsTokenHandlerIncorrectSecuritySettings, securitySettings.GetType().Name));
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public void AddTokenToRequest(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", $"Bearer {this.Token}");
        }
    }
}
