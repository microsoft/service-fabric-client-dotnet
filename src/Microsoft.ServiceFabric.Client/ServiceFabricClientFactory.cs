// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Security;
    using Resources;

    /// <summary>
    /// Factory to create IServiceFabricClient depending on arguments passed to Create method.
    /// </summary>
    public class ServiceFabricClientFactory
    {
        private const string ServiceFabricHttpClientAssemblyName = "Microsoft.ServiceFabric.Client.Http";
        private const string ServiceFabricHttpClientTypeName = "Microsoft.ServiceFabric.Client.Http.ServiceFabricHttpClient,Microsoft.ServiceFabric.Client.Http";

        /// <summary>
        /// Instantiate correct implementation of IServiceFabricClient depending on the cluster endpoint uri scheme.
        /// </summary>
        /// <param name="clusterEndpoint">Uri for Service Cluster management endpoint.</param>
        /// <param name="clientSettings">Client settings for connecting to cluster. Default value is null which means connecting to unsecured cluster.</param>
        /// <returns>Instance of correct implementation of IServiceFabricClient depending on the cluster endpoint uri scheme.</returns>
        public static IServiceFabricClient Create(Uri clusterEndpoint, ClientSettings clientSettings = null)
        {
            return Create(new List<Uri>() { clusterEndpoint }, clientSettings);
        }

        /// <summary>
        /// Instantiate correct implementation of IServiceFabricClient depending on the cluster endpoints uri scheme.
        /// </summary>
        /// <param name="clusterEndpoints">Uris for Service Cluster management endpoint.</param>
        /// <param name="clientSettings">Client settings for connecting to cluster. Default value is null which means connecting to unsecured cluster.</param>
        /// <returns>Instance of correct implementation of IServiceFabricClient depending on the cluster endpoint uri scheme.</returns>
        public static IServiceFabricClient Create(IList<Uri> clusterEndpoints, ClientSettings clientSettings = null)
        {
            IServiceFabricClient serviceFabricClient = null;

            if (clusterEndpoints == null)
            {
                // TODO: Create Tcp FabricClient by default in this case when Tcp Fabric CLient implementation is available.
                throw new ArgumentNullException(nameof(clusterEndpoints));
            }

            if (clusterEndpoints.Count == 0)
            {
                throw new ArgumentException(SR.ErrorClusterEndpointNotProvided, nameof(clusterEndpoints));
            }

            if (clusterEndpoints.Any(url => url == null))
            {
                throw new ArgumentException(SR.ErrorUrlCannotBeNull, nameof(clusterEndpoints));
            }

            // all endpoints must have same Uri.UriScheme
            var scheme = clusterEndpoints[0].Scheme;

            if (clusterEndpoints.Any(url => !string.Equals(url.Scheme, scheme, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException(SR.ErrorUrlSchemeMismatch);
            }

            if (scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
            {
                // Since this factory is used to create IServiceFabricClient based on the endpoints scheme, its generic
                // should use reflection to create ServiceFabricHttpClient.
                object[] args =
                {
                    clusterEndpoints,
                    clientSettings,
                    null, //// null for optional innerHandler param
                };

                var type = Type.GetType(ServiceFabricHttpClientTypeName);
                var obj = Activator.CreateInstance(type, args);

                serviceFabricClient = (IServiceFabricClient)obj;
            }

            return serviceFabricClient;
        }
    }
}
