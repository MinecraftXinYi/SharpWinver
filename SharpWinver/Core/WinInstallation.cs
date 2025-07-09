namespace SharpWinver.Core;

using NativeInterop;

internal static class WinInstallation
{
    internal static long? SystemInstallationDateTime
    {
        get => WinNTRegistryValueReader.GetDwordValue(RegistryPath.WinNTCurrentVersion, "InstallDate");
    }

    internal static string? SystemRegisteredOwner
    {
        get => WinNTRegistryValueReader.GetStringValue(RegistryPath.WinNTCurrentVersion, "RegisteredOwner");
    }

    internal static string? SystemRegisteredOrganization
    {
        get => WinNTRegistryValueReader.GetStringValue(RegistryPath.WinNTCurrentVersion, "RegisteredOrganization");
    }
}
