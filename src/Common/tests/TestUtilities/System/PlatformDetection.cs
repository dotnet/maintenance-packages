// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Authentication;
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

        private static readonly Lazy<bool> s_IsInHelix = new Lazy<bool>(() => Environment.GetEnvironmentVariables().Keys.Cast<string>().Any(key => key.StartsWith("HELIX")));
        public static bool IsInHelix => s_IsInHelix.Value;

        public static bool IsNetCore => Environment.Version.Major >= 5 || RuntimeInformation.FrameworkDescription.StartsWith(".NET Core", StringComparison.OrdinalIgnoreCase);
        public static bool IsMonoRuntime => Type.GetType("Mono.RuntimeStructs") != null;
        public static bool IsNotMonoRuntime => !IsMonoRuntime;
        public static bool IsMonoInterpreter => GetIsRunningOnMonoInterpreter();
        public static bool IsMonoAOT => Environment.GetEnvironmentVariable("MONO_AOT_MODE") == "aot";
        public static bool IsNotMonoAOT => Environment.GetEnvironmentVariable("MONO_AOT_MODE") != "aot";
        public static bool IsNativeAot => IsNotMonoRuntime && !IsReflectionEmitSupported;
        public static bool IsNotNativeAot => !IsNativeAot;
        public static bool IsFreeBSD => RuntimeInformation.IsOSPlatform(OSPlatform.Create("FREEBSD"));
        public static bool IsNetBSD => RuntimeInformation.IsOSPlatform(OSPlatform.Create("NETBSD"));
        public static bool IsAndroid => RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID"));
        public static bool IsNotAndroid => !IsAndroid;
        public static bool IsAndroidX86 => IsAndroid && IsX86Process;
        public static bool IsNotAndroidX86 => !IsAndroidX86;
        public static bool IsiOS => RuntimeInformation.IsOSPlatform(OSPlatform.Create("IOS"));
        public static bool IstvOS => RuntimeInformation.IsOSPlatform(OSPlatform.Create("TVOS"));
        public static bool IsMacCatalyst => RuntimeInformation.IsOSPlatform(OSPlatform.Create("MACCATALYST"));
        public static bool IsNotMacCatalyst => !IsMacCatalyst;
        public static bool Isillumos => RuntimeInformation.IsOSPlatform(OSPlatform.Create("ILLUMOS"));
        public static bool IsSolaris => RuntimeInformation.IsOSPlatform(OSPlatform.Create("SOLARIS"));
        public static bool IsBrowser => RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"));
        public static bool IsNotBrowser => !IsBrowser;
        public static bool IsMobile => IsBrowser || IsAppleMobile || IsAndroid;
        public static bool IsNotMobile => !IsMobile;
        public static bool IsAppleMobile => IsMacCatalyst || IsiOS || IstvOS;
        public static bool IsNotAppleMobile => !IsAppleMobile;

        public static bool IsArmProcess => RuntimeInformation.ProcessArchitecture == Architecture.Arm;
        public static bool IsNotArmProcess => !IsArmProcess;
        public static bool IsArm64Process => RuntimeInformation.ProcessArchitecture == Architecture.Arm64;
        public static bool IsNotArm64Process => !IsArm64Process;
        public static bool IsArmOrArm64Process => IsArmProcess || IsArm64Process;
        public static bool IsNotArmNorArm64Process => !IsArmOrArm64Process;
        public static bool IsS390xProcess => (int)RuntimeInformation.ProcessArchitecture == 5; // Architecture.S390x
        public static bool IsArmv6Process => (int)RuntimeInformation.ProcessArchitecture == 7; // Architecture.Armv6
        public static bool IsPpc64leProcess => (int)RuntimeInformation.ProcessArchitecture == 8; // Architecture.Ppc64le
        public static bool IsX64Process => RuntimeInformation.ProcessArchitecture == Architecture.X64;
        public static bool IsX86Process => RuntimeInformation.ProcessArchitecture == Architecture.X86;
        public static bool IsNotX86Process => !IsX86Process;
        public static bool Is32BitProcess => IntPtr.Size == 4;
        public static bool Is64BitProcess => IntPtr.Size == 8;

        public static bool IsMarshalGetExceptionPointersSupported => !IsMonoRuntime && !IsNativeAot;

        private static readonly Lazy<bool> s_isCheckedRuntime = new Lazy<bool>(() => AssemblyConfigurationEquals("Checked"));
        private static readonly Lazy<bool> s_isReleaseRuntime = new Lazy<bool>(() => AssemblyConfigurationEquals("Release"));
        private static readonly Lazy<bool> s_isDebugRuntime = new Lazy<bool>(() => AssemblyConfigurationEquals("Debug"));

        public static bool IsCheckedRuntime => s_isCheckedRuntime.Value;
        public static bool IsReleaseRuntime => s_isReleaseRuntime.Value;
        public static bool IsDebugRuntime => s_isDebugRuntime.Value;

        // For use as needed on tests that time out when run on a Debug runtime.
        // Not relevant for timeouts on external activities, such as network timeouts.
        public static int SlowRuntimeTimeoutModifier = (PlatformDetection.IsDebugRuntime ? 5 : 1);

        public static bool IsThreadingSupported => !IsBrowser;
        public static bool IsBinaryFormatterSupported => IsNotMobile && !IsNativeAot;

        public static bool IsStartingProcessesSupported => !IsiOS && !IstvOS;

        public static bool IsSpeedOptimized => !IsSizeOptimized;
        public static bool IsSizeOptimized => IsBrowser || IsAndroid || IsAppleMobile;

        public static bool IsBrowserDomSupported => IsEnvironmentVariableTrue("IsBrowserDomSupported");
        public static bool IsBrowserDomSupportedOrNotBrowser => IsNotBrowser || IsBrowserDomSupported;
        public static bool IsBrowserDomSupportedOrNodeJS => IsBrowserDomSupported || IsNodeJS;
        public static bool IsNotBrowserDomSupported => !IsBrowserDomSupported;
        public static bool IsWebSocketSupported => IsEnvironmentVariableTrue("IsWebSocketSupported");
        public static bool IsNodeJS => IsEnvironmentVariableTrue("IsNodeJS");
        public static bool IsNotNodeJS => !IsNodeJS;
        public static bool IsNodeJSOnWindows => GetNodeJSPlatform() == "win32";
        public static bool LocalEchoServerIsNotAvailable => !LocalEchoServerIsAvailable;
        public static bool LocalEchoServerIsAvailable => IsBrowser;

        public static bool IsUsingLimitedCultures => !IsNotMobile;
        public static bool IsNotUsingLimitedCultures => IsNotMobile;

        public static bool IsLinqExpressionsBuiltWithIsInterpretingOnly => s_linqExpressionsBuiltWithIsInterpretingOnly.Value;
        public static bool IsNotLinqExpressionsBuiltWithIsInterpretingOnly => !IsLinqExpressionsBuiltWithIsInterpretingOnly;
        private static readonly Lazy<bool> s_linqExpressionsBuiltWithIsInterpretingOnly = new Lazy<bool>(GetLinqExpressionsBuiltWithIsInterpretingOnly);
        private static bool GetLinqExpressionsBuiltWithIsInterpretingOnly()
        {
            return !(bool)typeof(LambdaExpression).GetMethod("get_CanCompileToIL").Invoke(null, Array.Empty<object>());
        }

        public static bool IsAsyncFileIOSupported => !IsBrowser;

        public static bool IsLineNumbersSupported => !IsNativeAot;

#if NETCOREAPP
        public static bool IsReflectionEmitSupported => RuntimeFeature.IsDynamicCodeSupported;
        public static bool IsNotReflectionEmitSupported => !IsReflectionEmitSupported;
#else
        public static bool IsReflectionEmitSupported => true;
#endif

        public static bool IsInvokingStaticConstructorsSupported => !IsNativeAot;
        public static bool IsInvokingFinalizersSupported => !IsNativeAot;

        public static bool IsMetadataUpdateSupported => !IsNativeAot;

        public static bool IsPreciseGcSupported => !IsMonoRuntime;

        public static bool IsNotIntMaxValueArrayIndexSupported => s_largeArrayIsNotSupported.Value;

        public static bool IsAssemblyLoadingSupported => !IsNativeAot;
        public static bool IsNonBundledAssemblyLoadingSupported => IsAssemblyLoadingSupported && !IsMonoAOT;
        public static bool IsMethodBodySupported => !IsNativeAot;
        public static bool IsDebuggerTypeProxyAttributeSupported => !IsNativeAot;
        public static bool HasAssemblyFiles => !string.IsNullOrEmpty(typeof(PlatformDetection).Assembly.Location);
        public static bool HasHostExecutable => HasAssemblyFiles; // single-file don't have a host

        private static volatile Tuple<bool> s_lazyNonZeroLowerBoundArraySupported;
        public static bool IsNonZeroLowerBoundArraySupported
        {
            get
            {
                if (s_lazyNonZeroLowerBoundArraySupported == null)
                {
                    bool nonZeroLowerBoundArraysSupported = false;
                    try
                    {
                        Array.CreateInstance(typeof(int), new int[] { 5 }, new int[] { 5 });
                        nonZeroLowerBoundArraysSupported = true;
                    }
                    catch (PlatformNotSupportedException)
                    {
                    }
                    s_lazyNonZeroLowerBoundArraySupported = Tuple.Create<bool>(nonZeroLowerBoundArraysSupported);
                }
                return s_lazyNonZeroLowerBoundArraySupported.Item1;
            }
        }

        private static volatile Tuple<bool> s_lazyMetadataTokensSupported;
        public static bool IsMetadataTokenSupported
        {
            get
            {
                if (s_lazyMetadataTokensSupported == null)
                {
                    bool metadataTokensSupported = false;
                    try
                    {
                        _ = typeof(PlatformDetection).MetadataToken;
                        metadataTokensSupported = true;
                    }
                    catch (InvalidOperationException)
                    {
                    }
                    s_lazyMetadataTokensSupported = Tuple.Create<bool>(metadataTokensSupported);
                }
                return s_lazyMetadataTokensSupported.Item1;
            }
        }

        public static bool IsDomainJoinedMachine => !Environment.MachineName.Equals(Environment.UserDomainName, StringComparison.OrdinalIgnoreCase);
        public static bool IsNotDomainJoinedMachine => !IsDomainJoinedMachine;
        public static bool UsesMobileAppleCrypto => IsMacCatalyst || IsiOS || IstvOS;

        // Changed to `true` when trimming
        public static bool IsBuiltWithAggressiveTrimming => IsNativeAot;
        public static bool IsNotBuiltWithAggressiveTrimming => !IsBuiltWithAggressiveTrimming;

        private static readonly Lazy<bool> s_largeArrayIsNotSupported = new Lazy<bool>(IsLargeArrayNotSupported);

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private static bool IsLargeArrayNotSupported()
        {
            try
            {
                var tmp = new byte[int.MaxValue];
                return tmp == null;
            }
            catch (OutOfMemoryException)
            {
                return true;
            }
        }

        private static readonly Lazy<bool> m_isInvariant = new Lazy<bool>(()
            => (bool?)Type.GetType("System.Globalization.GlobalizationMode")?.GetProperty("Invariant", BindingFlags.NonPublic | BindingFlags.Static)?.GetValue(null) == true);

        private static readonly Lazy<Version> m_icuVersion = new Lazy<Version>(GetICUVersion);
        public static Version ICUVersion => m_icuVersion.Value;

        public static bool IsInvariantGlobalization => m_isInvariant.Value;
        public static bool IsNotInvariantGlobalization => !IsInvariantGlobalization;
        public static bool IsIcuGlobalization => ICUVersion > new Version(0, 0, 0, 0);
        public static bool IsNlsGlobalization => IsNotInvariantGlobalization && !IsIcuGlobalization;

        private static Version GetICUVersion()
        {
            int version = 0;
            try
            {
                Type interopGlobalization = Type.GetType("Interop+Globalization, System.Private.CoreLib");
                if (interopGlobalization != null)
                {
                    MethodInfo methodInfo = interopGlobalization.GetMethod("GetICUVersion", BindingFlags.NonPublic | BindingFlags.Static);
                    if (methodInfo != null)
                    {
                        version = (int)methodInfo.Invoke(null, null);
                    }
                }
            }
            catch { }

            return new Version(version >> 24,
                              (version >> 16) & 0xFF,
                              (version >> 8) & 0xFF,
                              version & 0xFF);
        }

        private static readonly Lazy<bool> s_fileLockingDisabled = new Lazy<bool>(()
            => (bool?)Type.GetType("Microsoft.Win32.SafeHandles.SafeFileHandle")?.GetProperty("DisableFileLocking", BindingFlags.NonPublic | BindingFlags.Static)?.GetValue(null) == true);

        private static bool GetProtocolSupportFromWindowsRegistry(SslProtocols protocol, bool defaultProtocolSupport, bool disabledByDefault = false)
        {
            string registryProtocolName = protocol switch
            {
#pragma warning disable CS0618 // Ssl2 and Ssl3 are obsolete
                SslProtocols.Ssl3 => "SSL 3.0",
#pragma warning restore CS0618
                SslProtocols.Tls => "TLS 1.0",
                SslProtocols.Tls11 => "TLS 1.1",
                SslProtocols.Tls12 => "TLS 1.2",
#if !NETFRAMEWORK
                SslProtocols.Tls13 => "TLS 1.3",
#endif
                _ => throw new Exception($"Registry key not defined for {protocol}.")
            };

            string clientKey = @$"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\{registryProtocolName}\Client";
            string serverKey = @$"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\SecurityProviders\SCHANNEL\Protocols\{registryProtocolName}\Server";

            object client, server;
            object clientDefault, serverDefault;
            try
            {
                client = Registry.GetValue(clientKey, "Enabled", defaultProtocolSupport ? 1 : 0);
                server = Registry.GetValue(serverKey, "Enabled", defaultProtocolSupport ? 1 : 0);

                clientDefault = Registry.GetValue(clientKey, "DisabledByDefault", 1);
                serverDefault = Registry.GetValue(serverKey, "DisabledByDefault", 1);

                if (client is int c && server is int s && clientDefault is int cd && serverDefault is int sd)
                {
                    return (c == 1 && s == 1) && (!disabledByDefault || (cd == 0 && sd == 0));
                }
            }
            catch (SecurityException)
            {
                // Insufficient permission, assume that we don't have protocol support (since we aren't exactly sure)
                return false;
            }
            catch { }

            return defaultProtocolSupport;
        }

        private static bool GetIsRunningOnMonoInterpreter()
        {
#if NETCOREAPP
            return IsMonoRuntime && RuntimeFeature.IsDynamicCodeSupported && !RuntimeFeature.IsDynamicCodeCompiled;
#else
            return false;
#endif
        }

        private static bool IsEnvironmentVariableTrue(string variableName)
        {
            if (!IsBrowser)
                return false;

            var val = Environment.GetEnvironmentVariable(variableName);
            return (val != null && val == "true");
        }

        private static string GetNodeJSPlatform()
        {
            if (!IsNodeJS)
                return null;

            return Environment.GetEnvironmentVariable("NodeJSPlatform");
        }

        private static bool AssemblyConfigurationEquals(string configuration)
        {
            AssemblyConfigurationAttribute assemblyConfigurationAttribute = typeof(string).Assembly.GetCustomAttribute<AssemblyConfigurationAttribute>();

            return assemblyConfigurationAttribute != null &&
                string.Equals(assemblyConfigurationAttribute.Configuration, configuration, StringComparison.InvariantCulture);
        }
    }
}
