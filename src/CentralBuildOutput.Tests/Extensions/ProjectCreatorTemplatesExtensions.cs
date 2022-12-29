namespace Treasure.Build.CentralBuildOutput.Tests.Extensions;

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
            .Property("CentralBuildOutputPath", centralBuidOutputPath);

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
