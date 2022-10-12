using Application.DAOInterfaces;
using Application.DTOs;
using Domain;

namespace FileData.DAOs;

public class AwardDao : IAwardDao
{
    private FileContext context;

    public AwardDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Award> Create(Award award)
    {
        context.Awards.Add(award);
        context.SaveChanges();
        return Task.FromResult(award);
    }

    public Task<Award?> GetByName(string name)
    {
        Award? existing = context.Awards.FirstOrDefault(a =>
            a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<Subreddit> GetSubreddit(string subreddit)
    {
        Subreddit? desiredSubreddit =
            context.Subreddits.FirstOrDefault(s => s.Title.Equals(subreddit, StringComparison.OrdinalIgnoreCase));
        if (desiredSubreddit == null)
        {
            throw new Exception("There is no such subreddit");
        }

        return Task.FromResult(desiredSubreddit);
    }

    public async Task<Post> GetPostInSubreddit(string subreddit, int postId)
    {
        Subreddit desiredSubreddit = await GetSubreddit(subreddit);
        Post? desiredPost = desiredSubreddit.Posts.FirstOrDefault(
            p => p.Id == postId);
        if (desiredPost == null)
        {
            throw new Exception("There is no such post in this subreddit");
        }

        return desiredPost;
    }

    public async Task<Comment> GetCommentInPostInSubreddit(string subreddit, int postId, int commentId)
    {
        Post desiredPost = await GetPostInSubreddit(subreddit, postId);
        Comment? desiredComment = desiredPost.Comments.FirstOrDefault(
            c => c.Id == commentId);
        if (desiredComment == null)
        {
            throw new Exception("There is no such comment in this subreddit");
        }

        return desiredComment;
    }

    public Task<int> GetNextId()
    {
        return Task.FromResult(context.Awards.Count);
    }

    public async Task<Post> AwardAPost(AwardToPostDto dto)
    {
        Award desiredAward = await GetByName(dto.awardName);
        Post desiredPost = await GetPostInSubreddit(dto.subreddit, dto.postId);
        desiredPost.AddAward(desiredAward);
        context.SaveChanges();
        return desiredPost;
    }

    public async Task<Comment> AwardAComment(AwardToCommentDto dto)
    {
        Comment desiredComment = await GetCommentInPostInSubreddit(dto.subreddit, dto.postId, dto.commentId);
        Award desiredAward = await GetByName(dto.awardName);
        desiredComment.AddAward(desiredAward);
        context.SaveChanges();
        return desiredComment;
    }
}