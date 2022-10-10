using Domain;

namespace Application.DAOInterfaces;

public interface IAwardDao
{
    public Task<Award> Create(Award award);
    public Task<Award?> GetByName(String name);
    public Task<int> GetNextId();
}