namespace Treasure.Build.CentralBuildOutput.Tests;

using Microsoft.Build.Utilities.ProjectCreation;

internal static class ProjectCreatorTemplatesExtensions
{
    public static ProjectCreator DirectoryBuildProps(
        this ProjectCreatorTemplates _,
        string testRootPath,
        string assemblyPath,
        string centralBuidOutputPath = "$(MSBuildThisFileDirectory)",
        Action<ProjectCreator>? projectFunction = null)
    {
        ProjectCreator result = ProjectCreator.Create()
            .Property("CentralBuildOutputPath", centralBuidOutputPath)
            .Property("Configuration", "Debug", setIfEmpty: true)
            .Property("Platform", "AnyCPU", setIfEmpty: true);

        if (projectFunction is not null)
        {
            projectFunction(result);
        }

        result.Import(Path.Combine(assemblyPath, @"Sdk\Sdk.props"))
            .Import(Path.Combine(assemblyPath, @"Sdk\Sdk.targets"))
            .Save(Path.Combine(testRootPath, "Directory.Build.props"));

        return result;
    }
}
