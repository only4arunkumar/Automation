@pushd %~dp0

%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "JobAdder_Automation.csproj"

@if ERRORLEVEL 1 goto end

@cd ..\packages\xunit.runner.console.*\tools



xunit.console "%~dp0\bin\Debug\JobAdder_Automation.dll"  -parallel assemblies -maxthreads 15 -verbose -xml TestResult.xml

:: Can be used when we need to filter and runs testcase belonging to secific category
::nunit3-console.exe  "%~dp0\bin\Debug\JobAdder_Automation.dll" --where:cat==Login

@copy TestResult.xml   "%~dp0\bin\Debug\TestResult.xml"

@popd      

@pushd %~dp0
cd ..\packages\ReportUnit.*\tools
ReportUnit.exe "%~dp0\bin\Debug\TestResult.xml

@popd      
