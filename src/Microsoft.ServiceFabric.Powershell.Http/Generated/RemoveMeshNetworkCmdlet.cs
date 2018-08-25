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
    /// Deletes an existing Service Fabric container network.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "SFMeshNetwork", DefaultParameterSetName = "DeleteMeshNetwork")]
    public partial class RemoveMeshNetworkCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NetworkName. The name of a Service Fabric container network. A network name serves as the identity of
        /// a container network and is case-sensitive.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "DeleteMeshNetwork")]
        public string NetworkName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "DeleteMeshNetwork")]
        public long? ServerTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the force flag. If provided, then the destructive action will be performed without asking for
        /// confirmation prompt.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "DeleteMeshNetwork")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                if (((this.Force != null) && this.Force) || this.ShouldContinue(string.Empty, string.Empty))
                {
                    this.ServiceFabricClient.MeshNetworks.DeleteMeshNetworkAsync(
                        networkName: this.NetworkName,
                        serverTimeout: this.ServerTimeout,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                    Console.WriteLine("Success!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
