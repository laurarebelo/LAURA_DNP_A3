using Application.DAOInterfaces;
using Domain;

namespace FileData.DAOs;

public class SubredditDao : ISubredditDao
{
    private FileContext context;

    public SubredditDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Subreddit> Create(Subreddit subreddit)
    {
        context.Subreddits.Add(subreddit);
        context.SaveChanges();
        return Task.FromResult(subreddit);
    }
}