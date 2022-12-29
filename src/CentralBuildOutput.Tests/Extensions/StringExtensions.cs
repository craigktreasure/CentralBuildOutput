namespace Treasure.Build.CentralBuildOutput.Tests.Extensions;

using System;

internal static class StringExtensions
{
    public static string MakeRelative(this string path, string rootPath)
    {
        if (!Path.IsPathFullyQualified(path))
        {
            throw new ArgumentException($"The path is not fully qualified: '{path}'.", nameof(path));
        }

        string result = path;

        if (path.StartsWith(rootPath, StringComparison.Ordinal))
        {
            result = result[rootPath.Length..];
        }

        return result;
    }

    public static string ToPosixPath(this string path)
        => path.Replace('\\', '/');
}
