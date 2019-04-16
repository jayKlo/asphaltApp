using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace asphaltApp
{


    public partial class HomePage : ContentPage
    {
        //Display user's name on Home Page (is displaying email until change is made to API to pass name)
        public string GreetingName { get; } = "Welcome, " + Constants.Email;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void OnHambugerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void TappedAsyncReports(object sender, EventArgs e)
        {

                await Navigation.PushAsync(new Reports());

        }

    }
    
}
