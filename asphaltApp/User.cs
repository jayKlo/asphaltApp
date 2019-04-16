namespace asphaltApp
{
    //Used for creation of a user object during Signup. Server variables are stored in Constants, not here. 
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Password_Conf { get; set; }

        public string apiKey { get; set; }

        public int roleID { get; set; }

        public int? tripID { get; set; }

        public string phoneNumber { get; set; }



    }
}