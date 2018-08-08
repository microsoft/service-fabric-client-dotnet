// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes a setting for the container.
    /// </summary>
    public partial class Setting
    {
        /// <summary>
        /// Initializes a new instance of the Setting class.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The value of the setting.</param>
        public Setting(
            string name = default(string),
            string value = default(string))
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets the name of the setting.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the setting.
        /// </summary>
        public string Value { get; }
    }
}
