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
    /// Starts Chaos in the cluster.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "SFChaos", DefaultParameterSetName = "StartChaos")]
    public partial class StartChaosCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets TimeToRunInSeconds. Total time (in seconds) for which Chaos will run before automatically stopping.
        /// The maximum allowed value is 4,294,967,295 (System.UInt32.MaxValue).
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "StartChaos")]
        public string TimeToRunInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxClusterStabilizationTimeoutInSeconds. The maximum amount of time to wait for all cluster entities
        /// to become stable and healthy. Chaos executes in iterations and at the start of each iteration it validates the
        /// health of cluster entities.
        /// During validation if a cluster entity is not stable and healthy within MaxClusterStabilizationTimeoutInSeconds,
        /// Chaos generates a validation failed event.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "StartChaos")]
        public long? MaxClusterStabilizationTimeoutInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxConcurrentFaults. MaxConcurrentFaults is the maximum number of concurrent faults induced per
        /// iteration.
        /// Chaos executes in iterations and two consecutive iterations are separated by a validation phase.
        /// The higher the concurrency, the more aggressive the injection of faults, leading to inducing more complex series of
        /// states to uncover bugs.
        /// The recommendation is to start with a value of 2 or 3 and to exercise caution while moving up.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "StartChaos")]
        public long? MaxConcurrentFaults
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets EnableMoveReplicaFaults. Enables or disables the move primary and move secondary faults.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "StartChaos")]
        public bool? EnableMoveReplicaFaults
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets WaitTimeBetweenFaultsInSeconds. Wait time (in seconds) between consecutive faults within a single
        /// iteration.
        /// The larger the value, the lower the overlapping between faults and the simpler the sequence of state transitions
        /// that the cluster goes through.
        /// The recommendation is to start with a value between 1 and 5 and exercise caution while moving up.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "StartChaos")]
        public long? WaitTimeBetweenFaultsInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets WaitTimeBetweenIterationsInSeconds. Time-separation (in seconds) between two consecutive iterations of
        /// Chaos.
        /// The larger the value, the lower the fault injection rate.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "StartChaos")]
        public long? WaitTimeBetweenIterationsInSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ClusterHealthPolicy. Passed-in cluster health policy is used to validate health of the cluster in
        /// between Chaos iterations. If the cluster health is in error or if an unexpected exception happens during fault
        /// execution--to provide the cluster with some time to recuperate--Chaos will wait for 30 minutes before the next
        /// health-check.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "StartChaos")]
        public ClusterHealthPolicy ClusterHealthPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Context. Describes a map, which is a collection of (string, string) type key-value pairs. The map can
        /// be used to record information about
        /// the Chaos run. There cannot be more than 100 such pairs and each string (key or value) can be at most 4095
        /// characters long.
        /// This map is set by the starter of the Chaos run to optionally store the context about the specific run.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "StartChaos")]
        public ChaosContext Context
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ChaosTargetFilter. List of cluster entities to target for Chaos faults.
        /// This filter can be used to target Chaos faults only to certain node types or only to certain application instances.
        /// If ChaosTargetFilter is not used, Chaos faults all cluster entities.
        /// If ChaosTargetFilter is used, Chaos faults only the entities that meet the ChaosTargetFilter specification.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "StartChaos")]
        public ChaosTargetFilter ChaosTargetFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "StartChaos")]
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
                var chaosParameters = new ChaosParameters(
                timeToRunInSeconds: this.TimeToRunInSeconds,
                maxClusterStabilizationTimeoutInSeconds: this.MaxClusterStabilizationTimeoutInSeconds,
                maxConcurrentFaults: this.MaxConcurrentFaults,
                enableMoveReplicaFaults: this.EnableMoveReplicaFaults,
                waitTimeBetweenFaultsInSeconds: this.WaitTimeBetweenFaultsInSeconds,
                waitTimeBetweenIterationsInSeconds: this.WaitTimeBetweenIterationsInSeconds,
                clusterHealthPolicy: this.ClusterHealthPolicy,
                context: this.Context,
                chaosTargetFilter: this.ChaosTargetFilter);

                this.ServiceFabricClient.ChaosClient.StartChaosAsync(
                    chaosParameters: chaosParameters,
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
