using System.Collections.Generic;

namespace Domain
{
    public class Subreddit
    {
        private string Title { get; set; }
        private List<Post> Posts { get; }

        public Subreddit(string title)
        {
            Title = title;
            Posts = new List<Post>();
        }

        public void AddPost(Post post)
        {
            Posts.Add(post);
        }

        public void RemovePost(Post post)
        {
            Posts.Remove(post);
        }

    }
    
    
}