using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Notifications;
using NotificationsExtensions.Tiles; // NotificationsExtensions.Win10


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Tumblr10Nav.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            this.InitializeComponent();
            this.Loaded += DetailPage_Loaded;           
        }

        public Photoset selectedImage;


        private void DetailPage_Loaded(object sender, RoutedEventArgs e)
        {
            selectedImage = (Application.Current as App).selectedPhotoset;
            gridDetail.DataContext = selectedImage;

            MapIcon mapIcon1 = new MapIcon();
            BasicGeoposition a = new BasicGeoposition();
            a.Longitude = selectedImage.Longitude;
            a.Latitude = selectedImage.Latitude;
            mapIcon1.Location = new Geopoint(a);
            mapIcon1.NormalizedAnchorPoint = new Point(0.3, 0.3);
            mapDetail.Center = new Geopoint(a);
            //mapIcon1.Title = selectedImage.City;
            mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png"));
            mapIcon1.ZIndex = 0;
            mapDetail.MapElements.Add(mapIcon1);


            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentPhotos()
                        {
                            Images = {new TileImageSource(selectedImage.Thumbnail)}
                        }
                    }
                    ,
                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentPhotos()
                        {
                            Images = { new TileImageSource(selectedImage.Thumbnail) }
                        }
                    }
                    
                }
            };


            #region TileText Update

            //TileContent content = new TileContent()
            //{
            //    Visual = new TileVisual()
            //    {
            //        TileMedium = new TileBinding()
            //        {
            //            Content = new TileBindingContentAdaptive()
            //            {
            //                Children =
            //    {
            //        new TileText()
            //        {
            //            Text = selectedImage.Title
            //        },

            //        new TileText()
            //        {
            //            Text = selectedImage.City,
            //            Style = TileTextStyle.CaptionSubtle
            //        },

            //        new TileText()
            //        {
            //            Text = selectedImage.Country,
            //            Style = TileTextStyle.CaptionSubtle
            //        }
            //    }
            //            }
            //        },

            //        TileWide = new TileBinding()
            //        {
            //            Content = new TileBindingContentAdaptive()
            //            {
            //                Children =
            //    {
            //        new TileText()
            //        {
            //            Text = selectedImage.Title,
            //            Style = TileTextStyle.Subtitle
            //        },

            //        new TileText()
            //        {
            //            Text = selectedImage.City,
            //            Style = TileTextStyle.CaptionSubtle
            //        },

            //        new TileText()
            //        {
            //            Text = selectedImage.Country,
            //            Style = TileTextStyle.CaptionSubtle
            //        }
            //    }
            //            }
            //        }
            //    }
            //};
            #endregion

            var notification = new TileNotification(content.GetXml());
            // And send the notification
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WebViewDetail));
        }


    }
}
