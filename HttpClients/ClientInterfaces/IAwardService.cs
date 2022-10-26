using Domain;
using Domain.DTOs;

namespace HttpClients.ClientInterfaces;

public interface IAwardService
{
    Task<Award> Create(AwardCreationDto dto);
    Task<IEnumerable<Award>> GetAll();
    Task<Award> AwardPost(AwardToPostDto dto);
}