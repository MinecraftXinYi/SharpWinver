using SharpWinver.ABI;
using SharpWinver.Core.Helpers;

namespace SharpWinver.Core;

public static class OnlineWinProductInfo
{
    public static string WindowsProductName
    {
        get
        {
            string? product = GetWindowsProductNameFromApi();
            product ??= GetWindowsProductNameFromRegistry();
            product ??= DefaultInfo.WindowsGeneric;
            return product;
        }
    }

    public static string? GetWindowsProductNameFromApi()
        => WinBrandApiHelper.IsWinBrandApiCallable ? WinBrandApi.BrandingFormatString(WinBrandApi.Variables.WindowsLong) : null;

    public static string? GetWindowsProductNameFromRegistry()
        => NTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "ProductName");

    public static uint? GetWindowsSKUIdFromApi(uint dwOSMajorVersion, uint dwOSMinorVersion)
        => WinProductApi.GetProductInfo(dwOSMajorVersion, dwOSMinorVersion, uint.MinValue, uint.MinValue, out uint product) ? product : null;

    public static string? GetWindowsSKUNameFromRegistry()
        => NTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "EditionID");

    public static string WindowsCopyrightString
        => WinBrandApiHelper.IsWinBrandApiCallable ? WinBrandApi.BrandingFormatString(WinBrandApi.Variables.WindowsCopyright) : DefaultInfo.DefaultMicrosoftCopyrightString;
}
