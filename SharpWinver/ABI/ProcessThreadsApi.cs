using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace SharpWinver.ABI;

internal static class ProcessThreadsApi
{
    internal static HANDLE GetCurrentProcess()
    {
        try
        {
            [DllImport(WinDllName.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern HANDLE GetCurrentProcess();
            return GetCurrentProcess();
        }
        catch (Exception)
        {
            [DllImport(WinDllName.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern HANDLE GetCurrentProcess();
            return GetCurrentProcess();
        }
    }
}
