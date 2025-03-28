using Jotem.Catalog.Api.Features.Categories;
using Jotem.Catalog.Api.Options;
using Jotem.Catalog.Api.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



//Extension methods
builder.Services.AddMongoOptions();
builder.Services.AddRepositoryOptions();

var app = builder.Build();

app.AddCategoryEntpointGroupExt();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

