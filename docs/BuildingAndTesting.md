# Building and testing

## Requirements

### Using Visual Studio

* [Visual Studio 2022 17.4+][download-vs]
  * You'll also need the [.NET 6 SDK][download-dotnet-6-sdk] and [.NET 7 SDK][download-dotnet-7-sdk].

### Using Visual Studio Code

* [Visual Studio Code][download-vs-code]
  * Install recommended extensions.
* [.NET 6 SDK][download-dotnet-6-sdk]
* [.NET 7 SDK][download-dotnet-7-sdk]

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

[download-dotnet-6-sdk]: https://dotnet.microsoft.com/download/dotnet/6.0 "Download .NET 6.0"
[download-dotnet-7-sdk]: https://dotnet.microsoft.com/download/dotnet/7.0 "Download .NET 7.0"
[download-vs]: https://visualstudio.microsoft.com/downloads/ "Download Visual Studio"
[download-vs-code]: https://code.visualstudio.com/Download "Download Visual Studio Code"
