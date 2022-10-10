using Application.DAOInterfaces;
using Domain;

namespace FileData.DAOs;

public class AwardDao : IAwardDao
{
    private FileContext context;

    public AwardDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Award> Create(Award award)
    {
        context.Awards.Add(award);
        context.SaveChanges();
        return Task.FromResult(award);
    }

    public Task<Award?> GetByName(string name)
    {
        Award? existing = context.Awards.FirstOrDefault(a =>
            a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<int> GetNextId()
    {
        return Task.FromResult(context.Awards.Count);
    }
}