namespace Domain
{
    public class Comment : Postable
    {
        public Comment(int id, string body, User user) : base(id, body, user)
        {
            // :)
        }
    }
}