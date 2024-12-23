namespace Treasure.Build.CentralBuildOutput.Tests;

using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Logging;

using Treasure.Build.CentralBuildOutput.Tests.Extensions;

using Xunit;

internal sealed class TestProjectOutput : IDisposable
{
    /// <summary>
    /// Gets the output path.
    /// </summary>
    public string OutputPath { get; }

    /// <summary>
    /// Gets the <see cref="OutputPath"/> with path separators normalized to '/'.
    /// </summary>
    public string OutputPathNormalized => this.OutputPath.ToPosixPath();

    private TestProjectOutput(string outputPath) => this.OutputPath = outputPath;

    public static TestProjectOutput CreateInTemp(ITestOutputHelper outputHelper)
        => CreateInTemp(outputHelper.BuildLoggerFor<TestProjectOutput>());

    public static TestProjectOutput CreateInTemp(ILogger logger)
        => CreateInTemp(logger, "CentralBuildOutputTests", Path.GetRandomFileName());

    public static implicit operator string(TestProjectOutput value) => value.OutputPath;

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    public override string ToString() => this.OutputPath;

    private static TestProjectOutput CreateInTemp(ILogger logger, params string[] paths)
    {
        string tempPath = ResolveTempPath(logger);
        string outputPath = Path.Combine(paths.Prepend(tempPath).ToArray());

        if (!Path.EndsInDirectorySeparator(outputPath))
        {
            outputPath += Path.DirectorySeparatorChar;
        }

        Directory.CreateDirectory(outputPath);
        Environment.CurrentDirectory = outputPath;
        return new TestProjectOutput(outputPath);
    }

    [SuppressMessage("Performance", "CA1848:Use the LoggerMessage delegates")]
    private static string ResolveTempPath(ILogger logger)
    {
        // The Path.GetTempPath is problematic on macOS machines as it can returns values that are hard to resolve and
        // compare to later. We use the RUNNER_TEMP environment variable when available to get a more reliable temp path.
        string tempPath = Environment.GetEnvironmentVariable("RUNNER_TEMP") ?? Path.GetTempPath();

        logger.LogInformation("Temp path: {TempPath}", tempPath);

        return tempPath;
    }

    [SuppressMessage("Design", "CA1031:Do not catch general exception types")]
    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (Directory.Exists(this.OutputPath))
            {
                try
                {
                    Directory.Delete(this.OutputPath, recursive: true);
                }
                catch
                {
                    try
                    {
                        Thread.Sleep(500);

                        Directory.Delete(this.OutputPath, recursive: true);
                    }
                    catch
                    {
                        // Ignored
                    }
                }
            }
        }
    }
}
