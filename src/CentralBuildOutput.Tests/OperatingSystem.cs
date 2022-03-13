namespace Treasure.Build.CentralBuildOutput.Tests;

#if NETCOREAPP3_1
using System.Runtime.InteropServices;
#endif

internal static class OperatingSystem
{
    public static bool IsLinux() =>
#if NET5_0_OR_GREATER
        System.OperatingSystem.IsLinux();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#endif

    public static bool IsMacOS() =>
#if NET5_0_OR_GREATER
        System.OperatingSystem.IsMacOS();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#endif

    public static bool IsWindows() =>
#if NET5_0_OR_GREATER
        System.OperatingSystem.IsWindows();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif
}
