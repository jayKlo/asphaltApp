using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace asphaltApp
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Map map = new Map();


            await getReportLocations(map);

            // Build the page.
            Content = new StackLayout
            {
                Children =
                {
                    map
                }
            };

        }

        // Get locations of all reports and display as pins on map
        public async Task getReportLocations(Map map)
        {
            var reportLocations = await JsonHelper.GetReportsAsync();
            reportLocations.ForEach((Report) =>
            {

                Position position = new Position(Report.reportLat, Report.reportLong);
                map.MoveToRegion(new MapSpan(position, 0.01, 0.01));
                map.Pins.Add(new Pin
                {
                    Label = Report.title + " , " + Report.description,
                    Position = position
                });

                Console.WriteLine("Location found for report: " + Report.title + " at: " + Report.reportLat + " , " + Report.reportLong);

            });


        }
            

    }
}
