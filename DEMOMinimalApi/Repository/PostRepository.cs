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
            var posts = await (_db.Posts).Where(x=>x.HasBeenDeleted != 1).ToListAsync();
            return posts;
        }

        public async Task<Post> GetDataById(int id)
        {
            var post = (await GetAllData()).FirstOrDefault(x=>x.PostId==id);
            return post;
            
        }

        public async Task<Post> DeleteData(int id)
        {
            //soft delete
            Post? data = await GetDataById(id);

            if (data == null)
            {
                return data;
            }
            else
            {
                data.HasBeenDeleted = 1;
                await _db.SaveChangesAsync();
                return data;
            }
        }

        public async Task<Post> AddData(Post post)
        {
            Post? data = await _db.Posts.FirstOrDefaultAsync(x => x.PostId == post.PostId);

            if (data == null)
            {
                await _db.AddAsync(post);
                await _db.SaveChangesAsync();       
            }
            else if (data.HasBeenDeleted == 1)
            {
                data.HasBeenDeleted = 0;
                await _db.SaveChangesAsync();
            }
            return await GetDataById(post.PostId);
        }


        public async Task<Post> UpdateData(Post post,int id)
        {
            Post? data = await GetDataById(id);

            if (data == null)
            {
                return data;
            }
            else
            {
                data.Title = post.Title;
                data.Body = post.Body;
                await _db.SaveChangesAsync();
                return data;
            }
        }
    }
}
