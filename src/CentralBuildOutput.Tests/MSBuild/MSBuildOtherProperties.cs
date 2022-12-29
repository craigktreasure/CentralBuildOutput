namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;

internal sealed class MSBuildOtherProperties
{
    /// <summary>
    /// Gets or sets the ms build project extension path.
    /// Undocumented.
    /// </summary>
    public string MSBuildProjectExtensionPath { get; init; } = string.Empty;

    /// <summary>
    /// By default, Microsoft.Common.props imports $(MSBuildProjectExtensionsPath)$(MSBuildProjectFile).*.props and Microsoft.Common.targets imports $(MSBuildProjectExtensionsPath)$(MSBuildProjectFile).*.targets. The default value of MSBuildProjectExtensionsPath is $(BaseIntermediateOutputPath), obj/. NuGet uses this mechanism to refer to build logic delivered with packages; that is, at restore time, it creates {project}.nuget.g.props files that refer to the package contents.
    /// You can disable this extensibility mechanism by setting the property ImportProjectExtensionProps to false in a Directory.Build.props or before importing Microsoft.Common.props.
    /// https://docs.microsoft.com/visualstudio/msbuild/customize-your-build#msbuildprojectextensionspath
    /// </summary>
    public string MSBuildProjectExtensionsPath { get; init; } = string.Empty;

    public static MSBuildOtherProperties Load(ProjectCreator creator)
    {
        creator.TryGetPropertyValue(nameof(MSBuildProjectExtensionPath), out string msBuildProjectExtensionPath);
        creator.TryGetPropertyValue(nameof(MSBuildProjectExtensionsPath), out string msBuildProjectExtensionsPath);

        MSBuildOtherProperties result = new()
        {
            MSBuildProjectExtensionPath = msBuildProjectExtensionPath,
            MSBuildProjectExtensionsPath = msBuildProjectExtensionsPath,
        };

        return result;
    }
}
