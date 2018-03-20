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
    ///   <para>Enumerates how communication is protected.</para>
    /// </summary>
    public enum ProtectionLevel
    {
        /// <summary>
        ///   <para>Not protected.</para>
        /// </summary>
        None = 0,

        /// <summary>
        ///   <para>Only integrity is protected.</para>
        /// </summary>
        Sign = 1,

        /// <summary>
        ///   <para>Both confidentiality and integrity are protected.</para>
        /// </summary>
        EncryptAndSign = 2
    }
}
