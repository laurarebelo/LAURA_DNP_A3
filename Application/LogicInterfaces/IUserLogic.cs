using System.Threading.Tasks;
using Domain.DTOs;

namespace Application.LogicInterfaces
{
    public interface IUserLogic
    {
        Task<User> CreateAsync(UserCreationDto userToCreate);
    }
}