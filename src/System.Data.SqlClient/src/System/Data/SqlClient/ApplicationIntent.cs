// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Data.SqlClient
{
    /// <summary>
    /// Represents the application workload type when connecting to a server.
    /// </summary>
    public enum ApplicationIntent
    {
        ReadWrite = 0,
        ReadOnly = 1,
    }
}
