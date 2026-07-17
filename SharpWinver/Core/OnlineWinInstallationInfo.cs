using SharpWinver.ABI;
using SharpWinver.Core.Helpers;
using System;

namespace SharpWinver.Core;

public static class OnlineWinInstallationInfo
{
    public static DateTime? SystemInstallationDateTime
    {
        get
        {
            long? rawData = NTRegistryValueReader.GetDwordValue(WinInfoRegPath.WinNTCurrentVersion, "InstallDate");
            return rawData.HasValue ? UnixTimeHelper.GetDateTimeFromUnixTimeSeconds(rawData.Value) : null;
        }
    }

    public static string? SystemRegisteredOwner
        => NTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "RegisteredOwner");

    public static string? SystemRegisteredOrganization
        => NTRegistryValueReader.GetStringValue(WinInfoRegPath.WinNTCurrentVersion, "RegisteredOrganization");
}
