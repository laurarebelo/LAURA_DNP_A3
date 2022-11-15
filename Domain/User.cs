namespace Domain
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User(string username, string password, string email, string role)
        {
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }

        public User()
        {
        }
    }
}