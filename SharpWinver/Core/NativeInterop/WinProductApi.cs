using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;

namespace SharpWinver.Core.NativeInterop;

public static class WinProductApi
{
    public static bool GetProductInfo(uint dwOSMajorVersion, uint dwOSMinorVersion, uint dwSpMajorVersion, uint dwSpMinorVersion, out uint dwReturnedProductType)
    {
        try
        {
            [DllImport(WinDll.KernelBase, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern BOOL GetProductInfo(uint dwOSMajorVersion, uint dwOSMinorVersion, uint dwSpMajorVersion, uint dwSpMinorVersion, out uint dwReturnedProductType);
            BOOL result = GetProductInfo(dwOSMajorVersion, dwOSMinorVersion, dwSpMajorVersion, dwSpMinorVersion, out dwReturnedProductType);
            return result;
        }
        catch (Exception)
        {
            [DllImport(WinDll.Kernel32, SetLastError = true)]
            [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
            static extern BOOL GetProductInfo(uint dwOSMajorVersion, uint dwOSMinorVersion, uint dwSpMajorVersion, uint dwSpMinorVersion, out uint dwReturnedProductType);
            BOOL result = GetProductInfo(dwOSMajorVersion, dwOSMinorVersion, dwSpMajorVersion, dwSpMinorVersion, out dwReturnedProductType);
            return result;
        }
    }
}
