using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace asphaltApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewReports : ContentPage
	{
		public ViewReports ()
		{
			InitializeComponent ();
		}

        async void HomeButton(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
    }
}