// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Runtime.InteropServices;

namespace System
{
    public static partial class PlatformDetection
    {
        //
        // Do not use the " { get; } = <expression> " pattern here. Having all the initialization happen in the type initializer
        // means that one exception anywhere means all tests using PlatformDetection fail. If you feel a value is worth latching,
        // do it in a way that failures don't cascade.
        //

        public static bool IsWindows => false;
        public static bool IsWindows7 => false;

    }
}
