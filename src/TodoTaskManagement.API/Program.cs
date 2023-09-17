using Microsoft.AspNetCore.Mvc;
using TodoTaskManagement.API.Endpoints.v1;
using TodoTaskManagement.Application;
using TodoTaskManagement.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

// builder.Services
//     .AddApiVersioning(setup =>
//     {
//         setup.DefaultApiVersion = new ApiVersion(1, 0);
//         setup.AssumeDefaultVersionWhenUnspecified = true;
//         setup.ReportApiVersions = true;
//     })
//     .AddVersionedApiExplorer(setup =>
//     {
//         setup.GroupNameFormat = "'v'VVV";
//         setup.SubstituteApiVersionInUrl = true;
//     });

var app = builder.Build();

app.UseSwaggerUI();

app.MapTodoItemEndpoints();

app.Run();