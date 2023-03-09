namespace Authentication.Helpers
{
    public class CustomRole
    {
        private const string ADMIN = "Admin";
        private const string USER = "User";

        public const string Admin_Role = ADMIN;
        public const string User_Role = USER;
        public const string All_Role = USER+","+ADMIN;
    }
}
