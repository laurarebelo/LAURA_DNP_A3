using Application.DAOInterfaces;
using Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class CommentEfcDao : ICommentDao
{
    private readonly RedditContext context;

    public CommentEfcDao(RedditContext context)
    {
        this.context = context;
    }
    public async Task<Comment> CreateAsync(Comment comment)
    {
        EntityEntry<Comment> newComment = await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return newComment.Entity;
    }

    public Task<int> GetNextCommentId(string subreddit, int postId)
    {
        //q método burro
        return Task.FromResult(-1);
    }

    public Task<Comment> Get(string subreddit, int postId, int commentId)
    {
        return Task.FromResult(context.Comments.First(c => c.Id == commentId));
    }

    public Task<Comment> UpvoteComment(Comment comment)
    {
        Comment cmt = Get(comment.Subreddit,comment.PostId,comment.Id).Result;
        cmt.NumUpvotes++;
        context.SaveChangesAsync();
        return Task.FromResult(cmt);
    }

    public Task<Comment> DownvoteComment(Comment comment)
    {
        Comment cmt = Get(comment.Subreddit,comment.PostId,comment.Id).Result;
        cmt.NumDownvotes++;
        context.SaveChangesAsync();
        return Task.FromResult(cmt);
    }
}