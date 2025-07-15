using WDK = Windows.Wdk;
using Win32 = Windows.Win32;

using Windows.Wdk.Foundation;
using Windows.Wdk.System.Registry;
using Windows.Wdk.System.SystemServices;
using Windows.Win32.Foundation;

namespace SharpWinver.Core.NativeInterop;

public unsafe static class WinNTRegistryValueReader
{
    internal static KEY_VALUE_PARTIAL_INFORMATION* ReadKeyValuePartialInfo(string keyPath, string valueName, out void* heap)
    {
        // Init the key name and open registry.
        UNICODE_STRING usz_keyPath = new();
        Win32.PInvoke.RtlInitUnicodeString(ref usz_keyPath, keyPath);
        OBJECT_ATTRIBUTES objattrib_key = new()
        {
            Length = (uint)sizeof(OBJECT_ATTRIBUTES),
            ObjectName = &usz_keyPath,
            Attributes = Win32.PInvoke.OBJ_CASE_INSENSITIVE,
            SecurityDescriptor = null,
            SecurityQualityOfService = null,
            RootDirectory = HANDLE.Null
        };
        NTSTATUS status = WDK.PInvoke.NtOpenKey(out HANDLE hKey, (uint)GENERIC_ACCESS_RIGHTS.GENERIC_READ, objattrib_key);

        // Can't open the key.
        if (status != NTSTATUS.STATUS_SUCCESS)
        {
            heap = null;
            return null;
        }

        // Init the value name.
        UNICODE_STRING usz_valueName = new();
        Win32.PInvoke.RtlInitUnicodeString(ref usz_valueName, valueName);

        // Query once to get the size of KEY_VALUE_PARTIAL_INFORMATION we need.
        WDK.PInvoke.NtQueryValueKey(hKey, usz_valueName, KEY_VALUE_INFORMATION_CLASS.KeyValuePartialInformation, null, 0, out uint length);

        // Allocate memory for value.
        heap = RtlHeapApi.RtlCreateHeap(0, null, 0, 0, null, null);
        void* buffer = RtlHeapApi.RtlAllocateHeap(heap, WDK.PInvoke.HEAP_ZERO_MEMORY, length);

        // Second query for value.
        KEY_VALUE_PARTIAL_INFORMATION* lp_keyValuePartialInfo = (KEY_VALUE_PARTIAL_INFORMATION*)buffer;
        status = WDK.PInvoke.NtQueryValueKey(hKey, usz_valueName, KEY_VALUE_INFORMATION_CLASS.KeyValuePartialInformation, lp_keyValuePartialInfo, length, out _);

        // Close the key.
        WDK.PInvoke.NtClose(hKey);

        // Can't query the value.
        if (status != NTSTATUS.STATUS_SUCCESS)
        {
            RtlHeapApi.RtlDestroyHeap(heap);
            heap = null;
            return null;
        }

        // Return the value.
        return lp_keyValuePartialInfo;
    }

    public static string? GetStringValue(string keyPath, string valueName)
    {
        KEY_VALUE_PARTIAL_INFORMATION* info = ReadKeyValuePartialInfo(keyPath, valueName, out void* heap);
        if (info == null) return null;
        string value = new((char*)&info->Data);
        RtlHeapApi.RtlDestroyHeap(heap);
        return value;
    }

    public static uint? GetDwordValue(string keyPath, string valueName)
    {
        KEY_VALUE_PARTIAL_INFORMATION* info = ReadKeyValuePartialInfo(keyPath, valueName, out void* heap);
        if (info == null) return null;
        uint value = *(uint*)&info->Data;
        RtlHeapApi.RtlDestroyHeap(heap);
        return value;
    }

    public static ulong? GetQwordValue(string keyPath, string valueName)
    {
        KEY_VALUE_PARTIAL_INFORMATION* info = ReadKeyValuePartialInfo(keyPath, valueName, out void* heap);
        if (info == null) return null;
        ulong value = *(ulong*)&info->Data;
        RtlHeapApi.RtlDestroyHeap(heap);
        return value;
    }
}
