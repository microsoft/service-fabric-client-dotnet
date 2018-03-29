// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Specifies the security settings for Windows credentials.
    /// </summary>
    public sealed class WindowsSecuritySettings : SecuritySettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsSecuritySettings" /> class.
        /// </summary>
        public WindowsSecuritySettings() : base(SecurityType.Windows)
        {
        }
    }
}
