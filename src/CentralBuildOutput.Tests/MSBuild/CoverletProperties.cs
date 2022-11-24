namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;

internal sealed class CoverletProperties
{
    /// <summary>
    /// The coverlet output path.
    /// </summary>
    public string CoverletOutput { get; init; } = string.Empty;

    public static CoverletProperties Load(ProjectCreator creator)
    {
        creator.TryGetPropertyValue(nameof(CoverletOutput), out string coverletOutput);

        CoverletProperties result = new()
        {
            CoverletOutput = coverletOutput,
        };

        return result;
    }
}
