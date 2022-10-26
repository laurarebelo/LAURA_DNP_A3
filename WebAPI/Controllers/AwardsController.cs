using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AwardsController : ControllerBase
{
    private readonly IAwardLogic awardLogic;
    
    public AwardsController(IAwardLogic awardLogic)
    {
        this.awardLogic = awardLogic;
    }
    
    [HttpPost]
    [Route("allAwards")] 
    public async Task<ActionResult<Award>> CreateAsync(AwardCreationDto dto)
    {
        try
        {
            Award award = await awardLogic.CreateAsync(dto);
            return Created($"/awards/{award.Name}", award);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    [Route("awardPost")] 
    public async Task<ActionResult<Award>> AwardPost(AwardToPostDto dto)
    {
        try
        {
            Award award = await awardLogic.AwardPost(dto);
            return Ok(award);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    [Route("awardComment")] 
    public async Task<ActionResult<Post>> AwardComment(AwardToCommentDto dto)
    {
        try
        {
            Comment comment = await awardLogic.AwardComment(dto);
            return Created($"/subreddits/{comment.Subreddit}/{comment.PostId}/{comment.Id}", comment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("allAwards")] 
    public async Task<ActionResult<IEnumerable<Award>>> GetAll()
    {
        try
        {
            var post = await awardLogic.GetAll();
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}