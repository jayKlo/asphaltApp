﻿using System;
using RestSharp;
using System.Web;
namespace asphaltApp
{
    public static class Constants
    {

        //Holds all information about the logged in user
        public static string Name = "";
        public static string Email = "";
        public static string Password = "";
        public static string apiTokie = "";
        public static int roleID = 0; //ID 2 for regular user, 1 for admin
        public static int? tripID = null; //Null if no trip is assigned
        public static string phoneNumber = "";
        public static string avatar = "";
        public static double latitude = 0;
        public static double longitude = 0;


        public static string TheName
        {
            get { return Name; }
            set { Name = value; }

        }

        public static string TheAvatar
        {
            get { return avatar; }
            set { avatar = value; }

        }

        public static string TheApiTokie
        {
            get { return apiTokie; }
            set { apiTokie = value; }
        }

        public static string TheEmail
        {
            get { return Email; }
            set { Email = value; }
        }

        public static string ThePassword
        {
            get { return Password; }
            set { Password = value; }
        }

        public static int TheRoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        public static int? TheTripID
        {
            get { return tripID; }
            set { tripID = value; }
        }

        public static string ThePhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public static double TheLatitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public static double TheLongitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public static void LogoutUser()
        {
            //API Call to log out of session with server
            App.IsUserLoggedIn = false;
            string logoutReq = Constants.apiTokie;
            var client = new RestClient("https://peakchaos.com/api/auth/logout");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", logoutReq);
            IRestResponse response = client.Execute(request);

            //Debugging

            var content = response.Content;
            Console.WriteLine(logoutReq);
            Console.WriteLine(content);
            Console.WriteLine(Constants.apiTokie);

        }

    }
}

