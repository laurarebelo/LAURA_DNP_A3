using Application.DTOs;
using Domain;

namespace Application.LogicInterfaces
{
    public interface IUserLogic
    {
        Task<User> CreateAsync(UserCreationDto userToCreate);
    }
}