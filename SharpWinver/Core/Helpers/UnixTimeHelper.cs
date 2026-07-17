using System;

namespace SharpWinver.Core.Helpers;

internal static class UnixTimeHelper
{
    internal static readonly DateTime UnixEpoch = new(1970, 1, 1);

    internal static DateTime GetDateTimeFromUnixTimeSeconds(long seconds)
        => UnixEpoch.AddSeconds(seconds);
}
