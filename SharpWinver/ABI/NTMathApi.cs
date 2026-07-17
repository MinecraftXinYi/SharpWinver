using System.Runtime.InteropServices;

namespace SharpWinver.ABI;

internal static class NTMathApi
{
    [DllImport(WinDllName.NTDLL, CallingConvention = CallingConvention.StdCall)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static extern double sin(double x);
}
