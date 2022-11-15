using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class RedditContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Subreddit> Subreddits { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = C:/Users/laura/OneDrive/Documents/GitHub/LAURA_DNP_A3/EfcDataAccess/Reddit.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>().HasKey(comment => comment.Id);
        modelBuilder.Entity<User>().HasKey(user => user.Username);
        modelBuilder.Entity<Post>().HasKey(p => p.Id);
        modelBuilder.Entity<Subreddit>().HasKey(s => s.Title);
    }
}