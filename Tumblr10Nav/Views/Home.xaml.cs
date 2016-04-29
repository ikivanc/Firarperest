//using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Tumblr10Nav.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            gridViewPhotos.SizeChanged += GridViewPhotos_SizeChanged;   
        }



        private void GridViewPhotos_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //ItemsWrapGrid appItemsPanel = (ItemsWrapGrid)gridViewPhotos.ItemsPanelRoot;
            
            //double optimizedWidth = 360.0;
            //var number = (int)e.NewSize.Width / (int)optimizedWidth;
            //appItemsPanel.ItemWidth = (int)e.NewSize.Width / (double)number;            
            ////appItemsPanel.ItemHeight = appItemsPanel.ItemWidth * 0.55;
        }

        //  private IMobileServiceTable<Photoset> photosetTable = App.MobileService.GetTable<Photoset>();


        //private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Can Go back Feature
            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
       
            Photoset ps = new Photoset();
            //gridViewPhotos.ItemsSource = await ps.getAllPhotosAMS();

            gridViewPhotos.ItemsSource = ps.getAllPhotos();
            preloader.Visibility = Visibility.Collapsed;
         
            //Device Family spesific features
            InitializeUi();
         

        }

        private async void InitializeUi()
        {

            if (String.Equals(AnalyticsInfo.VersionInfo.DeviceFamily, "Windows.Mobile")) { }
            else if (String.Equals(AnalyticsInfo.VersionInfo.DeviceFamily, "Windows.Dektop")) { }


            //If we have a phone contract, hide the status bar
            //if (windows.foundation.metadata.apiinformation.istypepresent("windows.ui.viewmanagement.statusbar"))
            //{
            //    var statusbar = windows.ui.viewmanagement.statusbar.getforcurrentview();
            //    await statusbar.showasync();
            //    //statusbar.backgroundcolor = windows.ui.colors.green;
            //    statusbar.backgroundopacity = 0;

            //    statusbar.foregroundcolor = windows.ui.colors.white;

            //}

            //if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            //{
            //    StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            //}

            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                var statusBar = StatusBar.GetForCurrentView();
                await statusBar.HideAsync();
            }
        }

        private void gridViewPhotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Photoset selectedPS = gridViewPhotos.SelectedItem as Photoset;
            (Application.Current as App).selectedPhotoset = selectedPS;
            this.Frame.Navigate(typeof(DetailPage));
        }

    }
}
