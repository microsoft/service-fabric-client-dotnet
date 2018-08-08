// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The list of service resources in the cluster. The list is paged when all of the results cannot fit in a single
    /// message. The next set of results can be obtained by executing the same query with the continuation token provided
    /// in this list.
    /// </summary>
    public partial class PagedServiceResourceReplicaDescriptionList
    {
        /// <summary>
        /// Initializes a new instance of the PagedServiceResourceReplicaDescriptionList class.
        /// </summary>
        /// <param name="continuationToken">The continuation token parameter is used to obtain next set of results. The
        /// continuation token is included in the response of the API when the results from the system do not fit in a single
        /// response. When this value is passed to the next API call, the API returns next set of results. If there are no
        /// further results, then the continuation token is not included in the response.</param>
        /// <param name="items">List of service resource description.</param>
        public PagedServiceResourceReplicaDescriptionList(
            ContinuationToken continuationToken = default(ContinuationToken),
            IEnumerable<ServiceResourceReplicaDescription> items = default(IEnumerable<ServiceResourceReplicaDescription>))
        {
            this.ContinuationToken = continuationToken;
            this.Items = items;
        }

        /// <summary>
        /// Gets the continuation token parameter is used to obtain next set of results. The continuation token is included in
        /// the response of the API when the results from the system do not fit in a single response. When this value is passed
        /// to the next API call, the API returns next set of results. If there are no further results, then the continuation
        /// token is not included in the response.
        /// </summary>
        public ContinuationToken ContinuationToken { get; }

        /// <summary>
        /// Gets list of service resource description.
        /// </summary>
        public IEnumerable<ServiceResourceReplicaDescription> Items { get; }
    }
}
