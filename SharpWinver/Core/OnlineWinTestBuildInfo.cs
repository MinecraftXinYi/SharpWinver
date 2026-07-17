using SharpWinver.ABI;
using System;

namespace SharpWinver.Core;

public unsafe static class OnlineWinTestBuildInfo
{
    public static DateTime? SystemExpirationDateTime
    {
        get
        {
            long rawData;
            try
            {
                rawData = *(long*)NTKernelDataAddress.KUSER_SHARED_DATA_SystemExpirationDate;
            }
            catch (Exception)
            {
                return null;
            }
            return rawData != default ? DateTime.FromFileTimeUtc(rawData) : null;
        }
    }
}
