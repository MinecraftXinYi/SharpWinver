using System.Runtime.InteropServices;
using Windows.Win32.System.SystemInformation;

namespace SharpWinver.Core.NativeInterop;

internal static class WinOSArchitectureMap
{
    internal static Architecture? ArchitectureMap1(PROCESSOR_ARCHITECTURE procArch)
        => procArch switch
        {
            PROCESSOR_ARCHITECTURE.PROCESSOR_ARCHITECTURE_AMD64 => Architecture.X64,
            PROCESSOR_ARCHITECTURE.PROCESSOR_ARCHITECTURE_IA64 => Architecture.X64,
            PROCESSOR_ARCHITECTURE.PROCESSOR_ARCHITECTURE_INTEL => Architecture.X86,
            PROCESSOR_ARCHITECTURE.PROCESSOR_ARCHITECTURE_ARM64 => Architecture.Arm64,
            PROCESSOR_ARCHITECTURE.PROCESSOR_ARCHITECTURE_ARM => Architecture.Arm,
            PROCESSOR_ARCHITECTURE.PROCESSOR_ARCHITECTURE_UNKNOWN => null,
            _ => null
        };

    internal static Architecture? ArchitectureMap2(IMAGE_FILE_MACHINE imageFM)
        => imageFM switch
        {
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_I386 => Architecture.X86,
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_AMD64 => Architecture.X64,
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_IA64 => Architecture.X64,
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_ARM => Architecture.Arm,
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_THUMB => Architecture.Arm,
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_ARMNT => Architecture.Arm,
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_ARM64 => Architecture.Arm64,
            IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_UNKNOWN => null,
            _ => null
        };
}
