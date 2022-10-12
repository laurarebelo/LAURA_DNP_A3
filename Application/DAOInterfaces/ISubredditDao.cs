using Application.DTOs;
using Domain;

namespace Application.DAOInterfaces;

public interface ISubredditDao
{
    public Task<Subreddit> Create(Subreddit subreddit);
    public Task<Subreddit?> GetByTitle(String title);
    public Task<List<string>> GetAllTitles();
}