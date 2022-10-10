using System.Collections.Generic;

namespace Domain
{
    public class Post : Postable
    {
        public string Title { get; set; }
        public List<Comment> Comments { get; set; }
        public string Subreddit { get; set; }

        public Post(int id, string title, string body, User user, string subreddit) : base(id, body,user)
        {
            Title = title;
            Comments = new List<Comment>();
            Subreddit = subreddit;
        }
    }
}