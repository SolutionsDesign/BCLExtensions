@echo off
pushd.
call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsMsBuildCmd.bat"
popd
echo Building Release build....
pushd src
MSBuild BCLExtensions.csproj /v:m /p:Configuration=Release
echo Done!
echo Creating NuGetPackage
nuget.exe pack SD.Tools.BCLExtensions.nuspec -NoPackageAnalysis -NonInteractive
echo Done!
popd