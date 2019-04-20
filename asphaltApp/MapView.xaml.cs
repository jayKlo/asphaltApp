using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace asphaltApp
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();
            var map = new Map();
            Position userPosition = new Position(Constants.latitude, Constants.longitude);
            Position position2 = new Position(38.891693, -104.805122);
            Position position3 = new Position(38.890315, -104.797708);
            Position position4 = new Position(38.888912, -104.807133);
            Position position5 = new Position(38.892828, -104.812626);
            Position position6 = new Position(38.891283, -104.790503);
            map.MoveToRegion(new MapSpan(userPosition, 0.01, 0.01));

            map.Pins.Add(new Pin
            {
                Label = "A pothole 2",
                Position = position2
             });
            map.Pins.Add(new Pin
            {
                Label = "A pothole 3",
                Position = position3
            });
            map.Pins.Add(new Pin
            {
                Label = "A pothole 4",
                Position = position4
            });
            map.Pins.Add(new Pin
            {
                Label = "A pothole 5",
                Position = position5
            });
            map.Pins.Add(new Pin
            {
                Label = "A pothole 6",
                Position = position6
            });


            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;



        }
    }
}
