// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Creates a particular correlation between services.
    /// </summary>
    public partial class ServiceCorrelationDescription
    {
        /// <summary>
        /// Initializes a new instance of the ServiceCorrelationDescription class.
        /// </summary>
        /// <param name="scheme">The service correlation scheme. Possible values include: 'Invalid', 'Affinity',
        /// 'AlignedAffinity', 'NonAlignedAffinity'</param>
        /// <param name="serviceName">The name of the service that the correlation relationship is established with.</param>
        public ServiceCorrelationDescription(
            ServiceCorrelationScheme? scheme,
            ServiceName serviceName)
        {
            scheme.ThrowIfNull(nameof(scheme));
            serviceName.ThrowIfNull(nameof(serviceName));
            this.Scheme = scheme;
            this.ServiceName = serviceName;
        }

        /// <summary>
        /// Gets the service correlation scheme. Possible values include: 'Invalid', 'Affinity', 'AlignedAffinity',
        /// 'NonAlignedAffinity'
        /// </summary>
        public ServiceCorrelationScheme? Scheme { get; }

        /// <summary>
        /// Gets the name of the service that the correlation relationship is established with.
        /// </summary>
        public ServiceName ServiceName { get; }
    }
}
