using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Net;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;

namespace asphaltApp
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            //Console.WriteLine(isValid);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                //Save local user variables to global Constants 
                 Constants.TheName = user.Name;
                 Constants.TheEmail = user.Email;
                 Constants.ThePassword = user.Password;
                 Constants.TheApiTokie = "Bearer " + user.apiKey;
                 Constants.TheName = getUserName(Constants.apiTokie);
                Navigation.InsertPageBefore(new HomePage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            user.apiKey = ServerLogin(user);
            if ((user.apiKey) == "")
            {
                return false;
            }
            else return true;
        }


        //Server Login
        public string ServerLogin(User user)
        {
            //Implement API calls here
            string encodedEmail = HttpUtility.UrlEncode(user.Email);
            string fullString = "email=" + encodedEmail + "&password=" + user.Password;
            var client = new RestClient("https://peakchaos.com");
            var request = new RestRequest("/api/auth/login", Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", fullString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //Parse API token
            string apiToken = getBetween(content, "\"access_token\":\"", "\",\"token_type");

            //Debugging
            /*
            Console.WriteLine(content);
            Console.WriteLine(apiToken);
            Console.WriteLine(content.GetType());
            Console.WriteLine(encodedEmail);
            */

            return apiToken;

        }

        //Used to parse API token in response
        public string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public string getUserName(string token)
        {
            string accessToken = token;
            var client = new RestClient("https://peakchaos.com/api/auth/user");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", accessToken);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //parse the users name from api return
            string userName = getBetween(content, "\"name\":\"", "\",\"email");

            return userName;
            Console.WriteLine(content);
        }
    }
}

