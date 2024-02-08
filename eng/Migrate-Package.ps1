# Licensed to the .NET Foundation under one or more agreements.
# The .NET Foundation licenses this file to you under the MIT license.

Param (
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrWhiteSpace()]
    [string]
    # An absolute path to the origin repo clone root folder.
    # Must use forward slashes as separators (Unix style).
    $OriginRepoPath # Examples: 'C:/source/repos/corefx', '/home/user/runtime'.
,
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrWhiteSpace()]
    [string]
    # The name of the remote in the origin repo where the origin branch resides.
    $OriginRemote # Example: 'origin', 'upstream', 'dotnet', 'azdo'.
,
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrWhiteSpace()]
    [string]
    # The source branch from the origin repo.
    $OriginBranch # Examples: 'release/2.1', 'release/3.1'.
,
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrWhiteSpace()]
    [string]
    # The name of the assembly, file or directory to migrate.
    $AssemblyFileOrDirectoryToMigrate # Examples: 'System.Buffers', 'Microsoft.Bcl.HashCode', 'Common', 'MutableDecimal.cs'
,
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrWhiteSpace()]
    [string]
    # A relative path where the assembly, directory or file is located.
    # It should be relative to $OriginRepoPath.
    # Must use forward slashes as separators (Unix style).
    $AssemblyFileOrDirectoryRelativeDirectoryPath # Examples: 'src', 'src/libraries', 'src/libraries/Common/src/System'.
,
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrWhiteSpace()]
    [string]
    # An absolute path to the destination repo clone root folder.
    # Must use forward slashes as separators (Unix style).
    $DestinationRepoPath # Examples: 'C:/source/repos/maintenance-packages', '/home/user/maintenance-packages'.
)

#### Functions ####

Function Write-Color
{
    Param (
        [ValidateNotNullOrWhiteSpace()]
        [string] $newColor
    )

    $oldColor = $host.UI.RawUI.ForegroundColor
    $host.UI.RawUI.ForegroundColor = $newColor

    If ($args)
    {
        Write-Output $args
    }
    Else
    {
        $input | Write-Output
    }

    $host.UI.RawUI.ForegroundColor = $oldColor
}

Function VerifyPathOrExit
{
    Param (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [string]
        $path
    )

    If (-Not (Test-Path -Path $path))
    {
        Write-Error "The path does not exist: $path"
        Exit
    }
    ElseIf (-Not ($path -match "^[a-zA-Z0-9\.\-_:/ ]+$"))
    {
        Write-Error "The path will not work with Git. Avoid backslashes: $path"
        Exit
    }

    Write-Color green "The path is valid: $path"
}

Function Execute-Command
{
    Param (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]
        $command
    )

    Write-Color cyan "Executing: $command"
    Invoke-Expression $command
}

#### Execution ####

Write-Output "Verifying paths..."

$OriginRepoPath = [IO.Path]::TrimEndingDirectorySeparator($OriginRepoPath)
$DestinationRepoPath = [IO.Path]::TrimEndingDirectorySeparator($DestinationRepoPath)
$AssemblyFileOrDirectoryRelativeDirectoryPath = [IO.Path]::TrimEndingDirectorySeparator($AssemblyFileOrDirectoryRelativeDirectoryPath)
$FullAssemblyPath = "$OriginRepoPath/$AssemblyFileOrDirectoryRelativeDirectoryPath/$AssemblyFileOrDirectoryToMigrate"
$RelativeAssemblyPath = "$AssemblyFileOrDirectoryRelativeDirectoryPath/$AssemblyFileOrDirectoryToMigrate"

VerifyPathOrExit $OriginRepoPath
VerifyPathOrExit $DestinationRepoPath
VerifyPathOrExit $FullAssemblyPath

$SplittedBranchName = "SplittedBranch"
$MigratedFolderName = "migrated"
$WorkingBranchName = "WorkingBranch"
$NoHistoryBranchName = "NoHistoryBranch"
$OldRepoRemoteName = "old-repo"
$NewRepoRemoteName = "new-repo"

# Go to origin repo
Execute-Command "Set-Location $OriginRepoPath -Verbose"

# Get the branch just in case
Execute-Command "git fetch $OriginRemote $OriginBranch"

# Switch to the desired branch
Execute-Command "git checkout $OriginBranch"

# Delete the existing branch, just in case
Execute-Command "git branch -D $SplittedBranchName"

# Filter commits relevant to assembly, may take a long time
Execute-Command "git subtree split -P '$RelativeAssemblyPath' -b $SplittedBranchName"

# Move to that branch
Execute-Command "git checkout $SplittedBranchName"

# Remove any files that don't belong
Execute-Command "git reset --hard"

# Put everything under the migrated directory
Execute-Command "New-Item -ItemType Directory -Name '$MigratedFolderName' -Verbose"
Execute-Command "Move-Item -Path '*' -Destination '$MigratedFolderName' -Exclude '$MigratedFolderName' -Verbose"

Write-Color red "PAUSE"
$IN = Read-Host "Please verify that the files that were moved to the '$MigratedFolderName' folder look good, then press any key to continue..."

Execute-Command "git add *"
Execute-Command "git commit -m 'Move everything to the migrated folder'"

# Go back to maintenance-packages
Execute-Command "Set-Location $DestinationRepoPath -Verbose"

# Change to main and update it if needed
Execute-Command "git checkout main"

# Remove the remote to upstream if it already exists, just in case
Execute-Command "git remote remove $NewRepoRemoteName"
Execute-Command "git remote add $NewRepoRemoteName https://github.com/dotnet/maintenance-packages"
Execute-Command "git fetch $NewRepoRemoteName main"
Execute-Command "git checkout main"
Execute-Command "git reset --hard $NewRepoRemoteName/main"

# Delete the existing branch, just in case
Execute-Command "git branch -D $WorkingBranchName"

# Create the final branch
Execute-Command "git checkout -b $WorkingBranchName"

# Delete the existing branch, just in case
Execute-Command "git branch -D $NoHistoryBranchName"

# Create empty branch
Execute-Command "git checkout --orphan $NoHistoryBranchName"

# Remove all files that didn't go away, needs to be completely empty
Execute-Command "git reset --hard"

# Just in case, to avoid bringing in any leftover files
Execute-Command "git clean -fdx"

# Remove the remote to the old repo if it already exists, just in case
Execute-Command "git remote remove $OldRepoRemoteName"
# Add origin repo as a remote
Execute-Command "git remote add $OldRepoRemoteName $OriginRepoPath"

# Bring in the filtered commits from old repo into maintenance-packages
Execute-Command "git pull $OldRepoRemoteName $SplittedBranchName"

Write-Color red "PAUSE"
$IN = Read-Host "Please check the contents of $NoHistoryBranchName before merging it with $WorkingBranchName, then press any key to continue..."

# # Switch to final branch
Execute-Command "git checkout $WorkingBranchName"

# Bring in the changes that were migrated to the empty branch
Execute-Command "git merge --allow-unrelated-histories $NoHistoryBranchName"

Write-Color green "Finished!"