using Application.DAOInterfaces;
using Application.DTOs;
using Application.LogicInterfaces;
using Domain;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{
    private ICommentDao commentDao;
    private IPostDao postDao;
    private IUserDao userDao;

    public CommentLogic(ICommentDao commentDao, IPostDao postDao, IUserDao userDao)
    {
        this.commentDao = commentDao;
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Comment> CreateAsync(CommentCreationDto dto)
    {
        Post? existing = await postDao.GetByIdAndSubreddit(dto.Subreddit, dto.PostId);
        if (existing == null)
        {
            throw new Exception("You cannot comment on a non existing post.");
        }

        User? existingUser = await userDao.GetByUsername(dto.Username);
        if (existingUser == null)
        {
            throw new Exception("Non existing user.");
        }

        int id = await commentDao.GetNextCommentId(dto.Subreddit, dto.PostId);

        Comment created = new Comment(id, dto.PostId, dto.Body, existingUser, dto.Subreddit);
        return await commentDao.CreateAsync(created);
    }
}