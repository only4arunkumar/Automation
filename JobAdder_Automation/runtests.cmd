@pushd %~dp0

%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "JobAdder_Automation.csproj"

@if ERRORLEVEL 1 goto end

@cd ..\packages\NUnit.ConsoleRunner.*\tools



nunit3-console.exe  "%~dp0\bin\Debug\JobAdder_Automation.dll" 


@popd
