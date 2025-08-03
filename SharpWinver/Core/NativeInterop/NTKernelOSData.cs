namespace SharpWinver.Core.NativeInterop;

public static class NTKernelOSData
{
    public const nint KUSER_SHARED_DATA = 0x7FFE0000;
    public const nint KUSER_SHARED_DATA_NtMajorVersion = KUSER_SHARED_DATA + 0x026C;
    public const nint KUSER_SHARED_DATA_NtMinorVersion = KUSER_SHARED_DATA + 0x0270;
    public const nint KUSER_SHARED_DATA_SystemExpirationDate = KUSER_SHARED_DATA + 0x02C8;
}
