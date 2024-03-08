# Maintenance Packages


## Description

This project hosts different packages from the .NET Platform that are still under support but whose original home/branch is not building any longer. The main purpose of it is to be able to have a servicing vehicle for them using the latest toolset.


## Project FAQ

- How do I know if a particular package belongs on this repo?
  - If a package/library is still building in a supported branch, then this repository is not the right place for it, and the supported branch where they're still building is their preferred servicing vehicle.
- Ok, I've determined that this package does belong on the repo, what is the process to add it?
  - Continue reading.


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

Note to maintainers: You'll most likely have to port from the internal repo. Please consult with the @dotnet/area-infrastructure-libraries members for guidance on choosing the correct repo of origin and branch name.

After executing the script, do the following:

1. Double check that the created branch is up-to-date with `main`. If it isn't, merge the latest changes in `main` (important: do not rebase).
2. Rename the branch to one of your choosing. You can use `git branch -M <OldName> <NewName>`.
3. Manually copy any source code files that were not brought in by the script, and commit it. For example, those located under the `Common/` or the `CoreLib/` directories in the origin repo won't be included in the migration.
4. Delete the obsolete infrastructure files that are not relevant anymore when using the latest version of arcade.
5. Use the modern Microsoft.NET.Sdk for the csproj files.
6. Set the target frameworks to those the package should continue supporting. This might not be as straightforward so please feel free to reach out to the @dotnet/area-infrastructure-libraries members for guidance.
7. Update the `AssemblyVersion`, `VersionPrefix` and `PackageValidationBaselineVersion` in the src csproj file as needed:
  A. We only need to set the `AssemblyVersion` when an assembly has overlap with a framework assembly (for example, `System.Buffers`). If the package is behaving completely out of band, it can use the repo-wide versioning, meaning we don't need to add the `AssemblyVersion` properties (For example: `Microsoft.Bcl.HashCode` and `System.Net.WebSockets.WebSocketProtocol`). There should be three separate property values for `AssemblyVersion`:
    i. The unconditioned property, which should match the assembly version value of the last stable package we released. It should also be suffixed with the comment: `<!-- NO-INCREMENT: This version is frozen for .NET Standard and .NETCoreApp because the assembly ships inbox. -->`.
    ii. A property conditioned to check if the framework reading it is one that will consume this package once we release a new package version. The value should start with the same number as the unconditioned property.
    iii. Another conditioned property, with the same condition as the previous one, but additionally checking for the condition `'IsPackable' == 'true'`. The value should have the minor version number bumped by one, and should represent the value of the future package to publish.
  B. `VersionPrefix` must have two property values:
    i. One is unconditioned, and should match the last _stable_ version we released of this package (you chan check on nuget.org). Avoid preview and rc versions.
    ii. The other one is conditioned to `'IsPackable' == 'true'`. This property value is what will be used in the next version we release of this package. It needs to bump the minor version to the next value. For example, if the unconditioned `VersionPrefix` is 5.1.0 (where 5 is the major version, 1 is the minor version, and 0 is the patch version), we need to bump the minor version of this property to 2: 5.2.0.
  C. The `PackageValidationBaselineVersion` value should match the same value as the unconditioned `VersionPrefix`. This property represents the package version that ApiCompat should use to compare the next package version with, to ensure the APIs are fully compatible.
8. Add the csprojs to the base sln file.
9. Delete dead source code. For example, code protected by preprocessor directives that are not relevant anymore due to the specified framework being out of support.
10. Build the whole repo using the base `build.cmd|sh` script.
11. Turn `<IsPackable>` to `true`, then run `dotnet pack` to see if APICompat / PackageValidation complain, in which case you'll have to address the issues. When done, set it back to `false`.
12. Squash all the _new_ commits introduced by you in this repo, excluding the migrated commit history.
13. Submit the PR and tag @dotnet/area-infrastructure-libraries for review.


## How to produce stable package versions

Package versions produced by official builds for this repo will automatically contain a prerelease suffix. This is in order to be able to iterate through changes until we are ready to have a final build when we are ready for a new servicing release. When that time comes, all that is needed in order to produce packages that don't have the prerelease suffix is to manually queue a build in the official pipeline, and set the variable `DotNetFinalVersionKind` to `release`. This will automatically cause Arcade to set the right version for the package, as well as use a dedicated NuGet feed to push the final build assets (in order to avoid potential version clashes).


## How to service a library

The default build will automatically build all of the libraries that have been added to the repo. That said, given this repository is used to service packages, and you won't always want to service all of the packages at the same time, packages for libraries are not generated by default. To enable a library to produce a package and be serviced:

1. Set the `<IsPackable>` property to `true` in the library's project file.
2. Set the value of the `<VersionPrefix>` property to the value of the other property with the same name but conditioned to `'$(IsPackable)' == 'true'`.
3. Bump the minor version number of the `VersionPrefix` property conditioned with `'$(IsPackable)' == 'true'">` property to the next value.
4. Set the value of the `AssemblyVersion` property, conditioned to `$([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)')) == '.NETFramework'`, to the value of the other property with the same name but conditioned to `'$(IsPackable)' == 'true' and $([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)')) == '.NETFramework'`.
5. Bump the minor version number of the `AssemblyVersion` property conditioned with `$([MSBuild]::GetTargetFrameworkIdentifier('$(TargetFramework)')) == '.NETFramework'` to the next value.
6. Set the `PackageValidationBaselineVersion` property value to the same of the unconditioned `VersionPrefix`.
7. Important: Do not modify the value of the _unconditioned_ `AssemblyVersion`.


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


## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
