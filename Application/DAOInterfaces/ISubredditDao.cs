using Domain;

namespace Application.DAOInterfaces;

public interface ISubredditDao
{
    public Task<Subreddit> Create(Subreddit subreddit);
}