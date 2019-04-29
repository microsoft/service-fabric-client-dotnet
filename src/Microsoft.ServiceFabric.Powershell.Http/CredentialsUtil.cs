// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Contains methods for getting credentials from AAD and loading X509 certificates.
    /// </summary>
    internal class CredentialsUtil
    {
        public static async Task<string> GetAccessTokenAsync(AadMetadata aad, CancellationToken cancellationToken)
        {
            var authority = aad.Authority;
            var authContext = new AuthenticationContext(authority);
            AuthenticationResult authResult = null;
            var token = string.Empty;

            // On full .net framework, use interactive logon to get token.
            // On dotnet core, acquire token using device id.
            // https://github.com/AzureAD/azure-activedirectory-library-for-dotnet/wiki/Acquiring-a-token-return-AuthenticationResult-and-possibly-UserInfo
#if DotNetCoreClr
            try
            {
                authResult = await authContext.AcquireTokenSilentAsync(aad.Cluster, aad.Client);
            }
            catch (AdalException adalException)
            {
                if (adalException.ErrorCode == AdalError.FailedToAcquireTokenSilently
                 || adalException.ErrorCode == AdalError.InteractionRequired)
                {
                    try
                    {
                        var codeResult = await authContext.AcquireDeviceCodeAsync(aad.Cluster, aad.Client);
                        Console.WriteLine(Resource.MsgAADSignin);
                        Console.WriteLine(codeResult.Message + "\n");
                        authResult = await authContext.AcquireTokenByDeviceCodeAsync(codeResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(Resource.ErrorAAD);
                        Console.WriteLine("Message: " + ex.Message + "\n");
                    }
                }
            }

            token = authResult.AccessToken;
#else
            authResult = await authContext.AcquireTokenAsync(
                aad.Cluster,
                aad.Client,
                new Uri(aad.Redirect),
                new PlatformParameters(PromptBehavior.SelectAccount));
            token = authResult.AccessToken;            
#endif
            return token;
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
