using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
using RestSharp;

//This file is to place JSON parsers from the API endpoints for use in various pages
namespace asphaltApp
{
    public static class JsonHelper
    {
        const string BASE_URL = "https://peakchaos.com/api/auth/";
        const string POST_ENDPOINT = "reports";

        //Get a list of all reports
        //for use in the Map View page
        public static async Task<List<Report>> GetReportsAsync()
        {
            using (var httpClient = new HttpClient())
            {

                
                string logoutReq = Constants.apiTokie;
                var client = new RestClient("https://peakchaos.com/api/auth/reports");
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Authorization", logoutReq);
                var cancellationTokenSource = new CancellationTokenSource();
                var restResponse = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
                var reports = JsonConvert.DeserializeObject<List<Report>>(restResponse.Content);
                return reports;

                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.apiTokie);
                //var jsonString = await httpClient.GetStringAsync(BASE_URL + POST_ENDPOINT);
                //var reports = JsonConvert.DeserializeObject<List<Report>>(jsonString);
                //return reports;
            }
        }
    }


}

