namespace Treasure.Build.CentralBuildOutput.Tests.MSBuild;

using Microsoft.Build.Utilities.ProjectCreation;

using Treasure.Build.CentralBuildOutput.Tests.Extensions;

/// <summary>
/// Common MSBuild project properties.
/// https://docs.microsoft.com/visualstudio/msbuild/common-msbuild-project-properties
/// </summary>
internal sealed class CommonMSBuildProperties
{
    /// <summary>
    /// Specifies additional folders in which compilers should look for reference assemblies.
    /// Project type: .NET
    /// </summary>
    public string AdditionalLibPaths { get; init; } = string.Empty;

    /// <summary>
    /// Causes the compiler to make all type information from the specified files available to the project you are compiling. This property is equivalent to the /addModules compiler switch.
    /// Project type: .NET
    /// </summary>
    public string AddModules { get; init; } = string.Empty;

    /// <summary>
    /// The path where AL.exe can be found. This property overrides the current version of AL.exe to enable use of a different version.
    /// Project type: .NET
    /// </summary>
    public string ALToolPath { get; init; } = string.Empty;

    /// <summary>
    /// The .ico icon file to pass to the compiler for embedding as a Win32 icon. The property is equivalent to the /win32icon compiler switch.
    /// Project type: .NET
    /// </summary>
    public string ApplicationIcon { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the path of the file that is used to generate external User Account Control (UAC) manifest information. Applies only to Visual Studio projects targeting Windows Vista. In most cases, the manifest is embedded. However, if you use Registration Free COM or ClickOnce deployment, then the manifest can be an external file that is installed together with your application assemblies. For more information, see the NoWin32Manifest property in this topic.
    /// Project type: All
    /// </summary>
    public string ApplicationManifest { get; init; } = string.Empty;

    /// <summary>
    /// The name of the final output assembly after the project is built.
    /// Project type: .NET
    /// </summary>
    public string AssemblyName { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the file that's used to sign the assembly (.snk or .pfx) and that's passed to the ResolveKeySource task to generate the actual key that's used to sign the assembly.
    /// Project type: .NET
    /// </summary>
    public string AssemblyOriginatorKeyFile { get; init; } = string.Empty;

    /// <summary>
    /// A list of locations to search during build-time reference assembly resolution. The order in which paths appear in this list is meaningful because paths listed earlier takes precedence over later entries.
    /// Project type: .NET
    /// </summary>
    public string AssemblySearchPaths { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the base address of the main output assembly. This property is equivalent to the /baseaddress compiler switch.
    /// Project type: .NET
    /// </summary>
    public string BaseAddress { get; init; } = string.Empty;

    /// <summary>
    /// The top-level folder where all configuration-specific intermediate output folders are created. The default value is obj\. The following code is an example: <BaseIntermediateOutputPath>c:\xyz\obj\</BaseIntermediateOutputPath>
    /// Project type: All
    /// </summary>
    public string BaseIntermediateOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the base path for the output file. If it is set, MSBuild will use OutputPath = $(BaseOutputPath)\$(Configuration)\. Example syntax: <BaseOutputPath>c:\xyz\bin\</BaseOutputPath>
    /// Project type: All
    /// </summary>
    public string BaseOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether project references are built or cleaned in parallel when Multi-Proc MSBuild is used. The default value is true, which means that projects will be built in parallel if the system has multiple cores or processors.
    /// Project type: All
    /// </summary>
    public string BuildInParallel { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether project references are built by MSBuild. Automatically set to false if you are building your project in the Visual Studio integrated development environment (IDE), true if otherwise. -p:BuildProjectReferences=false can be specified on the command line to avoid checking that referenced projects are up to date.
    /// Project type: All
    /// </summary>
    public string BuildProjectReferences { get; init; } = string.Empty;

    /// <summary>
    /// The name of the file that will be used as the "clean cache." The clean cache is a list of generated files to be deleted during the cleaning operation. The file is put in the intermediate output path by the build process. This property specifies only file names that do not have path information.
    /// Project type: All
    /// </summary>
    public string CleanFile { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the code page to use for all source-code files in the compilation. This property is equivalent to the /codepage compiler switch.
    /// Project type: .NET
    /// </summary>
    public string CodePage { get; init; } = string.Empty;

    /// <summary>
    /// An optional response file that can be passed to the compiler tasks.
    /// Project type: .NET
    /// </summary>
    public string CompilerResponseFile { get; init; } = string.Empty;

    /// <summary>
    /// The configuration that you are building, generally Debug or Release, but configurable at the solution and project levels.
    /// Project type: All
    /// </summary>
    public string Configuration { get; init; } = string.Empty;

    /// <summary>
    /// The path of csc.exe, the C# compiler.
    /// Project type: C#
    /// </summary>
    public string CscToolPath { get; init; } = string.Empty;

    /// <summary>
    /// The name of a project file or targets file that is to be imported automatically before the common targets import.
    /// Project type: All
    /// </summary>
    public string CustomBeforeMicrosoftCommonTargets { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether symbols are generated by the build. Setting -p:DebugSymbols=false on the command line disables generation of program database (.pdb) symbol files.
    /// Project type: All
    /// </summary>
    public string DebugSymbols { get; init; } = string.Empty;

    /// <summary>
    /// Defines the level of debug information that you want generated. Valid values are "full," "pdbonly," "portable", "embedded", and "none."
    /// Project type: All
    /// </summary>
    public string DebugType { get; init; } = string.Empty;

    /// <summary>
    /// Defines conditional compiler constants. Symbol/value pairs are separated by semicolons and are specified by using the following syntax: symbol1 = value1 ; symbol2 = value2 The property is equivalent to the /define compiler switch.
    /// Project type: .NET
    /// </summary>
    public string DefineConstants { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether you want the DEBUG constant defined.
    /// Project type: All
    /// </summary>
    public string DefineDebug { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether you want the TRACE constant defined.
    /// Project type: All
    /// </summary>
    public string DefineTrace { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether you want to delay-sign the assembly rather than full-sign it.
    /// Project type: .NET
    /// </summary>
    public string DelaySign { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether the compiler should produce identical assemblies for identical inputs. This parameter corresponds to the /deterministic switch of the compilers.
    /// Project type: .NET
    /// </summary>
    public string Deterministic { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that applies to Visual Studio only. The Visual Studio build manager uses a process called FastUpToDateCheck to determine whether a project must be rebuilt to be up to date. This process is faster than using MSBuild to determine this. Setting the DisableFastUpToDateCheck property to true lets you bypass the Visual Studio build manager and force it to use MSBuild to determine whether the project is up to date.
    /// Project type: All
    /// </summary>
    public string DisableFastUpToDateCheck { get; init; } = string.Empty;

    /// <summary>
    /// The name of the file that is generated as the XML documentation file. This name includes only the file name and has no path information.
    /// Project type: .NET
    /// </summary>
    public string DocumentationFile { get; init; } = string.Empty;

    /// <summary>
    /// Specifies how the compiler task should report internal compiler errors. Valid values are "prompt," "send," or "none." This property is equivalent to the /errorreport compiler switch.
    /// Project type: .NET
    /// </summary>
    public string ErrorReport { get; init; } = string.Empty;

    /// <summary>
    /// The GenerateDeploymentManifest task adds a  deploymentProvider tag to the deployment manifest if the project file includes any of the following elements: -   UpdateUrl-   InstallUrl-   PublishUrl Using ExcludeDeploymentUrl, however, you can prevent the deploymentProvider tag from being added to the deployment manifest even if any of the above URLs are specified. To do this, add the following property to your project file: <ExcludeDeploymentUrl>true</ExcludeDeploymentUrl> Note:  ExcludeDeploymentUrl is not exposed in the Visual Studio IDE and can be set only by manually editing the project file. Setting this property does not affect publishing within Visual Studio; that is, the deploymentProvider tag will still be added to the URL specified by PublishUrl.
    /// Project type: .NET
    /// </summary>
    public string ExcludeDeploymentUrl { get; init; } = string.Empty;

    /// <summary>
    /// Specifies, in bytes, where to align the sections of the output file. Valid values are 512, 1024, 2048, 4096, 8192. This property is equivalent to the /filealignment compiler switch.
    /// Project type: .NET
    /// </summary>
    public string FileAlignment { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the location of mscorlib.dll and microsoft.visualbasic.dll. This parameter is equivalent to the /sdkpath switch of the vbc.exe compiler.
    /// Project type: Visual Basic
    /// </summary>
    public string FrameworkPathOverride { get; init; } = string.Empty;

    /// <summary>
    /// A boolean parameter that indicates whether documentation is generated by the build. If true, the build generates documentation information and puts it in an .xml file together with the name of the executable file or library that the build task created.
    /// Project type: .NET
    /// </summary>
    public string GenerateDocumentation { get; init; } = string.Empty;

    /// <summary>
    /// Generate full paths for filenames in output by using the -fullpaths compiler option.
    /// Project type: C#
    /// </summary>
    public string GenerateFullPaths { get; init; } = string.Empty;

    /// <summary>
    /// Indicates whether XML serialization assemblies should be generated by SGen.exe, which can be set to on, auto, or off. This property is used for assemblies that target .NET Framework only. To generate XML serialization assemblies for .NET Standard or .NET Core assemblies, reference the Microsoft.XmlSerializer.Generator NuGet package.
    /// Project type: .NET
    /// </summary>
    public string GenerateSerializationAssemblies { get; init; } = string.Empty;

    /// <summary>
    /// The full intermediate output path as derived from BaseIntermediateOutputPath, if no path is specified. For example, obj\debug\.
    /// Project type: All
    /// </summary>
    public string IntermediateOutputPath { get; init; } = string.Empty;

    /// <summary>
    /// The name of the strong-name key container.
    /// Project type: All
    /// </summary>
    public string KeyContainerName { get; init; } = string.Empty;

    /// <summary>
    /// The name of the strong-name key file.
    /// Project type: All
    /// </summary>
    public string KeyOriginatorFile { get; init; } = string.Empty;

    /// <summary>
    /// The name of the assembly that the compiled module is to be incorporated into. The property is equivalent to the /moduleassemblyname compiler switch.
    /// Project type: .NET
    /// </summary>
    public string ModuleAssemblyName { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the path where project extensions are located. By default, this takes the same value as BaseIntermediateOutputPath.
    /// Project type: All
    /// </summary>
    public string MSBuildProjectExtensionsPath { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether you want compiler logo to be turned off. This property is equivalent to the /nologo compiler switch.
    /// Project type: All
    /// </summary>
    public string NoLogo { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether to avoid referencing the standard library (mscorlib.dll). The default value is false.
    /// Project type: .NET
    /// </summary>
    public string NoStdLib { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether the Visual Basic runtime (Microsoft.VisualBasic.dll) should be included as a reference in the project.
    /// Project type: Visual Basic
    /// </summary>
    public string NoVBRuntimeReference { get; init; } = string.Empty;

    /// <summary>
    /// Suppresses the specified warnings. Only the numeric part of the warning identifier must be specified. Multiple warnings are separated by semicolons. This parameter corresponds to the /nowarn switch of the compilers.
    /// Project type: .NET
    /// </summary>
    public string NoWarn { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether User Account Control (UAC) manifest information will be embedded in the application's executable. Applies only to Visual Studio projects targeting Windows Vista. In projects deployed using ClickOnce and Registration-Free COM, this element is ignored. False (the default value) specifies that User Account Control (UAC) manifest information be embedded in the application's executable. True specifies that UAC manifest information not be embedded. This property applies only to Visual Studio projects targeting Windows Vista. In projects deployed using ClickOnce and Registration-Free COM, this property is ignored. You should add NoWin32Manifest only if you do not want Visual Studio to embed any manifest information in the application's executable; this process is called virtualization. To use virtualization, set &lt;ApplicationManifestgt; in conjunction with &lt;NoWin32Manifest&gt; as follows: -   For Visual Basic projects, remove the &lt;ApplicationManifest&gt; node. (In Visual Basic projects, &lt;NoWin32Manifest&gt; is ignored when an &lt;ApplicationManifest&gt; node exists.)-   For C# projects, set &lt;ApplicationManifestgt; to False and &lt;NoWin32Manifest&gt; to True. (In C# projects, &lt;ApplicationManifestgt; overrides &lt;NoWin32Manifest&gt;.) This property is equivalent to the /nowin32manifest compiler switch of vbc.exe.
    /// Project type: .NET
    /// </summary>
    public string NoWin32Manifest { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that when set to true, enables compiler optimizations. This property is equivalent to the /optimize compiler switch.
    /// Project type: .NET
    /// </summary>
    public string Optimize { get; init; } = string.Empty;

    /// <summary>
    /// Specifies how string comparisons are made. Valid values are "binary" or "text." This property is equivalent to the /optioncompare compiler switch of vbc.exe.
    /// Project type: VisualBasic
    /// </summary>
    public string OptionCompare { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that when set to true, requires explicit declaration of variables in the source code. This property is equivalent to the /optionexplicit compiler switch.
    /// Project type: Visual Basic
    /// </summary>
    public string OptionExplicit { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that when set to true, enables type inference of variables. This property is equivalent to the /optioninfer compiler switch.
    /// Project type: Visual Basic
    /// </summary>
    public string OptionInfer { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that when set to true, causes the build task to enforce strict type semantics to restrict implicit type conversions. This property is equivalent to the /optionstrict switch of the vbc.exe compiler.
    /// Project type: Visual Basic
    /// </summary>
    public string OptionStrict { get; init; } = string.Empty;

    /// <summary>
    /// Indicates the final output location for the project or solution. When building a solution, OutDir can be used to gather multiple project outputs in one location. In addition, OutDir is included in AssemblySearchPaths used for resolving references. For example, bin\Debug.
    /// Project type: All
    /// </summary>
    public string OutDir { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the path to the output directory, relative to the project directory, for example, bin\Debug.
    /// Project type: All
    /// </summary>
    public string OutputPath { get; init; } = string.Empty;

    /// <summary>
    /// Gets the <see cref="OutputPath"/> with path separators normalized.
    /// </summary>
    /// <remarks>
    /// The target framework is added appended to the OutputPath at some point, which adds a '/' or '\' to the end
    /// depending on the OS. We normalize the path separators to '/' in this case.
    /// </remarks>
    public string OutputPathNormalized => this.OutputPath.ToPosixPath();

    /// <summary>
    /// Specifies the file format of the output file. This parameter can have one of the following values: -   Library. Creates a code library. (Default value.)-   Exe. Creates a console application.-   Module. Creates a module.-   Winexe. Creates a Windows-based program. For C# and Visual Basic, this property is equivalent to the /target switch. The output type can be automatically overriden by inferencing. See OutputType set to WinExe for WPF and WinForms apps. Disable inferencing by setting DisableWinExeOutputInference to true.
    /// Project type: All
    /// </summary>
    public string OutputType { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether you want to enable the build to overwrite read-only files or trigger an error.
    /// Project type: All
    /// </summary>
    public string OverwriteReadOnlyFiles { get; init; } = string.Empty;

    /// <summary>
    /// Specifies how to map physical paths to source path names output by the compiler. This property is equivalent to the /pathmap switch of the compilers.
    /// Project type: .NET
    /// </summary>
    public string PathMap { get; init; } = string.Empty;

    /// <summary>
    /// The file name of the .pdb file that you are emitting. This property is equivalent to the /pdb switch of the csc.exe compiler.
    /// Project type: .NET
    /// </summary>
    public string PdbFile { get; init; } = string.Empty;

    /// <summary>
    /// The operating system you are building for. Examples for .NET Framework builds are "Any CPU", "x86", and "x64".
    /// Project type: All
    /// </summary>
    public string Platform { get; init; } = string.Empty;

    /// <summary>
    /// The processor architecture that is used when assembly references are resolved. Valid values are "msil," "x86," "amd64," or "ia64."
    /// Project type: .NET
    /// </summary>
    public string ProcessorArchitecture { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that instructs the compiler to emit only a reference assembly rather than compiled code. Cannot be used in conjunction with ProduceReferenceAssembly.  This property corresponds to the /refonly switch of the vbc.exe and csc.exe compilers.
    /// Project type: .NET
    /// </summary>
    public string ProduceOnlyReferenceAssembly { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that when set to true enables production of reference assemblies for the current assembly. Deterministic should be true when using this feature. This property corresponds to the /refout switch of the vbc.exe and csc.exe compilers.
    /// Project type: .NET
    /// </summary>
    public string ProduceReferenceAssembly { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether to disable integer overflow error checks. The default value is false. This property is equivalent to the /removeintchecks switch of the vbc.exe compiler.
    /// Project type: Visual Basic
    /// </summary>
    public string RemoveIntegerChecks { get; init; } = string.Empty;

    /// <summary>
    /// The root namespace to use when you name an embedded resource. This namespace is part of the embedded resource manifest name.
    /// Project type: All
    /// </summary>
    public string RootNamespace { get; init; } = string.Empty;

    /// <summary>
    /// The ID of the AL.exe hashing algorithm to use when satellite assemblies are created.
    /// Project type: .NET
    /// </summary>
    public string Satellite_AlgorithmId { get; init; } = string.Empty;

    /// <summary>
    /// The base address to use when culture-specific satellite assemblies are built by using the CreateSatelliteAssemblies target.
    /// Project type: .NET
    /// </summary>
    public string Satellite_BaseAddress { get; init; } = string.Empty;

    /// <summary>
    /// The company name to pass into AL.exe during satellite assembly generation.
    /// Project type: .NET
    /// </summary>
    public string Satellite_CompanyName { get; init; } = string.Empty;

    /// <summary>
    /// The configuration name to pass into AL.exe during satellite assembly generation.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Configuration { get; init; } = string.Empty;

    /// <summary>
    /// The description text to pass into AL.exe during satellite assembly generation.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Description { get; init; } = string.Empty;

    /// <summary>
    /// Embeds the specified file in the satellite assembly that has the resource name "Security.Evidence."
    /// Project type: .NET
    /// </summary>
    public string Satellite_EvidenceFile { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a string for the File Version field in the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_FileVersion { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a value for the Flags field in the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Flags { get; init; } = string.Empty;

    /// <summary>
    /// Causes the build task to use absolute paths for any files reported in an error message.
    /// Project type: .NET
    /// </summary>
    public string Satellite_GenerateFullPaths { get; init; } = string.Empty;

    /// <summary>
    /// Links the specified resource files to a satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_LinkResource { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the fully-qualified name (that is, class.method) of the method to use as an entry point when a module is converted to an executable file during satellite assembly generation.
    /// Project type: .NET
    /// </summary>
    public string Satellite_MainEntryPoint { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a string for the Product field in the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_ProductName { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a string for the ProductVersion field in the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_ProductVersion { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the file format of the satellite assembly output file as "library," "exe," or "win." The default value is "library."
    /// Project type: .NET
    /// </summary>
    public string Satellite_TargetType { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a string for the Title field in the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Title { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a string for the Trademark field in the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Trademark { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the version information for the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Version { get; init; } = string.Empty;

    /// <summary>
    /// Inserts an .ico icon file in the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Win32Icon { get; init; } = string.Empty;

    /// <summary>
    /// Inserts a Win32 resource (.res file) into the satellite assembly.
    /// Project type: .NET
    /// </summary>
    public string Satellite_Win32Resource { get; init; } = string.Empty;

    /// <summary>
    /// An optional tool path that indicates where to obtain SGen.exe when the current version of SGen.exe is overridden.
    /// Project type: .NET
    /// </summary>
    public string SGenToolPath { get; init; } = string.Empty;

    /// <summary>
    /// A boolean value that indicates whether proxy types should be generated by SGen.exe. This applies only when GenerateSerializationAssemblies is set to on. The SGen target uses this property to set the UseProxyTypes flag. This property defaults to true, and there is no UI to change this. To generate the serialization assembly for non-webservice types, add this property to the project file and set it to false before importing the Microsoft.Common.Targets or the C#/VB.targets.
    /// Project type: .NET
    /// </summary>
    public string SGenUseProxyTypes { get; init; } = string.Empty;

    /// <summary>
    /// When true, generate a warning on invalid platform and configuration combinations, but do not fail the build; when false or undefined (the default), generate an error.
    /// Project type: All
    /// </summary>
    public string SkipInvalidConfigurations { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the class or module that contains the Main method or Sub Main procedure. This property is equivalent to the /main compiler switch.
    /// Project type: .NET
    /// </summary>
    public string StartupObject { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the minimum version of the subsystem that the generated executable file can use. This property is equivalent to the /subsystemversion compiler switch. For information about the default value of this property, see /subsystemversion (Visual Basic) or /subsystemversion (C# compiler options).
    /// Project type: .NET
    /// </summary>
    public string SubsystemVersion { get; init; } = string.Empty;

    /// <summary>
    /// The version of the .NET Compact Framework that is required to run the application that you are building. Specifying this lets you reference certain framework assemblies that you may not be able to reference otherwise.
    /// Project type: .NET
    /// </summary>
    public string TargetCompactFramework { get; init; } = string.Empty;

    /// <summary>
    /// The version of the .NET Framework that is required to run the application that you are building. Specifying this lets you reference certain framework assemblies that you may not be able to reference otherwise.
    /// Project type: .NET
    /// </summary>
    public string TargetFrameworkVersion { get; init; } = string.Empty;

    /// <summary>
    /// A boolean parameter that, if true, causes all warnings to be treated as errors. This parameter is equivalent to the /nowarn compiler switch.
    /// Project type: .NET
    /// </summary>
    public string TreatWarningsAsErrors { get; init; } = string.Empty;

    /// <summary>
    /// A boolean property that you can set to true when you want all build outputs in a solution to use the same output directory. If true, referenced projects' output is not copied to projects that use those dependencies, as is normally the case when this setting is false. Setting this parameter to true does not change the actual output directory of any projects; you still need to set the output directory to the desired common output directory for each project that requires it.
    /// Project type: .NET
    /// </summary>
    public string UseCommonOutputDirectory { get; init; } = string.Empty;

    /// <summary>
    /// A boolean parameter that, if true, causes the build task to use the in-process compiler object, if it is available. This parameter is used only by Visual Studio.
    /// Project type: .NET
    /// </summary>
    public string UseHostCompilerIfAvailable { get; init; } = string.Empty;

    /// <summary>
    /// A boolean parameter that, if true, logs compiler output by using UTF-8 encoding. This parameter is equivalent to the /utf8Output compiler switch.
    /// Project type: .NET
    /// </summary>
    public string Utf8Output { get; init; } = string.Empty;

    /// <summary>
    /// An optional path that indicates another location for vbc.exe when the current version of vbc.exe is overridden.
    /// Project type: Visual Basic
    /// </summary>
    public string VbcToolPath { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the verbosity of the Visual Basic compiler's output. Valid values are "Quiet," "Normal" (the default value), or "Verbose."
    /// Project type: Visual Basic
    /// </summary>
    public string VbcVerbosity { get; init; } = string.Empty;

    /// <summary>
    /// Specifies the version of Visual Studio under which this project should be considered to be running. If this property isn't specified, MSBuild sets it to a default value of {VisualStudioMajorVersion}.0; for instance it will be 17.0 for all versions of Visual Studio 2022. This property is used in several project types to specify the set of targets that are used for the build. If ToolsVersion is set to 4.0 or higher for a project, VisualStudioVersion is used to specify which sub-toolset to use. For more information, see Toolset (ToolsVersion).
    /// Project type: All
    /// </summary>
    public string VisualStudioVersion { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a list of warnings to treat as errors. This parameter is equivalent to the /warnaserror compiler switch.
    /// Project type: .NET
    /// </summary>
    public string WarningsAsErrors { get; init; } = string.Empty;

    /// <summary>
    /// Specifies a list of warnings that are not treated as errors. This parameter is equivalent to the /warnaserror compiler switch.
    /// Project type: .NET
    /// </summary>
    public string WarningsNotAsErrors { get; init; } = string.Empty;

    /// <summary>
    /// The name of the manifest file that should be embedded in the final assembly. This parameter is equivalent to the /win32Manifest compiler switch.
    /// Project type: .NET
    /// </summary>
    public string Win32Manifest { get; init; } = string.Empty;

    /// <summary>
    /// The file name of the Win32 resource to be embedded in the final assembly. This parameter is equivalent to the /win32resource compiler switch.
    /// Project type: .NET
    /// </summary>
    public string Win32Resource { get; init; } = string.Empty;

    public static CommonMSBuildProperties Load(ProjectCreator creator)
    {
        creator.TryGetPropertyValue(nameof(AdditionalLibPaths), out string additionalLibPaths);
        creator.TryGetPropertyValue(nameof(AddModules), out string addModules);
        creator.TryGetPropertyValue(nameof(ALToolPath), out string aLToolPath);
        creator.TryGetPropertyValue(nameof(ApplicationIcon), out string applicationIcon);
        creator.TryGetPropertyValue(nameof(ApplicationManifest), out string applicationManifest);
        creator.TryGetPropertyValue(nameof(AssemblyOriginatorKeyFile), out string assemblyOriginatorKeyFile);
        creator.TryGetPropertyValue(nameof(AssemblySearchPaths), out string assemblySearchPaths);
        creator.TryGetPropertyValue(nameof(AssemblyName), out string assemblyName);
        creator.TryGetPropertyValue(nameof(BaseAddress), out string baseAddress);
        creator.TryGetPropertyValue(nameof(BaseIntermediateOutputPath), out string baseIntermediateOutputPath);
        creator.TryGetPropertyValue(nameof(BaseOutputPath), out string baseOutputPath);
        creator.TryGetPropertyValue(nameof(BuildInParallel), out string buildInParallel);
        creator.TryGetPropertyValue(nameof(BuildProjectReferences), out string buildProjectReferences);
        creator.TryGetPropertyValue(nameof(CleanFile), out string cleanFile);
        creator.TryGetPropertyValue(nameof(CodePage), out string codePage);
        creator.TryGetPropertyValue(nameof(CompilerResponseFile), out string compilerResponseFile);
        creator.TryGetPropertyValue(nameof(Configuration), out string configuration);
        creator.TryGetPropertyValue(nameof(CscToolPath), out string cscToolPath);
        creator.TryGetPropertyValue(nameof(CustomBeforeMicrosoftCommonTargets), out string customBeforeMicrosoftCommonTargets);
        creator.TryGetPropertyValue(nameof(DebugSymbols), out string debugSymbols);
        creator.TryGetPropertyValue(nameof(DebugType), out string debugType);
        creator.TryGetPropertyValue(nameof(DefineConstants), out string defineConstants);
        creator.TryGetPropertyValue(nameof(DefineDebug), out string defineDebug);
        creator.TryGetPropertyValue(nameof(DefineTrace), out string defineTrace);
        creator.TryGetPropertyValue(nameof(DelaySign), out string delaySign);
        creator.TryGetPropertyValue(nameof(Deterministic), out string deterministic);
        creator.TryGetPropertyValue(nameof(DisableFastUpToDateCheck), out string disableFastUpToDateCheck);
        creator.TryGetPropertyValue(nameof(DocumentationFile), out string documentationFile);
        creator.TryGetPropertyValue(nameof(ErrorReport), out string errorReport);
        creator.TryGetPropertyValue(nameof(ExcludeDeploymentUrl), out string excludeDeploymentUrl);
        creator.TryGetPropertyValue(nameof(FileAlignment), out string fileAlignment);
        creator.TryGetPropertyValue(nameof(FrameworkPathOverride), out string frameworkPathOverride);
        creator.TryGetPropertyValue(nameof(GenerateDocumentation), out string generateDocumentation);
        creator.TryGetPropertyValue(nameof(GenerateFullPaths), out string generateFullPaths);
        creator.TryGetPropertyValue(nameof(GenerateSerializationAssemblies), out string generateSerializationAssemblies);
        creator.TryGetPropertyValue(nameof(IntermediateOutputPath), out string intermediateOutputPath);
        creator.TryGetPropertyValue(nameof(KeyContainerName), out string keyContainerName);
        creator.TryGetPropertyValue(nameof(KeyOriginatorFile), out string keyOriginatorFile);
        creator.TryGetPropertyValue(nameof(ModuleAssemblyName), out string moduleAssemblyName);
        creator.TryGetPropertyValue(nameof(MSBuildProjectExtensionsPath), out string mSBuildProjectExtensionsPath);
        creator.TryGetPropertyValue(nameof(NoLogo), out string noLogo);
        creator.TryGetPropertyValue(nameof(NoStdLib), out string noStdLib);
        creator.TryGetPropertyValue(nameof(NoVBRuntimeReference), out string noVBRuntimeReference);
        creator.TryGetPropertyValue(nameof(NoWarn), out string noWarn);
        creator.TryGetPropertyValue(nameof(NoWin32Manifest), out string noWin32Manifest);
        creator.TryGetPropertyValue(nameof(Optimize), out string optimize);
        creator.TryGetPropertyValue(nameof(OptionCompare), out string optionCompare);
        creator.TryGetPropertyValue(nameof(OptionExplicit), out string optionExplicit);
        creator.TryGetPropertyValue(nameof(OptionInfer), out string optionInfer);
        creator.TryGetPropertyValue(nameof(OptionStrict), out string optionStrict);
        creator.TryGetPropertyValue(nameof(OutDir), out string outDir);
        creator.TryGetPropertyValue(nameof(OutputPath), out string outputPath);
        creator.TryGetPropertyValue(nameof(OutputType), out string outputType);
        creator.TryGetPropertyValue(nameof(OverwriteReadOnlyFiles), out string overwriteReadOnlyFiles);
        creator.TryGetPropertyValue(nameof(PathMap), out string pathMap);
        creator.TryGetPropertyValue(nameof(PdbFile), out string pdbFile);
        creator.TryGetPropertyValue(nameof(Platform), out string platform);
        creator.TryGetPropertyValue(nameof(ProcessorArchitecture), out string processorArchitecture);
        creator.TryGetPropertyValue(nameof(ProduceOnlyReferenceAssembly), out string produceOnlyReferenceAssembly);
        creator.TryGetPropertyValue(nameof(ProduceReferenceAssembly), out string produceReferenceAssembly);
        creator.TryGetPropertyValue(nameof(RemoveIntegerChecks), out string removeIntegerChecks);
        creator.TryGetPropertyValue(nameof(RootNamespace), out string rootNamespace);
        creator.TryGetPropertyValue(nameof(Satellite_AlgorithmId), out string satelliteAlgorithmId);
        creator.TryGetPropertyValue(nameof(Satellite_BaseAddress), out string satelliteBaseAddress);
        creator.TryGetPropertyValue(nameof(Satellite_CompanyName), out string satelliteCompanyName);
        creator.TryGetPropertyValue(nameof(Satellite_Configuration), out string satelliteConfiguration);
        creator.TryGetPropertyValue(nameof(Satellite_Description), out string satelliteDescription);
        creator.TryGetPropertyValue(nameof(Satellite_EvidenceFile), out string satelliteEvidenceFile);
        creator.TryGetPropertyValue(nameof(Satellite_FileVersion), out string satelliteFileVersion);
        creator.TryGetPropertyValue(nameof(Satellite_Flags), out string satelliteFlags);
        creator.TryGetPropertyValue(nameof(Satellite_GenerateFullPaths), out string satelliteGenerateFullPaths);
        creator.TryGetPropertyValue(nameof(Satellite_LinkResource), out string satelliteLinkResource);
        creator.TryGetPropertyValue(nameof(Satellite_MainEntryPoint), out string satelliteMainEntryPoint);
        creator.TryGetPropertyValue(nameof(Satellite_ProductName), out string satelliteProductName);
        creator.TryGetPropertyValue(nameof(Satellite_ProductVersion), out string satelliteProductVersion);
        creator.TryGetPropertyValue(nameof(Satellite_TargetType), out string satelliteTargetType);
        creator.TryGetPropertyValue(nameof(Satellite_Title), out string satelliteTitle);
        creator.TryGetPropertyValue(nameof(Satellite_Trademark), out string satelliteTrademark);
        creator.TryGetPropertyValue(nameof(Satellite_Version), out string satelliteVersion);
        creator.TryGetPropertyValue(nameof(Satellite_Win32Icon), out string satelliteWin32Icon);
        creator.TryGetPropertyValue(nameof(Satellite_Win32Resource), out string satelliteWin32Resource);
        creator.TryGetPropertyValue(nameof(SGenToolPath), out string sGenToolPath);
        creator.TryGetPropertyValue(nameof(SGenUseProxyTypes), out string sGenUseProxyTypes);
        creator.TryGetPropertyValue(nameof(SkipInvalidConfigurations), out string skipInvalidConfigurations);
        creator.TryGetPropertyValue(nameof(StartupObject), out string startupObject);
        creator.TryGetPropertyValue(nameof(SubsystemVersion), out string subsystemVersion);
        creator.TryGetPropertyValue(nameof(TargetCompactFramework), out string targetCompactFramework);
        creator.TryGetPropertyValue(nameof(TargetFrameworkVersion), out string targetFrameworkVersion);
        creator.TryGetPropertyValue(nameof(TreatWarningsAsErrors), out string treatWarningsAsErrors);
        creator.TryGetPropertyValue(nameof(UseCommonOutputDirectory), out string useCommonOutputDirectory);
        creator.TryGetPropertyValue(nameof(UseHostCompilerIfAvailable), out string useHostCompilerIfAvailable);
        creator.TryGetPropertyValue(nameof(Utf8Output), out string utf8Output);
        creator.TryGetPropertyValue(nameof(VbcToolPath), out string vbcToolPath);
        creator.TryGetPropertyValue(nameof(VbcVerbosity), out string vbcVerbosity);
        creator.TryGetPropertyValue(nameof(VisualStudioVersion), out string visualStudioVersion);
        creator.TryGetPropertyValue(nameof(WarningsAsErrors), out string warningsAsErrors);
        creator.TryGetPropertyValue(nameof(WarningsNotAsErrors), out string warningsNotAsErrors);
        creator.TryGetPropertyValue(nameof(Win32Manifest), out string win32Manifest);
        creator.TryGetPropertyValue(nameof(Win32Resource), out string win32Resource);

        CommonMSBuildProperties result = new()
        {
            AdditionalLibPaths = additionalLibPaths,
            AddModules = addModules,
            ALToolPath = aLToolPath,
            ApplicationIcon = applicationIcon,
            ApplicationManifest = applicationManifest,
            AssemblyOriginatorKeyFile = assemblyOriginatorKeyFile,
            AssemblySearchPaths = assemblySearchPaths,
            AssemblyName = assemblyName,
            BaseAddress = baseAddress,
            BaseIntermediateOutputPath = baseIntermediateOutputPath,
            BaseOutputPath = baseOutputPath,
            BuildInParallel = buildInParallel,
            BuildProjectReferences = buildProjectReferences,
            CleanFile = cleanFile,
            CodePage = codePage,
            CompilerResponseFile = compilerResponseFile,
            Configuration = configuration,
            CscToolPath = cscToolPath,
            CustomBeforeMicrosoftCommonTargets = customBeforeMicrosoftCommonTargets,
            DebugSymbols = debugSymbols,
            DebugType = debugType,
            DefineConstants = defineConstants,
            DefineDebug = defineDebug,
            DefineTrace = defineTrace,
            DelaySign = delaySign,
            Deterministic = deterministic,
            DisableFastUpToDateCheck = disableFastUpToDateCheck,
            DocumentationFile = documentationFile,
            ErrorReport = errorReport,
            ExcludeDeploymentUrl = excludeDeploymentUrl,
            FileAlignment = fileAlignment,
            FrameworkPathOverride = frameworkPathOverride,
            GenerateDocumentation = generateDocumentation,
            GenerateFullPaths = generateFullPaths,
            GenerateSerializationAssemblies = generateSerializationAssemblies,
            IntermediateOutputPath = intermediateOutputPath,
            KeyContainerName = keyContainerName,
            KeyOriginatorFile = keyOriginatorFile,
            ModuleAssemblyName = moduleAssemblyName,
            MSBuildProjectExtensionsPath = mSBuildProjectExtensionsPath,
            NoLogo = noLogo,
            NoStdLib = noStdLib,
            NoVBRuntimeReference = noVBRuntimeReference,
            NoWarn = noWarn,
            NoWin32Manifest = noWin32Manifest,
            Optimize = optimize,
            OptionCompare = optionCompare,
            OptionExplicit = optionExplicit,
            OptionInfer = optionInfer,
            OptionStrict = optionStrict,
            OutDir = outDir,
            OutputPath = outputPath,
            OutputType = outputType,
            OverwriteReadOnlyFiles = overwriteReadOnlyFiles,
            PathMap = pathMap,
            PdbFile = pdbFile,
            Platform = platform,
            ProcessorArchitecture = processorArchitecture,
            ProduceOnlyReferenceAssembly = produceOnlyReferenceAssembly,
            ProduceReferenceAssembly = produceReferenceAssembly,
            RemoveIntegerChecks = removeIntegerChecks,
            RootNamespace = rootNamespace,
            Satellite_AlgorithmId = satelliteAlgorithmId,
            Satellite_BaseAddress = satelliteBaseAddress,
            Satellite_CompanyName = satelliteCompanyName,
            Satellite_Configuration = satelliteConfiguration,
            Satellite_Description = satelliteDescription,
            Satellite_EvidenceFile = satelliteEvidenceFile,
            Satellite_FileVersion = satelliteFileVersion,
            Satellite_Flags = satelliteFlags,
            Satellite_GenerateFullPaths = satelliteGenerateFullPaths,
            Satellite_LinkResource = satelliteLinkResource,
            Satellite_MainEntryPoint = satelliteMainEntryPoint,
            Satellite_ProductName = satelliteProductName,
            Satellite_ProductVersion = satelliteProductVersion,
            Satellite_TargetType = satelliteTargetType,
            Satellite_Title = satelliteTitle,
            Satellite_Trademark = satelliteTrademark,
            Satellite_Version = satelliteVersion,
            Satellite_Win32Icon = satelliteWin32Icon,
            Satellite_Win32Resource = satelliteWin32Resource,
            SGenToolPath = sGenToolPath,
            SGenUseProxyTypes = sGenUseProxyTypes,
            SkipInvalidConfigurations = skipInvalidConfigurations,
            StartupObject = startupObject,
            SubsystemVersion = subsystemVersion,
            TargetCompactFramework = targetCompactFramework,
            TargetFrameworkVersion = targetFrameworkVersion,
            TreatWarningsAsErrors = treatWarningsAsErrors,
            UseCommonOutputDirectory = useCommonOutputDirectory,
            UseHostCompilerIfAvailable = useHostCompilerIfAvailable,
            Utf8Output = utf8Output,
            VbcToolPath = vbcToolPath,
            VbcVerbosity = vbcVerbosity,
            VisualStudioVersion = visualStudioVersion,
            WarningsAsErrors = warningsAsErrors,
            WarningsNotAsErrors = warningsNotAsErrors,
            Win32Manifest = win32Manifest,
            Win32Resource = win32Resource,
        };

        return result;
    }
}
