namespace Treasure.Build.CentralBuildOutput.Tests;

using System;
using System.Diagnostics.CodeAnalysis;

using Treasure.Build.CentralBuildOutput.Tests.Extensions;

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

    public static TestProjectOutput CreateInTemp()
        => CreateInTemp("CentralBuildOutputTests", Path.GetRandomFileName());

    public static TestProjectOutput CreateInTemp(params string[] paths)
    {
        string tempPath = ResolveTempPath();
        string outputPath = Path.Combine(paths.Prepend(tempPath).ToArray());

        if (!Path.EndsInDirectorySeparator(outputPath))
        {
            outputPath += Path.DirectorySeparatorChar;
        }

        Directory.CreateDirectory(outputPath);
        Environment.CurrentDirectory = outputPath;
        return new TestProjectOutput(outputPath);
    }

    public static implicit operator string(TestProjectOutput value) => value.OutputPath;

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    public override string ToString() => this.OutputPath;

    private static string ResolveTempPath()
    {
        string tempPath = Path.GetTempPath();

        if (OperatingSystem.IsMacOS())
        {
            // macOS can sometimes use an environment variable that maps to a
            // symlink. This prevents us from getting the full path that is
            // actually used later in msbuild. We need to resolve the full
            // path so that our tests can compare apples to apples.
            tempPath = Mono.Unix.UnixPath.GetCompleteRealPath(tempPath);
        }

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
