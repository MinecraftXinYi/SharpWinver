using SharpWinver.ABI;
using System;

namespace SharpWinver.Core.Helpers;

public static class WinBrandApiHelper
{
    public static bool IsWinBrandApiCallable
    {
        get
        {
            try
            {
                return !string.IsNullOrEmpty(WinBrandApi.BrandingFormatString(WinBrandApi.Variables.WindowsGeneric));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
