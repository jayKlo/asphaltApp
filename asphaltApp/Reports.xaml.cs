﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace asphaltApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Reports : ContentPage
	{
		public Reports ()
		{
			InitializeComponent();
		}
        //Try to get the user's location
        async void TappedAsyncMapView(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MapView());

        }

    }
}