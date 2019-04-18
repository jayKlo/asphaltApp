using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            try
            {
                //Set to high to get within 100 meters of current location
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);
                Constants.TheLatitude = location.Latitude;
                Constants.TheLongitude = location.Longitude;

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    await Navigation.PushAsync(new ReportForm());
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await DisplayAlert("Feature Not Supported", "Can not continue, try a different device.", "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                await DisplayAlert("Feature Not Enabled", "Can not continue, try a different device.", "OK");
            }
            catch (PermissionException pEx)
            {
                //Handle location permission not enabled exception
                await DisplayAlert("Location Denied", "Please enable location services.", "OK");
            }
            catch (Exception ex)
            {
                //Handle all other exceptions
                await DisplayAlert("Error Occured", "Burn device to ashes.", "OK");
            }

        }
        

        async void TappedAsyncOtherLocation(object sender, EventArgs e)
        {
            try
            {
                //Set to high to get within 100 meters of current location
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);
                Constants.TheLatitude = location.Latitude;
                Constants.TheLongitude = location.Longitude;

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    await Navigation.PushAsync(new MapReport());
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                await DisplayAlert("Feature Not Supported", "Can not continue, try a different device.", "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                await DisplayAlert("Feature Not Enabled", "Can not continue, try a different device.", "OK");
            }
            catch (PermissionException pEx)
            {
                //Handle location permission not enabled exception
                await DisplayAlert("Location Denied", "Please enable location services.", "OK");
            }
            catch (Exception ex)
            {
                //Handle all other exceptions
                await DisplayAlert("Error Occured", "Burn device to ashes.", "OK");
            }

        }
    }
}
