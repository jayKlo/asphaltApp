using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace asphaltApp
{
    public partial class ReportHazard : ContentPage
    {
        public ReportHazard()
        {
            InitializeComponent();
        }

        async void TappedAsyncThisLocation(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ReportHazard());

        }

        async void TappedAsyncOtherLocation(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ReportHazard());

        }
    }
}
