# .NET SDKs

The MSBuild project SDKs here are used to configure and extend your build. They
were heavily inspired by the SDKs from [MSBuildSdks](https://github.com/microsoft/MSBuildSdks).

## What SDKs are available?

### [Treasure.Build.CentralBuildOutput](./src/CentralBuildOutput/)

Automatically configure build output for .NET projects.

## How can I use these SDKs?

For detailed information, [read the documentation](https://docs.microsoft.com/visualstudio/msbuild/how-to-use-project-sdk).

When using an MSBuild Project SDK obtained via NuGet (such as the SDKs in this repo) a specific version **must** be
specified.

Either append the version to the package name:

```xml
<Project Sdk="Treasure.Build.CentralBuildOutput/1.0.0">
  ...
</Project>
```

Import in an MSBuild project file:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  ...
  <Sdk Name="Treasure.Build.CentralBuildOutput" Version="1.0.0" />
  ...
</Project>
```

Or omit the version from the SDK attribute and specify it in the version in `global.json`, which can be useful to
synchronize versions across multiple projects in a solution:

```json
{
  ...
  "msbuild-sdks": {
    "Treasure.Build.CentralBuildOutput" : "1.0.0"
  }
}
```

Since MSBuild 15.6, SDKs are downloaded as NuGet packages automatically. Earlier versions of MSBuild 15 required SDKs to
be installed.

Again, for more information, [read the documentation](https://docs.microsoft.com/visualstudio/msbuild/how-to-use-project-sdk).

## What are MSBuild SDKS?

MSBuild 15.0 introduced new project XML for .NET Core that we refer to as SDK-style. These SDK-style projects looks like:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net46</TargetFramework>
  </PropertyGroup>
</Project>
```

At evaluation time, MSBuild adds implicit imports at the top and bottom of the project like this:

```xml
<Project>
    <!-- Implicit top import -->
    <Import Project="Sdk.props" Sdk="Microsoft.NET.Sdk" />

    <PropertyGroup>
        <TargetFramework>net46</TargetFramework>
    </PropertyGroup>

    <!-- Implicit bottom import -->
    <Import Project="Sdk.targets" Sdk="Microsoft.NET.Sdk" />
</Project>
```
