using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace asphaltApp
{


    public partial class HomePage : ContentPage
    {
        //Display user's name on Home Page
        public string GreetingName { get; } = "Welcome, " + Constants.Name;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = this;
        }


       private async void TappedAsyncReports(object sender, EventArgs e)
        {

                await Navigation.PushAsync(new Reports());

        }

    }
}
