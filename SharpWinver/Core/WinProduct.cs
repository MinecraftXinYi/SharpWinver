namespace SharpWinver.Core;

using NativeInterop;

public static class WinProduct
{
    public static string? GetWindowsProductName()
    {
        if (!WinBrand.IsBrandApiCallable) return null;
        return WinBrand.BrandingFormatString(WinBrand.WindowsLong);
    }

    public static string? GetWindowsProductNameFromRegistry()
        => WinNTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "ProductName");

    public static WindowsSKU GetWindowsSKU(uint dwOSMajorVersion, uint dwOSMinorVersion)
    {
        if (!WinProductApi.GetProductInfo(dwOSMajorVersion, dwOSMinorVersion, 0, 0, out uint productType)) return WindowsSKU.Undefined;
        if (!WindowsSKU.TryParse(productType.ToString(), out WindowsSKU windowsSku)) return WindowsSKU.Undefined;
        return windowsSku;
    }

    public static WindowsSKU GetWindowsSKUFromRegistry()
    {
        string editionID = WinNTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "EditionID")!;
        if (string.IsNullOrEmpty(editionID)) return WindowsSKU.Undefined;
        if (!WindowsSKU.TryParse(editionID, out WindowsSKU windowsSku)) return WindowsSKU.Undefined;
        return windowsSku;
    }

    public static string? GetWindowsCopyrightString()
    {
        if (!WinBrand.IsBrandApiCallable) return null;
        return WinBrand.BrandingFormatString(WinBrand.WindowsCopyright);
    }
}
