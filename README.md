# Maintenance Packages

## Description

This project hosts different packages from the .NET Platform whose original home/branch is not building any longer. The main purpose of it is to be able to have a servicing vehicle for them which uses the latest toolset.

## Project FAQ

- How do I know if a particular package belongs on this repo?
  - As explained above, this repo is meant to be the home for packages that are no longer building in any supported repository/branch. Therefore, if a package/library is still building in one supported branch, then this repository is not the right place for it. The idea of this repo is to have a servicing vehicle for those packages, and if one package is still building in a supported branch, then by definition that is the servicing vehicle that should be used for servicing fixes to it.
- Ok, I've determined that this package does belong on the repo, what is the process to add it?
  - *ToDo*

## How to produce stable package versions

Package versions produced by official builds for this repo will automatically contain a prerelease suffix. This is in order to be able to iterate through changes until we are ready to have a final build when we are ready for a new servicing release. When that time comes, all that is needed in order to produce packages that don't have the prerelease suffix is to manually queue a build in the official pipeline, and set the variable `DotNetFinalVersionKind` to `release`. This will automatically cause Arcade to set the right version for the package, as well as use a dedicated NuGet feed to push the final build assets (in order to avoid potential version clashes).

## How to service a library

The default build will automatically build all of the libraries that have been added to the repo. That said, given this repository is used to service packages, and you won't always want to service all of the packages at the same time, packages for libraries are not built by default. Whenever a package needs to be serviced, the following steps will need to be follwed:

1. Determine the ServiceVersion to be used. When servicing a fix on a library package, the ServiceVersion (third part of the NuGet package version) will need to be bumped. This property is found in the library's src project. It's also possible that the property is not in that file, in which case you'll need to add it to the project and set it to 1. If the property is already in the source project, then just increment the servicing version by 1.
2. Ensure that the source project has the property `<GeneratePackageOnBuild>true</GeneratePackageOnBuild>` set. This will ensure that the package for this library will be produced as part of the build.

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
