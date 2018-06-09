// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="HealthEvaluation" />.
    /// </summary>
    internal class HealthEvaluationConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static HealthEvaluation Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static HealthEvaluation GetFromJsonProperties(JsonReader reader)
        {
            HealthEvaluation obj;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("Application", StringComparison.Ordinal))
            {
                obj = ApplicationHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Applications", StringComparison.Ordinal))
            {
                obj = ApplicationsHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ApplicationTypeApplications", StringComparison.Ordinal))
            {
                obj = ApplicationTypeApplicationsHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeltaNodesCheck", StringComparison.Ordinal))
            {
                obj = DeltaNodesCheckHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplication", StringComparison.Ordinal))
            {
                obj = DeployedApplicationHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedApplications", StringComparison.Ordinal))
            {
                obj = DeployedApplicationsHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServicePackage", StringComparison.Ordinal))
            {
                obj = DeployedServicePackageHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("DeployedServicePackages", StringComparison.Ordinal))
            {
                obj = DeployedServicePackagesHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Event", StringComparison.Ordinal))
            {
                obj = EventHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Node", StringComparison.Ordinal))
            {
                obj = NodeHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Nodes", StringComparison.Ordinal))
            {
                obj = NodesHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Partition", StringComparison.Ordinal))
            {
                obj = PartitionHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Partitions", StringComparison.Ordinal))
            {
                obj = PartitionsHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Replica", StringComparison.Ordinal))
            {
                obj = ReplicaHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Replicas", StringComparison.Ordinal))
            {
                obj = ReplicasHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Service", StringComparison.Ordinal))
            {
                obj = ServiceHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Services", StringComparison.Ordinal))
            {
                obj = ServicesHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("SystemApplication", StringComparison.Ordinal))
            {
                obj = SystemApplicationHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("UpgradeDomainDeltaNodesCheck", StringComparison.Ordinal))
            {
                obj = UpgradeDomainDeltaNodesCheckHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("UpgradeDomainNodes", StringComparison.Ordinal))
            {
                obj = UpgradeDomainNodesHealthEvaluationConverter.GetFromJsonProperties(reader);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }

            return obj;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, HealthEvaluation obj)
        {
            var kind = obj.Kind;

            if (kind.Equals(HealthEvaluationKind.Application))
            {
                ApplicationHealthEvaluationConverter.Serialize(writer, (ApplicationHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Applications))
            {
                ApplicationsHealthEvaluationConverter.Serialize(writer, (ApplicationsHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.ApplicationTypeApplications))
            {
                ApplicationTypeApplicationsHealthEvaluationConverter.Serialize(writer, (ApplicationTypeApplicationsHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.DeltaNodesCheck))
            {
                DeltaNodesCheckHealthEvaluationConverter.Serialize(writer, (DeltaNodesCheckHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.DeployedApplication))
            {
                DeployedApplicationHealthEvaluationConverter.Serialize(writer, (DeployedApplicationHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.DeployedApplications))
            {
                DeployedApplicationsHealthEvaluationConverter.Serialize(writer, (DeployedApplicationsHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.DeployedServicePackage))
            {
                DeployedServicePackageHealthEvaluationConverter.Serialize(writer, (DeployedServicePackageHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.DeployedServicePackages))
            {
                DeployedServicePackagesHealthEvaluationConverter.Serialize(writer, (DeployedServicePackagesHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Event))
            {
                EventHealthEvaluationConverter.Serialize(writer, (EventHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Node))
            {
                NodeHealthEvaluationConverter.Serialize(writer, (NodeHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Nodes))
            {
                NodesHealthEvaluationConverter.Serialize(writer, (NodesHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Partition))
            {
                PartitionHealthEvaluationConverter.Serialize(writer, (PartitionHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Partitions))
            {
                PartitionsHealthEvaluationConverter.Serialize(writer, (PartitionsHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Replica))
            {
                ReplicaHealthEvaluationConverter.Serialize(writer, (ReplicaHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Replicas))
            {
                ReplicasHealthEvaluationConverter.Serialize(writer, (ReplicasHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Service))
            {
                ServiceHealthEvaluationConverter.Serialize(writer, (ServiceHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.Services))
            {
                ServicesHealthEvaluationConverter.Serialize(writer, (ServicesHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.SystemApplication))
            {
                SystemApplicationHealthEvaluationConverter.Serialize(writer, (SystemApplicationHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.UpgradeDomainDeltaNodesCheck))
            {
                UpgradeDomainDeltaNodesCheckHealthEvaluationConverter.Serialize(writer, (UpgradeDomainDeltaNodesCheckHealthEvaluation)obj);
            }
            else if (kind.Equals(HealthEvaluationKind.UpgradeDomainNodes))
            {
                UpgradeDomainNodesHealthEvaluationConverter.Serialize(writer, (UpgradeDomainNodesHealthEvaluation)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
