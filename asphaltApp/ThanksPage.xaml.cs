using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace asphaltApp
{
    public partial class ThanksPage : ContentPage
    {
        public ThanksPage()
        {
            InitializeComponent();
        }

        async void TappedAsyncHome(object sender, EventArgs e)
        {

            Navigation.InsertPageBefore(new HomePage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();

        }

    }
}
