using DEMOMinimalApi.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MinApiDemo")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}

