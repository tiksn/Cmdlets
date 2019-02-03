#addin "Cake.Http"
#addin "Cake.Json"
#addin "Cake.ExtendedNuGet"
#addin nuget:?package=Newtonsoft.Json&version=9.0.1
#addin nuget:?package=NuGet.Core&version=2.14.0
#addin nuget:?package=NuGet.Versioning&version=4.6.2
#tool "nuget:?package=xunit.runner.console"
#addin nuget:?package=Cake.Git
#addin nuget:?package=TIKSN-Cake&loaddependencies=true

var target = Argument("target", "PostBuild");
var solution = "Cmdlets.sln";

using System;
using System.Linq;
using NuGet.Versioning;
DirectoryPath buildArtifactsDir;

Setup(context =>
{
    SetTrashParentDirectory(GitFindRootFromPath("."));
});

Teardown(context =>
{
    // Executed AFTER the last task.
});

Task("PostBuild")
  .IsDependentOn("Build")
  .Does(() =>
{
  CopyFile("TIKSN-PowerShell-Cmdlets.psd1", buildArtifactsDir.CombineWithFilePath("TIKSN-PowerShell-Cmdlets.psd1"));
});

Task("Build")
  .IsDependentOn("PreBuild")
  .Does(() =>
{
  buildArtifactsDir = CreateTrashSubDirectory("artifacts");

  MSBuild(solution, configurator =>
    configurator.SetConfiguration("Release")
        .SetVerbosity(Verbosity.Minimal)
        .UseToolVersion(MSBuildToolVersion.VS2017)
        .SetMSBuildPlatform(MSBuildPlatform.x64)
        .SetPlatformTarget(PlatformTarget.MSIL)
        .WithProperty("OutDir", buildArtifactsDir.FullPath)
        //.WithTarget("Rebuild")
        );
});

Task("PreBuild")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .Does(() =>
{

});

Task("Restore")
  .Description("Restores packages.")
  .Does(() =>
{
  NuGetRestore(solution);
});

Task("Clean")
  .Description("Cleans all directories that are used during the build process.")
  .Does(() =>
{
  CleanDirectories("**/bin/**");
  CleanDirectories("**/obj/**");
});

RunTarget(target);