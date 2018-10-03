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
    /// Adds the specified value as a new version of the specified secret resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "SFValueMeshSecretValue", DefaultParameterSetName = "AddValue")]
    public partial class AddValueMeshSecretValueCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets SecretResourceName. The name of the secret resource.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "AddValue")]
        public string SecretResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets SecretValueResourceName. The name of the secret resource value which is typically the version
        /// identifier for the value.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "AddValue")]
        public string SecretValueResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Name. Version identifier of the secret value.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "AddValue")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Name. Version identifier of the secret value.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = "AddValue")]
        public string Value { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            var secretValueResourceProperties = new SecretValueResourceProperties(
            value: this.Value);

            var secretValueResourceDescription = new SecretValueResourceDescription(
            name: this.Name,
            properties: secretValueResourceProperties);

            var result = this.ServiceFabricClient.MeshSecretValues.AddValueAsync(
                secretResourceName: this.SecretResourceName,
                secretValueResourceName: this.SecretValueResourceName,
                secretValueResourceDescription: secretValueResourceDescription,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

            this.WriteObject(this.FormatOutput(result));
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            return output;
        }
    }
}
