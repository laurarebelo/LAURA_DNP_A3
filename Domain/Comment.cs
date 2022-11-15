using System;

namespace Domain
{
    public class Comment : Postable
    {
        public int PostId { get; set; }
        public Comment(int id, int postid, string body, User user, string subreddit) : base(id, body, user, subreddit)
        {
            PostId = postid;
        }
        
        public Comment(){}
    }
}