using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IAwardLogic
{
    public Task<Award> CreateAsync(AwardCreationDto dto);
    public Task<Award> AwardPost(AwardToPostDto dto);
    public Task<Comment> AwardComment(AwardToCommentDto dto);
    public Task<IEnumerable<Award>> GetAll();
}