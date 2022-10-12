using Application.DAOInterfaces;
using Application.DTOs;
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

    public Task<Subreddit?> GetByTitle(string title)
    {
        Subreddit? existing = context.Subreddits.FirstOrDefault(
            s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public Task<List<string>> GetAllTitles()
    {
        List<string> allTitles = new List<string>();
        foreach (var Subreddit in context.Subreddits)
        {
            allTitles.Add(Subreddit.Title);
        }

        return Task.FromResult(allTitles);
    }
}