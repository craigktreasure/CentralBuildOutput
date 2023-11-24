# Building and testing

## Requirements

### Using Visual Studio

* [Visual Studio 2022 17.8+][download-vs]
  * You'll also need the [.NET 6 SDK][download-dotnet-6-sdk], [.NET 7 SDK][download-dotnet-7-sdk], and [.NET 8 SDK][download-dotnet-8-sdk].

### Using Visual Studio Code

* [Visual Studio Code][download-vs-code]
  * Install recommended extensions.
* [.NET 6 SDK][download-dotnet-6-sdk]
* [.NET 7 SDK][download-dotnet-7-sdk]
* [.NET 8 SDK][download-dotnet-8-sdk]

## Build the SDK

To build the project SDK, run the following command:

``` shell
dotnet build
```

## Run the tests

To run all the tests, simply run the following command:

``` shell
dotnet test
```

## Helpful tips

There are a bunch of helpful [tips for MSBuild][msbuild-tips]. One of those tips is the `-preprocess[:filepath]` or
`-pp[:filepath]` to create a single aggregated project file that inlines all of the files that would be imported during
a build. There are more details in the [MSBuild command-line reference][msbuild-cli-reference].

[download-dotnet-6-sdk]: https://dotnet.microsoft.com/download/dotnet/6.0 "Download .NET 6.0"
[download-dotnet-7-sdk]: https://dotnet.microsoft.com/download/dotnet/7.0 "Download .NET 7.0"
[download-dotnet-8-sdk]: https://dotnet.microsoft.com/download/dotnet/8.0 "Download .NET 8.0"
[download-vs]: https://visualstudio.microsoft.com/downloads/ "Download Visual Studio"
[download-vs-code]: https://code.visualstudio.com/Download "Download Visual Studio Code"
[msbuild-tips]: https://github.com/dotnet/msbuild/blob/main/documentation/wiki/MSBuild-Tips-&-Tricks.md "MSBuild Command-Line Switches"
[msbuild-cli-reference]: https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference?view=vs-2022 "MSBuild command-line reference"
