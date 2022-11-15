using Application.DAOInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly RedditContext context;

    public PostEfcDao(RedditContext context)
    {
        this.context = context;
    }
    public async Task<Post> Create(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    
    public Task<int> GetNextPostId(string subreddit)
    {/*
        Subreddit? sub = context.Subreddits.FirstOrDefault(
            s => s.Title.ToLower().Equals(subreddit.ToLower()));
        if (sub == null)
        {
            throw new Exception("This subreddit doesn't exist.");
        }
        return Task.FromResult(sub.Posts.Count);
        */
        return Task.FromResult(-1);
    }
    

    public async Task<Post> GetByIdAndSubreddit(string subreddit, int id)
    { //it will only get by the ID
        Post? post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            throw new Exception("No such post.");
        }
        return post;
    }

    public async Task<Post> UpvotePost(Post post)
    {
        Post? p = await context.Posts.FindAsync(post.Id);
        p.Upvote();
        return p;
    }

    public async Task<Post> DownvotePost(Post post)
    {
        Post? p = await context.Posts.FindAsync(post.Id);
        p.Downvote();
        return p;
    }

    public Task<List<PostBrowseDto>> GetAllPostTitles(string subreddit)
    {
        List<PostBrowseDto> list = new List<PostBrowseDto>();

        var posts = context.Posts.Where(p => p.Subreddit.ToLower().Equals(subreddit));
        
        foreach (var p in posts)
        {
            list.Add(new PostBrowseDto(p.Title, p.Id));
        }

        return Task.FromResult(list);
    }
    
    

    public Task<IEnumerable<Post>> Get(PostSearchParameters searchParams)
    { //este método a não fazer sentido absolutamente nenhum lol
        IEnumerable<Post> posts = context.Posts.Where(
            p => p.Subreddit.ToLower().Equals(searchParams.subreddit.ToLower()));

        if (searchParams.postId != null)
        {
            posts = posts.Where(p => p.Id == searchParams.postId);
        }

        return Task.FromResult(posts);
    }
}