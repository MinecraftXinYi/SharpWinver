using SharpWinver.ABI;
using SharpWinver.Core.Helpers;
using System;

namespace SharpWinver.Core;

public unsafe static class OnlineWinVersionInfo
{
    public static uint[] WinNTVersionNumbers
    {
        get
        {
            uint[]? version = GetWinNTVersionNumbersFromKernelData();
            if (version == null) version = GetWinNTVersionNumbersFromApi();
            else if (version[2] == uint.MinValue) version[2] = GetWinNTVersionNumbersFromApi()[2];
            return version;
        }
    }

    public static uint[] GetWinNTVersionNumbersFromApi()
    {
        RtlNTVersionApi.RtlGetNtVersionNumbers(out uint major, out uint minor, out uint buildraw);
        uint build = RtlNTVersionApi.CorrectRtlNtBuildNumber(buildraw);
        return new uint[] { major, minor, build };
    }

    public static uint[]? GetWinNTVersionNumbersFromKernelData()
    {
        uint major, minor, build;
        try
        {
            major = *(uint*)NTKernelDataAddress.KUSER_SHARED_DATA_NtMajorVersion;
            minor = *(uint*)NTKernelDataAddress.KUSER_SHARED_DATA_NtMinorVersion;
        }
        catch (Exception)
        {
            return null;
        }
        try
        {
            build = *(uint*)NTKernelDataAddress.KUSER_SHARED_DATA_NtBuildNumber;
        }
        catch (Exception)
        {
            build = uint.MinValue;
        }
        return new uint[] { major, minor, build };
    }

    public static string? WindowsVersionTag
    {
        get
        {
            string? version = NTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "DisplayVersion");
            version ??= NTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "ReleaseId");
            version ??= NTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "CSDVersion");
            return version;
        }
    }

    public static uint WindowsRevisionNumber
    {
        get
        {
            uint? revision = NTRegistryValueReader.GetDwordValue(WinInfoRegPath.WinNTCurrentVersion, "UBR");
            revision ??= NTRegistryValueReader.GetDwordValue(WinInfoRegPath.WinNTCurrentVersion, "BaseBuildRevisionNumber");
            return revision.GetValueOrDefault();
        }
    }
}
