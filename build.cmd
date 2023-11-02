@echo off
setlocal

set _args=%*
if "%~1"=="-?" set _args=-help
if "%~1"=="/?" set _args=-help

powershell -ExecutionPolicy ByPass -NoProfile -Command "& '%~dp0eng\common\build.ps1' -restore -build" %_args%
exit /b %ERRORLEVEL%