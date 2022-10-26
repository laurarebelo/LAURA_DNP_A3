

namespace Domain.DTOs
{
    public class AwardToPostDto
    {
        public string awardName { get; set; }
        public string subreddit { get; set; }
        public int postId { get; set; }

        public AwardToPostDto(string awardName, string subreddit, int postId)
        {
            this.awardName = awardName;
            this.subreddit = subreddit;
            this.postId = postId;
        }
    }
}