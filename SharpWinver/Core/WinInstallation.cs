namespace SharpWinver.Core;

using NativeInterop;

internal static class WinInstallation
{
    internal static long? SystemInstallationDateTime
    {
        get => WinNTRegistryValueReader.GetDwordValue(WinInfoRegPath.WinNTCurrentVersion, "InstallDate");
    }

    internal static string? SystemRegisteredOwner
    {
        get => WinNTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "RegisteredOwner");
    }

    internal static string? SystemRegisteredOrganization
    {
        get => WinNTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "RegisteredOrganization");
    }
}
