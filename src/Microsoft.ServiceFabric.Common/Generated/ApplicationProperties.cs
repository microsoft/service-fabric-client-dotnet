// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This type describes properties of an application resource.
    /// </summary>
    public partial class ApplicationProperties
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationProperties class.
        /// </summary>
        /// <param name="description">User readable description of the application.</param>
        /// <param name="debugParams">Internal use.</param>
        /// <param name="services">describes the services in the application.</param>
        /// <param name="healthState">Describes the health state of an application resource. Possible values include:
        /// 'Invalid', 'Ok', 'Warning', 'Error', 'Unknown'
        /// 
        /// The health state of a Service Fabric entity such as Cluster, Node, Application, Service, Partition, Replica etc.
        /// </param>
        /// <param name="unhealthyEvaluation">When the application's health state is not 'Ok', this additional details from
        /// service fabric Health Manager for the user to know why the application is marked unhealthy.</param>
        /// <param name="status">Status of the application resource. Possible values include: 'Invalid', 'Ready', 'Upgrading',
        /// 'Creating', 'Deleting', 'Failed'</param>
        /// <param name="statusDetails">Gives additional information about the current status of the application
        /// deployment.</param>
        /// <param name="serviceNames">Names of the services in the application.</param>
        /// <param name="diagnostics">Describes the diagnostics definition and usage for an application resource.</param>
        public ApplicationProperties(
            string description = default(string),
            string debugParams = default(string),
            IEnumerable<ServiceResourceDescription> services = default(IEnumerable<ServiceResourceDescription>),
            HealthState? healthState = default(HealthState?),
            string unhealthyEvaluation = default(string),
            ApplicationResourceStatus? status = default(ApplicationResourceStatus?),
            string statusDetails = default(string),
            IEnumerable<string> serviceNames = default(IEnumerable<string>),
            DiagnosticsDescription diagnostics = default(DiagnosticsDescription))
        {
            this.Description = description;
            this.DebugParams = debugParams;
            this.Services = services;
            this.HealthState = healthState;
            this.UnhealthyEvaluation = unhealthyEvaluation;
            this.Status = status;
            this.StatusDetails = statusDetails;
            this.ServiceNames = serviceNames;
            this.Diagnostics = diagnostics;
        }

        /// <summary>
        /// Gets user readable description of the application.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets internal use.
        /// </summary>
        public string DebugParams { get; }

        /// <summary>
        /// Gets describes the services in the application.
        /// </summary>
        public IEnumerable<ServiceResourceDescription> Services { get; }

        /// <summary>
        /// Gets describes the health state of an application resource. Possible values include: 'Invalid', 'Ok', 'Warning',
        /// 'Error', 'Unknown'
        /// 
        /// The health state of a Service Fabric entity such as Cluster, Node, Application, Service, Partition, Replica etc.
        /// </summary>
        public HealthState? HealthState { get; }

        /// <summary>
        /// Gets when the application's health state is not 'Ok', this additional details from service fabric Health Manager
        /// for the user to know why the application is marked unhealthy.
        /// </summary>
        public string UnhealthyEvaluation { get; }

        /// <summary>
        /// Gets status of the application resource. Possible values include: 'Invalid', 'Ready', 'Upgrading', 'Creating',
        /// 'Deleting', 'Failed'
        /// </summary>
        public ApplicationResourceStatus? Status { get; }

        /// <summary>
        /// Gets gives additional information about the current status of the application deployment.
        /// </summary>
        public string StatusDetails { get; }

        /// <summary>
        /// Gets names of the services in the application.
        /// </summary>
        public IEnumerable<string> ServiceNames { get; }

        /// <summary>
        /// Gets describes the diagnostics definition and usage for an application resource.
        /// </summary>
        public DiagnosticsDescription Diagnostics { get; }
    }
}
