# CLAUDE.md

This file provides guidance to AI agents when working with code in this repository.

## Project Overview

This repository contains `Treasure.Build.CentralBuildOutput`, an MSBuild project SDK that centralizes build output for .NET projects. Instead of placing `bin` and `obj` folders in each project directory, this SDK writes all build output to a common location with a tree structure mirroring the project structure.

## Build Commands

```shell
# Build the SDK
dotnet build

# Run all tests
dotnet test

# Run tests for a specific framework
dotnet test --framework net9.0
```

## Project Structure

- `src/CentralBuildOutput/` - The MSBuild SDK package (uses `Microsoft.Build.NoTargets`)
  - `Sdk/Sdk.props` - Entry point props imported by consuming projects
  - `Sdk/Sdk.targets` - Entry point targets that conditionally imports the appropriate configuration
  - `Sdk/ConfigureBuildOutput.targets` - Core logic for redirecting build output paths
  - `Sdk/ConfigureBuildOutputForArtifacts.targets` - Configuration when using .NET 8+ artifacts output
- `src/CentralBuildOutput.Tests/` - xUnit tests using `MSBuild.ProjectCreation` for in-memory MSBuild testing
- `samples/CentralBuildOutput/` - Sample projects demonstrating SDK usage
- `eng/` - Build infrastructure (analyzers, defaults, packaging configuration)

## Key Architecture Details

**SDK Entry Points**: The SDK uses standard MSBuild SDK conventions with `Sdk.props` and `Sdk.targets` files that get automatically imported when a project references the SDK.

**Two Modes of Operation**:

1. **Standard mode** (`ConfigureBuildOutput.targets`): Redirects `BaseIntermediateOutputPath`, `BaseOutputPath`, `OutputPath`, `PublishDir`, etc. to centralized folders prefixed with `__` (configurable via `CentralBuildOutputFolderPrefix`)
2. **Artifacts mode** (`ConfigureBuildOutputForArtifacts.targets`): When `UseArtifactsOutput=true`, defers to .NET 8+ artifacts output but still centralizes test results

**Path Calculation**: The SDK calculates `RelativeProjectPath` by determining the relative path from `CentralBuildOutputPath` (or `CentralBuildOutputRelativeToPath` if set) to the project directory, preserving the folder hierarchy in output.

**This Repo's Own Build**: Uses .NET 8+ artifacts output (`UseArtifactsOutput=true`) with `ArtifactsPath` set to `__artifacts`.

## Testing Approach

Tests use `MSBuild.ProjectCreation` to create in-memory MSBuild projects and verify that the SDK correctly sets output path properties. The test project copies SDK files to its output directory to enable testing.

## Versioning

Uses Nerdbank.GitVersioning for version management.

## Coding style

The project adheres to styles defined in `.editorconfig`.
