using SharpWinver;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
        Console.WriteLine("Windows Edition" + ":  " + Winver.WindowsEdition.OSEditionName);
        Console.WriteLine("Windows Version" + ":  " + Winver.WindowsVersion.VersionTag);
        Console.WriteLine("OS Version" + ":  " + string.Join(".", Winver.WindowsVersion.OSVersion));
        Console.WriteLine("OS Architecture" + ":  " + Winver.WindowsEdition.OSArchitecture);
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
