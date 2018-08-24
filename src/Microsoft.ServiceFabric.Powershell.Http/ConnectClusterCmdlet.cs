// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Common.Security;

    /// <summary>
    /// Cmdlet to connect to Service Fabric cluster.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "SFCluster")]
    public class ConnectClusterCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Service Faric cluster http gateway endpoint address.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "Default")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Windows")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "X509")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "Aad")]
        [ValidateNotNullOrEmpty]
        public string[] ConnectionEndpoint
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets switch parameter for selecting Windows credentials when connecting to Service Fabric cluster secured with Windows credentials.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "Windows")]
        public SwitchParameter WindowsCredential
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets switch parameter for slecting X509 Credentials when connecting to Service Fabric Cluster secured with X509 certificate.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "X509")]
        public SwitchParameter X509Credential
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets switch parameter for slecting Azure Active Directory credentials when connecting to Service Fabric Cluster secured with Azure Active Directory..
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "Aad")]
        public SwitchParameter AzureActiveDirectory
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets or sets Subject common names or DNS names of X509 certificate of the server.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "X509")]
        [Parameter(Mandatory = false, ParameterSetName = "Dsts")]
        [Parameter(Mandatory = false, ParameterSetName = "Aad")]
        public string[] ServerCommonName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Issuer Cert thumbprints for X509 certificate of the server. When provided alongwith ServerCommonName, its used to validate server cert's issuer thumbprint.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "X509")]
        [Parameter(Mandatory = false, ParameterSetName = "Dsts")]
        [Parameter(Mandatory = false, ParameterSetName = "Aad")]
        public string[] IssuerCertThumbprints
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets thumbprint of X509 certificate of the server.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "X509")]
        [Parameter(Mandatory = false, ParameterSetName = "Dsts")]
        [Parameter(Mandatory = false, ParameterSetName = "Aad")]
        public string[] ServerCertThumbprint
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the switch to get Azure Active Directory metadata. When this switch is specified, Connect commandlet displays the Azure aCtive Directory metadata without validating the connection with AAD credentials.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Aad")]
        public SwitchParameter GetMetadata
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the client certificate.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "X509")]
        public X509Certificate2 ClientCertificate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the <see cref="X509FindType"/> to find the client certificate.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "X509")]
        public X509FindType FindType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the FindValue to find the client certificate.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "X509")]
        public string FindValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the <see cref="StoreLocation"/> to find the client certificate.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "X509")]
        public StoreLocation StoreLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the StoreName to find the client certificate.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "X509")]
        public string StoreName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Azure Active Directory Security Token.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Aad")]
        public string SecurityToken
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the Security Token from a Azure Active Directory or DSTS.
        /// </summary>
        /// <returns>Security Access token.</returns>
        internal string GetSecurityToken()
        {
            if (this.AzureActiveDirectory.IsPresent && string.IsNullOrEmpty(this.SecurityToken))
            {
                // Get AAD metadata from cluster and Token from AAD.
                return string.Empty;
            }            

            return string.Empty;
        }

        /// <inheritdoc />
        protected override void BeginProcessing()
        {
            foreach (var endPoint in this.ConnectionEndpoint)
            {
                if (!endPoint.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                    && !Uri.TryCreate(endPoint, UriKind.Absolute, out var uri))
                {
                    throw new PSArgumentException(Resource.ErrorIncorrectEndpointFormat);
                }
            }
        }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            Func<CancellationToken, Task<SecuritySettings>> securitySettings = null;
            if (this.WindowsCredential.IsPresent)
            {
                securitySettings = (ct) => Task.FromResult<SecuritySettings>(new WindowsSecuritySettings());
            }
            else if (this.X509Credential.IsPresent || this.AzureActiveDirectory.IsPresent)
            {
                var x509Names = new List<X509Name>();
                RemoteX509SecuritySettings remoteX509SecuritySettings = null;

                // ServerCommonName or ServerThumbprint must be provided when connecting with IP Address.
                if (this.ServerCertThumbprint == null && this.ServerCommonName == null)
                {
                    var uri = this.ConnectionEndpoint.Select(e => new Uri(e)).Where(u => u.HostNameType.Equals(UriHostNameType.Dns));

                    if (uri.Count() == 0)
                    {
                        throw new PSArgumentException(Resource.ErrorNoServerCommonNameIrServerCertThumbprint);
                    }

                    x509Names = uri.Select(x => new X509Name(x.Host)).ToList();
                    remoteX509SecuritySettings = new RemoteX509SecuritySettings(x509Names);
                }
                else if (this.ServerCommonName != null)
                {
                    // Use Issuer thumbprint if provided.
                    if (this.IssuerCertThumbprints != null && this.IssuerCertThumbprints.Length > 0)
                    {
                        if (this.ServerCommonName.Length != this.IssuerCertThumbprints.Length)
                        {
                            throw new PSArgumentException(Resource.CommonNameIssuerThumbprintMismatch);
                        }
                        else
                        {
                            for (int i = 0; i < this.ServerCommonName.Length; i++)
                            {
                                x509Names.Add(new X509Name(this.ServerCommonName[i], this.IssuerCertThumbprints[i]));
                            }
                        }
                    }
                    else
                    {
                        x509Names = this.ServerCommonName.Select(name => new X509Name(name)).ToList();
                    }

                    remoteX509SecuritySettings = new RemoteX509SecuritySettings(x509Names);
                }
                else if (this.ServerCertThumbprint != null)
                {
                    remoteX509SecuritySettings = new RemoteX509SecuritySettings(this.ServerCertThumbprint);
                }

                if (this.AzureActiveDirectory.IsPresent)
                {
                    if (this.GetMetadata.IsPresent)
                    {
                        securitySettings = (ct) => Task.FromResult<SecuritySettings>(new AzureActiveDirectorySecuritySettings("DummyTokenToGetMetadata", remoteX509SecuritySettings));
                    }
                    else
                    {
                        if (this.SecurityToken != null)
                        {
                            securitySettings = (ct) => Task.FromResult<SecuritySettings>(new AzureActiveDirectorySecuritySettings(this.SecurityToken, remoteX509SecuritySettings));
                        }
                        else
                        {
                            securitySettings = (ct) => Task.FromResult<SecuritySettings>(new AzureActiveDirectorySecuritySettings(CredentialsUtil.GetAccessTokenAsync, remoteX509SecuritySettings));   
                        }
                    }
                }
                else
                {
                    if (this.ClientCertificate == null)
                    {
                        var clientCert = CredentialsUtil.GetCertificate(this.StoreLocation, this.StoreName, this.FindValue, this.FindType);

                        if (clientCert != null)
                        {
                            throw new PSInvalidOperationException(Resource.ErrorLoadingClientCertificate);
                        }

                        securitySettings = (ct) => Task.FromResult<SecuritySettings>(new X509SecuritySettings(clientCert, remoteX509SecuritySettings));
                    }
                    else
                    {
                        securitySettings = (ct) => Task.FromResult<SecuritySettings>(new X509SecuritySettings(this.ClientCertificate, remoteX509SecuritySettings));
                    }                    
                }
            }

            var client = ServiceFabricClientFactory.Create(this.ConnectionEndpoint.Select(e => new Uri(e)).ToList(), new ClientSettings(securitySettings));
            
            if (this.GetMetadata.IsPresent)
            {
                var aadMetadata = client.Cluster.GetAadMetadataAsync(cancellationToken: this.CancellationToken).GetAwaiter().GetResult().Metadata;
                var result = new PSObject();

                result.Properties.Add(new PSNoteProperty(nameof(aadMetadata.Authority), aadMetadata.Authority));
                result.Properties.Add(new PSNoteProperty(nameof(aadMetadata.Client), aadMetadata.Client));
                result.Properties.Add(new PSNoteProperty(nameof(aadMetadata.Cluster), aadMetadata.Cluster));
                result.Properties.Add(new PSNoteProperty(nameof(aadMetadata.Login), aadMetadata.Login));
                result.Properties.Add(new PSNoteProperty(nameof(aadMetadata.Redirect), aadMetadata.Redirect));
                result.Properties.Add(new PSNoteProperty(nameof(aadMetadata.Tenant), aadMetadata.Tenant));

                this.WriteObject(result);
            }

            this.SessionState.PSVariable.Set(Constants.ClusterConnectionVariableName, client);
            client.Cluster.GetClusterManifestAsync(cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
            Console.WriteLine(Resource.MsgConnectSuccess);
        }
    }
}
