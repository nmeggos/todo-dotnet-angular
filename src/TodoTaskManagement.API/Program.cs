using Microsoft.AspNetCore.Mvc;
using TodoTaskManagement.API.Endpoints;
using TodoTaskManagement.Application;
using TodoTaskManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<TodoDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseSwaggerUI();

app.MapTodoItemEndpoints();
app.MapTodoCategoryEndpoints();

app.Run();