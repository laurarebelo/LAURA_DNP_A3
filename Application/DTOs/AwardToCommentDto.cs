namespace Application.DTOs;

public class AwardToCommentDto
{
    public string awardName { get; set; }
    public string subreddit { get; set; }
    public int postId { get; set; }
    public int commentId { get; set; }
}