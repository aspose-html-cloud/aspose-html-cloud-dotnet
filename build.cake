#tool nuget:?package=xunit.runner.console&version=2.3.1

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
var configuration = Argument("configuration", "Debug");


//////////////////////////////////////////////////////////////////////
// VARIABLES
//////////////////////////////////////////////////////////////////////
var solution = "aspose.html.cloud.sdk";
var testResultDir = System.IO.Path.GetFullPath("./Aspose.HTML.Cloud.SDK.Net.Tests/TestResult/") ;


//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore($"./{solution}", new NuGetRestoreSettings { });

    MSBuild($"./{solution}" , settings => settings
        .SetConfiguration(configuration)
        .UseToolVersion(MSBuildToolVersion.VS2019)
        .WithRestore());
});

Task("Clean")
    .Does(() =>
{

    CleanDirectories("./**/bin");
});

Task("Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var arguments = new ProcessArgumentBuilder()
                .Append("test")
                .Append(@"Aspose.HTML.Cloud.Sdk.Tests.dll")
                .Append($"--ResultsDirectory {testResultDir}")
                .Append($"--logger \"trx;LogFileName=test-result.trx\"")
                ;
                
    Information(arguments.Render());
	 
	var exitcode = StartProcess(@"dotnet", new ProcessSettings
    {
        Arguments = arguments,
        WorkingDirectory = "./Aspose.HTML.Cloud.SDK.Net.Tests/bin/Debug/netcoreapp3.1/"
    });

    if(exitcode != 0)
        throw new Exception("Tests have failed.");

})
.Finally(() =>
{
    XmlTransform("trx-junit.xslt",
        $"{testResultDir}test-result.trx",
        $"junit-test-result.xml",
        new XmlTransformationSettings { OmitXmlDeclaration = true }
        );
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(Argument("target", "Build"));
