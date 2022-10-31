using System.Collections.Generic;

namespace Domain
{
    public abstract class Postable
    {
        public string Subreddit { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }
        public User User { get; set; }
        public int NumUpvotes { get; set; }
        public int NumDownvotes { get; set; }

        protected Postable(int id, string body, User user, string subreddit)
        {
            Subreddit = subreddit;
            Id = id;
            Body = body;
            User = user;
            NumUpvotes = 0;
            NumDownvotes = 0;
        }

        public void Upvote()
        {
            NumUpvotes++;
        }

        public void Downvote()
        {
            NumDownvotes++;
        }

        public void UndoUpvote()
        {
            NumUpvotes--;
        }

        public void UndoDownvote()
        {
            NumDownvotes--;
        }
    }
}