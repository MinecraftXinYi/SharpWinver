namespace SharpWinver.Core.NativeInterop;

public unsafe static class NTKernelOSData
{
    // Thanks to @dhrdlicka for the code
    public static readonly long* KUSER_SHARED_DATA_SystemExpirationDate = (long*)0x7ffe02c8;
}
