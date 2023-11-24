# Treasure.Build.CentralBuildOutput

[![CentralBuildOutput-CI](https://github.com/craigktreasure/CentralBuildOutput/actions/workflows/CI.yml/badge.svg)](https://github.com/craigktreasure/CentralBuildOutput/actions/workflows/CI.yml)
[![NuGet](https://img.shields.io/nuget/v/Treasure.Build.CentralBuildOutput)](https://www.nuget.org/packages/Treasure.Build.CentralBuildOutput/)
[![NuGet](https://img.shields.io/nuget/dt/Treasure.Build.CentralBuildOutput)](https://www.nuget.org/packages/Treasure.Build.CentralBuildOutput/)

- [Treasure.Build.CentralBuildOutput](#treasurebuildcentralbuildoutput)
  - [Centrally Managing Build Output](#centrally-managing-build-output)
    - [Build output](#build-output)
    - [Extensibility and configuration](#extensibility-and-configuration)
    - [Using with artifacts output](#using-with-artifacts-output)
  - [Controlling SDK versions](#controlling-sdk-versions)

The `Treasure.Build.CentralBuildOutput` MSBuild project SDK allows project tree owners to centralize their build
output in one place. By default, build output is placed in the project folder in `bin` and `obj` folders. This SDK
will cause all of the build output to be written to a common set of folders in a tree structure that mimics the project
structure.

This project was heavily inspired by the project SDKs from [MSBuildSdks][msbuild-sdks].

For more information about MSBuild project SDKs, see [here][msbuild-project-sdks].

## Centrally Managing Build Output

To get started, you will need to create a `Directory.Build.props` file at the root of your repository if you don't have
one already. In that file, you'll need to declare a `CentralBuildOutputPath` property with the value set to the path of
the location you want to write the build output. You'll then need to import the `Treasure.Build.CentralBuildOutput` SDK.

Example `Directory.Build.props`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Define the build output location. -->
    <CentralBuildOutputPath>$(MSBuildThisFileDirectory)</CentralBuildOutputPath>
  </PropertyGroup>

  <!-- Import the CentralBuildOutput SDK. -->
  <Sdk Name="Treasure.Build.CentralBuildOutput" Version="3.1.0" />
</Project>
```

> **Note:**
>
> The version number can be controlled in other ways. See [here](#controlling-sdk-versions).

### Build output

> **Note:**
>
> When using .NET 8 [artifacts output][artifacts-output], the build output will be different. See [below](#using-with-artifacts-output) for more details.

Build output folders written to the location defined by the `CentralBuildOutputPath` MSBuild property:

| Folder Name    | Description                                            |
| ---            | ---                                                    |
| __intermediate | The intermediate build output.                         |
| __output       | The build output.                                      |
| __packages     | The output of packages.                                |
| __publish      | The published output.                                  |
| __test-results | The output of test results including Coverlet reports. |

You can change the default prefix (`__`) by setting a new value to the `CentralBuildOutputFolderPrefix` MSBuild property.

Underneath these build output folders will be a tree structure that matches the tree structure of your project folders.

Consider the following project structure:

```text
/Directory.Build.props
/src/MyClassLibrary/MyClassLibrary.csproj
/src/MyClassLibrary.Tests/MyClassLibrary.Tests.csproj
```

The relative path between the root of your repository and your project will be calculated. For the structure above, the
relative path for **MyClassLibrary** is `src/MyClassLibrary`. A `Debug` build, publish, package, and test output would
look like the following:

```text
/__intermediate/src/MyClassLibrary/*
/__intermediate/src/MyClassLibrary.Tests/*
/__output/Debug/AnyCPU/src/MyClassLibrary/net6.0/*
/__output/Debug/AnyCPU/src/MyClassLibrary.Tests/net6.0/*
/__packages/NuGet/Debug/*
/__publish/Debug/AnyCPU/src/MyClassLibrary/*
/__test-results/src/MyClassLibrary.Tests/*
```

The relative path can be adjusted using the `CentralBuildOutputRelativeToPath` MSBuild property. For example:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Define the build output location. -->
    <CentralBuildOutputPath>$(MSBuildThisFileDirectory)</CentralBuildOutputPath>

    <!-- Adjust the relative path (eliminates the src folder in the build output tree). -->
    <CentralBuildOutputRelativeToPath>$(MSBuildThisFileDirectory)/src</CentralBuildOutputRelativeToPath>
  </PropertyGroup>

  <!-- Import the CentralBuildOutput SDK. -->
  <Sdk Name="Treasure.Build.CentralBuildOutput" Version="3.1.0" />
</Project>
```

This would result in the following build output:

```text
/__intermediate/MyClassLibrary/*
/__intermediate/MyClassLibrary.Tests/*
/__output/Debug/AnyCPU/MyClassLibrary/net6.0/*
/__output/Debug/AnyCPU/MyClassLibrary.Tests/net6.0/*
/__packages/NuGet/Debug/*
/__publish/Debug/AnyCPU/MyClassLibrary/*
/__test-results/MyClassLibrary.Tests/*
```

### Extensibility and configuration

Setting the following properties controls how Central Build Output works.

| Property                                | Description                                                                                          |
| ---                                     | ---                                                                                                  |
| `CentralBuildOutputPath` (Required)     | Defines the output path of the build output folders.                                                 |
| `CentralBuildOutputConfigPlatLast`      | Places the configuration and platform at the end of the path if set to `true`.                       |
| `CentralBuildOutputFolderPrefix`        | Overrides the output folder prefix. Default is `__`.                                                 |
| `CentralBuildOutputNoDefaultPlatform`   | Omits the default platform name in the output path unless necessary if set to `true`.                |
| `CentralBuildOutputNoPlatform`          | Omits the platform from the output path if set to `true`.                                            |
| `CentralBuildOutputRelativeToPath`      | Redefines the root folder used to calculate the relative folder used in build output folders.        |
| `CustomBeforeCentralBuildOutputProps`   | A list of custom MSBuild projects to import **before** central build output properties are declared. |
| `CustomAfterCentralBuildOutputProps`    | A list of custom MSBuild projects to import **after** central build output properties are declared.  |
| `CustomBeforeCentralBuildOutputTargets` | A list of custom MSBuild projects to import **before** central build output targets are declared.    |
| `CustomAfterCentralBuildOutputTargets`  | A list of custom MSBuild projects to import **after** central build output targets are declared.     |
| `EnableCentralBuildOutput`              | Indicates whether central build output is enabled or not. Set to `false` to disable.                 |

### Using with artifacts output

Since .NET 8's new [artifacts output][artifacts-output] accomplishes many of the same goals as
`Treasure.Build.CentralBuildOutput`, the SDK will behave differently when used in conjunction with artifacts output.
Specifically, no changes will be made to artifacts output except that test results and
[coverlet code coverage][coverlet] output will be output to a `test-results` directory underneath the artifacts output
path.

[Artifacts output][artifacts-output] can be enabled by setting:

```xml
<UseArtifactsOutput>true</UseArtifactsOutput>
```

The artifact output path can also be configured by setting the `ArtifactsPath` property:

```xml
<ArtifactsPath>$(MSBuildThisFileDirectory)__artifacts</ArtifactsPath>
```

The `ArtifactsPath` property would be used instead of setting the `CentralBuildOutputPath` property. None of the
`CentralBuildOutput*` properties defined in [extensibility and configuration](#extensibility-and-configuration) will
have any effect, but the rest still work.

A simple example `Directory.Build.props` would be:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Define the build output location. -->
    <UseArtifactsOutput>true</UseArtifactsOutput>
    <ArtifactsPath>$(MSBuildThisFileDirectory)__artifacts</ArtifactsPath>
  </PropertyGroup>

  <!-- Import the CentralBuildOutput SDK. -->
  <Sdk Name="Treasure.Build.CentralBuildOutput" Version="3.1.0" />
</Project>
```

## Controlling SDK versions

For more detailed information, see the [MSBuild documentation][msbuild-project-sdks].

When using an MSBuild Project SDK obtained via NuGet (such as the SDK in this repo) a specific version **must** be
specified.

Specify the version number as an attribute of the SDK import:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  ...
  <Sdk Name="Treasure.Build.CentralBuildOutput" Version="3.1.0" />
  ...
</Project>
```

Or, omit the version from the SDK attribute and specify it in the version in `global.json`, which can be useful to
synchronize versions across multiple projects in a solution:

```json
{
  ...
  "msbuild-sdks": {
    "Treasure.Build.CentralBuildOutput" : "3.1.0"
  }
}
```

[artifacts-output]: https://learn.microsoft.com/en-us/dotnet/core/sdk/artifacts-output "Artifacts output layout"
[coverlet]: https://github.com/coverlet-coverage/coverlet "Coverlet"
[msbuild-project-sdks]: https://learn.microsoft.com/visualstudio/msbuild/how-to-use-project-sdk "Use MSBuild project SDKs"
[msbuild-sdks]: https://github.com/microsoft/MSBuildSdks
