// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes the resource that is used for triggering auto scaling.
    /// </summary>
    public partial class AutoScalingResourceMetric : AutoScalingMetric
    {
        /// <summary>
        /// Initializes a new instance of the AutoScalingResourceMetric class.
        /// </summary>
        /// <param name="name">Name of the resource (like cpu or memoryInGB). Possible values include: 'cpu',
        /// 'memoryInGB'</param>
        public AutoScalingResourceMetric(
            string name)
            : base(
                Common.AutoScalingMetricKind.Resource)
        {
            name.ThrowIfNull(nameof(name));
            this.Name = name;
        }

        /// <summary>
        /// Gets name of the resource (like cpu or memoryInGB). Possible values include: 'cpu', 'memoryInGB'
        /// </summary>
        public string Name { get; }
    }
}
