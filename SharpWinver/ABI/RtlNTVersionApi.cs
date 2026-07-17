using System.Runtime.InteropServices;

namespace SharpWinver.ABI;

public static class RtlNTVersionApi
{
    [DllImport(WinDllName.NTDLL)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern void RtlGetNtVersionNumbers(out uint major, out uint minor, out uint buildraw);

    public static uint CorrectRtlNtBuildNumber(uint buildraw)
        => buildraw & 0xffff;
}
