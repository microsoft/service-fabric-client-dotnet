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
    /// Converter for <see cref="ServicePlacementPolicyDescription" />.
    /// </summary>
    internal class ServicePlacementPolicyDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServicePlacementPolicyDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ServicePlacementPolicyDescription GetFromJsonProperties(JsonReader reader)
        {
            ServicePlacementPolicyDescription obj;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Type", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Type.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("InvalidDomain", StringComparison.Ordinal))
            {
                obj = ServicePlacementInvalidDomainPolicyDescriptionConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("NonPartiallyPlaceService", StringComparison.Ordinal))
            {
                obj = ServicePlacementNonPartiallyPlaceServicePolicyDescriptionConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("PreferredPrimaryDomain", StringComparison.Ordinal))
            {
                obj = ServicePlacementPreferPrimaryDomainPolicyDescriptionConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("RequiredDomain", StringComparison.Ordinal))
            {
                obj = ServicePlacementRequiredDomainPolicyDescriptionConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("RequiredDomainDistribution", StringComparison.Ordinal))
            {
                obj = ServicePlacementRequireDomainDistributionPolicyDescriptionConverter.GetFromJsonProperties(reader);
            }
            else
            {
                throw new InvalidOperationException("Unknown Type.");
            }

            return obj;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ServicePlacementPolicyDescription obj)
        {
            var kind = obj.Type;

            if (kind.Equals(ServicePlacementPolicyType.InvalidDomain))
            {
                ServicePlacementInvalidDomainPolicyDescriptionConverter.Serialize(writer, (ServicePlacementInvalidDomainPolicyDescription)obj);
            }
            else if (kind.Equals(ServicePlacementPolicyType.NonPartiallyPlaceService))
            {
                ServicePlacementNonPartiallyPlaceServicePolicyDescriptionConverter.Serialize(writer, (ServicePlacementNonPartiallyPlaceServicePolicyDescription)obj);
            }
            else if (kind.Equals(ServicePlacementPolicyType.PreferredPrimaryDomain))
            {
                ServicePlacementPreferPrimaryDomainPolicyDescriptionConverter.Serialize(writer, (ServicePlacementPreferPrimaryDomainPolicyDescription)obj);
            }
            else if (kind.Equals(ServicePlacementPolicyType.RequiredDomain))
            {
                ServicePlacementRequiredDomainPolicyDescriptionConverter.Serialize(writer, (ServicePlacementRequiredDomainPolicyDescription)obj);
            }
            else if (kind.Equals(ServicePlacementPolicyType.RequiredDomainDistribution))
            {
                ServicePlacementRequireDomainDistributionPolicyDescriptionConverter.Serialize(writer, (ServicePlacementRequireDomainDistributionPolicyDescription)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Type.");
            }
        }
    }
}
