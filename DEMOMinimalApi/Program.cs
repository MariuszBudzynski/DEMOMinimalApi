using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    // for testing purposes to be removed later
    return new Post() {UserId= 1,Id = 1, Title = "test" , Body = "test" };

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
    public string Title { get; set; }
    public string Body { get; set; }
}

