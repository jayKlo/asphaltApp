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
            var map = new Map(
            MapSpan.FromCenterAndRadius(
            new Position(Constants.latitude, Constants.longitude), Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
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
