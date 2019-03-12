// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains the list of Chaos events and the continuation token to get the next segment.
    /// </summary>
    public partial class ChaosEventsSegment
    {
        /// <summary>
        /// Initializes a new instance of the ChaosEventsSegment class.
        /// </summary>
        /// <param name="continuationToken">The continuation token parameter is used to obtain next set of results. The
        /// continuation token is included in the response of the API when the results from the system do not fit in a single
        /// response. When this value is passed to the next API call, the API returns next set of results. If there are no
        /// further results then the continuation token is not included in the response.</param>
        /// <param name="history">List of Chaos events that meet the user-supplied criteria.</param>
        public ChaosEventsSegment(
            ContinuationToken continuationToken = default(ContinuationToken),
            IEnumerable<ChaosEventWrapper> history = default(IEnumerable<ChaosEventWrapper>))
        {
            this.ContinuationToken = continuationToken;
            this.History = history;
        }

        /// <summary>
        /// Gets the continuation token parameter is used to obtain next set of results. The continuation token is included in
        /// the response of the API when the results from the system do not fit in a single response. When this value is passed
        /// to the next API call, the API returns next set of results. If there are no further results then the continuation
        /// token is not included in the response.
        /// </summary>
        public ContinuationToken ContinuationToken { get; }

        /// <summary>
        /// Gets list of Chaos events that meet the user-supplied criteria.
        /// </summary>
        public IEnumerable<ChaosEventWrapper> History { get; }
    }
}
