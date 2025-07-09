namespace SharpWinver;

using Core;

public static partial class Winver
{
    /// <summary>
    /// 当前运行的 Windows 系统副本的版权条款信息
    /// </summary>
    public static class WinOSLegalInfo
    {
        /// <summary>
        /// 当前系统副本的版权声明信息
        /// </summary>
        public static string OSCopyrightString
        {
            get => WinProduct.GetWindowsCopyrightString() ?? DefaultInfoStrings.DefaultMicrosoftCopyrightString;
        }
    }
}
