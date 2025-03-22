using SharpWinver;
using SharpWinver.Core;
using System.Diagnostics;

namespace SharpWinverNativeAOTest;

internal unsafe class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Test sample for SharpWinver Library on Native AOT");
        Console.WriteLine("-------------------------------");
        Debug.WriteLine($"IsWindowsNT: {Winver.IsWindowsNT}");
        Console.ReadKey();
        Console.WriteLine("----Current Windows OS Info----");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Windows Edition" + ":  " + Winver.WindowsEdition.OSEdition);
        Console.WriteLine("Windows Version" + ":  " + Winver.WindowsVersion.VersionTag);
        Console.WriteLine("OS Version" + ":  " + string.Join(".", Winver.WindowsVersion.OSVersion));
        Console.WriteLine("OS Architecture" + ":  " + Winver.WindowsEdition.OSArchitecture);
        WinNTVersion.RtlGetNtVersionNumbers(out uint major, out uint minor, out _);
        Debug.WriteLine($"Windows SKU (from registry): {(WinProduct.GetWindowsSKUFromRegistry())}");
        Debug.WriteLine($"Windows SKU (from api): {(WinProduct.GetWindowsSKUFromWinApi(major, minor))}");
        Debug.WriteLine($"OS Architecture (method1): {WinNTProcArch.GetNTOSArchitecture1()}");
        Debug.WriteLine($"OS Architecture (method2): {WinNTProcArch.GetNTOSArchitecture2()}");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
