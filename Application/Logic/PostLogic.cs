using Application.DAOInterfaces;
using Application.DTOs;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private IUserDao userDao;
    private IPostDao postDao;

    public PostLogic(IUserDao userDao, IPostDao postDao)
    {
        this.userDao = userDao;
        this.postDao = postDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? userPoster = await userDao.GetByUsername(dto.Username);
        if (userPoster == null)
        {
            throw new Exception("That user dont exist");
        }

        int id = postDao.GetNextPostId(dto.Subreddit).Result;
        Post newPost = new Post(id, dto.Title, dto.Body, userPoster, dto.Subreddit);
        Post created = await postDao.Create(newPost);
        return created;
    }

    public async Task<Post> UpvotePost(PostVoteDto dto)
    {
        Post? whichPost = await postDao.GetByIdAndSubreddit(dto.subreddit, dto.postId);
        if (whichPost == null)
        {
            throw new("There is no such post");
        }

        return await postDao.UpvotePost(whichPost);
    }

    public async Task<Post> DownvotePost(PostVoteDto dto)
    {
        Post? whichPost = await postDao.GetByIdAndSubreddit(dto.subreddit, dto.postId);
        if (whichPost == null)
        {
            throw new("There is no such post");
        }

        return await postDao.DownvotePost(whichPost);
    }

    public async Task<List<PostBrowseDto>> GetAllPostTitles(string subreddit)
    {
        return await postDao.GetAllPostTitles(subreddit);
    }
}