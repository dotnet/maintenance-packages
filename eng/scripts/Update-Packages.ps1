# Licensed to the .NET Foundation under one or more agreements.
# The .NET Foundation licenses this file to you under the MIT license.

###########
# Imports #
###########

. $PSScriptRoot/Shared.ps1

#############
# Functions #
#############

Function Get-NewVersion
{
    Param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]$ElementValue,
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [int]$NegativePosition
    )

    if ($NegativePosition -ge 0)
    {
        Write-Error "The position number '$NegativePosition' should have been negative." -ErrorAction Stop
    }

    $components = $ElementValue -Split '\.'

    if (($NegativePosition * -1) -gt $components.Length)
    {
        Write-Error "Version number '$ElementValue' is out of range." -ErrorAction Stop
    }

    $components[$NegativePosition] = [int]$components[$NegativePosition] + 1

    Return [string]::Join('.', $components)
}

###############
# Main Script #
###############

$RepoRootPath = Join-Path -Path $PSScriptRoot -ChildPath "../.."
$csprojFiles = Get-ChildItem -Path (Join-Path $RepoRootPath "src\*\src") -Filter "*.csproj" -Recurse

foreach ($csprojFile in $csprojFiles)
{
    $xdoc = [System.Xml.Linq.XDocument]::Load($csprojFile)

    $propertyGroup = $xdoc.Root.Elements("PropertyGroup") |
                     Where-Object { $null -ne $_.Element("IsPackable") -And $_.Element("IsPackable").Value -eq "true" } |
                     Select-Object -First 1

    if ($propertyGroup)
    {
        $assemblyNameLowerCase = [System.IO.Path]::GetFileNameWithoutExtension($csprojFile).ToLowerInvariant()
        $response = Invoke-RestMethod -Uri "https://api.nuget.org/v3/flatcontainer/$assemblyNameLowerCase/index.json" -Method Get
        $latestNuGetVersion = $response.versions[-1]

        $conditionedVersionPrefix = $propertyGroup.Elements("VersionPrefix") |
                         Where-Object { $_.Attribute("Condition") -and $_.Attribute("Condition").Value -eq "`'`$(IsPackable)`' == 'true'" } |
                         Select-Object -First 1

        if ($null -ne $conditionedVersionPrefix -and $conditionedVersionPrefix.GetType() -eq [System.Xml.Linq.XElement])
        {
            if ($latestNuGetVersion -eq $conditionedVersionPrefix.Value)
            {
                foreach ($isPackableElement in $propertyGroup.Elements("IsPackable"))
                {
                    $isPackableElement.Value = "false"
                }
                foreach ($versionPrefixElement in $propertyGroup.Elements("VersionPrefix"))
                {
                    $versionPrefixElement.Value = Get-NewVersion -ElementValue $versionPrefixElement.Value -NegativePosition -1
                }
                foreach ($assemblyVersionElement in $propertyGroup.Elements("AssemblyVersion"))
                {
                    $assemblyVersionElement.Value = Get-NewVersion -ElementValue $assemblyVersionElement.Value -NegativePosition -2
                }
                foreach ($packageValidationBaselineVersionElement in $propertyGroup.Elements("PackageValidationBaselineVersion"))
                {
                    $packageValidationBaselineVersionElement.Value = Get-NewVersion -ElementValue $packageValidationBaselineVersionElement.Value -NegativePosition -1
                }

                $xdoc.Save($csprojFile)
            }
        }
    }
}
