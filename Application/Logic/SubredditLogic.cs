using Application.DAOInterfaces;
using Application.DTOs;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class SubredditLogic : ISubredditLogic

{
    private readonly ISubredditDao subredditDao;

    public SubredditLogic(ISubredditDao subredditDao)
    {
        this.subredditDao = subredditDao;
    }
    
    public Task<Subreddit> CreateAsync(SubredditCreationDto dto)
    {
        return subredditDao.Create(new Subreddit(dto.Title));
    }

    public Task<Subreddit?> GetByTitle(string title)
    {
        return subredditDao.GetByTitle(title);
    }

    public Task<List<string>> GetAllTitles()
    {
        return subredditDao.GetAllTitles();
    }
}