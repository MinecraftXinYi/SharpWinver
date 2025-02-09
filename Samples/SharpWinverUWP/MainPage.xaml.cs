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
        public MainPage()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.AcrylicBrush"))
                Background = new AcrylicBrush() { BackgroundSource = AcrylicBackgroundSource.HostBackdrop };
            this.InitializeComponent();
            WinEditionContent.Text = Winver.WindowsEdition.OSEditionName;
            ReleaseVersionContent.Text = Winver.WindowsVersion.VersionTag;
            OSVersionContent.Text = string.Join(".", Winver.WindowsVersion.OSVersion);
            OSArchContent.Text = Winver.WindowsEdition.OSArchitecture.ToString();
            Debug.WriteLine($"IsWindowsNT: {Winver.IsWindowsNT}");
            Debug.WriteLine($"Windows SKU (from registry): {(WinProduct.GetWindowsSKUFromRegistry() ?? WindowsSKU.Undefined)}");
            Debug.WriteLine($"Windows SKU (from api): {(WinProduct.GetWindowsSKUFromWinApi(10, 0) ?? WindowsSKU.Undefined)}");
            Debug.WriteLine($"OS Architecture (method1): {WinNTProcArch.GetNTOSArchitecture1()}");
            Debug.WriteLine($"OS Architecture (method2): {WinNTProcArch.GetNTOSArchitecture2()}");
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            _ = ApplicationView.GetForCurrentView().TryConsolidateAsync();
        }
    }
}
