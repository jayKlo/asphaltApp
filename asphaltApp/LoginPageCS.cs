using System;
using System.Linq;
using System.Net;
using System.Web;
using Xamarin.Forms;
using RestSharp;
using RestSharp.Authenticators;

namespace asphaltApp
{
    public class LoginPageCS : ContentPage
    {
        Entry emailEntry, passwordEntry;
        Label messageLabel;

        public LoginPageCS()
        {

            var toolbarItem = new ToolbarItem
            {
                Text = "Sign Up"
            };

            toolbarItem.Clicked += OnSignUpButtonClicked;
            ToolbarItems.Add(toolbarItem);

            messageLabel = new Label();
            emailEntry = new Entry
            {
                Placeholder = "email"
            };
            passwordEntry = new Entry
            {
                IsPassword = true
            };
            var loginButton = new Button
            {
                Text = "Login"
            };
            loginButton.Clicked += OnLoginButtonClicked;

            Title = "Login";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label { Text = "email" },
                    emailEntry,
                    new Label { Text = "Password" },
                    passwordEntry,
                    loginButton,
                    messageLabel
                }
            };
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPageCS());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };


            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                //Save local user variables to global Constants 
                Constants.theName = user.Name;
                Constants.theEmail = user.Email;
                Constants.thePassword = user.Password;
                Constants.theApiTokie = user.apiKey;
                Navigation.InsertPageBefore(new MainPageCS(), this);
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
            //request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", fullString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //Parse API token
            string apiToken = getBetween(content, "\"access_token\":\"", "\",\"token_type");

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

    }
}