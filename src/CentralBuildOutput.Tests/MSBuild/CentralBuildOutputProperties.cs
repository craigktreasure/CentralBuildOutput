namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;

internal class CentralBuildOutputProperties
{
    /// <summary>
    /// The appx package directory.
    /// </summary>
    public string AppxPackageDir { get; init; } = string.Empty;

    /// <summary>
    /// The base intermediate output directory.
    /// </summary>
    public string BaseIntDir { get; init; } = string.Empty;

    /// <summary>
    /// The base NuGet directory.
    /// </summary>
    public string BaseNuGetDir { get; init; } = string.Empty;

    /// <summary>
    /// The base output directory.
    /// </summary>
    public string BaseOutDir { get; init; } = string.Empty;

    /// <summary>
    /// The base packages dir.
    /// </summary>
    public string BasePackagesDir { get; init; } = string.Empty;

    /// <summary>
    /// The base project intermediate output path.
    /// </summary>
    public string BaseProjectIntermediateOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The base project output path.
    /// </summary>
    public string BaseProjectOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The base project publish output path.
    /// </summary>
    public string BaseProjectPublishOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The base project test results output path
    /// </summary>
    public string BaseProjectTestResultsOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The base publish directory.
    /// </summary>
    public string BasePublishDir { get; init; } = string.Empty;

    /// <summary>
    /// The base test results directory.
    /// </summary>
    public string BaseTestResultsDir { get; init; } = string.Empty;

    /// <summary>
    /// The output folder prefix to be used on output folders.
    /// This can be overridden.
    /// </summary>
    public string CentralBuildOutputFolderPrefix { get; init; } = string.Empty;

    /// <summary>
    /// The output path.
    /// Required to be set when <see cref="EnableCentralBuildOutput"/> is not 'false'.
    /// </summary>
    public string CentralBuildOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The default artifacts source for the Microsoft.Build.Artifacts package.
    /// </summary>
    public string DefaultArtifactsSource { get; init; } = string.Empty;

    /// <summary>
    /// Indicates whether CentralBuildOutput is enabled or not.
    /// </summary>
    public string EnableCentralBuildOutput { get; init; } = string.Empty;

    /// <summary>
    /// The package output path.
    /// </summary>
    public string PackageOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The project intermediate output path.
    /// For csproj.
    /// </summary>
    public string ProjectIntermediateOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The project specific intermediate and output paths.
    /// </summary>
    public string ProjectOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The relative project path.
    /// This can be overridden.
    /// </summary>
    public string RelativeProjectPath { get; init; } = string.Empty;

    public static CentralBuildOutputProperties Load(ProjectCreator creator)
    {
        creator.TryGetPropertyValue(nameof(AppxPackageDir), out string appxPackageDir);
        creator.TryGetPropertyValue(nameof(BaseIntDir), out string baseIntDir);
        creator.TryGetPropertyValue(nameof(BaseNuGetDir), out string baseNuGetDir);
        creator.TryGetPropertyValue(nameof(BaseOutDir), out string baseOutDir);
        creator.TryGetPropertyValue(nameof(BasePackagesDir), out string basePackagesDir);
        creator.TryGetPropertyValue(nameof(BaseProjectIntermediateOutputPath), out string baseProjectIntermediateOutputPath);
        creator.TryGetPropertyValue(nameof(BaseProjectOutputPath), out string baseProjectOutputPath);
        creator.TryGetPropertyValue(nameof(BaseProjectPublishOutputPath), out string baseProjectPublishOutputPath);
        creator.TryGetPropertyValue(nameof(BaseProjectTestResultsOutputPath), out string baseProjectTestResultsOutputPath);
        creator.TryGetPropertyValue(nameof(BasePublishDir), out string basePublishDir);
        creator.TryGetPropertyValue(nameof(BaseTestResultsDir), out string baseTestResultsDir);
        creator.TryGetPropertyValue(nameof(CentralBuildOutputFolderPrefix), out string centralBuildOutputFolderPrefix);
        creator.TryGetPropertyValue(nameof(CentralBuildOutputPath), out string centralBuildOutputPath);
        creator.TryGetPropertyValue(nameof(DefaultArtifactsSource), out string defaultArtifactsSource);
        creator.TryGetPropertyValue(nameof(EnableCentralBuildOutput), out string enableCentralBuildOutput);
        creator.TryGetPropertyValue(nameof(PackageOutputPath), out string packageOutputPath);
        creator.TryGetPropertyValue(nameof(ProjectIntermediateOutputPath), out string projectIntermediateOutputPath);
        creator.TryGetPropertyValue(nameof(ProjectOutputPath), out string projectOutputPath);
        creator.TryGetPropertyValue(nameof(RelativeProjectPath), out string relativeProjectPath);

        CentralBuildOutputProperties result = new()
        {
            AppxPackageDir = appxPackageDir,
            BaseIntDir = baseIntDir,
            BaseNuGetDir = baseNuGetDir,
            BaseOutDir = baseOutDir,
            BasePackagesDir = basePackagesDir,
            BaseProjectIntermediateOutputPath = baseProjectIntermediateOutputPath,
            BaseProjectOutputPath = baseProjectOutputPath,
            BaseProjectPublishOutputPath = baseProjectPublishOutputPath,
            BaseProjectTestResultsOutputPath = baseProjectTestResultsOutputPath,
            BasePublishDir = basePublishDir,
            BaseTestResultsDir = baseTestResultsDir,
            CentralBuildOutputFolderPrefix = centralBuildOutputFolderPrefix,
            CentralBuildOutputPath = centralBuildOutputPath,
            DefaultArtifactsSource = defaultArtifactsSource,
            EnableCentralBuildOutput = enableCentralBuildOutput,
            PackageOutputPath = packageOutputPath,
            ProjectIntermediateOutputPath = projectIntermediateOutputPath,
            ProjectOutputPath = projectOutputPath,
            RelativeProjectPath = relativeProjectPath,
        };

        return result;
    }
}
