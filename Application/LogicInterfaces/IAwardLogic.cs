using Application.DTOs;
using Domain;

namespace Application.LogicInterfaces;

public interface IAwardLogic
{
    public Task<Award> Create(AwardCreationDto dto);
}