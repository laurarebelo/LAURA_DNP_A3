namespace Domain
{
    public class Post : Postable
    {
        private string Title { get; set; }

        public Post(string title, string body, User user) : base(body,user)
        {
            Title = title;
        }
    }
}