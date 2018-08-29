// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Client;
    using Microsoft.ServiceFabric.Common.Utilities;

    /// <summary>
    /// Deploys mesh resources in a Service Fabric Mesh cluster.
    /// </summary>
    [Cmdlet("Deploy", "SFMeshResource")]
    public class DeployMeshResourcesCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Resources Hash, which is a comma separated list of yaml definitions for each resource type:
        /// network, volume, app, gateway.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public Dictionary<string, string> ResourceDescriptionFileHash { get; set; }

        /// <summary>
        /// Gets or sets the output directory for the generated resource descriptions.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "json")]
        public string OutputResourceDescription { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var outputDir = this.OutputResourceDescription;
            if (string.IsNullOrEmpty(this.OutputResourceDescription))
            {
                outputDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            }

            // if input hash contains network key
            if (this.ResourceDescriptionFileHash.ContainsKey("network"))
            {
                var jsonList = YamlUtils.GenerateMergedResourceDescription(this.ResourceDescriptionFileHash["network"], outputDir);
                foreach (var jsonListIter in jsonList)
                {
                    var resourceName = YamlUtils.GetKeyValueFromJSON(jsonListIter, "Name");

                    // call create network with resource name and resource jsonfile
                    client.MeshNetworks.CreateOrUpdateMeshNetworkAsync(
                        networkResourceName: resourceName,
                        descriptionFile: jsonListIter,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                }
            }

            // if input hash contains volume key
            if (this.ResourceDescriptionFileHash.ContainsKey("volume"))
            {
                var jsonList = YamlUtils.GenerateMergedResourceDescription(this.ResourceDescriptionFileHash["volume"], outputDir);
                foreach (var jsonListIter in jsonList)
                {
                    var resourceName = YamlUtils.GetKeyValueFromJSON(jsonListIter, "Name");

                    // call create volume with resource name and resource jsonfile
                    client.MeshVolumes.CreateOrUpdateMeshVolumeAsync(
                        volumeResourceName: resourceName,
                        descriptionFile: jsonListIter,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                }
            }

            // if input hash contains app key
            if (this.ResourceDescriptionFileHash.ContainsKey("app"))
            {
                var jsonList = YamlUtils.GenerateMergedResourceDescription(this.ResourceDescriptionFileHash["app"], outputDir);
                foreach (var jsonListIter in jsonList)
                {
                    var resourceName = YamlUtils.GetKeyValueFromJSON(jsonListIter, "Name");

                    // call create app with resource name and resource jsonfile
                    client.MeshApplications.CreateOrUpdateMeshApplicationAsync(
                        applicationResourceName: resourceName,
                        descriptionFile: jsonListIter,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                }
            }

            // if input hash contains gateway key
            if (this.ResourceDescriptionFileHash.ContainsKey("gateway"))
            {
                var jsonList = YamlUtils.GenerateMergedResourceDescription(this.ResourceDescriptionFileHash["gateway"], outputDir);
                foreach (var jsonListIter in jsonList)
                {
                    var resourceName = YamlUtils.GetKeyValueFromJSON(jsonListIter, "Name");

                    // call create gateway with resource name and resource jsonfile
                    client.MeshGateways.CreateOrUpdateMeshGatewayAsync(
                        gatewayResourceName: resourceName,
                        descriptionFile: jsonListIter,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                }
            }

            if (string.IsNullOrEmpty(this.OutputResourceDescription))
            {
                Directory.Delete(outputDir, true);
            }
        }
    }
}
