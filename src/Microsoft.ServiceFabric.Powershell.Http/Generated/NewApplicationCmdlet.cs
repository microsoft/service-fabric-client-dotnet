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
    /// Creates a Service Fabric application.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFApplication", DefaultParameterSetName = "CreateApplication")]
    public partial class NewApplicationCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Name. The name of the application, including the 'fabric:' URI scheme.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "CreateApplication")]
        public ApplicationName Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets TypeName. The application type name as defined in the application manifest.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "CreateApplication")]
        public string TypeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets TypeVersion. The version of the application type as defined in the application manifest.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "CreateApplication")]
        public string TypeVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Parameters. List of application parameters with overridden values from their default values specified
        /// in the application manifest.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "CreateApplication")]
        public IReadOnlyDictionary<string, string> Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationCapacity. Describes capacity information for services of this application. This description
        /// can be used for describing the following.
        /// - Reserving the capacity for the services on the nodes
        /// - Limiting the total number of nodes that services of this application can run on
        /// - Limiting the custom capacity metrics to limit the total consumption of this metric by the services of this
        /// application
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "CreateApplication")]
        public ApplicationCapacityDescription ApplicationCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "CreateApplication")]
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
                var applicationDescription = new ApplicationDescription(
                name: this.Name,
                typeName: this.TypeName,
                typeVersion: this.TypeVersion,
                parameters: this.Parameters,
                applicationCapacity: this.ApplicationCapacity);

                this.ServiceFabricClient.Applications.CreateApplicationAsync(
                    applicationDescription: applicationDescription,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
