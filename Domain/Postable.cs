using System.Collections.Generic;

namespace Domain
{
    public abstract class Postable
    {
        private string Body { get; set; }
        private User User { get; set; }
        private int NumUpvotes { get; set; }
        private int NumDownvotes { get; set; }
        private List<Comment> Comments { get;}
        private List<Award> Awards { get;}

        protected Postable(string body, User user)
        {
            Body = body;
            User = user;
            NumUpvotes = 0;
            NumDownvotes = 0;
            Comments = new List<Comment>();
            Awards = new List<Award>();

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

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }

        public void AddAward(Award award)
        {
            Awards.Add(award);
        }

        public void RemoveAward(Award award)
        {
            Awards.Remove(award);
        }
    }
}