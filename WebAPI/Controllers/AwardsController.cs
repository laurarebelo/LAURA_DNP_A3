using Application.DTOs;
using Application.LogicInterfaces;
using Domain;
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
    public async Task<ActionResult<Award>> CreateAsync(AwardCreationDto dto)
    {
        try
        {
            Award award = await awardLogic.Create(dto);
            return Created($"/awards/{award.Name}", award);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}