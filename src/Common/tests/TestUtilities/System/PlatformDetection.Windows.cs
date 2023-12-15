// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32;
using Xunit;

namespace System
{
    public static partial class PlatformDetection
    {
        //
        // Do not use the " { get; } = <expression> " pattern here. Having all the initialization happen in the type initializer
        // means that one exception anywhere means all tests using PlatformDetection fail. If you feel a value is worth latching,
        // do it in a way that failures don't cascade.
        //

        public static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsWindows7 => IsWindows && GetWindowsVersion() == 6 && GetWindowsMinorVersion() == 1;
        private static volatile Version s_windowsVersionObject;
        internal static Version GetWindowsVersionObject()
        {
            if (s_windowsVersionObject is null)
            {
                Assert.Equal(0, Interop.NtDll.RtlGetVersionEx(out Interop.NtDll.RTL_OSVERSIONINFOEX osvi));
                Version newObject = new Version(checked((int)osvi.dwMajorVersion), checked((int)osvi.dwMinorVersion), checked((int)osvi.dwBuildNumber));
                s_windowsVersionObject = newObject;
            }

            return s_windowsVersionObject;
        }

        internal static uint GetWindowsVersion() => (uint)GetWindowsVersionObject().Major;
        internal static uint GetWindowsMinorVersion() => (uint)GetWindowsVersionObject().Minor;
    }
}
