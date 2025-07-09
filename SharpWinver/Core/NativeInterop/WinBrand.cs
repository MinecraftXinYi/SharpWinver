using System;
using System.Runtime.InteropServices;

namespace SharpWinver.Core.NativeInterop;

public static class WinBrand
{
    [DllImport(WinDll.WinBrand, CharSet = CharSet.Unicode, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern string BrandingFormatString(string format);

    public const string WindowsLong = "%WINDOWS_LONG%";
    public const string WindowsCopyright = "%WINDOWS_COPYRIGHT%";
    public const string WindowsProduct = "%WINDOWS_PRODUCT%";
    public const string WindowsShort = "%WINDOWS_SHORT%";
    public const string MicrosoftCompanyName = "%MICROSOFT_COMPANYNAME%";
    public const string WindowsGeneric = "%WINDOWS_GENERIC%";

    public static bool IsBrandApiCallable
    {
        get
        {
            try
            {
                string? tryGetContent = BrandingFormatString(WindowsGeneric);
                if (tryGetContent != null) return tryGetContent.Length > 0;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
