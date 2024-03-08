using DEMOMinimalApi.Data.DatabaseContext;
using DEMOMinimalApi.Repository.Interfaces;

namespace DEMOMinimalApi.Repository
{
    public class Repository : IRepository<Post>
    {
        private readonly DatabaseContext _db;

        public Repository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task SavaData(List<Post> posts)
        {
            
            foreach (var post in posts)
            {
                _db.Add(new Post
                {
                    
                });
                


            }
            await _db.SaveChangesAsync();

        }
    }
}
