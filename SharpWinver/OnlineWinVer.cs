using SharpWinver.ABI;
using SharpWinver.Core;
using System;
using System.Runtime.InteropServices;

namespace SharpWinver;

/// <summary>
/// 获取联机 Windows 系统副本的版本信息
/// </summary>
public sealed class OnlineWinVer : IWinVer
{
    /// <summary>
    /// 检测当前运行的操作系统是否基于 Windows NT 内核
    /// (只有基于或模拟 Windows NT 内核的操作系统才能正常调用该类中的方法)
    /// </summary>
    public static bool IsWindowsNT
    {
        get
        {
            try
            {
                NTMathApi.sin(default);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public OnlineWinVer()
    {
        OSVersion = new(WinNTVersion.Major, WinNTVersion.Minor, WinNTVersion.Build, (int)OnlineWinVersionInfo.WindowsRevisionNumber);
    }

    public string Edition { get; } = GetWindowsEditionForCurrent();

    public WindowsSKU SKU { get; } = GetWindowsSKUForCurrent();

    public Architecture OSArchitecture { get; } = OnlineWinProcArchInfo.NTOSArchitecture;

    public Version OSVersion { get; }

    public Version WinNTVersion { get; } = GetWinNTVersionForCurrent();

    public string VersionTag { get; } = OnlineWinVersionInfo.WindowsVersionTag ?? string.Empty;

    public static string GetWindowsEditionForCurrent()
    {
        string product = OnlineWinProductInfo.WindowsProductName;
        if (product == DefaultInfo.WindowsGeneric) product = $"{product} {GetWindowsSKUForCurrent()}";
        return product;
    }

    public static WindowsSKU GetWindowsSKUForCurrent()
    {
        uint[] ver = OnlineWinVersionInfo.GetWinNTVersionNumbersFromApi();
        WindowsSKU? sku = (WindowsSKU?)OnlineWinProductInfo.GetWindowsSKUIdFromApi(ver[0], ver[1]);
        if (!sku.HasValue)
        {
            string? name = OnlineWinProductInfo.GetWindowsProductNameFromRegistry();
            if (string.IsNullOrEmpty(name)) sku = WindowsSKU.Undefined;
            else
            {
                WindowsSKU.TryParse(name, out WindowsSKU parsed);
                sku = parsed;
            }
        }
        return sku.Value;
    }

    public static Version GetWinNTVersionForCurrent()
    {
        uint[] version = OnlineWinVersionInfo.WinNTVersionNumbers;
        return new((int)version[0], (int)version[1], (int)version[2]);
    }
}
