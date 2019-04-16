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
            var signUpSucceeded = ServerSignup(user);
            var noIssues = AreDetailsValid(user);
            if (signUpSucceeded && noIssues)
            {
                    var rootPage = Navigation.NavigationStack.FirstOrDefault();
                    await Navigation.PopToRootAsync();

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

        bool ServerSignup(User user)
        {

            //Implement API calls here
            string encodedEmail = HttpUtility.UrlEncode(user.Email);
            string fullString = "name=" + user.Name + "&email=" + encodedEmail + "&password=" + user.Password + "&password_confirmation=" + user.Password_Conf;
            var client = new RestClient("https://peakchaos.com");
            var request = new RestRequest("/api/auth/signup", Method.POST);
            //request.AddHeader("cache-control", "no-cache");
            request.AddHeader("X-Requested-With", "XMLHttpRequest");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", fullString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            if (content.Contains("Successfully")) return true;
            else return false;


        }

    }
}


