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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UltimateNotepad
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoteLocation : Page
    {
        NavigationEventArgs arg;
        string latitude, longitude,title;
        public NoteLocation()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           var postNote = e.Parameter as Note;
            latitude = postNote.Latitude;
            longitude = postNote.Longitude;
            title = postNote.Title;

        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

            base.OnNavigatingFrom(e);
          

        }

        private void noteMap_Loaded(object sender, RoutedEventArgs e)
        {
            Geopoint centerGeopoint = new Geopoint(new BasicGeoposition()

            { Latitude = double.Parse(latitude), Longitude = double.Parse(longitude) });
            noteMap.Center = centerGeopoint;
            noteMap.ZoomLevel = 12;

            //adding mapElements
            MapIcon mapicon = new MapIcon();
            mapicon.Location = centerGeopoint;
            mapicon.Title = title;
            // mapicon.Image= RandomAccessStream
            //mapicon.Image =
            //    RandomAccessStreamReference
            //    .CreateFromUri(new Uri("ms-appx:///Assets/mapmarker.png"));
            noteMap.MapElements.Add(mapicon);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
