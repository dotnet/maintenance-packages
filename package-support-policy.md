# Package support policy for maintenance-packages

As it has been described in the [.NET Release policies](https://github.com/dotnet/core/blob/main/release-policies.md) document, .NET library packages provide additional functionality that complements the .NET libraries and application frameworks like ASP.NET Core. The library packages have the same [support model as the .NET versions](https://dotnet.microsoft.com/en-us/platform/support/policy) that they target.

For example, [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/#supportedframeworks-body-tab) supports multiple .NET versions via the frameworks it targets.

Our packages support any target framework versions that are currently in-support. You can find out which frameworks are supported by a specific package by visiting its NuGet page and navigating to the frameworks tab.

Additionally, you can find out which target frameworks are currently in-support by visiting the following pages:

- .NET: https://dotnet.microsoft.com/en-us/platform/support/policy
- .NET Framework: https://learn.microsoft.com/en-us/lifecycle/products/microsoft-net-framework

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

A package will be supported for as long as it targets frameworks that are still supported. For example: [System.Numerics.Vectors](https://www.nuget.org/packages/System.Json#supportedframeworks-body-tab) will is supported because it provides an implementation on .NET Framework 4.6.2, which is still in support.

## Reporting issues

If you find an issue in an assembly that is hosted in this repo, please report it in our central repo: https://github.com/dotnet/runtime/issues/new/choose.

## Should I consume this package? Which version should I consume?

Please refer to the table below to:

- Learn why there is a new version of some nuget packages.
- Depending on the target framework, determine if you should remove the reference to a nuget package from your project or if you should keep it.

| Package                                                      | Use in .NET 6.0? | Use in .NET Standard 2.0?                           | Use in .NET Framework 4.6.2?                        |
|--------------------------------------------------------------|------------------|-----------------------------------------------------|-----------------------------------------------------|
| Microsoft.Bcl.AsyncInterfaces                                | Remove           | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Bcl.Cryptography                                   | N/A              | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Bcl.HashCode                                       | Remove           | Migrated                                            | Migrated                                            |
| Microsoft.CSharp                                             | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| Microsoft.Diagnostics.Tracing.EventSource.Redist             | Remove           | Unsupported OOB version of in-box component         | Unsupported OOB version of in-box component         |
| Microsoft.DotNet.ILCompiler                                  | N/A              | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Caching.Abstractions                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Caching.Memory                          | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration                           | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.Abstractions              | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.Binder                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.CommandLine               | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.EnvironmentVariables      | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.FileExtensions            | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.Ini                       | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.Json                      | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.UserSecrets               | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Configuration.Xml                       | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.DependencyInjection                     | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.DependencyInjection.Abstractions        | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.DependencyInjection.Specification.Tests | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.DependencyModel                         | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.FileProviders.Abstractions              | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.FileProviders.Composite                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.FileProviders.Physical                  | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.FileSystemGlobbing                      | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Hosting                                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Hosting.Abstractions                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Hosting.Systemd                         | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Hosting.WindowsServices                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Http                                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging                                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging.Abstractions                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging.Configuration                   | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging.Console                         | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging.Debug                           | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging.EventLog                        | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging.EventSource                     | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Logging.TraceSource                     | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Options                                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Options.ConfigurationExtensions         | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Options.DataAnnotations                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Extensions.Primitives                              | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.ILVerification                                     | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.IO.Redist                                          | Remove           | Unsupported OOB version of in-box component         | Unsupported OOB version of in-box component         |
| Microsoft.ML.OnnxRuntime                                     | Remove           | #N/A                                                | #N/A                                                |
| Microsoft.NET.ILLink                                         | Remove           | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.NET.ILLink.Tasks                                   | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.NET.Sdk.IL                                         | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.NET.WebAssembly.Threading                          | N/A              | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.NETCore.ILAsm                                      | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.NETCore.ILDAsm                                     | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.NETCore.Platforms                                  | Upgrade          | No code                                             | No code                                             |
| Microsoft.NETCore.Platforms.Future                           | Remove           | No code                                             | No code                                             |
| Microsoft.NETCore.Targets                                    | Remove           | No code                                             | No code                                             |
| Microsoft.NETCore.TestHost                                   | None             | Unsupported test-only package                       | Unsupported test-only package                       |
| Microsoft.VisualBasic                                        | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| Microsoft.Win32.Primitives                                   | Remove           | Façade                                              | Façade                                              |
| Microsoft.Win32.Registry                                     | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| Microsoft.Win32.Registry.AccessControl                       | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Win32.SystemEvents                                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| Microsoft.Windows.Compatibility                              | Upgrade          | No code                                             | No code                                             |
| Microsoft.Windows.Compatibility.Shims                        | Remove           | Façade                                              | Façade                                              |
| Microsoft.XmlSerializer.Generator                            | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| NETStandard.Library                                          | Remove           | Reference assembly                                  | Reference assembly                                  |
| System.AppContext                                            | Remove           | Façade                                              | Façade                                              |
| System.Buffers                                               | Remove           | Migrated                                            | Migrated                                            |
| System.CodeDom                                               | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Collections                                           | Remove           | Façade                                              | Façade                                              |
| System.Collections.Concurrent                                | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Collections.Immutable                                 | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Collections.NonGeneric                                | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Collections.Specialized                               | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.ComponentModel                                        | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.ComponentModel.Annotations                            | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.ComponentModel.Composition                            | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.ComponentModel.Composition.Registration               | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.ComponentModel.EventBasedAsync                        | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.ComponentModel.Primitives                             | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.ComponentModel.TypeConverter                          | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Composition                                           | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Composition.AttributedModel                           | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Composition.Convention                                | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Composition.Hosting                                   | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Composition.Runtime                                   | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Composition.TypedParts                                | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Configuration.ConfigurationManager                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Console                                               | Remove           | Façade                                              | Façade                                              |
| System.Data.Common                                           | Remove           | Simple implementation                               | Simple implementation                               |
| System.Data.DataSetExtensions                                | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Data.Odbc                                             | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Data.OleDb                                            | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Data.SqlClient                                        | None             | Migrated                                            | Migrated                                            |
| System.Diagnostics.Contracts                                 | Remove           | Façade                                              | Façade                                              |
| System.Diagnostics.Debug                                     | Remove           | Façade                                              | Façade                                              |
| System.Diagnostics.DiagnosticSource                          | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Diagnostics.EventLog                                  | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Diagnostics.FileVersionInfo                           | Remove           | Façade                                              | Façade                                              |
| System.Diagnostics.PerformanceCounter                        | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Diagnostics.Process                                   | Remove           | Façade                                              | Façade                                              |
| System.Diagnostics.StackTrace                                | Remove           | Simple implementation                               | Simple implementation                               |
| System.Diagnostics.TextWriterTraceListener                   | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Diagnostics.Tools                                     | Remove           | Façade                                              | Façade                                              |
| System.Diagnostics.TraceSource                               | Remove           | Façade                                              | Façade                                              |
| System.Diagnostics.Tracing                                   | Remove           | Unsupported implementation                          | Unsupported implementation                          |
| System.DirectoryServices                                     | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.DirectoryServices.AccountManagement                   | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.DirectoryServices.Protocols                           | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Drawing.Common                                        | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Drawing.Primitives                                    | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Dynamic.Runtime                                       | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Formats.Asn1                                          | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Formats.Cbor                                          | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Globalization                                         | Remove           | Façade                                              | Façade                                              |
| System.Globalization.Calendars                               | Remove           | Façade                                              | Façade                                              |
| System.Globalization.Extensions                              | Remove           | Simple implementation                               | Simple implementation                               |
| System.IO                                                    | Remove           | Façade                                              | Façade                                              |
| System.IO.Compression                                        | Remove           | .NET Framework implementation with in-box façade    | .NET Framework implementation with in-box façade    |
| System.IO.Compression.ZipFile                                | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.IO.FileSystem                                         | Remove           | Façade                                              | Façade                                              |
| System.IO.FileSystem.AccessControl                           | Remove           | Simple implementation                               | Simple implementation                               |
| System.IO.FileSystem.DriveInfo                               | Remove           | Façade                                              | Façade                                              |
| System.IO.FileSystem.Primitives                              | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.IO.FileSystem.Watcher                                 | Remove           | Façade                                              | Façade                                              |
| System.IO.Hashing                                            | New              | Inbox in latest                                     | Inbox in latest                                     |
| System.IO.IsolatedStorage                                    | Remove           | Façade                                              | Façade                                              |
| System.IO.MemoryMappedFiles                                  | Remove           | Façade                                              | Façade                                              |
| System.IO.Packaging                                          | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.IO.Pipelines                                          | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.IO.Pipes                                              | Remove           | Façade                                              | Façade                                              |
| System.IO.Pipes.AccessControl                                | Remove           | Simple implementation                               | Simple implementation                               |
| System.IO.Ports                                              | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.IO.UnmanagedMemoryStream                              | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Json                                                  | Remove           | Migrated                                            | Migrated                                            |
| System.Linq                                                  | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Linq.Expressions                                      | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Linq.Parallel                                         | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Linq.Queryable                                        | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Management                                            | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Memory                                                | Remove           | Migrated                                            | Migrated                                            |
| System.Memory.Data                                           | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Net.Http                                              | Remove           | Simple implementation                               | Simple implementation                               |
| System.Net.Http.Json                                         | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Net.Http.Rtc                                          | Remove           | Reference assembly                                  | Reference assembly                                  |
| System.Net.Http.WinHttpHandler                               | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Net.NameResolution                                    | Remove           | Façade                                              | Façade                                              |
| System.Net.NetworkInformation                                | Remove           | Façade                                              | Façade                                              |
| System.Net.Ping                                              | Remove           | Façade                                              | Façade                                              |
| System.Net.Primitives                                        | Remove           | Façade                                              | Façade                                              |
| System.Net.Requests                                          | Remove           | Façade                                              | Façade                                              |
| System.Net.Security                                          | Remove           | Façade                                              | Façade                                              |
| System.Net.Sockets                                           | Remove           | Simple implementation                               | Simple implementation                               |
| System.Net.WebHeaderCollection                               | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Net.WebSockets                                        | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Net.WebSockets.Client                                 | Remove           | Façade                                              | Façade                                              |
| System.Net.WebSockets.WebSocketProtocol                      | Remove           | Migrated                                            | Migrated                                            |
| System.Numerics.Tensors                                      | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Numerics.Vectors                                      | Remove           | Migrated                                            | Migrated                                            |
| System.Numerics.Vectors.WindowsRuntime                       | Remove           | Unsupported implementation (targets built-in WinRT) | Unsupported implementation (targets built-in WinRT) |
| System.ObjectModel                                           | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Reflection                                            | Remove           | Façade                                              | Façade                                              |
| System.Reflection.Context                                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Reflection.DispatchProxy                              | Remove           | Migrated                                            | Migrated                                            |
| System.Reflection.Emit                                       | Remove           | Unsupported implementation                          | Unsupported implementation                          |
| System.Reflection.Emit.ILGeneration                          | Remove           | Unsupported implementation                          | Unsupported implementation                          |
| System.Reflection.Emit.Lightweight                           | Remove           | Unsupported implementation                          | Unsupported implementation                          |
| System.Reflection.Extensions                                 | Remove           | Façade                                              | Façade                                              |
| System.Reflection.Metadata                                   | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Reflection.MetadataLoadContext                        | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Reflection.Primitives                                 | Remove           | Façade                                              | Façade                                              |
| System.Reflection.TypeExtensions                             | Remove           | Simple implementation                               | Simple implementation                               |
| System.Resources.Extensions                                  | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Resources.Reader                                      | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Resources.ResourceManager                             | Remove           | Façade                                              | Façade                                              |
| System.Resources.Writer                                      | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Runtime                                               | Remove           | Façade                                              | Façade                                              |
| System.Runtime.Caching                                       | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Runtime.CompilerServices.Unsafe                       | Upgrade          | Migrated                                            | Migrated                                            |
| System.Runtime.CompilerServices.VisualC                      | Remove           | Façade                                              | Façade                                              |
| System.Runtime.Experimental                                  | New              | Façade                                              | Façade                                              |
| System.Runtime.Extensions                                    | Remove           | Façade                                              | Façade                                              |
| System.Runtime.Handles                                       | Remove           | Façade                                              | Façade                                              |
| System.Runtime.InteropServices                               | Remove           | Façade                                              | Façade                                              |
| System.Runtime.InteropServices.RuntimeInformation            | Remove           | .NET Framework implementation with in-box façade    | .NET Framework implementation with in-box façade    |
| System.Runtime.InteropServices.WindowsRuntime                | Remove           | Façade                                              | Façade                                              |
| System.Runtime.Intrinsics.Experimental                       | Remove           | Façade                                              | Façade                                              |
| System.Runtime.Loader                                        | Remove           | Façade                                              | Façade                                              |
| System.Runtime.Numerics                                      | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Runtime.Serialization.Formatters                      | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Runtime.Serialization.Json                            | Remove           | Façade                                              | Façade                                              |
| System.Runtime.Serialization.Primitives                      | Remove           | Simple implementation                               | Simple implementation                               |
| System.Runtime.Serialization.Schema                          | N/A              | Inbox in latest                                     | Inbox in latest                                     |
| System.Runtime.Serialization.Xml                             | Remove           | Façade                                              | Façade                                              |
| System.Runtime.WindowsRuntime                                | None             | Unsupported implementation (targets built-in WinRT) | Unsupported implementation (targets built-in WinRT) |
| System.Runtime.WindowsRuntime.UI.Xaml                        | None             | Unsupported implementation (targets built-in WinRT) | Unsupported implementation (targets built-in WinRT) |
| System.Security.AccessControl                                | Remove           | Unsupported implementation (In-box since 7.0)       | Unsupported implementation (In-box since 7.0)       |
| System.Security.Claims                                       | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Security.Cryptography.Algorithms                      | Remove           | Simple implementation                               | Simple implementation                               |
| System.Security.Cryptography.Cng                             | Remove           | PNSE                                                | PNSE                                                |
| System.Security.Cryptography.Cose                            | N/A              | Inbox in latest                                     | Inbox in latest                                     |
| System.Security.Cryptography.Csp                             | Remove           | Façade                                              | Façade                                              |
| System.Security.Cryptography.Encoding                        | Remove           | Façade                                              | Façade                                              |
| System.Security.Cryptography.OpenSsl                         | Remove           | PNSE                                                | PNSE                                                |
| System.Security.Cryptography.Pkcs                            | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Security.Cryptography.Primitives                      | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Security.Cryptography.ProtectedData                   | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Security.Cryptography.X509Certificates                | Remove           | Façade                                              | Façade                                              |
| System.Security.Cryptography.Xml                             | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Security.Permissions                                  | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Security.Principal                                    | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Security.Principal.Windows                            | Remove           | PNSE                                                | PNSE                                                |
| System.Security.SecureString                                 | Remove           | .NET Framework implementation with in-box façade    | .NET Framework implementation with in-box façade    |
| System.ServiceModel.Syndication                              | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.ServiceProcess.ServiceController                      | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Speech                                                | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Text.Encoding                                         | Remove           | Façade                                              | Façade                                              |
| System.Text.Encoding.CodePages                               | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Text.Encoding.Extensions                              | Remove           | Façade                                              | Façade                                              |
| System.Text.Encodings.Web                                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Text.Json                                             | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Text.RegularExpressions                               | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Threading                                             | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Threading.AccessControl                               | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Threading.Channels                                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Threading.Overlapped                                  | Remove           | .NET Framework implementation with in-box façade    | .NET Framework implementation with in-box façade    |
| System.Threading.RateLimiting                                | N/A              | Inbox in latest                                     | Inbox in latest                                     |
| System.Threading.Tasks                                       | Remove           | Façade                                              | Façade                                              |
| System.Threading.Tasks.Dataflow                              | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Threading.Tasks.Extensions                            | Remove           | Migrated                                            | Migrated                                            |
| System.Threading.Tasks.Parallel                              | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Threading.Thread                                      | Remove           | Façade                                              | Façade                                              |
| System.Threading.ThreadPool                                  | Remove           | Façade                                              | Façade                                              |
| System.Threading.Timer                                       | Remove           | Façade                                              | Façade                                              |
| System.ValueTuple                                            | Remove           | .NET Framework implementation with in-box façade    | .NET Framework implementation with in-box façade    |
| System.Windows.Extensions                                    | Upgrade          | Inbox in latest                                     | Inbox in latest                                     |
| System.Xml.ReaderWriter                                      | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Xml.XDocument                                         | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Xml.XmlDocument                                       | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Xml.XmlSerializer                                     | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Xml.XPath                                             | Remove           | .NET Standard 2.0 implementation, not used anywhere | .NET Standard 2.0 implementation, not used anywhere |
| System.Xml.XPath.XDocument                                   | Remove           | Simple implementation                               | Simple implementation                               |
| System.Xml.XPath.XmlDocument                                 | Remove           | Migrated                                            | Migrated                                            |