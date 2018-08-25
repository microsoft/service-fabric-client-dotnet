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
    /// Gets the list of Service Fabric container networks created in the Service Fabric cluster that match the specified
    /// filters.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshNetworks", DefaultParameterSetName = "GetMeshNetworks")]
    public partial class GetMeshNetworksCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NetworkStatusFilter. Allow filtering of container network state objects returned by GetNetworkInfoList
        /// query based on the container networks' status.
        /// - Default - Default value, which performs the same function as selecting "all". The value is 0.
        /// - All - Filter that matches input with any NetworkStatus value. The value is 65535.
        /// - Ready - Filter that matches input with NetworkStatus value ready. The value is 1.
        /// - Creating - Filter that matches input with NetworkStatus value creating. The value is 2.
        /// - Deleting - Filter that matches input with NetworkStatus value deleting. The value is 4.
        /// - Updating - Filter that matches input with NetworkStatus value updating. The value is 8.
        /// - Stopping - Filter that matches input with NetworkStatus value stopping. The value is 16.
        /// - Stopped - Filter that matches input with NetworkStatus value stopped. The value is 32.
        /// - Starting - Filter that matches input with NetworkStatus value starting. The value is 64.
        /// - Failed - Filter that matches input with NetworkStatus value failed. The value is 128.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "GetMeshNetworks")]
        public int? NetworkStatusFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxResults. The maximum number of results to be returned as part of the paged queries. This parameter
        /// defines the upper bound on the number of results returned. The results returned can be less than the specified
        /// maximum results if they do not fit in the message as per the max message size restrictions defined in the
        /// configuration. If this parameter is zero or not specified, the paged query includes as many results as possible
        /// that fit in the return message.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "GetMeshNetworks")]
        public long? MaxResults
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "GetMeshNetworks")]
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
                var continuationToken = ContinuationToken.Empty;
                do
                {
                    var result = this.ServiceFabricClient.MeshNetworks.GetMeshNetworksAsync(
                        networkStatusFilter: this.NetworkStatusFilter,
                        continuationToken: continuationToken,
                        maxResults: this.MaxResults,
                        serverTimeout: this.ServerTimeout,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                    var count = 0;
                    foreach (var item in result.Data)
                    {
                        count++;
                        this.WriteObject(this.FormatOutput(item));
                    }

                    continuationToken = result.ContinuationToken;
                    this.WriteDebug(string.Format(Resource.MsgCountAndContinuationToken, count, continuationToken));
                }
                while (continuationToken.Next);
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
