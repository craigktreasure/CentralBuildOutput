namespace Treasure.Build.CentralBuildOutput.Tests;

using System;

internal static class StringExtensions
{
    private static readonly char[] trimCharacters = new[] { '/', '\\' };

    public static string MakeRelative(this string path, string rootPath)
    {
        if (!Path.IsPathFullyQualified(path))
        {
            throw new ArgumentException($"The path is not fully qualified: {path}.", nameof(path));
        }

        string result = path;

        if (path.StartsWith(rootPath, StringComparison.Ordinal))
        {
            result = result[rootPath.Length..].TrimStart(trimCharacters);
        }

        return result;
    }

    public static string ToPosixPath(this string path)
        => path.Replace('\\', '/');
}
