using System;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace SharpWinver.Core.NativeInterop;

internal static class Krnl32ProcApi
{
    internal static HANDLE GetCurrentProcess()
    {
        try
        {
            [DllImport(WinDll.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern HANDLE GetCurrentProcess();
            return GetCurrentProcess();
        }
        catch (Exception)
        {
            [DllImport(WinDll.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern HANDLE GetCurrentProcess();
            return GetCurrentProcess();
        }
    }

    internal static BOOL CloseHandle(HANDLE hObject)
    {
        try
        {
            [DllImport(WinDll.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern BOOL CloseHandle(HANDLE hObject);
            return CloseHandle(hObject);
        }
        catch (Exception)
        {
            return PInvoke.CloseHandle(hObject);
        }
    }
}
