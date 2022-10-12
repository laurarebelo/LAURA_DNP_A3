using Application.DTOs;
using Application.LogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostsController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Created($"/subreddits/{post.Subreddit}/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    [Route("upvote")] 
    public async Task<ActionResult<Post>> UpvotePost(PostVoteDto dto)
    {
        try
        {
            Post post = await postLogic.UpvotePost(dto);
            return Accepted($"/subreddits/{post.Subreddit}/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    [Route("downvote")] 
    public async Task<ActionResult<Post>> DownvotePost(PostVoteDto dto)
    {
        try
        {
            Post post = await postLogic.DownvotePost(dto);
            return Accepted($"/subreddits/{post.Subreddit}/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("all")]
    public async Task<ActionResult<List<PostBrowseDto>>> GetAllTitlesInASubreddit(string subreddit)
    {
        try
        {
            var postTitles = await postLogic.GetAllPostTitles(subreddit);
            return Ok(postTitles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}