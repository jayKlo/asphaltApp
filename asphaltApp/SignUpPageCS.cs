using System;
using System.Linq;
using System.Net;
using System.Web;
using Xamarin.Forms;
using RestSharp;
using RestSharp.Authenticators;

namespace asphaltApp
{
    public class SignUpPageCS : ContentPage
    {
        Entry nameEntry, emailEntry, passwordEntry, confirmPasswordEntry;
        Label messageLabel;

        public SignUpPageCS()
        {
            messageLabel = new Label();
            nameEntry = new Entry
            {
                Placeholder = "name"
            };
            emailEntry = new Entry();
            passwordEntry = new Entry
            {
                IsPassword = true
            };
            confirmPasswordEntry = new Entry
            {
                IsPassword = true
            };
            var signUpButton = new Button
            {
                Text = "Sign Up"
            };
            signUpButton.Clicked += OnSignUpButtonClicked;

            Title = "Sign Up";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Email Address" },
                    emailEntry,
                    new Label { Text = "Password" },
                    passwordEntry,
                    new Label { Text = "Confirm Password" },
                    confirmPasswordEntry,
                    signUpButton,
                    messageLabel
                }
            };
        }

        public async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Email = emailEntry.Text,
                Name = nameEntry.Text,
                Password = passwordEntry.Text,
                Password_Conf = confirmPasswordEntry.Text
            };

            ServerSignup(user);
            // Sign up logic goes here
            //var pass2 = confirmPasswordEntry.Text;

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                //Save local variables to global constants
                Constants.Name = user.Name;
                Constants.Email = user.Email;
                Constants.Password = user.Password;
                Constants.apiTokie = user.apiKey;
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                  //  Navigation.InsertPageBefore(new ChamplainTours.Views.ItemListPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                messageLabel.Text = "Sign up failed";
            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }

        void ServerSignup(User user)
        {

            //Implement API calls here
            string encodedEmail = HttpUtility.UrlEncode(user.Email);
            string fullString = "name=" + user.Name + "&email=" + encodedEmail + "&password=" + user.Password + "&password_confirmation=" + user.Password_Conf;
            var client = new RestClient("https://peakchaos.com");
            var request = new RestRequest("/api/auth/signup", Method.POST);
            //request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddParameter("undefined", fullString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            //Parse API token
            string apiToken = getBetween(content, "\"api_token\":\"", "\"}}");
            user.apiKey = apiToken;
            // Debugging
            Console.WriteLine(fullString);
            Console.WriteLine(content);
            Console.WriteLine(apiToken);
            Console.WriteLine(content.GetType());
            Console.WriteLine(encodedEmail);


        }

        //Used to parse API token in response
        public static string getBetween(string strSource, string strStart, string strEnd)
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


