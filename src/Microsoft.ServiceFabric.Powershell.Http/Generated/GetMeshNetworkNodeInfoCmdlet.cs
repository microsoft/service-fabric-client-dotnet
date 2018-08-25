// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Common;

    /// <summary>
    /// Gets the information about a Service Fabric node that a Service Fabric container network is deployed to.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshNetworkNodeInfo", DefaultParameterSetName = "GetMeshNetworkNodeInfo")]
    public partial class GetMeshNetworkNodeInfoCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NetworkName. The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshNetworkNodeInfo")]
        public string NetworkName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets NodeName. The name of the node.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "GetMeshNetworkNodeInfo")]
        public NodeName NodeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "GetMeshNetworkNodeInfo")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                var result = this.ServiceFabricClient.MeshNetworks.GetMeshNetworkNodeInfoAsync(
                    networkName: this.NetworkName,
                    nodeName: this.NodeName,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
