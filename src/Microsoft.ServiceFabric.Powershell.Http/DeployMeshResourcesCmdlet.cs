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

    /// <summary>
    /// Deploys mesh resources in a Service Fabric Mesh cluster.
    /// </summary>
    [Cmdlet("Deploy", "SFMeshResources")]
    public class DeployMeshResourcesCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Resource Description Files, which is a list of yaml definitions for the resources
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public List<string> ResourceDescriptionList { get; set; }

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

            // Send the yaml list and the out dir to the util
            var resources = YamlUtils.GetFinalResourceDescriptionFromYamls(this.ResourceDescriptionList, outputDir);
            foreach (var resourceIter in resources)
            {
                switch (resourceIter.Item1)
                {
                    case YamlUtils.ResourseType.NETWORK:
                        client.MeshNetworks.CreateOrUpdateMeshNetworkAsync(
                            networkResourceName: resourceIter.Item2,
                            jsonDescription: resourceIter.Item3,
                            apiVersion: resourceIter.Item4,
                            cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                        break;

                    case YamlUtils.ResourseType.VOLUME:
                        client.MeshVolumes.CreateOrUpdateMeshVolumeAsync(
                            volumeResourceName: resourceIter.Item2,
                            jsonDescription: resourceIter.Item3,
                            apiVersion: resourceIter.Item4,
                            cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                        break;

                    case YamlUtils.ResourseType.APPLICATION:
                        client.MeshApplications.CreateOrUpdateMeshApplicationAsync(
                            applicationResourceName: resourceIter.Item2,
                            jsonDescription: resourceIter.Item3,
                            apiVersion: resourceIter.Item4,
                            cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                        break;

                    case YamlUtils.ResourseType.GATEWAY:
                        client.MeshGateways.CreateOrUpdateMeshGatewayAsync(
                            gatewayResourceName: resourceIter.Item2,
                            jsonDescription: resourceIter.Item3,
                            apiVersion: resourceIter.Item4,
                            cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
                        break;

                    default:
                        throw new PSArgumentException(Resource.ErrorInvalidResourceType, resourceIter.Item1.ToString());
                }
            }

            if (string.IsNullOrEmpty(this.OutputResourceDescription))
            {
                Directory.Delete(outputDir, true);
            }
        }
    }
}
