using Application.DTOs;
using Domain;

namespace Application.LogicInterfaces;

public interface ICommentLogic
{
    public Task<Comment> CreateAsync(CommentCreationDto dto);
}