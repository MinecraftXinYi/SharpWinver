using System;

namespace SharpWinver;

using Core;

public static partial class Winver
{
    /// <summary>
    /// 当前运行的 Windows 系统副本的安装信息
    /// </summary>
    public static class WinInstallationInfo
    {
        /// <summary>
        /// 当前系统副本的安装日期及时间
        /// </summary>
        public static DateTime OSInstallationDateTime
        {
            get => DateTime.FromFileTimeUtc(WinInstallation.SystemInstallationDateTime.GetValueOrDefault());
        }

        /// <summary>
        /// 注册当前系统副本的用户名称
        /// </summary>
        public static string OSRegisteredOwner
        {
            get => WinInstallation.SystemRegisteredOwner ?? DefaultInfoStrings.DefaultRegisteredOwner;
        }

        /// <summary>
        /// 注册当前系统副本的组织名称
        /// </summary>
        public static string OSRegisteredOrganization
        {
            get => WinInstallation.SystemRegisteredOrganization ?? string.Empty;
        }
    }
}
