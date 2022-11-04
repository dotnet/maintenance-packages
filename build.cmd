@echo off
setlocal

for %%x in (%*) do (
    if "%%x"=="-pack" set _packArg=/p:BuildPackages=true
    if "%%x"=="-test" set _testArg=/p:BuildTests=true
)

powershell -ExecutionPolicy ByPass -NoProfile -command "& """%~dp0eng\common\Build.ps1""" -restore -build %* %_packArg% %_testArg%"
exit /b %ErrorLevel%