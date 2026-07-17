using System;
using System.Runtime.InteropServices;

namespace SharpWinver;

public interface IWinVer
{
    string Edition { get; }

    WindowsSKU SKU { get; }

    Architecture OSArchitecture { get; }

    Version OSVersion { get; }

    Version WinNTVersion { get; }

    string VersionTag { get; }
}
