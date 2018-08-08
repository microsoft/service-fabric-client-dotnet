// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes an environment variable for the container.
    /// </summary>
    public partial class EnvironmentVariable
    {
        /// <summary>
        /// Initializes a new instance of the EnvironmentVariable class.
        /// </summary>
        /// <param name="name">The name of the environment variable.</param>
        /// <param name="value">The value of the environment variable.</param>
        public EnvironmentVariable(
            string name = default(string),
            string value = default(string))
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets the name of the environment variable.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the environment variable.
        /// </summary>
        public string Value { get; }
    }
}
