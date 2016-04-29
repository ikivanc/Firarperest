using System;
using System.Collections.Generic;
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
    public sealed partial class WebViewDetail : Page
    {
        public WebViewDetail()
        {
            this.InitializeComponent();
            this.Loaded += WebViewDetail_Loaded;
        }

          
    private void WebViewDetail_Loaded(object sender, RoutedEventArgs e)
    {
    
        webviewDetail.Source = new Uri((Application.Current as App).selectedPhotoset.Url);
    }

        private void webviewDetail_LoadCompleted(object sender, NavigationEventArgs e)
        {
            preloader.Visibility = Visibility.Collapsed;
        }
    }
}
