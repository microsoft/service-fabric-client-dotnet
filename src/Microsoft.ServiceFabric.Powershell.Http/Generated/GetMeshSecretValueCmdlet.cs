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
    /// Lists the specified value of the secret resource.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFMeshSecretValue", DefaultParameterSetName = "ListMeshSecretValue")]
    public partial class GetMeshSecretValueCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets SecretResourceName. The name of the secret resource.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ListMeshSecretValue")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ListMeshSecretValues")]
        public string SecretResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets SecretValueResourceName. The name of the secret resource value which is typically the version
        /// identifier for the value.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ListMeshSecretValue")]
        public string SecretValueResourceName
        {
            get;
            set;
        }

        /// <inheritdoc/>
        protected override void ProcessRecordInternal()
        {
            try
            {
                if (this.ParameterSetName.Equals("ListMeshSecretValue"))
                {
                    var result = this.ServiceFabricClient.MeshSecretValues.ListMeshSecretValueAsync(
                        secretResourceName: this.SecretResourceName,
                        secretValueResourceName: this.SecretValueResourceName,
                        cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                    this.WriteObject(this.FormatOutput(result));
                }
                else if (this.ParameterSetName.Equals("ListMeshSecretValues"))
                {
                    var continuationToken = ContinuationToken.Empty;
                    do
                    {
                        var result = this.ServiceFabricClient.MeshSecretValues.ListMeshSecretValuesAsync(
                            secretResourceName: this.SecretResourceName,
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
