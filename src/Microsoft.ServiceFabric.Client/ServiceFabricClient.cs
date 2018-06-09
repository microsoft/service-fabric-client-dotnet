// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Common.Security;
    using Resources;

    /// <summary>
    /// Represents the base class for the Service Fabric client.
    /// </summary>
    public abstract class ServiceFabricClient : IServiceFabricClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFabricClient"/> class.
        /// </summary>
        /// <param name="clusterEndpoint">Uri for Service Cluster management endpoint.</param>
        /// <param name="clientSettings">Client settings for connecting to cluster. Default value is null which means connecting to unsecured cluster.</param>
        protected ServiceFabricClient(Uri clusterEndpoint, ClientSettings clientSettings = null)
            : this(new List<Uri>() { clusterEndpoint }, clientSettings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceFabricClient"/> class.
        /// </summary>
        /// <param name="clusterEndpoints">Uris for Service Cluster management endpoint.</param>
        /// <param name="clientSettings">Client settings for connecting to cluster. Default value is null which means connecting to unsecured cluster.</param>
        protected ServiceFabricClient(
            IReadOnlyList<Uri> clusterEndpoints,
            ClientSettings clientSettings = null)
        {
            if (clusterEndpoints == null)
            {
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

            this.ClusterEndpoints = clusterEndpoints;

            // setup security settings
            this.ClientSettings = clientSettings;
        }

        /// <inheritdoc/>
        public IApplicationClient Applications { get; protected set; }

        /// <inheritdoc/>
        public IApplicationTypeClient ApplicationTypes { get; protected set; }

        /// <inheritdoc/>
        public IBackupRestoreClient BackupRestore { get; protected set; }

        /// <inheritdoc/>
        public IChaosClient ChaosClient { get; protected set; }

        /// <inheritdoc/>
        public IClusterClient Cluster { get; protected set; }

        /// <inheritdoc/>
        public ICodePackageClient CodePackages { get; protected set; }

        /// <inheritdoc/>
        public IComposeDeploymentClient ComposeDeployments { get; protected set; }

        /// <inheritdoc/>
        public IFaultsClient Faults { get; protected set; }

        /// <inheritdoc/>
        public IImageStoreClient ImageStore { get; protected set; }

        /// <inheritdoc/>
        public IInfrastructureClient Infrastructure { get; protected set; }

        /// <inheritdoc/>
        public INodeClient Nodes { get; protected set; }

        /// <inheritdoc/>
        public IPartitionClient Partitions { get; protected set; }

        /// <inheritdoc/>
        public IPropertyManagementClient Properties { get; protected set; }

        /// <inheritdoc/>
        public IReplicaClient Replicas { get; protected set; }

        /// <inheritdoc/>
        public IRepairManagementClient Repairs { get; protected set; }

        /// <inheritdoc/>
        public IServiceClient Services { get; protected set; }

        /// <inheritdoc/>
        public IServicePackageClient ServicePackages { get; protected set; }

        /// <inheritdoc/>
        public IServiceTypeClient ServiceTypes { get; protected set; }

        /// <inheritdoc/>
        public IEventsStoreClient EventsStore { get; protected set; }

        /// <summary>
        /// Gets the client settings for connecting to cluster.
        /// </summary>
        /// <value><see cref="ClientSettings"/> for connecting to cluster.</value>
        protected ClientSettings ClientSettings { get; }

        /// <summary>
        /// Gets the Uri for Service Cluster management endpoint.
        /// </summary>
        /// <value>Cluster endpoint <see cref="System.Uri"/> .</value>
        protected IReadOnlyList<Uri> ClusterEndpoints { get; }
    }
}
