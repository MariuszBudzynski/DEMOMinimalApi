using DEMOMinimalApi;
using DEMOMinimalApi.Data.AutoDataLoader;
using DEMOMinimalApi.Data.DatabaseContext;
using DEMOMinimalApi.Data.Operations;
using DEMOMinimalApi.Data.Operations.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MinApiDemo")));
ServiceRegistration.AddPostServices(builder.Services);
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

app.MapGet("/Posts", async (IGetAllUseCase<Post> getAllPostsUseCase) =>
{
    var data = await getAllPostsUseCase.ExecuteAsync();
    return Results.Ok(data);
    
});

app.MapGet("/Posts/{id}", async (int id,IGetByIdUseCase<Post> getPostByIdUseCase ) =>
{
   var data = await getPostByIdUseCase.ExecuteAsync(id);

    if (data == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(data);

});

app.MapPost("/Posts",async (Post post,IAddDataUseCase<Post> addDataUseCase)=> 
{
    var data = await addDataUseCase.ExecuteAsync(post);
    return Results.Ok(data);
});

app.MapPut("/Posts", async (Post post,int id,IUpdateDataUseCase<Post> updateDataUseCase) =>
{
   var data = await updateDataUseCase.ExecuteAsync(post, id);

    if (data == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(data);
});

app.MapDelete("/Posts/{id}", async (int id,IDeleteDataUseCase<Post> deleteDataUseCase) =>
{
    var data = await deleteDataUseCase.ExecuteAsync(id);
    if (data == null)
    {
        return Results.NotFound();
    }
    return Results.NoContent();

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
