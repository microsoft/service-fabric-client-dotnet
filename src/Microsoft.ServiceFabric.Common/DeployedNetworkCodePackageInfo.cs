// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information about a Service Fabric code package deployed to a Service Fabric node and associated with a Service
    /// Fabric container network.
    /// </summary>
    public partial class DeployedNetworkCodePackageInfo
    {
        /// <summary>
        /// Initializes a new instance of the DeployedNetworkCodePackageInfo class.
        /// </summary>
        /// <param name="applicationName">The name of the application, including the 'fabric:' URI scheme.</param>
        /// <param name="networkName">The name of a Service Fabric container network.</param>
        /// <param name="codePackageName">The name of the code package defined in the service manifest.</param>
        /// <param name="codePackageVersion">The version of the code package specified in service manifest.</param>
        /// <param name="serviceManifestName">The name of service manifest that specified this code package.</param>
        /// <param name="servicePackageActivationId">The ActivationId of a deployed service package. If
        /// ServicePackageActivationMode specified at the time of creating the service
        /// is 'SharedProcess' (or if it is not specified, in which case it defaults to 'SharedProcess'), then value of
        /// ServicePackageActivationId
        /// is always an empty string.
        /// </param>
        /// <param name="containerAddress">The address of the container in the container network.</param>
        /// <param name="containerId">The id of the container.</param>
        public DeployedNetworkCodePackageInfo(
            ApplicationName applicationName = default(ApplicationName),
            string networkName = default(string),
            string codePackageName = default(string),
            string codePackageVersion = default(string),
            string serviceManifestName = default(string),
            string servicePackageActivationId = default(string),
            string containerAddress = default(string),
            string containerId = default(string))
        {
            this.ApplicationName = applicationName;
            this.NetworkName = networkName;
            this.CodePackageName = codePackageName;
            this.CodePackageVersion = codePackageVersion;
            this.ServiceManifestName = serviceManifestName;
            this.ServicePackageActivationId = servicePackageActivationId;
            this.ContainerAddress = containerAddress;
            this.ContainerId = containerId;
        }

        /// <summary>
        /// Gets the name of the application, including the 'fabric:' URI scheme.
        /// </summary>
        public ApplicationName ApplicationName { get; }

        /// <summary>
        /// Gets the name of a Service Fabric container network.
        /// </summary>
        public string NetworkName { get; }

        /// <summary>
        /// Gets the name of the code package defined in the service manifest.
        /// </summary>
        public string CodePackageName { get; }

        /// <summary>
        /// Gets the version of the code package specified in service manifest.
        /// </summary>
        public string CodePackageVersion { get; }

        /// <summary>
        /// Gets the name of service manifest that specified this code package.
        /// </summary>
        public string ServiceManifestName { get; }

        /// <summary>
        /// Gets the ActivationId of a deployed service package. If ServicePackageActivationMode specified at the time of
        /// creating the service
        /// is 'SharedProcess' (or if it is not specified, in which case it defaults to 'SharedProcess'), then value of
        /// ServicePackageActivationId
        /// is always an empty string.
        /// </summary>
        public string ServicePackageActivationId { get; }

        /// <summary>
        /// Gets the address of the container in the container network.
        /// </summary>
        public string ContainerAddress { get; }

        /// <summary>
        /// Gets the id of the container.
        /// </summary>
        public string ContainerId { get; }
    }
}
