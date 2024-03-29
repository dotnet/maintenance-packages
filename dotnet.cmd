@echo off

powershell -ExecutionPolicy ByPass -NoProfile -Command "& { . '%~dp0eng\common\tools.ps1'; InitializeDotNetCli $true $true }"

if NOT [%ERRORLEVEL%] == [0] (
  echo Failed to install or invoke dotnet... 1>&2
  exit /b %ERRORLEVEL%
)

set /p dotnetPath=<%~dp0artifacts\toolset\sdk.txt

:: Clear the 'Platform' env variable for this session, as it's a per-project setting within the build, and
:: misleading value (such as 'MCD' in HP PCs) may lead to build breakage (issue: #69).
set Platform=

:: Disable first run since we want to control all package sources
set DOTNET_NOLOGO=1

call "%dotnetPath%\dotnet.exe" %*
