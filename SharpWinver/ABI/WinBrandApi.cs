using System.Runtime.InteropServices;

namespace SharpWinver.ABI;

public static class WinBrandApi
{
    [DllImport(WinDllName.WinBrand, CharSet = CharSet.Unicode, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    public static extern string BrandingFormatString(string format);

    public static class Variables
    {
        public const string
            WindowsLong = "%WINDOWS_LONG%",
            WindowsCopyright = "%WINDOWS_COPYRIGHT%",
            WindowsProduct = "%WINDOWS_PRODUCT%",
            WindowsShort = "%WINDOWS_SHORT%",
            MicrosoftCompanyName = "%MICROSOFT_COMPANYNAME%",
            WindowsGeneric = "%WINDOWS_GENERIC%";
    }
}
