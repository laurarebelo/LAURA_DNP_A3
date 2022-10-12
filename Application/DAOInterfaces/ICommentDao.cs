using Domain;

namespace Application.DAOInterfaces;

public interface ICommentDao
{
    public Task<Comment> CreateAsync(Comment comment);
    public Task<int> GetNextCommentId(string subreddit, int postId);
}