using Application.DTOs;
using Domain;

namespace Application.LogicInterfaces;

public interface ISubredditLogic
{ 
    Task<Subreddit> CreateAsync(SubredditCreationDto dto);
}