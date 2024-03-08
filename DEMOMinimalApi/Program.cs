using DEMOMinimalApi.Data.AutoDataLoader;
using DEMOMinimalApi.Data.DatabaseContext;
using DEMOMinimalApi.Data.Operations;
using DEMOMinimalApi.Data.Operations.Interfaces;
using DEMOMinimalApi.Repository;
using DEMOMinimalApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MinApiDemo")));
builder.Services.AddScoped<IRepository<Post>, PostRepository>();
builder.Services.AddScoped<LoadData>();
builder.Services.AddScoped<FirstLoadDataSaveUseCase<Post>, FirstLoadDataSaveUseCase>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//is used to retrieve the instance of the service injected into the container
var loadData = app.Services.CreateScope().ServiceProvider.GetRequiredService<LoadData>();
await loadData.LoadDataJSON();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Posts", () =>
{
    // to implement
    
});

app.MapGet("/Posts/{id}", (int id) =>
{
   // to implement

});

app.MapPost("/Posts",(Post post)=> 
{
    // to implement
});

app.MapPut("/Posts", (Post post,int id) =>
{
    // to implement
});

app.MapDelete("/Posts/{id}", (int id) =>
{
    // to implement

});

app.Run();

public class Post
{
    [Key]
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public int HasBeenDeleted { get; set; } = 0;
}
