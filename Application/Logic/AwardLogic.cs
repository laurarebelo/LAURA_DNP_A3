using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class AwardLogic : IAwardLogic
{
    private readonly IAwardDao awardDao;

    public AwardLogic(IAwardDao dao)
    {
        this.awardDao = dao;
    }

    public async Task<Award> CreateAsync(AwardCreationDto dto)
    {
        Award? existing = await awardDao.GetByName(dto.Name);
        if (existing != null)
        {
            throw new Exception("There is already an award with that name.");
        }
        
        Award newAward = new Award(dto.Name);
        Award created = await awardDao.Create(newAward);
        return created;

    }

    public Task<Award> AwardPost(AwardToPostDto dto)
    {
        return awardDao.AwardAPost(dto);
    }

    public Task<Comment> AwardComment(AwardToCommentDto dto)
    {
        return awardDao.AwardAComment(dto);
    }

    public Task<IEnumerable<Award>> GetAll()
    {
        return awardDao.GetAll();
    }
}