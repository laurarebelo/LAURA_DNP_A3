using Domain;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    public Task<Post> Create(Post post);
    public Task<int> GetNextPostId(String subreddit);
}