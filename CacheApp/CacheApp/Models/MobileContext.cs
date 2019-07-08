using Microsoft.EntityFrameworkCore;

namespace CacheApp.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MobileContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}