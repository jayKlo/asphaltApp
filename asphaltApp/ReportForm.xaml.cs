using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace asphaltApp
{
    public partial class ReportForm : ContentPage
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        async void TappedAsyncSubmitForm(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ThanksPage());

        }
    }
}
