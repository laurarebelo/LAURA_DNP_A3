using Application.DAOInterfaces;
using Application.DTOs;
using Application.Logic;
using Application.LogicInterfaces;
using FileData;
using FileData.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

builder.Services.AddScoped<ISubredditDao, SubredditDao>();
builder.Services.AddScoped<ISubredditLogic, SubredditLogic>();

builder.Services.AddScoped<IPostDao, PostDao>();
builder.Services.AddScoped<IPostLogic, PostLogic>();

builder.Services.AddScoped<IAwardDao, AwardDao>();
builder.Services.AddScoped<IAwardLogic, AwardLogic>();

builder.Services.AddScoped<ICommentDao, CommentDao>();
builder.Services.AddScoped<ICommentLogic, CommentLogic>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
