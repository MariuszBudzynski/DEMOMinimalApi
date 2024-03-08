using DEMOMinimalApi.Data.DatabaseContext;
using DEMOMinimalApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DEMOMinimalApi.Repository
{
    public class PostRepository : IRepository<Post>
    {
        private readonly DatabaseContext _db;

        public PostRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task FirstLoadDataSave(List<Post> posts)
        {
            var postsdata = await GetAllData();

            foreach (var post in posts)
            {

                var postInDb = postsdata.FirstOrDefault(x => x.PostId == post.Id);

                if (postInDb is null)
                {

                    _db.Add(new Post
                    {
                        PostId = post.Id,
                        UserId = post.UserId,
                        Title = post.Title,
                        Body = post.Body
                    });
                }
            }
            await _db.SaveChangesAsync();

        }

        public async Task<List<Post>> GetAllData()
        {
            var posts = await (_db.Posts).ToListAsync();
            return posts;
        }
    }
}
