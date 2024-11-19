# Maintenance Packages

## Description

This repo contains packages that are in maintenance and primarily updated for security servicing, as opposed to new features. They were previously hosted in repos or branches that are no longer active.

# How do I know if a particular package belongs on this repo?

If a package is still building in a supported branch, then this repository is not the right place for it, and the supported branch where they're still building is their preferred servicing vehicle.

On the other hand, if the package is still targeting frameworks that are still in support, and contains an actual source code implementation (as opposed to being a reference assembly or containing only type-forwards), but its source code currently lives in a branch from a .NET version that is already out of support, then the package is a candidate for getting migrated to this repo.

## How to migrate a library

1. You can use the `eng/Migrate-Package.ps1` script to automate most of the migration work, which includes most commit history relevant to the chosen assembly. Depending on the repo and branches of origin, as well as the root for all your cloned repos, you'll have to adjust the arguments. For example:

    a. Migrating a package from .NET Core 1.1:
   ```powershell
   .\eng\Migrate-Package.ps1 \
      -OriginRepoPath D:/corefx \
      -OriginRemote upstream \
      -OriginBranch v1.1.13 \
      -AssemblyFileOrDirectoryToMigrate System.Migratable.Assembly \
      -AssemblyFileOrDirectoryRelativeDirectoryPath src \
      -DestinationRepoPath D:/maintenance-packages
    ```

    a. Migrating a package from .NET Core 2.1:
   ```powershell
   .\eng\Migrate-Package.ps1 \
      -OriginRepoPath D:/corefx \
      -OriginRemote upstream \
      -OriginBranch v2.1.30 \
      -AssemblyFileOrDirectoryToMigrate System.Migratable.Assembly \
      -AssemblyFileOrDirectoryRelativeDirectoryPath src \
      -DestinationRepoPath D:/maintenance-packages
    ```

    b. Migrating a package from .NET Core 3.1:
    ```powershell
    .\eng\Migrate-Package.ps1 \
      -OriginRepoPath D:/corefx \
      -OriginRemote upstream \
      -OriginBranch v3.1.32 \
      -AssemblyFileOrDirectoryToMigrate System.Migratable.Assembly \
      -AssemblyFileOrDirectoryRelativeDirectoryPath src \
      -DestinationRepoPath D:/maintenance-packages
    ```

    c. Migrating a package from .NET 5.0:
    ```powershell
      .\eng\Migrate-Package.ps1 \
      -OriginRepoPath D:/runtime \
      -OriginRemote upstream \
      -OriginBranch v5.0.18 \
      -AssemblyFileOrDirectoryToMigrate System.Migratable.Assembly \
      -AssemblyFileOrDirectoryRelativeDirectoryPath src/libraries \
      -DestinationRepoPath D:/maintenance-packages
    ```
    
    d. Migrating a package from .NET 6.0:
    ```powershell
      .\eng\Migrate-Package.ps1 \
      -OriginRepoPath D:/runtime \
      -OriginRemote upstream \
      -OriginBranch v6.0.36 \
      -AssemblyFileOrDirectoryToMigrate System.Migratable.Assembly \
      -AssemblyFileOrDirectoryRelativeDirectoryPath src/libraries \
      -DestinationRepoPath D:/maintenance-packages
    ```

Note to maintainers: You'll most likely have to port from the internal repo. Please consult with the @dotnet/area-infrastructure-libraries members for guidance on choosing the correct repo of origin and branch name.

After executing the script, do the following:

1. Double check that the created branch is up-to-date with `main`. If it isn't, merge the latest changes in `main` (important: avoid rebasing your branch after this point).
2. Rename the branch to one of your choosing. You can use `git branch -M <OldName> <NewName>`.
3. Manually copy any source code files that were not brought in by the script, and commit it. For example, those located under the `Common/` or the `CoreLib/` directories in the origin repo won't be included in the migration.
4. Delete the obsolete infrastructure files that are not relevant anymore when using the latest version of arcade.
5. Use the modern Microsoft.NET.Sdk for the csproj files.
6. Set the target frameworks to those the package should continue supporting. This might not be as straightforward so please feel free to reach out to the @dotnet/area-infrastructure-libraries members for guidance.
7. Update the `AssemblyVersion`, `VersionPrefix` and `PackageValidationBaselineVersion` in the src csproj file as needed:
  A. We only need to set the `AssemblyVersion` when an assembly has overlap with a framework assembly (for example, `System.Buffers`). If the package is behaving completely out of band, it can use the repo-wide versioning, meaning we don't need to add the `AssemblyVersion` properties (For example: `Microsoft.Bcl.HashCode` and `System.Net.WebSockets.WebSocketProtocol`). There should be three separate property values for `AssemblyVersion`:
    i. The unconditioned property, also known as the pinned assembly version, which should match the assembly version value of the last stable package we released (for example, `4.6.1.6`) It should also be followed with the comment: `<!-- NO-INCREMENT: This version is frozen for .NET Standard and .NETCoreApp because the assembly ships inbox. -->`.
    ii. A property conditioned to check if the framework reading it is one that will consume this package once we release a new package version. The value should start with the same number as the unconditioned property (for example, `4.6.1.6` again).
    iii. Another conditioned property, with the same condition as the previous one, but additionally checking for the condition `'IsPackable' == 'true'`. The value should have the minor version number (second number from the right) bumped by one, and the revision number (first number from the right) needs to be reset to `0` (for example, `4.6.2.0`). This number should represent the value of the future package to publish.
  B. `VersionPrefix` must have two property values:
    i. One is unconditioned, and should match the last _stable_ version we released of this package (you chan check on nuget.org). Avoid preview and rc versions. For example, `4.8.6`.
    ii. The other property must be conditioned to `'IsPackable' == 'true'`. This property value is what will be used in the next version we release of this package. It needs to bump the minor version number (second number from the right) to the next value, and the revision number (first number from the right) needs to be reset to `0`. For example, `4.9.0`.
  C. The `PackageValidationBaselineVersion` value should match the same value as the unconditioned `VersionPrefix`. This property represents the package version that ApiCompat should use to compare the next package version with, to ensure the APIs are fully compatible. For example, `4.8.6`.
1. Add the csprojs to the base sln file.
2. Delete dead source code. For example, code protected by preprocessor directives that are not relevant anymore due to the specified framework being out of support.
3.  Build the whole repo using the base `build.cmd|sh` script.
4.  Turn `<IsPackable>` to `true`, then run `dotnet pack` to see if APICompat / PackageValidation complain, in which case you'll have to address the issues. When done, set it back to `false`.
5.  Squash all the _new_ commits introduced by you in this repo, excluding the migrated commit history.
6.  Add the new assembly folder to .github/CODEOWNERS and tag the correct area owner from https://github.com/dotnet/runtime/blob/main/docs/area-owners.md .
7.  Submit the PR and tag @dotnet/area-infrastructure-libraries for review.

## How to service a library

The official build automatically builds and tests all the assemblies in this repo, but does not generate new packages by default. To enable the production of a new package for servicing, you need to set the `<IsPackable>` property to `true` in the assembly's src project file. Do not bump version numbers at this stage.

Make sure to investigate any ApiCompat failures that arise, as they only show up when packing.

## How to disable servicing a library

1. set the `<IsPackable>` property to `false`. The assembly will continue getting built and tested in the official builds, but will not generate a new package.
2. Copy the `VersionPrefix` (and `AssemblyVersion` if it applies) from the `'$(IsPackable)' == 'true'` conditioned property, to the unconditioned property. Also copy the conditioned `VersionPrefix` value to the `PackageValidationBaselineVersion` property (if it applies).
3. Bump the minor version numbers (second number from the right) of the `VersionPrefix` (and `AssemblyVersion` if it applies) properties that are conditioned with `'$(IsPackable)' == 'true'`, and reset the revision number (first number from the right) to `0`.

### Example

Assuming these are the initial property values of your assembly:

```xml
<VersionPrefix>1.1.1</VersionPrefix>
<VersionPrefix Condition="'$(IsPackable)' == 'true'">1.2.0</VersionPrefix>
<AssemblyVersion>2.2.2.2</AssemblyVersion><!-- NO-INCREMENT: This version is frozen for .NET Standard and .NETCoreApp because the assembly ships inbox. -->
<AssemblyVersion Condition="$([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)')) == '.NETFramework'">2.2.2.2</AssemblyVersion>
<AssemblyVersion Condition="'$(IsPackable)' == 'true' and $([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)')) == '.NETFramework'">2.2.3.0</AssemblyVersion>
<PackageValidationBaselineVersion>1.1.1</PackageValidationBaselineVersion>
```

You need to change them to this:

```xml
<VersionPrefix>1.2.0</VersionPrefix>
<VersionPrefix Condition="'$(IsPackable)' == 'true'">1.2.1</VersionPrefix>
<AssemblyVersion>2.2.2.2</AssemblyVersion><!-- NO-INCREMENT: This version is frozen for .NET Standard and .NETCoreApp because the assembly ships inbox. -->
<AssemblyVersion Condition="$([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)')) == '.NETFramework'">2.2.3.0</AssemblyVersion>
<AssemblyVersion Condition="'$(IsPackable)' == 'true' and $([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)')) == '.NETFramework'">2.2.3.1</AssemblyVersion>
<PackageValidationBaselineVersion>1.2.0</PackageValidationBaselineVersion>
```

## Contribution bar

- [We only consider fixes that unblock critical issues](https://github.com/dotnet/runtime/blob/main/src/libraries/README.md#primary-bar)
- [We don't accept refactoring changes due to new language features](https://github.com/dotnet/runtime/blob/main/src/libraries/README.md#secondary-bars)

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Deployment

### Produce the stable package versions

Packages produced by builds for this repo will have a prerelease suffix appended to their name by default. This allows us to iterate through changes until we are ready to have a final build when we are ready for a new servicing release. When that time comes, all that is needed in order to produce packages that don't have the prerelease suffix is to manually queue a build in the official pipeline, and set the azdo pipeline variable `DotNetFinalVersionKind` to `release`. This will automatically cause Arcade to set the right version for the package, as well as use a dedicated NuGet feed to push the final build assets into an isolated feed where its name is suffixed with the commit number (in order to avoid potential version clashes).

### Push the packages to NuGet

A maintainer from @dotnet/area-infrastructure-libraries with the right permissions needs to download the produced stable artifacts and push them to NuGet.

### Create the release notes

1. Create a tag with the date of publishing in the format `YYYY.MM.DD`. There are no "release versions" in this repository because every package has its own release cadence.
2. Choose the commit from which the stable package versions were produced.
3. Add a title with the format "<Month> <Day> <Year> Release". See previous examples for guidance.
4. In the release notes text, describe the changes, any new packages that were added to the repo since the last release, any fixes merged to the packages, and add a link to the changelog. See previous examples for guidance.