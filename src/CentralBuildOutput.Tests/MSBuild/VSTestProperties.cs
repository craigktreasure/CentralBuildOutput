namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;

/// <summary>
/// Visual Studio Test properties.
/// https://github.com/microsoft/vstest/blob/main/src/Microsoft.TestPlatform.Build/Microsoft.TestPlatform.targets
/// </summary>
internal sealed class VSTestProperties
{
    /// <summary>
    /// The VSTest results directory.
    /// </summary>
    public string VSTestResultsDirectory { get; init; } = string.Empty;

    /// <summary>
    /// The VSTest trace data collector directory path.
    /// </summary>
    public string VSTestTraceDataCollectorDirectoryPath { get; init; } = string.Empty;

    public static VSTestProperties Load(ProjectCreator creator)
    {
        creator.TryGetPropertyValue(nameof(VSTestResultsDirectory), out string vsTestResultsDirectory);
        creator.TryGetPropertyValue(nameof(VSTestTraceDataCollectorDirectoryPath), out string vsTestTraceDataCollectorDirectoryPath);

        VSTestProperties result = new()
        {
            VSTestResultsDirectory = vsTestResultsDirectory,
            VSTestTraceDataCollectorDirectoryPath = vsTestTraceDataCollectorDirectoryPath,
        };

        return result;
    }
}
