using Application.DTOs;
using Domain;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
  public Task<Post> CreateAsync(PostCreationDto dto);
}