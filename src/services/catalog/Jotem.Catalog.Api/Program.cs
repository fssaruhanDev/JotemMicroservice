using Jotem.Catalog.Api;
using Jotem.Catalog.Api.Features.Categories;
using Jotem.Catalog.Api.Features.Courses;
using Jotem.Catalog.Api.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//Extension methods
builder.Services.AddMongoOptionsExt();
builder.Services.AddDatabaseOptionsExt();
builder.Services.AddCommandServiceExt(typeof(CatalogAssembly));
builder.Services.AddVersioningExt();
var app = builder.Build();

app.AddCategoryGroupEndpointExt(app.AddVersionSetExt());
app.AddCourseGroupEndpointExt(app.AddVersionSetExt());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

