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

    If ($NegativePosition -ge 0)
    {
        Write-Error "The position number '$NegativePosition' should have been negative." -ErrorAction Stop
    }

    $components = $ElementValue -Split '\.'

    If (($NegativePosition * -1) -gt $components.Length)
    {
        Write-Error "Version number '$ElementValue' is out of range." -ErrorAction Stop
    }

    $components[$NegativePosition] = [int]$components[$NegativePosition] + 1

    Return [string]::Join('.', $components)
}

Function Get-AssemblyNameLowerCase
{
    Param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]$MSBuildVersionFilePath
    )

    $assemblyName = [System.IO.Path]::GetFileNameWithoutExtension($MSBuildVersionFilePath)

    If ($assemblyName -eq "Versioning")
    {
        $srcFolderPath = Join-Path -Path ([System.IO.Path]::GetDirectoryName($MSBuildVersionFilePath)) -ChildPath "src"
        $actualCsproj = Get-ChildItem -Path $srcFolderPath -Filter "*.*proj" -Recurse | Select-Object -First 1
        $assemblyName = [System.IO.Path]::GetFileNameWithoutExtension($actualCsproj.FullName)
    }

    Return $assemblyName.ToLowerInvariant()
}

Function Save-Project
{
    Param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.Xml.Linq.XDocument]
        $XDoc,
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]$File
    )

    # Ideally, we would've simply used:
    #   $XDoc.Save($file, [System.Xml.Linq.SaveOptions]::DisableFormatting)
    # Unforutnately, it does not work as expected in PowerShell. Unlike in C#, the xml declaration
    # is still getting added at the top even though we specified to disable formatting.
    # Workaround: Use an XmlWriter to serialize into a string the XML without the xml declaration.
    # Also, we need to remove the trailing new line that is added by the XmlWriter.

    $stringWriter = New-Object System.IO.StringWriter
    $xmlWriterSettings = New-Object System.Xml.XmlWriterSettings
    $xmlWriterSettings.OmitXmlDeclaration = $true

    $xmlWriter = [System.Xml.XmlWriter]::Create($stringWriter, $xmlWriterSettings)
    $XDoc.WriteTo($xmlWriter)
    $xmlWriter.Close()

    $output = $stringWriter.ToString()

    If ($output.EndsWith("`r`n"))
    {
        $output = $output.Substring(0, $output.Length - 2)
    }
    ElseIf ($output.EndsWith("`n"))
    {
        $output = $output.Substring(0, $output.Length - 1)
    }

    Set-Content -Path $File -Value $output
}

###############
# Main Script #
###############

$RepoRootPath = Join-Path -Path $PSScriptRoot -ChildPath "../.."

$versioningPropsFilePaths = @((Join-Path $RepoRootPath "src" "System.Runtime.CompilerServices.Unsafe" "Versioning.props")) -as [string[]]
$csprojFilePaths = (Get-ChildItem -Path (Join-Path $RepoRootPath "src\*\src") -Filter "*.csproj" -Recurse | ForEach-Object { $_.FullName }) -as [string[]]

$msBuildVersionFilePaths = [System.Collections.Generic.List[string]]::new()
$msBuildVersionFilePaths.AddRange($versioningPropsFilePaths)
$msBuildVersionFilePaths.AddRange($csprojFilePaths)

foreach ($file in $msBuildVersionFilePaths)
{
    $xdoc = [System.Xml.Linq.XDocument]::Load($file, [System.Xml.Linq.LoadOptions]::PreserveWhitespace)

    $propertyGroup = $xdoc.Root.Elements("PropertyGroup") |
                     Where-Object { $null -ne $_.Element("IsPackable") -And $_.Element("IsPackable").Value -eq "true" } |
                     Select-Object -First 1

    if ($propertyGroup)
    {
        $assemblyNameLowerCase = Get-AssemblyNameLowerCase -MSBuildVersionFilePath $file
        $response = Invoke-RestMethod -Uri "https://api.nuget.org/v3/registration5-semver1/$assemblyNameLowerCase/index.json" -Method Get
        $latestNuGetVersion = $response.items[0].upper

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

                Save-Project -XDoc $xdoc -File $file
            }
        }
    }
}
