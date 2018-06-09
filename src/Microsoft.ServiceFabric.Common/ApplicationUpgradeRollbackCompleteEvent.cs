// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Application Upgrade Rollback Complete event.
    /// </summary>
    public partial class ApplicationUpgradeRollbackCompleteEvent : ApplicationEvent
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationUpgradeRollbackCompleteEvent class.
        /// </summary>
        /// <param name="eventInstanceId">The identifier for the FabricEvent instance.</param>
        /// <param name="timeStamp">The time event was logged.</param>
        /// <param name="applicationId">The identity of the application. This is an encoded representation of the application
        /// name. This is used in the REST APIs to identify the application resource.
        /// Starting in version 6.0, hierarchical names are delimited with the "\~" character. For example, if the application
        /// name is "fabric:/myapp/app1",
        /// the application identity would be "myapp\~app1" in 6.0+ and "myapp/app1" in previous versions.
        /// </param>
        /// <param name="applicationTypeName">Application type name.</param>
        /// <param name="applicationTypeVersion">Application type version.</param>
        /// <param name="failureReason">Describes reason of failure.</param>
        /// <param name="overallUpgradeElapsedTimeInMs">Overall upgrade time in milli-seconds.</param>
        /// <param name="hasCorrelatedEvents">Shows there is existing related events available.</param>
        public ApplicationUpgradeRollbackCompleteEvent(
            Guid? eventInstanceId,
            DateTime? timeStamp,
            string applicationId,
            string applicationTypeName,
            string applicationTypeVersion,
            string failureReason,
            double? overallUpgradeElapsedTimeInMs,
            bool? hasCorrelatedEvents = default(bool?))
            : base(
                eventInstanceId,
                timeStamp,
                Common.FabricEventKind.ApplicationUpgradeRollbackComplete,
                applicationId,
                hasCorrelatedEvents)
        {
            applicationTypeName.ThrowIfNull(nameof(applicationTypeName));
            applicationTypeVersion.ThrowIfNull(nameof(applicationTypeVersion));
            failureReason.ThrowIfNull(nameof(failureReason));
            overallUpgradeElapsedTimeInMs.ThrowIfNull(nameof(overallUpgradeElapsedTimeInMs));
            this.ApplicationTypeName = applicationTypeName;
            this.ApplicationTypeVersion = applicationTypeVersion;
            this.FailureReason = failureReason;
            this.OverallUpgradeElapsedTimeInMs = overallUpgradeElapsedTimeInMs;
        }

        /// <summary>
        /// Gets application type name.
        /// </summary>
        public string ApplicationTypeName { get; }

        /// <summary>
        /// Gets application type version.
        /// </summary>
        public string ApplicationTypeVersion { get; }

        /// <summary>
        /// Gets describes reason of failure.
        /// </summary>
        public string FailureReason { get; }

        /// <summary>
        /// Gets overall upgrade time in milli-seconds.
        /// </summary>
        public double? OverallUpgradeElapsedTimeInMs { get; }
    }
}
