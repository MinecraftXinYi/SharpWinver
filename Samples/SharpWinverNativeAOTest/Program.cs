using SharpWinver;

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
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
