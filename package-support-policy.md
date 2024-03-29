# Package support policy for maintenance-packages

As it has been described in the [.NET Release policies](https://github.com/dotnet/core/blob/main/release-policies.md) document, .NET library packages provide additional functionality that complements the .NET libraries and application frameworks like ASP.NET Core. The library packages have the same [support model as the .NET versions](https://dotnet.microsoft.com/en-us/platform/support/policy) that they target.

For example, [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/#supportedframeworks-body-tab) supports multiple .NET versions via the frameworks it targets.

Our packages support any target framework versions that are currently in-support. You can find out which frameworks are supported by a specific package by visiting its NuGet page and navigating to the frameworks tab.

Additionally, you can find out which target frameworks are currently in-support by visiting the following pages:

- .NET: https://dotnet.microsoft.com/en-us/platform/support/policy
- .NET Framework: https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet-framework

Keep in mind that the minimum .NET Standard version supported by a package depends on which minimum .NET and .NET Framework versions are supported by the package. Packages and projects targeting .NET Standard are expected to be compatible between each other by following the same rules specified by our .NET Standard policy.

## Release cadence

Some packages follow the same release cadence as the .NET release cadence, meaning we release a new version of the package each time we release a new .NET version. For example:

- [System.Text.Json](https://www.nuget.org/packages/System.Text.Json), which is part of the shared framework, but is also available as a NuGet package.
- [Microsoft.Extensions.Configuration.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions), which is exclusively released as a NuGet package.

Note that the source code of those two packages is hosted in the [dotnet/runtime](https://github.com/dotnet/runtime) repo.

On the other hand, the packages that come out from the maintenance-packages repo have a separate, independent release cadence, meaning their servicing releases will come out of this repo and will not be bound by any pre-defined release schedule.

These are packages that originally had their source code hosted in branches that are already out of support, but the packages themselves are still in-support, because they target frameworks that are still supported. Some examples:

- [System.Xml.XPath.XmlDocument](https://www.nuget.org/packages/System.Xml.XPath.XmlDocument) - Its source code used to be hosted in the .NET Core 1.1 branch.
- [System.Buffers](https://www.nuget.org/packages/System.Buffers) - Its source code used to be hosted in the .NET Core 2.1 branch.
- [Microsoft.Bcl.HashCode](https://www.nuget.org/packages/Microsoft.Bcl.HashCode) - Its source code used to be hosted in the.NET Core 3.1 branch.
- [System.Net.WebSockets.WebSocketProtocol](https://www.nuget.org/packages/System.Net.WebSockets.WebSocketProtocol) - Its source code used to be hosted in the .NET 5.0 branch.

## End of support

A package will be supported for as long as it targets frameworks that are still supported. For example: [System.Numerics.Vectors](https://www.nuget.org/packages/System.Json#supportedframeworks-body-tab). Of all the included target frameworks in the package, .NET Standard 2.0 is still in support at the moment of writing this document. As long as there are frameworks compatible with .NET Standard 2.0, the package will remain in support.

## Reporting issues

If you find an issue in an assembly that is hosted in this repo, please report it in our central repo: https://github.com/dotnet/runtime/issues/new/choose.

## Packages

Below is a complete list of packages that we have been published in past releases and an explanation of why they meet (or do not meet) the bar for migration into this repo.

### Supported and migrated

The following packages have been migrated into this repo already and are open for security fixes.
These packages had a large an complex enough implementation that targets at least one framework that is still in-support.

| Package                                                                                 | Last shipped release |
|-----------------------------------------------------------------------------------------|----------------------|
| [Microsoft.Bcl.HashCode](src/Microsoft.Bcl.HashCode/)                                   | 3.1                  |
| [System.Buffers](src/System.Buffers/)                                                   | 2.1                  |
| [System.Data.SqlClient](src/System.Data.SqlClient/)                                     | 3.1                  |
| [System.Json](src/System.Json/)                                                         | 3.1                  |
| [System.Memory](src/System.Memory/)                                                     | 2.1                  |
| [System.Net.WebSockets.WebSocketProtocol](src/System.Net.WebSockets.WebSocketProtocol/) | 5.0                  |
| [System.Numerics.Vectors](src/System.Numerics.Vectors/)                                 | 2.1                  |
| [System.Reflection.DispatchProxy](src/System.Reflection.DispatchProxy/)                 | 3.1                  |
| [System.Runtime.CompilerServices.Unsafe](src/System.Runtime.CompilerServices.Unsafe/)   | 6.0                  |
| [System.Threading.Tasks.Extensions](src/System.Threading.Tasks.Extensions/)             | 2.1                  |
| [System.Xml.XPath.XmlDocument](src/System.Xml.XPath.XmlDocument/)                       | 1.1                  |

### Implementation too simple

These packages also have a real implementation in a supported framework, but their code is too small and simple to be migrated immediately (mostly just extension classes).
In the future, if a security issue is found in one of these packages, we will consider migration, and any subsequent releases of such package will come out of this repo.

| Package                                 | Last shipped release |
|-----------------------------------------|----------------------|
| System.IO.FileSystem.AccessControl      | 5.0                  |
| System.IO.Pipes.AccessControl           | 5.0                  |
| System.Reflection.TypeExtensions        | 3.1                  |
| System.Data.Common                      | 1.1                  |
| System.Diagnostics.StackTrace           | 1.1                  |
| System.Globalization.Extensions         | 1.1                  |
| System.Net.Http                         | 1.1                  |
| System.Net.Sockets                      | 1.1                  |
| System.Runtime.Serialization.Primitives | 1.1                  |
| System.Security.Cryptography.Algorithms | 1.1                  |
| System.Xml.XPath.XDocument              | 1.1                  |

### No code

These packages contain no code.

| Package                            | Last shipped release |
|------------------------------------|----------------------|
| Microsoft.NETCore.Platforms.Future | 3.1                  |
| Microsoft.NETCore.Targets          | 5.0                  |
| Microsoft.NETCore.Platforms        | 7.0                  |

### PlatformNotSupportedException

All the APIs of these assemblies throw PNSE:

| Package                              | Last shipped release |
|--------------------------------------|----------------------|
| System.Security.Cryptography.Cng     | 5.0                  |
| System.Security.Cryptography.OpenSsl | 5.0                  |
| System.Security.Principal.Windows    | 5.0                  |

### Façades

These packages contain a .NET Framework implementation, but they have an in-box façade:

| System.IO.Compression                             | 1.1 |
|---------------------------------------------------|-----|
| System.Runtime.InteropServices.RuntimeInformation | 1.1 |
| System.Security.SecureString                      | 1.1 |
| System.Threading.Overlapped                       | 1.1 |
| System.ValueTuple                                 | 2.1 |

And all the APIs of the following assemblies are type-forwards:

| Package                                       | Last shipped release |
|-----------------------------------------------|----------------------|
| Microsoft.Win32.Primitives                    | 1.1                  |
| System.AppContext                             | 1.1                  |
| System.Collections                            | 1.1                  |
| System.Console                                | 1.1                  |
| System.Diagnostics.Contracts                  | 1.1                  |
| System.Diagnostics.Debug                      | 1.1                  |
| System.Diagnostics.FileVersionInfo            | 1.1                  |
| System.Diagnostics.Process                    | 1.1                  |
| System.Diagnostics.Tools                      | 1.1                  |
| System.Diagnostics.TraceSource                | 1.1                  |
| System.Globalization                          | 1.1                  |
| System.Globalization.Calendars                | 1.1                  |
| System.IO                                     | 1.1                  |
| System.IO.FileSystem                          | 1.1                  |
| System.IO.FileSystem.DriveInfo                | 1.1                  |
| System.IO.FileSystem.Watcher                  | 1.1                  |
| System.IO.IsolatedStorage                     | 1.1                  |
| System.IO.MemoryMappedFiles                   | 1.1                  |
| System.IO.Pipes                               | 1.1                  |
| System.Net.NameResolution                     | 1.1                  |
| System.Net.NetworkInformation                 | 1.1                  |
| System.Net.Ping                               | 1.1                  |
| System.Net.Primitives                         | 1.1                  |
| System.Net.Requests                           | 1.1                  |
| System.Net.Security                           | 1.1                  |
| System.Net.WebSockets.Client                  | 1.1                  |
| System.Reflection                             | 1.1                  |
| System.Reflection.Extensions                  | 1.1                  |
| System.Reflection.Primitives                  | 1.1                  |
| System.Resources.ResourceManager              | 1.1                  |
| System.Runtime                                | 1.1                  |
| System.Runtime.CompilerServices.VisualC       | 1.1                  |
| System.Runtime.Extensions                     | 1.1                  |
| System.Runtime.Handles                        | 1.1                  |
| System.Runtime.InteropServices                | 1.1                  |
| System.Runtime.InteropServices.WindowsRuntime | 1.1                  |
| System.Runtime.Loader                         | 1.1                  |
| System.Runtime.Serialization.Json             | 1.1                  |
| System.Runtime.Serialization.Xml              | 1.1                  |
| System.Security.Cryptography.Csp              | 1.1                  |
| System.Security.Cryptography.Encoding         | 1.1                  |
| System.Security.Cryptography.X509Certificates | 1.1                  |
| System.Text.Encoding                          | 1.1                  |
| System.Text.Encoding.Extensions               | 1.1                  |
| System.Threading.Tasks                        | 1.1                  |
| System.Threading.Thread                       | 1.1                  |
| System.Threading.ThreadPool                   | 1.1                  |
| System.Threading.Timer                        | 1.1                  |
| Microsoft.Windows.Compatibility.Shims         | 2.0                  |
| System.Runtime.Intrinsics.Experimental        | 5.0                  |
| System.Runtime.Experimental                   | 6.0                  |

## Reference assemblies

These packages only contain ref assemblies:

| Package             | Last shipped release |
|---------------------|----------------------|
| System.Net.Http.Rtc | 1.1                  |
| NETStandard.Library | 2.0                  |

## Unused implementation

These packages contain an actual implementation in .NET Standard 2.0, but it's not used anywhere:

| System.Collections.Concurrent              | 1.1 |
|--------------------------------------------|-----|
| System.Collections.NonGeneric              | 1.1 |
| System.Collections.Specialized             | 1.1 |
| System.ComponentModel                      | 1.1 |
| System.ComponentModel.EventBasedAsync      | 1.1 |
| System.ComponentModel.Primitives           | 1.1 |
| System.ComponentModel.TypeConverter        | 1.1 |
| System.Diagnostics.TextWriterTraceListener | 1.1 |
| System.Drawing.Primitives                  | 1.1 |
| System.Dynamic.Runtime                     | 1.1 |
| System.IO.Compression.ZipFile              | 1.1 |
| System.IO.FileSystem.Primitives            | 1.1 |
| System.IO.UnmanagedMemoryStream            | 1.1 |
| System.Linq                                | 1.1 |
| System.Linq.Expressions                    | 1.1 |
| System.Linq.Parallel                       | 1.1 |
| System.Linq.Queryable                      | 1.1 |
| System.Net.WebHeaderCollection             | 1.1 |
| System.Net.WebSockets                      | 1.1 |
| System.ObjectModel                         | 1.1 |
| System.Resources.Reader                    | 1.1 |
| System.Resources.Writer                    | 1.1 |
| System.Runtime.Numerics                    | 1.1 |
| System.Runtime.Serialization.Formatters    | 1.1 |
| System.Security.Claims                     | 1.1 |
| System.Security.Cryptography.Primitives    | 1.1 |
| System.Security.Principal                  | 1.1 |
| System.Text.RegularExpressions             | 1.1 |
| System.Threading                           | 1.1 |
| System.Threading.Tasks.Parallel            | 1.1 |
| System.Xml.ReaderWriter                    | 1.1 |
| System.Xml.XDocument                       | 1.1 |
| System.Xml.XmlDocument                     | 1.1 |
| System.Xml.XmlSerializer                   | 1.1 |
| System.Xml.XPath                           | 1.1 |
| Microsoft.VisualBasic                      | 2.1 |
| System.Data.DataSetExtensions              | 2.1 |
| Microsoft.CSharp                           | 3.1 |
| Microsoft.Win32.Registry                   | 5.0 |
| System.ComponentModel.Annotations          | 5.0 |

## Unsupported implementations

### Deprecated WinRT

These packages target the built-in WinRT implementation which is deprecated: https://learn.microsoft.com/en-us/dotnet/core/compatibility/interop/5.0/built-in-support-for-winrt-removed

Users should now move to use C#-WinRT: https://learn.microsoft.com/en-us/windows/apps/develop/platform/csharp-winrt/

| Package                                | Last shipped release |
|----------------------------------------|----------------------|
| System.Numerics.Vectors.WindowsRuntime | 1.1                  |
| System.Runtime.WindowsRuntime          | 3.1                  |
| System.Runtime.WindowsRuntime.UI.Xaml  | 3.1                  |

### Test-only

This package contains an unsupported test-only package:

| Package                    | Last shipped release |
|----------------------------|----------------------|
| Microsoft.NETCore.TestHost | 6.0                  |

# In-box

These packages are an unsupported OOB version of a component that became in-box:

| Package                                                      | Last shipped release |
|--------------------------------------------------------------|----------------------|
| System.Security.AccessControl                                | 6.0                  |
| Microsoft.Diagnostics.Tracing.EventSource.Redist             | 6.0                  |
| Microsoft.IO.Redist                                          | 6.0                  |

### Others

These packages are fully unsupported:

| Package                             | Last shipped release |
|-------------------------------------|----------------------|
| System.Diagnostics.Tracing          | 1.1                  |
| System.Reflection.Emit              | 3.1                  |
| System.Reflection.Emit.ILGeneration | 3.1                  |
| System.Reflection.Emit.Lightweight  | 3.1                  |
