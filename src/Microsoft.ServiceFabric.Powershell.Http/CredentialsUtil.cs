// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Identity.Client;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Contains methods for getting credentials from AAD and loading X509 certificates.
    /// </summary>
    internal class CredentialsUtil
    {
        public static async Task<string> GetAccessTokenAsync(AadMetadata aad, CancellationToken cancellationToken)
        {
            var pca = PublicClientApplicationBuilder
                                            .Create(aad.Client)
                                            .WithAuthority(aad.Authority).WithRedirectUri(aad.Redirect)

                                            .Build();
            var account = pca.GetAccountAsync(aad.Client)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
            AuthenticationResult authResult;

            // On full .net framework, use interactive logon to get token.
            // On dotnet core, acquire token using device id.
            // https://learn.microsoft.com/en-us/azure/active-directory/develop/scenario-desktop-acquire-token-device-code-flow?tabs=dotnet
            var scopes = new string[] { $"{aad.Cluster}/.default" };
            try
            {
                authResult = await pca.AcquireTokenSilent(scopes, account).ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            { 
                try
                {
                    authResult = await pca.AcquireTokenInteractive(scopes).WithAccount(account).ExecuteAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(Resource.ErrorAAD);
                    Console.WriteLine("Message: " + ex.Message + "\n");
                    throw ex;
                }
            }

            return authResult.AccessToken;
        }

        public static X509Certificate2 GetCertificate(StoreLocation storeLocation, string storeName, object findValue, X509FindType findType)
        {
            var store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var collection = store.Certificates;
            var ret = collection.Find(findType, findValue, false);

            if (ret.Count > 0)
            {
                return ret[0];
            }

            return null;
        }

        public static Task<string> GetAccessTokenDstsAsync(TokenServiceMetadata metadata, CancellationToken cancellationToken)
        {
            return DstsTokenHelper.GetAccessTokenFromDstsAsync(metadata, true, cancellationToken);
        }
    }
}
