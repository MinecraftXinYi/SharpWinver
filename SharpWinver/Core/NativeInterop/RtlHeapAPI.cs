using System.Runtime.InteropServices;

namespace SharpWinver.Core.NativeInterop;

internal unsafe static class RtlHeapApi
{
    [DllImport(WinDll.NTDLL, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static extern void* RtlCreateHeap(ulong Flags, void* HeapBase, ulong ReserveSize, ulong CommitSize, void* Lock, void* Parameters);

    [DllImport(WinDll.NTDLL, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static extern void* RtlAllocateHeap(void* HeapHandle, ulong Flags, ulong Size);

    [DllImport(WinDll.NTDLL, SetLastError = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static extern void* RtlDestroyHeap(void* HeapHandle);
}
