using Application.DTOs;
using Application.LogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentLogic commentLogic;
    
    public CommentsController(ICommentLogic commentLogic)
    {
        this.commentLogic = commentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateAsync(CommentCreationDto dto)
    {
        try
        {
            Comment comment = await commentLogic.CreateAsync(dto);
            return Created($"/subreddits/{comment.Subreddit}/{comment.PostId}/{comment.Id}", comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}