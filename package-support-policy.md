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

Note that the source code of those two packages lives in the [dotnet/runtime](https://github.com/dotnet/runtime) repo.

On the other hand, the packages that come out from the dotnet/maintenance-packages repo have a separate, independent release cadence, meaning their servicing releases will come out of this repo and will not be bound by any pre-defined release schedule.

## End of support

A package will be supported for as long as it targets frameworks that are still supported. For example: [System.Numerics.Vectors](https://www.nuget.org/packages/System.Json#supportedframeworks-body-tab) is supported because it provides an implementation on .NET Framework 4.6.2, which is still in support.

## Reporting issues

If you find an issue in an assembly that lives in this repo, please report it in our central repo: https://github.com/dotnet/runtime/issues/new/choose.

## Should I consume this package? Which version should I consume?

Please refer to the table below to:

- Learn if a package is still supported and in which target frameworks.
- Learn what action you should take if you're actively consuming one of these packages:
  - **Remove** the package reference from your projects.
  - **Update** to the latest package version.
  - **Migrate** to another library.
  - *Something else*.

| Package                                 | Support | Supported where and why?                        | Actions to take                        |
|-----------------------------------------|------------------|-------------------------------------------------|----------------------------------------|
| Microsoft.Bcl.HashCode                  | Yes              | <ul><li>.NET Framework 4.6.2+: Provides the implementation of [`HashCode`](https://learn.microsoft.com/en-us/dotnet/api/system.hashcode).</li><li>.NET 6+: The type is already part of the shared framework.</li></ul> | <ul><li>.NET Framework 4.6.2+: Update.</li><li>.NET 6+: Remove.</li></ul> |
| Microsoft.CSharp                        | Limited          | <ul><li>.NET Standard 2.0: Only used as a _reference_. Other uses are not supported.</li><li>.NET Framework 4.6.2+ and .NET 6+: The library is already part of the shared framework.</li></ul> | <ul><li>.NETStandard 2.0: Update.</li><li>.NET Framework 4.6.2+ and .NET 6+: Remove.</li></ul> |
| Microsoft.IO.Redist                     | Limited          | Intended for internal use only, not for general use. Use the equivalent System.IO APIs instead, which are part of the shared framework in all supported frameworks. | Remove. |
| System.Buffers                          | Yes              | <ul><li>.NET Framework 4.6.2+: Provides the implementation of [`ArrayPool<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1).</li><li>.NET 6+: The type is part of the shared framework.</li></ul> | <ul><li>.NET Framework 4.6.2+: Update.</li><li>.NET 6+: Remove.</li></ul> |
| System.Data.SqlClient                   | Limited          | <ul><li>.NET Framework 4.6.2+: The library is part of the shared framework.</li><li>.NET 8: Marked as obsolete, but [supported until .NET 8 goes EOL.](https://techcommunity.microsoft.com/blog/sqlserver/announcement-system-data-sqlclient-package-is-now-deprecated/4227205)</li><li>All other frameworks: Not supported.</li></ul> | <ul><li> .NET Framework 4.6.2+: Remove.</li><li>.NET 8: System.Data.SqlClient is obsolete. Consider migrating to Microsoft.Data.SqlClient.</li><li>All other frameworks: Remove and migrate to Microsoft.Data.SqlClient.</li></ul> |
| System.Diagnostics.Tracing              | No               | [`EventSource`](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.tracing.eventsource) is part of the shared framework in all supported frameworks. | Remove. |
| System.Json                             | Limited          | The assembly targets in-support frameworks but it was designed for Silverlight, which is no longer supported. [Use System.Text.Json instead](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview), which is actively maintained. | Remove. |
| System.Memory                           | Yes              | <ul><li>.NET Framework 4.6.2+: Provides the implementation of [`Span<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.span-1), [`ReadOnlySpan<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1), [`Memory`](https://learn.microsoft.com/en-us/dotnet/api/system.memory-1), [`ReadOnlyMemory<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.readonlymemory-1), [`MemoryPool<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.memorypool-1), [`ReadOnlySequence<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.readonlysequence-1), [`Utf8Parser`](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.text.utf8parser) and [`Utf8Formatter`](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.text.utf8formatter).</li><li>.NET 6+: The types are part of the shared framework.</li></ul> | <ul><li>.NET Framework 4.6.2+: Update.</li><li>.NET 6+: Remove.</li></ul> |
| System.Net.WebSockets.WebSocketProtocol | Yes              | The assembly targets in-support frameworks but the package was only needed in ASP.NET applications targeting .NET Standard 2.0 which required to use implementations provided in the package. These implementations are no longer required in currently supported frameworks. | Remove. |
| System.Numerics.Vectors                 | Yes              | <ul><li>.NET Framework 4.6.2+ and .NET Standard 2.0: Provides implementations of [`Vector`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector) and [`Vector<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector-1).</li><li>.NET Standard 2.0: Provides implementation of [`Matrix3x2`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.matrix3x2), [`Matrix4x4`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.matrix4x4), [`Plane`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.plane), [`Quaternion`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.quaternion), [`Vector2`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector2), [`Vector3`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector3) and [`Vector4`](https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector4)</li><li>.NET 6+: The types are part of the shared framework.</li></ul> | <ul><li>.NET Framework 4.6.2+ and .NET Standard 2.0: Update.</li><li>.NET 6+: Remove.</li></ul> |
| System.Reflection.DispatchProxy         | Yes              | <ul><li>.NET Framework 4.6.2+: Provides an implementation of [`DispatchProxy`](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.dispatchproxy).</li><li>.NET 6+: The type is part of the shared framework.</li></ul> | <ul><li>.NET Framework 4.6.2+: Update.</li><li>.NET 6+: Remove.</li></ul> |
| System.Runtime.CompilerServices.Unsafe  | Yes              | <ul><li>.NET Framework 4.6.2+: Provides the implementation of [`Unsafe`](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.unsafe).</li><li>.NET 6+: The type is part of the shared framework</li></ul> | <ul><li>.NET Framework 4.6.2+: Update.</li><li>.NET 6+: Remove.</li></ul> |
| System.Runtime.WindowsRuntime           | No               | Built-in support for WinRT [has been removed from .NET](https://learn.microsoft.com/en-us/dotnet/core/compatibility/interop/5.0/built-in-support-for-winrt-removed).<br />Follow [the recommended actions](https://learn.microsoft.com/en-us/dotnet/core/compatibility/interop/5.0/built-in-support-for-winrt-removed#recommended-action). | Remove. |
| System.Runtime.WindowsRuntime.UI.Xaml   | No               | Built-in support for WinRT [has been removed from .NET](https://learn.microsoft.com/en-us/dotnet/core/compatibility/interop/5.0/built-in-support-for-winrt-removed).<br />Follow [the recommended actions](https://learn.microsoft.com/en-us/dotnet/core/compatibility/interop/5.0/built-in-support-for-winrt-removed#recommended-action). | Remove. |
| System.Threading.Tasks.Extensions       | Yes              | <ul><li>.NET Framework 4.6.2+: Provides implementations of [`ValueTask`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask) and [`ValueTask<TResult>`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1).</li><li>.NET 6+: The types are already part of the shared framework.</li></ul> | <ul><li>.NET Framework 4.6.2+: Update.</li><li>.NET 6+: Remove.</li></ul> |
| System.ValueTuple                       | No               | The .NET Framework implementation contained in the package is simply an in-box façade that forwards the types to the system-installed framework. | Remove. |
| System.Xml.XPath.XmlDocument            | Limited          | Provides the implementation of the [`XmlDocumentXPathExtensions`](https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmldocumentxpathextensions) extension methods. It is recommended that you call the extended APIs directly. Only use the package if you absolutely need to use the extension methods. | Remove. |
