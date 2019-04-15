using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Web;
using System;

namespace asphaltApp
{
    public static class Constants
    {

        //Holds all information about the logged in user
        public static string Name = "";
        public static string Email = "";
        public static string Password = "";
        public static string apiTokie = "";
        public static int roleID = 2; //Default ID 2 for regular user, 1 for admin
        public static int tripID = 0;
        public static string phoneNumber = "";



        public static string theName
        {
            get { return Name; }
            set { Name = value; }

        }

        public static string theApiTokie
        {
            get { return apiTokie; }
            set { apiTokie = value; }
        }

        public static string theEmail
        {
            get { return Email; }
            set { Email = value; }
        }

        public static string thePassword
        {
            get { return Password; }
            set { Password = value; }
        }

        public static int theRoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        public static int theTripID
        {
            get { return tripID; }
            set { tripID = value; }
        }

        public static string thePhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public static void LogoutUser()
        {
            //API Call to log out of session with server
            string encodedEmail = HttpUtility.UrlEncode(Constants.Email);
            string logoutReq = "email=" + encodedEmail + "&password=" + Constants.Password;
            var client = new RestClient("http://159.89.133.225/api/logout");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", logoutReq, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            //Debugging
            /*
            var content = response.Content;
            Console.WriteLine(logoutReq);
            Console.WriteLine(content);
            Console.WriteLine(Constants.apiTokie);
            */
        }

    }
}
