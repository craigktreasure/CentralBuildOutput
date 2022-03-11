namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;

/// <summary>
/// Common macros for MSBuild commands and properties.
/// https://docs.microsoft.com/cpp/build/reference/common-macros-for-build-commands-and-properties
/// </summary>
internal class CommonMSBuildMacros
{
    /// <summary>
    /// The name of the current project configuration, for example, "Debug".
    /// </summary>
    public string Configuration { get; init; } = string.Empty;

    /// <summary>
    /// The installation directory of Visual Studio (defined as drive + path); includes the trailing backslash '\'.
    /// </summary>
    public string DevEnvDir { get; init; } = string.Empty;

    /// <summary>
    /// The directory into which the .NET Framework was installed.
    /// </summary>
    public string FrameworkDir { get; init; } = string.Empty;

    /// <summary>
    /// The directory into which you installed the .NET Framework. The .NET Framework could have been installed as part of Visual Studio or separately.
    /// </summary>
    public string FrameworkSDKDir { get; init; } = string.Empty;

    /// <summary>
    /// The version of the .NET Framework used by Visual Studio. Combined with $(FrameworkDir), the full path to the version of the .NET Framework use by Visual Studio.
    /// </summary>
    public string FrameworkVersion { get; init; } = string.Empty;

    /// <summary>
    /// The path to the fxcop.cmd file. The fxcop.cmd file is not installed with all Visual Studio editions.
    /// </summary>
    public string FxCopDir { get; init; } = string.Empty;

    /// <summary>
    /// Path to the directory specified for intermediate files. If it's a relative path, intermediate files go to this path appended to the project directory. This path should have a trailing slash. It resolves to the value for the Intermediate Directory property. Don't use $(OutDir) to define this property.
    /// </summary>
    public string IntDir { get; init; } = string.Empty;

    /// <summary>
    /// Path to the output file directory. If it's a relative path, output files go to this path appended to the project directory. This path should have a trailing slash. It resolves to the value for the Output Directory property. Don't use $(IntDir) to define this property.
    /// </summary>
    public string OutDir { get; init; } = string.Empty;

    /// <summary>
    /// The name of current project platform, for example, "Win32".
    /// </summary>
    public string Platform { get; init; } = string.Empty;

    /// <summary>
    /// The short name of current architecture, for example, "x86" or "x64".
    /// </summary>
    public string PlatformShortName { get; init; } = string.Empty;

    /// <summary>
    /// The directory of the project (defined as drive + path); includes the trailing backslash '\'.
    /// </summary>
    public string ProjectDir { get; init; } = string.Empty;

    /// <summary>
    /// The file extension of the project. It includes the '.' before the file extension.
    /// </summary>
    public string ProjectExt { get; init; } = string.Empty;

    /// <summary>
    /// The file name of the project (defined as base name + file extension).
    /// </summary>
    public string ProjectFileName { get; init; } = string.Empty;

    /// <summary>
    /// The base name of the project.
    /// </summary>
    public string ProjectName { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path name of the project (defined as drive + path + base name + file extension).
    /// </summary>
    public string ProjectPath { get; init; } = string.Empty;

    /// <summary>
    /// The output location for the publish target; includes the trailing backslash '\'. Defaults to the $(OutDir)app.publish\ folder.
    /// </summary>
    public string PublishDir { get; init; } = string.Empty;

    /// <summary>
    /// Set to the value of the Remote Machine property on the Debug property page.
    /// </summary>
    public string RemoteMachine { get; init; } = string.Empty;

    /// <summary>
    /// The namespace, if any, containing the application.
    /// </summary>
    public string RootNameSpace { get; init; } = string.Empty;

    /// <summary>
    /// The directory of the solution (defined as drive + path); includes the trailing backslash '\'. Defined only when building a solution in the IDE.
    /// </summary>
    public string SolutionDir { get; init; } = string.Empty;

    /// <summary>
    /// The file extension of the solution. It includes the '.' before the file extension. Defined only when building a solution in the IDE.
    /// </summary>
    public string SolutionExt { get; init; } = string.Empty;

    /// <summary>
    /// The file name of the solution (defined as base name + file extension). Defined only when building a solution in the IDE.
    /// </summary>
    public string SolutionFileName { get; init; } = string.Empty;

    /// <summary>
    /// The base name of the solution. Defined only when building a solution in the IDE.
    /// </summary>
    public string SolutionName { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path name of the solution (defined as drive + path + base name + file extension). Defined only when building a solution in the IDE.
    /// </summary>
    public string SolutionPath { get; init; } = string.Empty;

    /// <summary>
    /// The directory of the primary output file for the build (defined as drive + path); includes the trailing backslash '\'.
    /// </summary>
    public string TargetDir { get; init; } = string.Empty;

    /// <summary>
    /// The file extension of the primary output file for the build. It includes the '.' before the file extension.
    /// </summary>
    public string TargetExt { get; init; } = string.Empty;

    /// <summary>
    /// The file name of the primary output file for the build (defined as base name + file extension).
    /// </summary>
    public string TargetFileName { get; init; } = string.Empty;

    /// <summary>
    /// The base name of the primary output file for the build.
    /// </summary>
    public string TargetName { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path name of the primary output file for the build (defined as drive + path + base name + file extension).
    /// </summary>
    public string TargetPath { get; init; } = string.Empty;

    /// <summary>
    /// The directory that contains the C++ content of your Visual Studio installation. This property contains the version of the targeted Microsoft C++ (MSVC) toolset, which might be different that the host Visual Studio. For example, when building with $(PlatformToolset) = v140, $(VCInstallDir) contains the path to the Visual Studio 2015 installation.
    /// </summary>
    public string VCInstallDir { get; init; } = string.Empty;

    /// <summary>
    /// The directory into which you installed Visual Studio. This property contains the version of the targeted Visual Studio toolset, which might be different that the host Visual Studio. For example, when building with $(PlatformToolset) = v110, $(VSInstallDir) contains the path to the Visual Studio 2012 installation.
    /// </summary>
    public string VSInstallDir { get; init; } = string.Empty;

    /// <summary>
    /// The relative path from the web deployment root to where the project outputs belong.
    /// </summary>
    public string WebDeployPath { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path to the location of <localhost>. For example, c:\inetpub\wwwroot.
    /// </summary>
    public string WebDeployRoot { get; init; } = string.Empty;

    public static CommonMSBuildMacros Load(ProjectCreator creator)
    {
        creator.TryGetPropertyValue(nameof(Configuration), out string configuration);
        creator.TryGetPropertyValue(nameof(DevEnvDir), out string devEnvDir);
        creator.TryGetPropertyValue(nameof(FrameworkDir), out string frameworkDir);
        creator.TryGetPropertyValue(nameof(FrameworkSDKDir), out string frameworkSDKDir);
        creator.TryGetPropertyValue(nameof(FrameworkVersion), out string frameworkVersion);
        creator.TryGetPropertyValue(nameof(FxCopDir), out string fxCopDir);
        creator.TryGetPropertyValue(nameof(IntDir), out string intDir);
        creator.TryGetPropertyValue(nameof(OutDir), out string outDir);
        creator.TryGetPropertyValue(nameof(Platform), out string platform);
        creator.TryGetPropertyValue(nameof(PlatformShortName), out string platformShortName);
        creator.TryGetPropertyValue(nameof(ProjectDir), out string projectDir);
        creator.TryGetPropertyValue(nameof(ProjectExt), out string projectExt);
        creator.TryGetPropertyValue(nameof(ProjectFileName), out string projectFileName);
        creator.TryGetPropertyValue(nameof(ProjectName), out string projectName);
        creator.TryGetPropertyValue(nameof(ProjectPath), out string projectPath);
        creator.TryGetPropertyValue(nameof(PublishDir), out string publishDir);
        creator.TryGetPropertyValue(nameof(RemoteMachine), out string remoteMachine);
        creator.TryGetPropertyValue(nameof(RootNameSpace), out string rootNameSpace);
        creator.TryGetPropertyValue(nameof(SolutionDir), out string solutionDir);
        creator.TryGetPropertyValue(nameof(SolutionExt), out string solutionExt);
        creator.TryGetPropertyValue(nameof(SolutionFileName), out string solutionFileName);
        creator.TryGetPropertyValue(nameof(SolutionName), out string solutionName);
        creator.TryGetPropertyValue(nameof(SolutionPath), out string solutionPath);
        creator.TryGetPropertyValue(nameof(TargetDir), out string targetDir);
        creator.TryGetPropertyValue(nameof(TargetExt), out string targetExt);
        creator.TryGetPropertyValue(nameof(TargetFileName), out string targetFileName);
        creator.TryGetPropertyValue(nameof(TargetName), out string targetName);
        creator.TryGetPropertyValue(nameof(TargetPath), out string targetPath);
        creator.TryGetPropertyValue(nameof(VCInstallDir), out string vCInstallDir);
        creator.TryGetPropertyValue(nameof(VSInstallDir), out string vSInstallDir);
        creator.TryGetPropertyValue(nameof(WebDeployPath), out string webDeployPath);
        creator.TryGetPropertyValue(nameof(WebDeployRoot), out string webDeployRoot);

        CommonMSBuildMacros result = new()
        {
            Configuration = configuration,
            DevEnvDir = devEnvDir,
            FrameworkDir = frameworkDir,
            FrameworkSDKDir = frameworkSDKDir,
            FrameworkVersion = frameworkVersion,
            FxCopDir = fxCopDir,
            IntDir = intDir,
            OutDir = outDir,
            Platform = platform,
            PlatformShortName = platformShortName,
            ProjectDir = projectDir,
            ProjectExt = projectExt,
            ProjectFileName = projectFileName,
            ProjectName = projectName,
            ProjectPath = projectPath,
            PublishDir = publishDir,
            RemoteMachine = remoteMachine,
            RootNameSpace = rootNameSpace,
            SolutionDir = solutionDir,
            SolutionExt = solutionExt,
            SolutionFileName = solutionFileName,
            SolutionName = solutionName,
            SolutionPath = solutionPath,
            TargetDir = targetDir,
            TargetExt = targetExt,
            TargetFileName = targetFileName,
            TargetName = targetName,
            TargetPath = targetPath,
            VCInstallDir = vCInstallDir,
            VSInstallDir = vSInstallDir,
            WebDeployPath = webDeployPath,
            WebDeployRoot = webDeployRoot,
        };

        return result;
    }
}
