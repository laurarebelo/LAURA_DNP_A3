using Application.DTOs;
using Domain;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    public Task<Post> Create(Post post);
    public Task<int> GetNextPostId(String subreddit);
    public Task<Post?> GetByIdAndSubreddit(String subreddit, int id);
    public Task<Post> UpvotePost(Post post);
    public Task<Post> DownvotePost(Post post);
    public Task<List<PostBrowseDto>> GetAllPostTitles(string subreddit);
}