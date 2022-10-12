using Application.DTOs;
using Domain;

namespace Application.DAOInterfaces;

public interface IAwardDao
{
    public Task<Award> Create(Award award);
    public Task<Award?> GetByName(String name);
    public Task<Subreddit> GetSubreddit(String subreddit);
    public Task<Post> GetPostInSubreddit(String subreddit, int postId);
    public Task<Comment> GetCommentInPostInSubreddit(String subreddit, int postId, int commentId);
    public Task<int> GetNextId();
    public Task<Post> AwardAPost(AwardToPostDto atpDto);
    public Task<Comment> AwardAComment(AwardToCommentDto atcDto);
}