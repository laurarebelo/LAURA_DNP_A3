using Application.DAOInterfaces;
using Application.DTOs;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class AwardLogic : IAwardLogic
{
    private readonly IAwardDao awardDao;

    public AwardLogic(IAwardDao dao)
    {
        this.awardDao = dao;
    }

    public async Task<Award> Create(AwardCreationDto dto)
    {
        Award? existing = await awardDao.GetByName(dto.Name);
        if (existing != null)
        {
            throw new Exception("There is already an award with that name.");
        }

        int newId = awardDao.GetNextId().Result;
        
        Award newAward = new Award(dto.Name, newId);
        Award created = await awardDao.Create(newAward);
        return created;

    }
}