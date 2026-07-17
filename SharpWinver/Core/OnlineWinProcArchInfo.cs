using SharpWinver.ABI;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.System.SystemInformation;

namespace SharpWinver.Core;

public unsafe static class OnlineWinProcArchInfo
{
    public static Architecture NTOSArchitecture
    {
        get
        {
            Architecture? architecture = GetNTOSArchitecture2();
            architecture ??= GetNTOSArchitecture1();
            architecture ??= RuntimeInformation.OSArchitecture;
            return architecture.Value;
        }
    }

    public static Architecture? GetNTOSArchitecture1()
    {
        SYSTEM_INFO systemInfo;
        WinOSArchApi.GetNativeSystemInfo(&systemInfo);
        return WinOSArchitectureMap.ArchitectureMap1(systemInfo.Anonymous.Anonymous.wProcessorArchitecture);
    }

    public static Architecture? GetNTOSArchitecture2()
    {
        HANDLE hProcess = ProcessThreadsApi.GetCurrentProcess();
        IMAGE_FILE_MACHINE processMachine, nativeMachine;
        WinOSArchApi.IsWow64Process2(hProcess, &processMachine, &nativeMachine);
        return WinOSArchitectureMap.ArchitectureMap2(nativeMachine);
    }
}
