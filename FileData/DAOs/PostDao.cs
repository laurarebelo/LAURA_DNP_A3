using Application.DAOInterfaces;
using Domain;

namespace FileData.DAOs;

public class PostDao : IPostDao
{
    private readonly FileContext context;

    public PostDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> Create(Post post)
    {
        Subreddit? belongsTo = context.Subreddits.FirstOrDefault(subreddit =>
            subreddit.Title.Equals(post.Subreddit, StringComparison.OrdinalIgnoreCase));
        if (belongsTo == null)
        {
            throw new Exception("This subreddit does not exist.");
        }

        belongsTo.AddPost(post);
        context.SaveChanges();
        return Task.FromResult(post);
    }

    public Task<int> GetNextPostId(string subreddit)
    {
        Subreddit? belongsTo = context.Subreddits.FirstOrDefault(s =>
            s.Title.Equals(subreddit, StringComparison.OrdinalIgnoreCase));
        if (belongsTo == null)
        {
            throw new Exception("That subreddit does not exist.");
        }
        return Task.FromResult(belongsTo.Posts.Count);
    }
}