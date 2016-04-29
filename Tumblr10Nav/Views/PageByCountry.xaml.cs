//using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class PageByCountry : Page
    {
        public PageByCountry()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        //private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            Photoset ps = new Photoset();         
            //this.cvs1.Source = await ps.getByCountryGrouped();
            this.cvs1.Source = ps.getByCountryGrouped();
            preloader.Visibility = Visibility.Collapsed;
        }

        private void gridViewPhotos_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Photoset selectedPS = gridViewPhotos.SelectedItem as Photoset;
            (Application.Current as App).selectedPhotoset = selectedPS;
            this.Frame.Navigate(typeof(DetailPage));

        }
    }
}
