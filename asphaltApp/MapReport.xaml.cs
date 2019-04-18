using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

using Xamarin.Forms;

namespace asphaltApp
{
    public partial class MapReport : ContentPage
    {
        public MapReport()
        {
            InitializeComponent();
            var map = new Map(
            MapSpan.FromCenterAndRadius(
            new Position(Constants.latitude, Constants.longitude), Distance.FromMiles(0.3)))
            {
                IsShowingUser = false,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }


    }
}
