namespace SharpWinver.Core.NativeInterop;

public static class NTKernelOSData
{
    public const nint
        KUSER_SHARED_DATA = 0x7FFE0000,
        KUSER_SHARED_DATA_NtMajorVersion = KUSER_SHARED_DATA + 0x026C,
        KUSER_SHARED_DATA_NtMinorVersion = KUSER_SHARED_DATA + 0x0270,
        KUSER_SHARED_DATA_NtBuildNumber = KUSER_SHARED_DATA + 0x0260,
        KUSER_SHARED_DATA_SystemExpirationDate = KUSER_SHARED_DATA + 0x02C8;
}
