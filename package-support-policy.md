# Package support policy for maintenance-packages

As it has been described in the [.NET Release policies](https://github.com/dotnet/core/blob/main/release-policies.md) document, .NET library packages provide additional functionality that complements the .NET libraries and application frameworks like ASP.NET Core. The library packages have the same [support model as the .NET versions](https://dotnet.microsoft.com/en-us/platform/support/policy) that they target.

For example, [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/#supportedframeworks-body-tab) supports multiple .NET versions via the frameworks it targets.

Our packages support any target framework versions that are currently in-support. You can find out which frameworks are supported by a specific package by visiting its NuGet page and navigating to the frameworks tab.

Additionally, you can find out which target frameworks are currently in-support by visiting the following pages:

- .NET: https://dotnet.microsoft.com/en-us/platform/support/policy
- .NET Framework: https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet-framework
- .NET Standard: https://learn.microsoft.com/en-us/dotnet/standard/net-standard

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
