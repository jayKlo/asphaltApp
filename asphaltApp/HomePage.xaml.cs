using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace asphaltApp
{


    public partial class HomePage : ContentPage
    {
        //Display user's name on Home Page (is displaying email until change is made to API to pass name)
        public string GreetingName { get; } = "Welcome, " + Constants.Name;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void OnHambugerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        async void TappedAsyncReportHazard(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ReportHazard());

        }

        async void TappedAsyncViewReports(object sender, EventArgs e)
        {

                await Navigation.PushAsync(new Reports());

        }

    }
    
}
