# Licensed to the .NET Foundation under one or more agreements.
# The .NET Foundation licenses this file to you under the MIT license.

. $PSScriptRoot/Shared.ps1

Function Get-LatestNuGetVersion
{
    Param (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]$PackageId
    )

    $packageIdLower = $PackageId.ToLowerInvariant()
    $url = "https://api.nuget.org/v3/flatcontainer/$packageIdLower/index.json"
    $response = Invoke-RestMethod -Uri $url -Method Get
    return $response.versions[-1]
}

Function Get-NewVersion
{
    Param (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]$number,
        [Parameter(Mandatory = $true)]
        [int]$negativePosition
    )

    # Check if the version number is valid
    if ($negativePosition -ge 0)
    {
        Write-Error "The position must be negative." -ErrorAction Stop
    }
    $components = $number -Split '\.'
    if (($negativePosition * -1) -gt $components.Length)
    {
        Write-Error "Version number is out of range." -ErrorAction Stop
    }

    # Split this version number into its components then rewrite it by incrementing the component from right to left
    $components[$negativePosition] = [int]$components[$negativePosition] + 1
    return [string]::Join('.', $components)
}

Function Update-CsProj
{
    param (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]
        $CsprojPath
    )

    Add-Type -AssemblyName System.Xml.Linq
    $csproj = [System.Xml.Linq.XDocument]::Load($CsprojPath)

    $propertyGroup = $csproj.Root.Elements("PropertyGroup") |
                     Where-Object { $null -ne $_.Element("IsPackable") -And $_.Element("IsPackable").Value -eq "true" } |
                     Select-Object -First 1

    $propertyGroup.Elements("IsPackable")[0].Value = "false"

    foreach ($versionPrefix in $propertyGroup.Elements("VersionPrefix"))
    {
        $versionPrefix.Value = Get-NewVersion $versionPrefix.Value -negativePosition -1
    }

    foreach ($assemblyVersion in $propertyGroup.Elements("AssemblyVersion"))
    {
        $assemblyVersion.Value = Get-NewVersion $assemblyVersion.Value -negativePosition -2
    }

    foreach ($packageValidationBaselineVersion in $propertyGroup.Elements("PackageValidationBaselineVersion"))
    {
        $packageValidationBaselineVersion.Value = Get-NewVersion $packageValidationBaselineVersion.Value -negativePosition -1
    }


    $csproj.Save($CsprojPath)
}

$RepoRootPath = Join-Path -Path $PSScriptRoot -ChildPath "../.."
$RepoEngPath = Join-Path -Path $RepoRootPath -ChildPath "eng"

$VersionUpdaterPath = Join-Path -Path $RepoEngPath -ChildPath "VersionUpdater.csproj"

$msBuildOutput = Invoke-Expression "dotnet msbuild /nologo /t:CollectSourceProjects $VersionUpdaterPath" 2>$1

foreach ($projectOutput in $msBuildOutput)
{
    $pairs = $projectOutput -Split ','

    $Project = $null
    $IsPackable = $null
    $VersionPrefix = $null
    $AssemblyVersion = $null
    $PackageValidationBaselineVersion = $null

    foreach ($pair in $pairs)
    {
        $key, $value = $pair -Split '=', 2
        $key = $key.Trim()
        $value = $value.Trim("'")

        switch ($key)
        {
            "Project" { $Project = $value }
            "IsPackable" { $IsPackable = $value }
            "VersionPrefix" { $VersionPrefix = $value }
            "AssemblyVersion" { $AssemblyVersion = $value }
            "PackageValidationBaselineVersion" { $PackageValidationBaselineVersion = $value }
        }
    }

    If ($IsPackable -eq "true")
    {
        Write-Host "Project: $Project"
        Write-Host "  - VersionPrefix: $VersionPrefix"
        Write-Host "  - AssemblyVersion: $AssemblyVersion"
        Write-Host "  - PackageValidationBaselineVersion: $PackageValidationBaselineVersion"

        $assemblyName  = [System.IO.Path]::GetFileNameWithoutExtension($Project)

        $latest = Get-LatestNuGetVersion $assemblyName

        if ($latest -eq $VersionPrefix)
        {
            Write-Host "$assemblyName has been published to nuget so the repo versions need to be bumped."
            Update-CsProj $Project
        }
    }
}
