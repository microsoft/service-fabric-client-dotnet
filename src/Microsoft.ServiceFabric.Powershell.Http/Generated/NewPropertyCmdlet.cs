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
    /// Creates or updates a Service Fabric property.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFProperty", DefaultParameterSetName = "PutProperty")]
    public partial class NewPropertyCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NameId. The Service Fabric name, without the 'fabric:' URI scheme.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, ParameterSetName = "PutProperty")]
        public string NameId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets PropertyName. The name of the Service Fabric property.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "PutProperty")]
        public string PropertyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Value. Describes a Service Fabric property value.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "PutProperty")]
        public PropertyValue Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets CustomTypeId. The property's custom type ID. Using this property, the user is able to tag the type of
        /// the value of the property.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "PutProperty")]
        public string CustomTypeId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "PutProperty")]
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
                var propertyDescription = new PropertyDescription(
                propertyName: this.PropertyName,
                value: this.Value,
                customTypeId: this.CustomTypeId);

                this.ServiceFabricClient.Properties.PutPropertyAsync(
                    nameId: this.NameId,
                    propertyDescription: propertyDescription,
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
