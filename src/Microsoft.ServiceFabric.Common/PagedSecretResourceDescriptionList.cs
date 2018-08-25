// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The list of secret resources, paged if the number of results exceeds the limits of a single message. The next set
    /// of results can be obtained by executing the same query with the continuation token provided in the previous page.
    /// </summary>
    public partial class PagedSecretResourceDescriptionList
    {
        /// <summary>
        /// Initializes a new instance of the PagedSecretResourceDescriptionList class.
        /// </summary>
        /// <param name="continuationToken">The continuation token parameter is used to obtain next set of results. The
        /// continuation token is included in the response of the API when the results from the system do not fit in a single
        /// response. When this value is passed to the next API call, the API returns next set of results. If there are no
        /// further results, then the continuation token is not included in the response.</param>
        /// <param name="items">One page of the list.</param>
        public PagedSecretResourceDescriptionList(
            ContinuationToken continuationToken = default(ContinuationToken),
            IEnumerable<SecretResourceDescription> items = default(IEnumerable<SecretResourceDescription>))
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
        /// Gets one page of the list.
        /// </summary>
        public IEnumerable<SecretResourceDescription> Items { get; }
    }
}
