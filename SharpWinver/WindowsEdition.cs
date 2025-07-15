using System.Runtime.InteropServices;

namespace SharpWinver;

using Core;
using Core.NativeInterop;

public static partial class Winver
{
    /// <summary>
    /// 当前运行的 Windows 系统 SKU
    /// </summary>
    public static class WindowsEdition
    {
        public static WindowsSKU GetWindowsSKUGlobal()
        {
            RtlNTVersionApi.RtlGetNtVersionNumbers(out uint major, out uint minor, out _);
            WindowsSKU windowsSku = WinProduct.GetWindowsSKU(major, minor);
            if (windowsSku == WindowsSKU.Undefined) windowsSku = WinProduct.GetWindowsSKUFromRegistry();
            return windowsSku;
        }

        /// <summary>
        /// Windows SKU 内部名称
        /// </summary>
        public static string SKU => GetWindowsSKUGlobal().ToString();

        /// <summary>
        /// Windows SKU 显示名称
        /// </summary>
        public static string OSEdition
        {
            get
            {
                string osEdition = WinProduct.GetWindowsProductName()!;
                if (string.IsNullOrEmpty(osEdition)) osEdition = WinProduct.GetWindowsProductNameFromRegistry()!;
                if (string.IsNullOrEmpty(osEdition)) osEdition = $"{DefaultInfoStrings.WindowsGeneric} {SKU}";
                return osEdition;
            }
        }

        /// <summary>
        /// 操作系统平台架构
        /// </summary>
        public static Architecture OSArchitecture
        {
            get
            {
                Architecture? architecture = WinOSProcArch.GetNTOSArchitecture2();
                architecture ??= WinOSProcArch.GetNTOSArchitecture1();
                architecture ??= RuntimeInformation.ProcessArchitecture;
                return architecture.Value;
            }
        }
    }
}
