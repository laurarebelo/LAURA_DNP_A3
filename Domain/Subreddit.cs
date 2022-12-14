using System.Collections.Generic;

namespace Domain
{
    public class Subreddit
    {
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; }

        public Subreddit(string title)
        {
            Title = title;
            Posts = new List<Post>();
        }
        
        public Subreddit(){}

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