using SharpWinver;
using SharpWinver.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SharpWinverUWP
{
    public sealed partial class MainPage : Page
    {
        private IWinVer WinVer = new OnlineWinVer();

        public MainPage()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.AcrylicBrush"))
                Background = new AcrylicBrush() { BackgroundSource = AcrylicBackgroundSource.HostBackdrop };
            this.InitializeComponent();
            WinEditionContent.Text = WinVer.Edition;
            ReleaseVersionContent.Text = WinVer.VersionTag;
            OSVersionContent.Text = string.Join(".", WinVer.OSVersion);
            OSArchContent.Text = WinVer.OSArchitecture.ToString();
            Debug.WriteLine($"IsWindowsNT: {OnlineWinVer.IsWindowsNT}");
            Debug.WriteLine($"Windows SKU (from registry): {(OnlineWinProductInfo.GetWindowsSKUNameFromRegistry())}");
            Debug.WriteLine($"Windows SKU (from api): {(OnlineWinProductInfo.GetWindowsSKUIdFromApi(10, 0))}");
            Debug.WriteLine($"OS Architecture (method1): {OnlineWinProcArchInfo.GetNTOSArchitecture1()}");
            Debug.WriteLine($"OS Architecture (method2): {OnlineWinProcArchInfo.GetNTOSArchitecture2()}");
            Debug.WriteLine($"OS Version From Kernel Data: {string.Join(".", OnlineWinVersionInfo.GetWinNTVersionNumbersFromKernelData())}");
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            _ = ApplicationView.GetForCurrentView().TryConsolidateAsync();
        }
    }
}
