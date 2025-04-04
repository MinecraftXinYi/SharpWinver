using SharpWinver;
using SharpWinver.Core;

namespace SharpWinverNativeAOTest;

internal unsafe class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Test sample for SharpWinver Library on Native AOT");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"IsWindowsNT: {Winver.IsWindowsNT}");
        Console.ReadKey();
        Console.WriteLine("-------------------------------");
        Console.WriteLine("----Current Windows OS Info----");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Windows Edition" + ":  " + Winver.WindowsEdition.OSEdition);
        Console.WriteLine("Windows Version" + ":  " + Winver.WindowsVersion.VersionTag);
        Console.WriteLine("OS Version" + ":  " + string.Join(".", Winver.WindowsVersion.OSVersion));
        Console.WriteLine("OS Architecture" + ":  " + Winver.WindowsEdition.OSArchitecture);
        WinNTVersion.RtlGetNtVersionNumbers(out uint major, out uint minor, out _);
        Console.WriteLine($"Windows SKU (from registry): {(WinProduct.GetWindowsSKUFromRegistry())}");
        Console.WriteLine($"Windows SKU (from api): {(WinProduct.GetWindowsSKUFromWinApi(major, minor))}");
        Console.WriteLine($"OS Architecture (method1): {WinNTProcArch.GetNTOSArchitecture1()}");
        Console.WriteLine($"OS Architecture (method2): {WinNTProcArch.GetNTOSArchitecture2()}");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
