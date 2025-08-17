using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.System.SystemInformation;

namespace SharpWinver.Core.NativeInterop;

internal unsafe static class WinOSArchApi
{
    internal static void GetNativeSystemInfo(SYSTEM_INFO* lpSystemInfo)
    {
        try
        {
            [DllImport(WinDll.KernelBase, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern void GetNativeSystemInfo(SYSTEM_INFO* lpSystemInfo);
            GetNativeSystemInfo(lpSystemInfo);
        }
        catch (Exception)
        {
            [DllImport(WinDll.Kernel32, ExactSpelling = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern void GetNativeSystemInfo(SYSTEM_INFO* lpSystemInfo);
            GetNativeSystemInfo(lpSystemInfo);
        }
    }

    internal static BOOL IsWow64Process2(HANDLE hProcess, IMAGE_FILE_MACHINE* pProcessMachine, IMAGE_FILE_MACHINE* pNativeMachine)
    {
        try
        {
            [DllImport(WinDll.KernelBase, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern BOOL IsWow64Process2(HANDLE hProcess, IMAGE_FILE_MACHINE* pProcessMachine, IMAGE_FILE_MACHINE* pNativeMachine);
            return IsWow64Process2(hProcess, pProcessMachine, pNativeMachine);
        }
        catch (Exception)
        {
            [DllImport(WinDll.Kernel32, ExactSpelling = true, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern BOOL IsWow64Process2(HANDLE hProcess, IMAGE_FILE_MACHINE* pProcessMachine, IMAGE_FILE_MACHINE* pNativeMachine);
            return IsWow64Process2(hProcess, pProcessMachine, pNativeMachine);
        }
    }
}
