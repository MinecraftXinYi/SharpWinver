using SharpWinver;
using SharpWinver.Core;

namespace SharpWinverNativeAOTest;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Test sample for SharpWinver Library on Native AOT");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"IsWindowsNT: {OnlineWinVer.IsWindowsNT}");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("----Current Windows OS Info----");
        Console.WriteLine("-------------------------------");
        OnlineWinVer winVer = new();
        Console.WriteLine("Windows Edition" + ":  " + winVer.Edition);
        Console.WriteLine("Windows Version" + ":  " + winVer.VersionTag);
        Console.WriteLine("OS Version" + ":  " + string.Join(".", winVer.OSVersion));
        Console.WriteLine("OS Architecture" + ":  " + winVer.OSArchitecture);
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Windows SKU (from registry): {(OnlineWinProductInfo.GetWindowsSKUNameFromRegistry())}");
        Console.WriteLine($"Windows SKU (from api): {(OnlineWinProductInfo.GetWindowsSKUIdFromApi(10, 0))}");
        Console.WriteLine($"OS Architecture (method1): {OnlineWinProcArchInfo.GetNTOSArchitecture1()}");
        Console.WriteLine($"OS Architecture (method2): {OnlineWinProcArchInfo.GetNTOSArchitecture2()}");
        Console.WriteLine($"OS Version From Kernel Data: {string.Join(".", OnlineWinVersionInfo.GetWinNTVersionNumbersFromKernelData() ?? [])}");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
