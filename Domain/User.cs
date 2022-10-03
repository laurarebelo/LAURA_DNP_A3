namespace Domain
{
    public class User
    {
        private string username { get; set; }
        private string password { get; set; }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}