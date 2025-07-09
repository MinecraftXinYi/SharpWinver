using System.Runtime.InteropServices;

namespace SharpWinver.Core.NativeInterop;

public static class RtlNTVersionApi
{
    [DllImport(WinDll.NTDLL)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern void RtlGetNtVersionNumbers(out uint major, out uint minor, out uint buildraw);

    public static uint CorrectBuildNumber(uint buildraw)
        => buildraw & 0xffff;
}
