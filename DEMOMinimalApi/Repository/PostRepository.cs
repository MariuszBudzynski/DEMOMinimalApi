using DEMOMinimalApi.Data.DatabaseContext;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DatabaseContext _db;

        public PostRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task SavaData<T>(List<T> posts) where T : class
        {
            await _db.AddRangeAsync(posts);
            await _db.SaveChangesAsync();

        }
    }
}
