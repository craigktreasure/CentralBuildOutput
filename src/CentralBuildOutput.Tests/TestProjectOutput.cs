namespace Treasure.Build.CentralBuildOutput.Tests;

using System;
using System.Diagnostics.CodeAnalysis;

internal class TestProjectOutput : IDisposable
{
    public string OutputPath { get; }

    private TestProjectOutput(string outputPath) => this.OutputPath = outputPath;

    public static implicit operator string(TestProjectOutput value) => value.OutputPath;

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    [SuppressMessage("Design", "CA1031:Do not catch general exception types")]
    protected virtual void Dispose(bool disposing)
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

    public static TestProjectOutput CreateInTemp()
        => CreateInTemp("CentralBuildOutputTests", Path.GetRandomFileName());

    public static TestProjectOutput CreateInTemp(params string[] paths)
    {
        string outputPath = Path.Combine(paths.Prepend(Path.GetTempPath()).ToArray());
        Directory.CreateDirectory(outputPath);
        Environment.CurrentDirectory = outputPath;
        return new TestProjectOutput(outputPath);
    }
}
