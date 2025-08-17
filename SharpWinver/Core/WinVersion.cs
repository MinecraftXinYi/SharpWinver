using System;

namespace SharpWinver.Core;

using NativeInterop;

public static class WinVersion
{
    public static uint[] GetWinNTVersionNumbers()
    {
        RtlNTVersionApi.RtlGetNtVersionNumbers(out uint major, out uint minor, out uint buildraw);
        uint build = RtlNTVersionApi.CorrectRtlNtBuildNumber(buildraw);
        return new uint[] { major, minor, build };
    }

    public unsafe static uint[] GetWinNTVersionNumbersFromKernelData()
    {
        uint major = *(uint*)NTKernelOSData.KUSER_SHARED_DATA_NtMajorVersion;
        uint minor = *(uint*)NTKernelOSData.KUSER_SHARED_DATA_NtMinorVersion;
        uint build;
        try
        {
            build = *(uint*)NTKernelOSData.KUSER_SHARED_DATA_NtBuildNumber;
        }
        catch (Exception)
        {
            build = 0;
        }
        return new uint[] { major, minor, build };
    }

    public static string? GetWindowsVersionTag()
    {
        string? version = WinNTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "DisplayVersion");
        version ??= WinNTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "ReleaseId");
        version ??= WinNTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "CSDVersion");
        return version;
    }

    public static uint? GetWindowsRevisionNumber()
    {
        uint? revision = WinNTRegistryValueReader.GetDwordValue(WinInfoRegPath.WinNTCurrentVersion, "UBR");
        revision ??= WinNTRegistryValueReader.GetDwordValue(WinInfoRegPath.WinNTCurrentVersion, "BaseBuildRevisionNumber");
        return revision;
    }
}
