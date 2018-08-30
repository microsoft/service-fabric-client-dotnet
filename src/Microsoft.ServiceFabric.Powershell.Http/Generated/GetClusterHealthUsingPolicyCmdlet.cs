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
    /// Gets the health of a Service Fabric cluster using the specified policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SFClusterHealthUsingPolicy", DefaultParameterSetName = "GetClusterHealthUsingPolicy")]
    public partial class GetClusterHealthUsingPolicyCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets NodesHealthStateFilter. Allows filtering of the node health state objects returned in the result of
        /// cluster health query
        /// based on their health state. The possible values for this parameter include integer value of one of the
        /// following health states. Only nodes that match the filter are returned. All nodes are used to evaluate the
        /// aggregated health state.
        /// If not specified, all entries are returned.
        /// The state values are flag-based enumeration, so the value could be a combination of these values obtained using
        /// bitwise 'OR' operator.
        /// For example, if the provided value is 6 then health state of nodes with HealthState value of OK (2) and Warning (4)
        /// are returned.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public int? NodesHealthStateFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationsHealthStateFilter. Allows filtering of the application health state objects returned in
        /// the result of cluster health
        /// query based on their health state.
        /// The possible values for this parameter include integer value obtained from members or bitwise operations
        /// on members of HealthStateFilter enumeration. Only applications that match the filter are returned.
        /// All applications are used to evaluate the aggregated health state. If not specified, all entries are returned.
        /// The state values are flag-based enumeration, so the value could be a combination of these values obtained using
        /// bitwise 'OR' operator.
        /// For example, if the provided value is 6 then health state of applications with HealthState value of OK (2) and
        /// Warning (4) are returned.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public int? ApplicationsHealthStateFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets EventsHealthStateFilter. Allows filtering the collection of HealthEvent objects returned based on
        /// health state.
        /// The possible values for this parameter include integer value of one of the following health states.
        /// Only events that match the filter are returned. All events are used to evaluate the aggregated health state.
        /// If not specified, all entries are returned. The state values are flag-based enumeration, so the value could be a
        /// combination of these values, obtained using the bitwise 'OR' operator. For example, If the provided value is 6 then
        /// all of the events with HealthState value of OK (2) and Warning (4) are returned.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public int? EventsHealthStateFilter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ExcludeHealthStatistics. Indicates whether the health statistics should be returned as part of the
        /// query result. False by default.
        /// The statistics show the number of children entities in health state Ok, Warning, and Error.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public bool? ExcludeHealthStatistics
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets IncludeSystemApplicationHealthStatistics. Indicates whether the health statistics should include the
        /// fabric:/System application health statistics. False by default.
        /// If IncludeSystemApplicationHealthStatistics is set to true, the health statistics include the entities that belong
        /// to the fabric:/System application.
        /// Otherwise, the query result includes health statistics only for user applications.
        /// The health statistics must be included in the query result for this parameter to be applied.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public bool? IncludeSystemApplicationHealthStatistics
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationHealthPolicyMap. Defines a map that contains specific application health policies for
        /// different applications.
        /// Each entry specifies as key the application name and as value an ApplicationHealthPolicy used to evaluate the
        /// application health.
        /// If an application is not specified in the map, the application health evaluation uses the ApplicationHealthPolicy
        /// found in its application manifest or the default application health policy (if no health policy is defined in the
        /// manifest).
        /// The map is empty by default.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public IEnumerable<ApplicationHealthPolicyMapItem> ApplicationHealthPolicyMap
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ConsiderWarningAsError. Indicates whether warnings are treated with the same severity as errors.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public bool? ConsiderWarningAsError
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxPercentUnhealthyNodes. The maximum allowed percentage of unhealthy nodes before reporting an error.
        /// For example, to allow 10% of nodes to be unhealthy, this value would be 10.
        /// 
        /// The percentage represents the maximum tolerated percentage of nodes that can be unhealthy before the cluster is
        /// considered in error.
        /// If the percentage is respected but there is at least one unhealthy node, the health is evaluated as Warning.
        /// The percentage is calculated by dividing the number of unhealthy nodes over the total number of nodes in the
        /// cluster.
        /// The computation rounds up to tolerate one failure on small numbers of nodes. Default percentage is zero.
        /// 
        /// In large clusters, some nodes will always be down or out for repairs, so this percentage should be configured to
        /// tolerate that.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public int? MaxPercentUnhealthyNodes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets MaxPercentUnhealthyApplications. The maximum allowed percentage of unhealthy applications before
        /// reporting an error. For example, to allow 10% of applications to be unhealthy, this value would be 10.
        /// 
        /// The percentage represents the maximum tolerated percentage of applications that can be unhealthy before the cluster
        /// is considered in error.
        /// If the percentage is respected but there is at least one unhealthy application, the health is evaluated as Warning.
        /// This is calculated by dividing the number of unhealthy applications over the total number of application instances
        /// in the cluster, excluding applications of application types that are included in the
        /// ApplicationTypeHealthPolicyMap.
        /// The computation rounds up to tolerate one failure on small numbers of applications. Default percentage is zero.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public int? MaxPercentUnhealthyApplications
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ApplicationTypeHealthPolicyMap. Defines a map with max percentage unhealthy applications for specific
        /// application types.
        /// Each entry specifies as key the application type name and as value an integer that represents the
        /// MaxPercentUnhealthyApplications percentage used to evaluate the applications of the specified application type.
        /// 
        /// The application type health policy map can be used during cluster health evaluation to describe special application
        /// types.
        /// The application types included in the map are evaluated against the percentage specified in the map, and not with
        /// the global MaxPercentUnhealthyApplications defined in the cluster health policy.
        /// The applications of application types specified in the map are not counted against the global pool of applications.
        /// For example, if some applications of a type are critical, the cluster administrator can add an entry to the map for
        /// that application type
        /// and assign it a value of 0% (that is, do not tolerate any failures).
        /// All other applications can be evaluated with MaxPercentUnhealthyApplications set to 20% to tolerate some failures
        /// out of the thousands of application instances.
        /// The application type health policy map is used only if the cluster manifest enables application type health
        /// evaluation using the configuration entry for HealthManager/EnableApplicationTypeHealthEvaluation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ParameterSetName = "GetClusterHealthUsingPolicy")]
        public IEnumerable<ApplicationTypeHealthPolicyMapItem> ApplicationTypeHealthPolicyMap
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ServerTimeout. The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ParameterSetName = "GetClusterHealthUsingPolicy")]
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
                var clusterHealthPolicy = new ClusterHealthPolicy(
                considerWarningAsError: this.ConsiderWarningAsError,
                maxPercentUnhealthyNodes: this.MaxPercentUnhealthyNodes,
                maxPercentUnhealthyApplications: this.MaxPercentUnhealthyApplications,
                applicationTypeHealthPolicyMap: this.ApplicationTypeHealthPolicyMap);

                var clusterHealthPolicies = new ClusterHealthPolicies(
                applicationHealthPolicyMap: this.ApplicationHealthPolicyMap,
                clusterHealthPolicy: clusterHealthPolicy);

                var result = this.ServiceFabricClient.Cluster.GetClusterHealthUsingPolicyAsync(
                    nodesHealthStateFilter: this.NodesHealthStateFilter,
                    applicationsHealthStateFilter: this.ApplicationsHealthStateFilter,
                    eventsHealthStateFilter: this.EventsHealthStateFilter,
                    excludeHealthStatistics: this.ExcludeHealthStatistics,
                    includeSystemApplicationHealthStatistics: this.IncludeSystemApplicationHealthStatistics,
                    clusterHealthPolicies: clusterHealthPolicies,
                    serverTimeout: this.ServerTimeout,
                    cancellationToken: this.CancellationToken).GetAwaiter().GetResult();

                this.WriteObject(this.FormatOutput(result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <inheritdoc/>
        protected override object FormatOutput(object output)
        {
            var outputResult = output as ClusterHealth;

            var nodeHealthStatesObj = new PSObject(outputResult.NodeHealthStates);
            nodeHealthStatesObj.Members.Add(new PSCodeMethod("ToString", typeof(OutputFormatter).GetMethod("FormatObject")));

            var applicationHealthStatesObj = new PSObject(outputResult.ApplicationHealthStates);
            applicationHealthStatesObj.Members.Add(new PSCodeMethod("ToString", typeof(OutputFormatter).GetMethod("FormatObject")));

            var healthEventsObj = new PSObject(outputResult.HealthEvents);
            healthEventsObj.Members.Add(new PSCodeMethod("ToString", typeof(OutputFormatter).GetMethod("FormatObject")));

            var healthStatisticsObj = new PSObject(outputResult.HealthStatistics);
            healthStatisticsObj.Members.Add(new PSCodeMethod("ToString", typeof(OutputFormatter).GetMethod("FormatObject")));

            var result = new PSObject(outputResult);

            result.Properties.Add(new PSNoteProperty("AggregatedHealthState", outputResult.AggregatedHealthState));

            return result;
        }
    }
}
