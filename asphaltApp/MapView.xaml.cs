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
            new Position(37, -122), Distance.FromMiles(0.3)))
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
