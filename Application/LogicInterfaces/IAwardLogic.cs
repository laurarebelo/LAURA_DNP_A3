using Application.DTOs;
using Domain;

namespace Application.LogicInterfaces;

public interface IAwardLogic
{
    public Task<Award> CreateAsync(AwardCreationDto dto);
    public Task<Post> AwardPost(AwardToPostDto dto);
    public Task<Comment> AwardComment(AwardToCommentDto dto);
}