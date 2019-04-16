using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace asphaltApp
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Loads the appropriate view for the seting pressed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> The setting pressed. </param>
        async void OnSettingClicked(object sender, EventArgs e)
        {
            var setting = ((ListView)sender).SelectedItem.ToString();

            switch (setting)
            {
                case "Logout":
                    Constants.LogoutUser();
                    Navigation.InsertPageBefore(new LoginPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                    break;
                default:
                    await DisplayAlert("setting not implemented", "code me", "ok");
                    break;
            }

        }
    }
}
