using Microsoft.EntityFrameworkCore;

namespace DEMOMinimalApi.Data.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Post> Posts { get; set; }

    }
}
