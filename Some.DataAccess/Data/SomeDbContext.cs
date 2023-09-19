using Microsoft.EntityFrameworkCore;
using Some.DataAccess.Data.Entities;

namespace Some.DataAccess.Data
{
    public class SomeDbContext : DbContext
    {
        public SomeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
