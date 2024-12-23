namespace Treasure.Build.CentralBuildOutput.Tests;

using Microsoft.Build.Utilities.ProjectCreation;

using Shouldly;

using Treasure.Build.CentralBuildOutput.Tests.Extensions;
using Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Xunit;

public class CentralBuildOutputTests : MSBuildSdkTestBase
{
    public CentralBuildOutputTests(ITestOutputHelper testOutput)
        : base(testOutput)
    {
    }

    /// <summary>
    /// Validates a project with CentralBuildOutput missing a trailing slash:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void CentralBuildOutputMissingTrailingSlash()
    {
        // Arrange
        this.SetupDirectoryBuildProps("$(MSBuildThisFileDirectory.TrimEnd('/').TrimEnd('\\'))");

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.CentralBuildOutputPath.ShouldEndWith(Path.DirectorySeparatorChar.ToString());
    }

    /// <summary>
    /// Validates that the CentralBuildOutputPath must be set.
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void CentralBuildOutputPathMustBeSet()
    {
        // Arrange
        this.SetupDirectoryBuildProps(centralBuildOutputPath: string.Empty);

        // Act
        ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj")
            .Save()
            .TryRestore(out bool restoreResult, out BuildOutput buildOutput);

        // Assert
        restoreResult.ShouldBeFalse();
        buildOutput.Errors.Count.ShouldBe(1);
        string buildError = buildOutput.Errors.ElementAt(0);
        buildError.ShouldBeEquivalentTo("CentralBuildOutputPath must be set before importing the CentralBuildOutput project SDK.");

        buildOutput.Dispose();
    }

    /// <summary>
    /// Validates a project build with CentralBuildOutputConfigPlatLast set to `true`:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void ConfigPlatLast()
    {
        // Arrange
        this.SetupDirectoryBuildProps(projectFunction:
            p => p.Property("CentralBuildOutputConfigPlatLast", "true"));

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/src/MyClassLibrary/Debug/AnyCPU/AppPackages/");
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseNuGetDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/src/MyClassLibrary/Debug/AnyCPU/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/src/MyClassLibrary/Debug/AnyCPU/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("__");
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.EnableCentralBuildOutput.ShouldBeEmpty();
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("src/MyClassLibrary/Debug/AnyCPU/");
        cboProps.RelativeProjectPath.ShouldBe("src/MyClassLibrary/");

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/src/MyClassLibrary/Debug/AnyCPU/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/src/MyClassLibrary/Debug/AnyCPU/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/src/MyClassLibrary/Debug/AnyCPU/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        File.Exists("__output/src/MyClassLibrary/Debug/AnyCPU/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project in a project folder:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void DefaultConfiguration()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndPublishProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/AppPackages/");
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseNuGetDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyClassLibrary/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("__");
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.EnableCentralBuildOutput.ShouldBeEmpty();
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/AnyCPU/src/MyClassLibrary/");
        cboProps.RelativeProjectPath.ShouldBe("src/MyClassLibrary/");

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyClassLibrary/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        File.Exists("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        File.Exists("__publish/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project in a project folder:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void DefaultConfigurationWithMultiTargeting()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(
                path: "src/MyClassLibrary/MyClassLibrary.csproj",
                targetFrameworks: ["netstandard2.0", "netstandard2.1"]));

        // Assert
        Properties properties = Properties.Load(project);

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.OutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/");

        File.Exists("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        File.Exists("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.1/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Debug/netstandard2.1").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project built with CentralBuildOutputNoDefaultPlatform set to `true`:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void NoDefaultPlatform()
    {
        // Arrange
        this.SetupDirectoryBuildProps(
            projectFunction: p => p.Property("CentralBuildOutputNoDefaultPlatform", "true"));

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/src/MyClassLibrary/AppPackages/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/src/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/src/MyClassLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/src/MyClassLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/src/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/src/MyClassLibrary/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/src/MyClassLibrary/");

        File.Exists("__output/Debug/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates an x64 project built with CentralBuildOutputNoPlatform set to `true`:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void NoPlatform()
    {
        // Arrange
        this.SetupDirectoryBuildProps(projectFunction:
            p => p.Property("CentralBuildOutputNoPlatform", "true"));

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj", globalProperties: new Dictionary<string, string>()
            {
                ["Platform"] = "x64"
            }));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/src/MyClassLibrary/AppPackages/");
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseNuGetDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/src/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/src/MyClassLibrary/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("__");
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.EnableCentralBuildOutput.ShouldBeEmpty();
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/src/MyClassLibrary/");
        cboProps.RelativeProjectPath.ShouldBe("src/MyClassLibrary/");

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/src/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/src/MyClassLibrary/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/src/MyClassLibrary/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        File.Exists("__output/Debug/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/x64/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a NoTargets project that a .proj project file:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyCMakeLibrary/MyCMakeLibrary.proj
    /// </summary>
    [Fact]
    public void NoTargetsProjProject()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates.SdkCsproj(
            path: "src/MyCMakeLibrary/MyCMakeLibrary.proj",
            sdk: "Microsoft.Build.NoTargets/3.7.56"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyCMakeLibrary/AppPackages/");
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseNuGetDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyCMakeLibrary/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyCMakeLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyCMakeLibrary/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyCMakeLibrary/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("__");
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.EnableCentralBuildOutput.ShouldBeEmpty();
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyCMakeLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/AnyCPU/src/MyCMakeLibrary/");
        cboProps.RelativeProjectPath.ShouldBe("src/MyCMakeLibrary/");

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyCMakeLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyCMakeLibrary/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyCMakeLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/AnyCPU/src/MyCMakeLibrary/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyCMakeLibrary/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyCMakeLibrary/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyCMakeLibrary/");

        Directory.Exists("__intermediate/src/MyCMakeLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project in a project folder, but with CentralBuildOutputFolderPrefix set to "_prefix_":
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void PrefixOverride()
    {
        // Arrange
        this.SetupDirectoryBuildProps(
            projectFunction: p => p.Property("CentralBuildOutputFolderPrefix", "_prefix_"));

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("_prefix_intermediate/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("_prefix_output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("_prefix_packages/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("_prefix_publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("_prefix_test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("_prefix_");

        File.Exists("_prefix_output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("_prefix_intermediate/src/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project in the root folder:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void ProjectInRoot()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: Path.Combine(this.ProjectOutput, "MyClassLibrary.csproj")));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/AppPackages/");
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseNuGetDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("__");
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.EnableCentralBuildOutput.ShouldBeEmpty();
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/AnyCPU/");
        cboProps.RelativeProjectPath.ShouldBeEmpty();

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/AnyCPU/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
    }

    /// <summary>
    /// Validates a project in a project folder, but with CentralBuildOutputRelativeToPath set to remove the src folder:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void RelativePathOverride()
    {
        // Arrange
        this.SetupDirectoryBuildProps(
            projectFunction: p => p.Property("CentralBuildOutputRelativeToPath", Path.Combine(this.ProjectOutput, "src")));

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/MyClassLibrary/AppPackages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/MyClassLibrary/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/MyClassLibrary/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/MyClassLibrary/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/MyClassLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/AnyCPU/MyClassLibrary/");
        cboProps.RelativeProjectPath.ShouldBe("MyClassLibrary/");

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/MyClassLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/MyClassLibrary/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/AnyCPU/MyClassLibrary/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/MyClassLibrary/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/MyClassLibrary/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/MyClassLibrary/");

        File.Exists("__output/Debug/AnyCPU/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a traversal project:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     dirs.proj
    /// </summary>
    [Fact]
    public void TraversalProject()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Create(
            path: "dirs.proj",
            sdk: "Microsoft.Build.Traversal/3.1.6"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.RelativeProjectPath.ShouldBe("dirs/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/dirs/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/AnyCPU/dirs/net45/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/dirs/");

        Directory.Exists("obj").ShouldBeFalse();
        Directory.Exists("__intermediate/dirs").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project built for a Debug build configuration:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void WithBuildConfigurationDebug()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj", globalProperties: new Dictionary<string, string>()
            {
                ["Configuration"] = "Debug"
            }));

        // Assert
        Properties properties = Properties.Load(project);

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.Configuration.ShouldBe("Debug");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/");

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/AppPackages/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyClassLibrary/");
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/AnyCPU/src/MyClassLibrary/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyClassLibrary/");

        File.Exists("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project built for a Release build configuration:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void WithBuildConfigurationRelease()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj", globalProperties: new Dictionary<string, string>()
            {
                ["Configuration"] = "Release"
            }));

        // Assert
        Properties properties = Properties.Load(project);

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.Configuration.ShouldBe("Release");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Release/AnyCPU/src/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Release/AnyCPU/src/MyClassLibrary/netstandard2.0/");

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Release/AnyCPU/src/MyClassLibrary/AppPackages/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Release/AnyCPU/src/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Release/AnyCPU/src/MyClassLibrary/");
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Release/");
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Release/");
        cboProps.ProjectOutputPath.ShouldBe("Release/AnyCPU/src/MyClassLibrary/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Release/AnyCPU/src/MyClassLibrary/");

        File.Exists("__output/Release/AnyCPU/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Release/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project built specifying a build Platform of x64:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void WithPlatformX64()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndBuildProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj", globalProperties: new Dictionary<string, string>()
            {
                ["Platform"] = "x64"
            }));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/x64/src/MyClassLibrary/AppPackages/");
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseNuGetDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/x64/src/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/x64/src/MyClassLibrary/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("__");
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.EnableCentralBuildOutput.ShouldBeEmpty();
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/x64/src/MyClassLibrary/");
        cboProps.RelativeProjectPath.ShouldBe("src/MyClassLibrary/");

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/x64/src/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/x64/src/MyClassLibrary/netstandard2.0/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/x64/src/MyClassLibrary/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        File.Exists("__output/Debug/x64/src/MyClassLibrary/netstandard2.0/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/x64/Debug/netstandard2.0").ShouldBeTrue();
    }

    /// <summary>
    /// Validates a project which specified a Runtime Identifier:
    ///     Directory.Build.props
    ///     Directory.Build.targets
    ///     nuget.config
    ///     src/MyClassLibrary/MyClassLibrary.csproj
    /// </summary>
    [Fact]
    public void WithRuntimeIdentifier()
    {
        // Arrange
        this.SetupDirectoryBuildProps();

        // Act
        ProjectCreator project = this.CreateSaveAndPublishProject(() => ProjectCreator.Templates
            .SdkCsproj(path: "src/MyClassLibrary/MyClassLibrary.csproj", globalProperties: new Dictionary<string, string>
            {
                ["RuntimeIdentifier"] = "win10-x64"
            })
            .Property("RuntimeIdentifiers", "win10-x64;linux-x64"));

        // Assert
        Properties properties = Properties.Load(project);

        CentralBuildOutputProperties cboProps = properties.CentralBuildOutput;
        cboProps.AppxPackageDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/AppPackages/");
        cboProps.BaseIntDir.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/");
        cboProps.BaseNuGetDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/");
        cboProps.BaseOutDir.MakeRelative(this.ProjectOutput).ShouldBe("__output/");
        cboProps.BasePackagesDir.MakeRelative(this.ProjectOutput).ShouldBe("__packages/");
        cboProps.BaseProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.BaseProjectOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/");
        cboProps.BaseProjectPublishOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyClassLibrary/win10-x64/");
        cboProps.BaseProjectTestResultsOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");
        cboProps.BasePublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/");
        cboProps.BaseTestResultsDir.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/");
        cboProps.CentralBuildOutputFolderPrefix.ShouldBe("__");
        cboProps.CentralBuildOutputPath.ShouldBe(this.ProjectOutput);
        cboProps.DefaultArtifactsSource.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.EnableCentralBuildOutput.ShouldBeEmpty();
        cboProps.PackageOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__packages/NuGet/Debug/");
        cboProps.ProjectIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        cboProps.ProjectOutputPath.ShouldBe("Debug/AnyCPU/src/MyClassLibrary/");
        cboProps.RelativeProjectPath.ShouldBe("src/MyClassLibrary/");

        CoverletProperties coverletProps = properties.Coverlet;
        coverletProps.CoverletOutput.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        CommonMSBuildProperties msbuildProps = properties.MSBuildCommon;
        msbuildProps.BaseIntermediateOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");
        msbuildProps.BaseOutputPath.MakeRelative(this.ProjectOutput).ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/");
        msbuildProps.OutputPathNormalized.MakeRelative(this.ProjectOutput.OutputPathNormalized)
            .ShouldBe("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/win10-x64/");

        CommonMSBuildMacros msbuildMacros = properties.MSBuildMacros;
        msbuildMacros.PublishDir.MakeRelative(this.ProjectOutput).ShouldBe("__publish/Debug/AnyCPU/src/MyClassLibrary/win10-x64/");

        MSBuildOtherProperties msBuildOtherProps = properties.MSBuildOther;
        msBuildOtherProps.MSBuildProjectExtensionPath.MakeRelative(this.ProjectOutput).ShouldBe("__intermediate/src/MyClassLibrary/");

        VSTestProperties vsTestProps = properties.VSTest;
        vsTestProps.VSTestResultsDirectory.MakeRelative(this.ProjectOutput).ShouldBe("__test-results/src/MyClassLibrary/");

        File.Exists("__output/Debug/AnyCPU/src/MyClassLibrary/netstandard2.0/win10-x64/MyClassLibrary.dll").ShouldBeTrue();
        Directory.Exists("__intermediate/src/MyClassLibrary/Debug/netstandard2.0").ShouldBeTrue();
    }

    private ProjectCreator CreateSaveAndBuildProject(Func<ProjectCreator> projectFunction)
    {
        ProjectCreator projectCreator = projectFunction()
            .Save()
            .TryBuild(restore: true, out bool buildResult, out BuildOutput buildOutput);

        try
        {
            this.ValidateBuildOutput(buildResult, buildOutput);
        }
        finally
        {
            buildOutput.Dispose();
        }

        return projectCreator;
    }

    private ProjectCreator CreateSaveAndPublishProject(Func<ProjectCreator> projectFunction)
    {
        ProjectCreator projectCreator = projectFunction()
            .Save()
            .TryBuild(restore: true, target: "publish", out bool buildResult, out BuildOutput buildOutput);

        try
        {
            this.ValidateBuildOutput(buildResult, buildOutput);
        }
        finally
        {
            buildOutput.Dispose();
        }

        return projectCreator;
    }

    private ProjectCreator SetupDirectoryBuildProps(
        string centralBuildOutputPath = "$(MSBuildThisFileDirectory)",
        Action<ProjectCreator>? projectFunction = null)
        => ProjectCreator.Templates.DirectoryBuildProps(
            this.ProjectOutput,
            ThisAssemblyDirectory,
            centralBuildOutputPath,
            projectFunction);

    private void ValidateBuildOutput(bool buildResult, BuildOutput buildOutput)
    {
        // Fail on a failed build, any warnings, or any errors (presumably also failed build).
        if (!buildResult || buildOutput.Warnings.Count > 0 || buildOutput.Errors.Count > 0)
        {
            foreach (string warning in buildOutput.Warnings)
            {
                this.TestOutput.WriteLine("Warning: " + warning);
            }

            foreach (string error in buildOutput.Errors)
            {
                this.TestOutput.WriteLine("Error: " + error);
            }

            buildResult.ShouldBeTrue();
            buildOutput.Warnings.ShouldBeEmpty();
            buildOutput.Errors.ShouldBeEmpty();
        }
    }
}
