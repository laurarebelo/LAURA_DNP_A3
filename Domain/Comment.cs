namespace Domain
{
    public class Comment : Postable
    {
        public Comment(string body, User user) : base(body, user)
        {
            // :)
        }
    }
}