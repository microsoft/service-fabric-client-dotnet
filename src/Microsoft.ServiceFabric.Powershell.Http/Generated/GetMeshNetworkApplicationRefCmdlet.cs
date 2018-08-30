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
    /// Gets information about a Service Fabric application that is associated with a Service Fabric container network.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshNetworkApplicationRef", DefaultParameterSetName = "GetMeshNetworkApplicationRef")]
    public partial class GetMeshNetworkApplicationRefCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NetworkName. The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "GetMeshNetworkApplicationRef")]
        public string NetworkName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationResourceName. Service Fabric application resource name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "GetMeshNetworkApplicationRef")]
        public string ApplicationResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "GetMeshNetworkApplicationRef")]
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
                var result = this.ServiceFabricClient.MeshNetworks.GetMeshNetworkApplicationRefAsync(
                    networkName: this.NetworkName,
                    applicationResourceName: this.ApplicationResourceName,
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
