//using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class PageOnMap : Page
    {
        public PageOnMap()
        {
            this.InitializeComponent();
            this.Loaded += PageOnMap_Loaded;

        }

        //private async void PageOnMap_Loaded(object sender, RoutedEventArgs e)
        private void PageOnMap_Loaded(object sender, RoutedEventArgs e)
        {
            Photoset ps = new Photoset();
            //List<Photoset> pList = await ps.getAllPhotosAMS();

            List<Photoset> pList = ps.getAllPhotos();
            preloader.Visibility = Visibility.Collapsed;

            foreach (Photoset p in pList)
            {
                MapIcon mapIcon1 = new MapIcon();

                BasicGeoposition a = new BasicGeoposition();
                a.Longitude = p.Longitude;
                a.Latitude = p.Latitude;
                mapIcon1.Location = new Geopoint(a);
                mapIcon1.NormalizedAnchorPoint = new Point(0.3, 0.3);
                mapDetail.Center = new Geopoint(a);
                mapIcon1.Title = p.City;
                mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png"));
                mapIcon1.ZIndex = 0;
                mapDetail.MapElements.Add(mapIcon1);
                mapDetail.MapElementClick += MapDetail_MapElementClick;
               
            }            
            //mapDetail.Center = new Geopoint(new BasicGeoposition { Latitude = pList.Average(a=>a.Latitude), Longitude = pList.Average(a => a.Longitude)});
            mapDetail.Center = new Geopoint(new BasicGeoposition { Latitude = 36.654317, Longitude = 30.871094 });
            mapDetail.ZoomLevel = 3;
        }

        private void MapDetail_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            var a = (sender as MapControl).MapElements[0];
            var b = args.MapElements[0];

        }
    }
}
