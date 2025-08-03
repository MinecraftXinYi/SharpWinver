namespace SharpWinver.Core;

using NativeInterop;

public static class WinVersion
{
    public static uint[] GetWinNTVersionNumbers()
    {
        RtlNTVersionApi.RtlGetNtVersionNumbers(out uint major, out uint minor, out uint buildraw);
        uint build = RtlNTVersionApi.CorrectBuildNumber(buildraw);
        return new uint[] { major, minor, build };
    }

    public unsafe static uint[] GetWinNTVersionNumbersFromKernelData()
    {
        uint major = *(uint*)NTKernelOSData.KUSER_SHARED_DATA_NtMajorVersion;
        uint minor = *(uint*)NTKernelOSData.KUSER_SHARED_DATA_NtMinorVersion;
        return new uint[] { major, minor };
    }

    public static string? GetWindowsVersionTag()
    {
        string? version = WinNTRegistryValueReader.GetStringValue(RegistryPath.WinNTCurrentVersion, "DisplayVersion");
        version ??= WinNTRegistryValueReader.GetStringValue(RegistryPath.WinNTCurrentVersion, "ReleaseId");
        version ??= WinNTRegistryValueReader.GetStringValue(RegistryPath.WinNTCurrentVersion, "CSDVersion");
        return version;
    }

    public static uint? GetWindowsRevisionNumber()
    {
        uint? revision = WinNTRegistryValueReader.GetDwordValue(RegistryPath.WinNTCurrentVersion, "UBR");
        revision ??= WinNTRegistryValueReader.GetDwordValue(RegistryPath.WinNTCurrentVersion, "BaseBuildRevisionNumber");
        return revision;
    }
}
