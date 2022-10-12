using System.Collections.Generic;

namespace Domain
{
    public class Post : Postable
    {
        public string Title { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(int id, string title, string body, User user, string subreddit) : base(id, body,user, subreddit)
        {
            Title = title;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }
    }
}