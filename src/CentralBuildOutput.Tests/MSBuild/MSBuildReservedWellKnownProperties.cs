namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;

/// <summary>
/// MSBuild reserved and well-known properties.
/// https://docs.microsoft.com/visualstudio/msbuild/msbuild-reserved-and-well-known-properties
/// </summary>
internal sealed class MSBuildReservedWellKnownProperties
{
    /// <summary>
    /// The version of MSBuild assemblies used to build the project.
    /// Type: Reserved
    /// Example: 16.0
    /// </summary>
    public string MSBuildAssemblyVersion { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path of the folder where the MSBuild binaries that are currently being used are located (for example, C:\Windows\Microsoft.Net\Framework\<versionNumber>). This property is useful if you have to refer to files in the MSBuild directory. Do not include the final backslash on this property.
    /// Type: Reserved
    /// Example: C:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Current\Bin
    /// </summary>
    public string MSBuildBinPath { get; init; } = string.Empty;

    /// <summary>
    /// Introduced in the .NET Framework 4: there is no difference between the default values of MSBuildExtensionsPath and MSBuildExtensionsPath32. You can set the environment variable MSBUILDLEGACYEXTENSIONSPATH to a non-null value to enable the behavior of the default value of MSBuildExtensionsPath in earlier versions. In the .NET Framework 3.5 and earlier, the default value of MSBuildExtensionsPath points to the path of the MSBuild subfolder under the \Program Files\ or \Program Files (x86) folder, depending on the bitness of the current process. For example, for a 32-bit process on a 64-bit machine, this property points to the \Program Files (x86) folder. For a 64-bit process on a 64-bit machine, this property points to the \Program Files folder. Do not include the final backslash on this property. This location is a useful place to put custom target files. For example, your target files could be installed at \Program Files\MSBuild\MyFiles\Northwind.targets and then imported in project files by using this XML code: <Import Project="$(MSBuildExtensionsPath)\MyFiles\Northwind.targets"/>
    /// Type: Well-known
    /// Example: C:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild
    /// </summary>
    public string MSBuildExtensionsPath { get; init; } = string.Empty;

    /// <summary>
    /// The path of the MSBuild subfolder under the \Program Files or \Program Files (x86) folder. The path always points to the 32-bit \Program Files (x86) folder on a 32-bit machine and \Program Files on a 64-bit machine.". See also MSBuildExtensionsPath and MSBuildExtensionsPath64. Do not include the final backslash on this property.
    /// Type: Well-known
    /// Example: C:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild
    /// </summary>
    public string MSBuildExtensionsPath32 { get; init; } = string.Empty;

    /// <summary>
    /// The path of the MSBuild subfolder under the \Program Files folder. For a 64-bit machine, this path always points to the \Program Files folder. For a 32-bit machine, this path is blank. See also MSBuildExtensionsPath and MSBuildExtensionsPath32. Do not include the final backslash on this property.
    /// Type: Well-known
    /// Example: C:\Program Files\MSBuild
    /// </summary>
    public string MSBuildExtensionsPath64 { get; init; } = string.Empty;

    /// <summary>
    /// The 4 part version of MSBuild assemblies used to build the project.
    /// Type: Reserved
    /// Example: 16.11.0.30701
    /// </summary>
    public string MSBuildFileVersion { get; init; } = string.Empty;

    /// <summary>
    /// true if MSBuild is running interactively, allowing user input. This setting is controlled by the -interactive command-line option.
    /// Type: Reserved
    /// Example: false
    /// </summary>
    public string MSBuildInteractive { get; init; } = string.Empty;

    /// <summary>
    /// true if the previous task completed without any errors (even if there were warnings), or false if the previous task had errors. Typically, when an error occurs in a task, the error is the last thing that happens in that project. Therefore, the value of this property is never false, except in these scenarios: - When the ContinueOnError attribute of the Task element (MSBuild) is set to WarnAndContinue (or true) or ErrorAndContinue. - When the Target has an OnError element (MSBuild) as a child element.
    /// Type: Reserved
    /// Example: true
    /// </summary>
    public string MSBuildLastTaskResult { get; init; } = string.Empty;

    /// <summary>
    /// The maximum number of concurrent processes that are used when building. This is the value that you specified for -maxcpucount on the command line. If you specified -maxcpucount without specifying a value, then MSBuildNodeCount specifies the number of processors in the computer. For more information, see Command-line reference and Build multiple projects in parallel.
    /// Type: Reserved
    /// Example: 1
    /// </summary>
    public string MSBuildNodeCount { get; init; } = string.Empty;

    /// <summary>
    /// The location of the 32-bit program folder; for example, C:\Program Files (x86). Do not include the final backslash on this property.
    /// Type: Reserved
    /// Example: C:\Program Files (x86)
    /// </summary>
    public string MSBuildProgramFiles32 { get; init; } = string.Empty;

    /// <summary>
    /// The complete list of targets that are specified in the DefaultTargets attribute of the Project element. For example, the following Project element would have an MSBuildDefaultTargets property value of A;B;C: <Project DefaultTargets="A;B;C" >
    /// Type: Reserved
    /// Example: Build
    /// </summary>
    public string MSBuildProjectDefaultTargets { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path of the directory where the project file is located, for example C:\MyCompany\MyProduct. Do not include the final backslash on this property.
    /// Type: Reserved
    /// Example: C:\Source\Repos\ConsoleApp1\ConsoleApp1
    /// </summary>
    public string MSBuildProjectDirectory { get; init; } = string.Empty;

    /// <summary>
    /// The value of the MSBuildProjectDirectory property, excluding the root drive. Do not include the final backslash on this property.
    /// Type: Reserved
    /// Example: Source\Repos\ConsoleApp1\ConsoleApp1
    /// </summary>
    public string MSBuildProjectDirectoryNoRoot { get; init; } = string.Empty;

    /// <summary>
    /// The file name extension of the project file, including the period; for example, .proj.
    /// Type: Reserved
    /// Example: .csproj
    /// </summary>
    public string MSBuildProjectExtension { get; init; } = string.Empty;

    /// <summary>
    /// The complete file name of the project file, including the file name extension; for example, MyApp.proj.
    /// Type: Reserved
    /// Example: ConsoleApp1.csproj
    /// </summary>
    public string MSBuildProjectFile { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path and complete file name of the project file, including the file name extension; for example, C:\MyCompany\MyProduct\MyApp.proj.
    /// Type: Reserved
    /// Example: c:\Source\Repos\ConsoleApp1\ConsoleApp1\ConsoleApp1.csproj
    /// </summary>
    public string MSBuildProjectFullPath { get; init; } = string.Empty;

    /// <summary>
    /// The file name of the project file without the file name extension; for example, MyApp.
    /// Type: Reserved
    /// Example: ConsoleApp1
    /// </summary>
    public string MSBuildProjectName { get; init; } = string.Empty;

    /// <summary>
    /// The type of the runtime that is currently executing. Introduced in MSBuild 15. Value may be undefined (prior to MSBuild 15), Full indicating that MSBuild is running on the desktop .NET Framework, Core indicating that MSBuild is running on .NET Core (for example in dotnet build), or Mono indicating that MSBuild is running on Mono.
    /// Type: Reserved
    /// Example: Full
    /// </summary>
    public string MSBuildRuntimeType { get; init; } = string.Empty;

    /// <summary>
    /// The full semver 2.0 version of MSBuild assemblies used to build the project.
    /// Type: Reserved
    /// Example: 16.11.0-preview-21302-05+5e37cc992
    /// </summary>
    public string MSBuildSemanticVersion { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path of the folder where MSBuild is called. By using this property, you can build everything below a specific point in a project tree without creating <dirs>.proj files in every directory. Instead, you have just one project—for example, c:\traversal.proj, as shown here: <Project ...>     <ItemGroup>         <ProjectFiles              Include="$            (MSBuildStartupDirectory)            **\*.csproj"/>     </ItemGroup>     <Target Name="build">         <MSBuild             Projects="@(ProjectFiles)"/>     </Target> </Project> To build at any point in the tree, type: msbuild c:\traversal.proj Do not include the final backslash on this property.
    /// Type: Reserved
    /// Example: c:\Source\Repos\ConsoleApp1
    /// </summary>
    public string MSBuildStartupDirectory { get; init; } = string.Empty;

    /// <summary>
    /// The file name and file extension portion of MSBuildThisFileFullPath.
    /// Type: Reserved
    /// Example: ConsoleApp1.csproj
    /// </summary>
    public string MSBuildThisFile { get; init; } = string.Empty;

    /// <summary>
    /// The directory portion of MSBuildThisFileFullPath. Include the final backslash in the path.
    /// Type: Reserved
    /// Example: c:\Source\Repos\ConsoleApp1\ConsoleApp1\
    /// </summary>
    public string MSBuildThisFileDirectory { get; init; } = string.Empty;

    /// <summary>
    /// The directory portion of MSBuildThisFileFullPath, excluding the root drive. Include the final backslash in the path.
    /// Type: Reserved
    /// Example: Source\Repos\ConsoleApp1\ConsoleApp1\
    /// </summary>
    public string MSBuildThisFileDirectoryNoRoot { get; init; } = string.Empty;

    /// <summary>
    /// The file name extension portion of MSBuildThisFileFullPath.
    /// Type: Reserved
    /// Example: .csproj
    /// </summary>
    public string MSBuildThisFileExtension { get; init; } = string.Empty;

    /// <summary>
    /// The absolute path of the project or targets file that contains the target that is running. Tip: You can specify a relative path in a targets file that's relative to the targets file and not relative to the original project file.
    /// Type: Reserved
    /// Example: c:\Source\Repos\ConsoleApp1\ConsoleApp1\ConsoleApp1.csproj
    /// </summary>
    public string MSBuildThisFileFullPath { get; init; } = string.Empty;

    /// <summary>
    /// The file name portion of MSBuildThisFileFullPath, without the file name extension.
    /// Type: Reserved
    /// Example: ConsoleApp1
    /// </summary>
    public string MSBuildThisFileName { get; init; } = string.Empty;

    /// <summary>
    /// The installation path of the MSBuild version that's associated with the value of MSBuildToolsVersion. Do not include the final backslash in the path. This property cannot be overridden.
    /// Type: Reserved
    /// Example: C:\Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Current\Bin
    /// </summary>
    public string MSBuildToolsPath { get; init; } = string.Empty;

    /// <summary>
    /// The version of the MSBuild Toolset that is used to build the project. Note: An MSBuild Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information, see Toolset (ToolsVersion), and Standard and custom Toolset configurations.
    /// Type: Reserved
    /// Example: Current
    /// </summary>
    public string MSBuildToolsVersion { get; init; } = string.Empty;

    /// <summary>
    /// The version of MSBuild used to build the project.  This property can't be overridden, otherwise the error message MSB4004 - The 'MSBuildVersion' property is reserved, and can not be modified. is returned.
    /// Type: Reserved
    /// Example: 16.11.0
    /// </summary>
    public string MSBuildVersion { get; init; } = string.Empty;

    /// <summary>
    /// A list of warning codes to treat as errors.
    /// Type: Well-known
    /// Example: MSB1234;MSB5678
    /// </summary>
    public string MSBuildWarningsAsErrors { get; init; } = string.Empty;

    /// <summary>
    /// A list of warning codes to treat as messages.
    /// Type: Well-known
    /// Example: MSB1234;MSB5678
    /// </summary>
    public string MSBuildWarningsAsMessages { get; init; } = string.Empty;

    /// <summary>
    /// A list of warning codes that should not be promoted to errors even if the -warnAsError switch is set to promote all other warnings to errors. Note that it has no effect if that is not true.
    /// Type: Well-known
    /// Example: MSB1234;MSB5678
    /// </summary>
    public string MSBuildWarningsNotAsErrors { get; init; } = string.Empty;

    public static MSBuildReservedWellKnownProperties Load(ProjectCreator creator)
    {
        creator.TryGetPropertyValue(nameof(MSBuildBinPath), out string mSBuildBinPath);
        creator.TryGetPropertyValue(nameof(MSBuildExtensionsPath), out string mSBuildExtensionsPath);
        creator.TryGetPropertyValue(nameof(MSBuildExtensionsPath32), out string mSBuildExtensionsPath32);
        creator.TryGetPropertyValue(nameof(MSBuildExtensionsPath64), out string mSBuildExtensionsPath64);
        creator.TryGetPropertyValue(nameof(MSBuildWarningsAsErrors), out string mSBuildWarningsAsErrors);
        creator.TryGetPropertyValue(nameof(MSBuildWarningsNotAsErrors), out string mSBuildWarningsNotAsErrors);
        creator.TryGetPropertyValue(nameof(MSBuildWarningsAsMessages), out string mSBuildWarningsAsMessages);
        creator.TryGetPropertyValue(nameof(MSBuildInteractive), out string mSBuildInteractive);
        creator.TryGetPropertyValue(nameof(MSBuildLastTaskResult), out string mSBuildLastTaskResult);
        creator.TryGetPropertyValue(nameof(MSBuildNodeCount), out string mSBuildNodeCount);
        creator.TryGetPropertyValue(nameof(MSBuildProgramFiles32), out string mSBuildProgramFiles32);
        creator.TryGetPropertyValue(nameof(MSBuildProjectDefaultTargets), out string mSBuildProjectDefaultTargets);
        creator.TryGetPropertyValue(nameof(MSBuildProjectDirectory), out string mSBuildProjectDirectory);
        creator.TryGetPropertyValue(nameof(MSBuildProjectDirectoryNoRoot), out string mSBuildProjectDirectoryNoRoot);
        creator.TryGetPropertyValue(nameof(MSBuildProjectExtension), out string mSBuildProjectExtension);
        creator.TryGetPropertyValue(nameof(MSBuildProjectFile), out string mSBuildProjectFile);
        creator.TryGetPropertyValue(nameof(MSBuildProjectFullPath), out string mSBuildProjectFullPath);
        creator.TryGetPropertyValue(nameof(MSBuildProjectName), out string mSBuildProjectName);
        creator.TryGetPropertyValue(nameof(MSBuildRuntimeType), out string mSBuildRuntimeType);
        creator.TryGetPropertyValue(nameof(MSBuildStartupDirectory), out string mSBuildStartupDirectory);
        creator.TryGetPropertyValue(nameof(MSBuildThisFile), out string mSBuildThisFile);
        creator.TryGetPropertyValue(nameof(MSBuildThisFileDirectory), out string mSBuildThisFileDirectory);
        creator.TryGetPropertyValue(nameof(MSBuildThisFileDirectoryNoRoot), out string mSBuildThisFileDirectoryNoRoot);
        creator.TryGetPropertyValue(nameof(MSBuildThisFileExtension), out string mSBuildThisFileExtension);
        creator.TryGetPropertyValue(nameof(MSBuildThisFileFullPath), out string mSBuildThisFileFullPath);
        creator.TryGetPropertyValue(nameof(MSBuildThisFileName), out string mSBuildThisFileName);
        creator.TryGetPropertyValue(nameof(MSBuildToolsPath), out string mSBuildToolsPath);
        creator.TryGetPropertyValue(nameof(MSBuildToolsVersion), out string mSBuildToolsVersion);
        creator.TryGetPropertyValue(nameof(MSBuildVersion), out string mSBuildVersion);
        creator.TryGetPropertyValue(nameof(MSBuildAssemblyVersion), out string mSBuildAssemblyVersion);
        creator.TryGetPropertyValue(nameof(MSBuildFileVersion), out string mSBuildFileVersion);
        creator.TryGetPropertyValue(nameof(MSBuildSemanticVersion), out string mSBuildSemanticVersion);

        MSBuildReservedWellKnownProperties result = new()
        {
            MSBuildBinPath = mSBuildBinPath,
            MSBuildExtensionsPath = mSBuildExtensionsPath,
            MSBuildExtensionsPath32 = mSBuildExtensionsPath32,
            MSBuildExtensionsPath64 = mSBuildExtensionsPath64,
            MSBuildWarningsAsErrors = mSBuildWarningsAsErrors,
            MSBuildWarningsNotAsErrors = mSBuildWarningsNotAsErrors,
            MSBuildWarningsAsMessages = mSBuildWarningsAsMessages,
            MSBuildInteractive = mSBuildInteractive,
            MSBuildLastTaskResult = mSBuildLastTaskResult,
            MSBuildNodeCount = mSBuildNodeCount,
            MSBuildProgramFiles32 = mSBuildProgramFiles32,
            MSBuildProjectDefaultTargets = mSBuildProjectDefaultTargets,
            MSBuildProjectDirectory = mSBuildProjectDirectory,
            MSBuildProjectDirectoryNoRoot = mSBuildProjectDirectoryNoRoot,
            MSBuildProjectExtension = mSBuildProjectExtension,
            MSBuildProjectFile = mSBuildProjectFile,
            MSBuildProjectFullPath = mSBuildProjectFullPath,
            MSBuildProjectName = mSBuildProjectName,
            MSBuildRuntimeType = mSBuildRuntimeType,
            MSBuildStartupDirectory = mSBuildStartupDirectory,
            MSBuildThisFile = mSBuildThisFile,
            MSBuildThisFileDirectory = mSBuildThisFileDirectory,
            MSBuildThisFileDirectoryNoRoot = mSBuildThisFileDirectoryNoRoot,
            MSBuildThisFileExtension = mSBuildThisFileExtension,
            MSBuildThisFileFullPath = mSBuildThisFileFullPath,
            MSBuildThisFileName = mSBuildThisFileName,
            MSBuildToolsPath = mSBuildToolsPath,
            MSBuildToolsVersion = mSBuildToolsVersion,
            MSBuildVersion = mSBuildVersion,
            MSBuildAssemblyVersion = mSBuildAssemblyVersion,
            MSBuildFileVersion = mSBuildFileVersion,
            MSBuildSemanticVersion = mSBuildSemanticVersion,
        };

        return result;
    }
}
