using Application.DAOInterfaces;
using Domain;

namespace FileData.DAOs;

public class CommentDao : ICommentDao
{
    private readonly FileContext context;

    public CommentDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Comment> CreateAsync(Comment comment)
    {
        Subreddit subreddit =
            context.Subreddits.FirstOrDefault(
                s => s.Title.Equals(comment.Subreddit, StringComparison.OrdinalIgnoreCase))!;
        Post post = subreddit.Posts.FirstOrDefault(p => p.Id == comment.PostId)!;
        
        post.AddComment(comment);
        context.SaveChanges();
        return Task.FromResult(comment);
    }

    public Task<int> GetNextCommentId(string subreddit, int postId)
    {
        Subreddit? desiredSubreddit =
            context.Subreddits.FirstOrDefault(s => s.Title.Equals(subreddit, StringComparison.OrdinalIgnoreCase));
        if (desiredSubreddit == null)
        {
            throw new Exception("There is no such subreddit");
        }

        Post? desiredPost = desiredSubreddit.Posts.FirstOrDefault(
            p => p.Id == postId);
        if (desiredPost == null)
        {
            throw new Exception("There is no such post in this subreddit");
        }

        return Task.FromResult(desiredPost.Comments.Count);
    }
}