﻿using System;

namespace SharpWinver;

using Core;

public static partial class Winver
{
    /// <summary>
    /// 当前运行的 Windows 系统版本
    /// </summary>
    public static class WindowsVersion
    {
        /// <summary>
        /// Windows 系统版本代号
        /// </summary>
        public static string VersionTag
        {
            get
            {
                string? osVersionTag = WinVersion.GetWindowsVersionTag();
                return osVersionTag ?? DefaultInfoStrings.InfoIsUnknown;
            }
        }

        /// <summary>
        /// Windows NT 内核版本
        /// </summary>
        public static Version NTVersion
        {
            get
            {
                uint[] ntVersionNum = WinVersion.GetWinNTVersionNumbers();
                return new((int)ntVersionNum[0], (int)ntVersionNum[1], (int)ntVersionNum[2]);
            }
        }

        /// <summary>
        /// Windows 操作系统版本
        /// </summary>
        public static Version OSVersion
        {
            get
            {
                Version ntVersion = NTVersion;
                int revision = (int)WinVersion.GetWindowsRevisionNumber().GetValueOrDefault();
                return new(ntVersion.Major, ntVersion.Minor, ntVersion.Build, revision);
            }
        }
    }
}
