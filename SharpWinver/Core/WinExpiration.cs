namespace SharpWinver.Core;

using static NativeInterop.NTKernelOSData;

public static class WinExpiration
{
    public unsafe static long? GetSystemExpirationDateTime()
    {
        long rawData = *KUSER_SHARED_DATA_SystemExpirationDate;
        return rawData != 0 ? rawData : null;
    }
}
