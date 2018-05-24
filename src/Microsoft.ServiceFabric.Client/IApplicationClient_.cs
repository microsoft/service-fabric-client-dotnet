// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Exceptions;
    using Microsoft.ServiceFabric.Client.Exceptions;

    /// <summary>
    /// Interface containing methods for performing Application operations.
    /// </summary>
    public partial interface IApplicationClient
    {
		/// <summary>
		/// Uploads application package to Service Fabric image store after compressing all sub-directories under the service directory.
		/// </summary>
		/// <param name="applicationPackagePath">Absolute path to application package.</param>        
		/// <param name="compressPackage">Compress the package before uploading.</param>        
		/// <param name="applicationPackagePathInImageStore">Relative path in the image store where the application package should be copied.
		/// If this is not specified, it defaults to the folder name as specified by applicationPackagePath.
		/// </param>
		/// <param name="cancellationToken"></param>
		/// <returns>A task that represents the asynchronous operation.</returns>
		/// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
		/// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
		/// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/> and Error Message <see cref="FabricError.Message"/> indicating the failure.</exception>
		/// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
		Task UploadApplicationPackageAsync(
            string applicationPackagePath,
			bool compressPackage,
			string applicationPackagePathInImageStore = default(string),
            CancellationToken cancellationToken = default(CancellationToken));        
    }
}
