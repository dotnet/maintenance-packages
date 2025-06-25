# Licensed to the .NET Foundation under one or more agreements.
# The .NET Foundation licenses this file to you under the MIT license.

#### Functions ####

Function Write-Color {
    Param (
        [ValidateNotNullOrWhiteSpace()]
        [string] $newColor
    )

    $oldColor = $host.UI.RawUI.ForegroundColor
    $host.UI.RawUI.ForegroundColor = $newColor

    If ($args) {
        Write-Output $args
    }
    Else {
        $input | Write-Output
    }

    $host.UI.RawUI.ForegroundColor = $oldColor
}

Function VerifyPathOrExit {
    Param (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string]
        $path
    )

    If (-Not (Test-Path -Path $path)) {
        Write-Error "The path does not exist: $path"
        Exit
    }
    ElseIf (-Not ($path -match "^[a-zA-Z0-9\.\-_:/ ]+$")) {
        Write-Error "The path will not work with Git. Avoid backslashes: $path"
        Exit
    }

    Write-Color green "The path is valid: $path"
}

Function Execute-Command {
    Param (
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrWhiteSpace()]
        [string]
        $command
    )

    Write-Color cyan "Executing: $command"
    Invoke-Expression $command
}
