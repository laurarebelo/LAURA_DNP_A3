using Application.DAOInterfaces;
using Application.DTOs;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;
    
    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsername(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        User toCreate = new User
        {
            Username = dto.UserName,
            Password = dto.Password
        };
    
        User created = await userDao.Create(toCreate);
    
        return created;
    }
    
}