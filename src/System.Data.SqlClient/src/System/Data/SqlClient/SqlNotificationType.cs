// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Data.SqlClient
{
#if NET8_0_OR_GREATER
    [Obsolete("Use the Microsoft.Data.SqlClient package instead.")]
#endif
    public enum SqlNotificationType
    {
        Change = 0,
        Subscribe = 1,

        // use negative values for client-only-generated values
        Unknown = -1
    }
}
