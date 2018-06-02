var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");

var projectPath = "./Result/";
var testProjectPattern = "./**/*Tests.csproj";

var tempPath = "./tmp";
var testResultsPath = "./testResults";

Task("Clean")
    .Does(() => {
        EnsureDirectoryExists(artifactsPath);
        CleanDirectories(artifactsPath);
        CleanDirectories(testResultsPath);
        CleanDirectories(tempPath);
        CleanDirectories("./**/bin");
        CleanDirectories("./**/obj");
    });

Task("Build")
    .Does(() => {
        var settings = new DotNetCoreBuildSettings {
            Configuration = configuration,
        };
        DotNetCoreBuild(projectPath, settings);
    });

Task("RunUnitTests")
    .Does(() => {
        var settings = new DotNetCoreTestSettings {
            Logger = "trx",
            Configuration = configuration,
            ResultsDirectory = testResultsPath
        };

        foreach (var projectFile in GetFiles(testProjectPattern))
        {
            DotNetCoreTest(projectFile.FullPath, settings);            
        }
    });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("RunUnitTests");
    
RunTarget(target);