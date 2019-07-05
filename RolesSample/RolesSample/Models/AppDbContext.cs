using Microsoft.EntityFrameworkCore;

namespace RolesSample.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminRoleName = "admin";
            var userRoleName = "user";

            var adminEmail = "admin@mail.ru";
            var adminPassword = "123456";

            // добавляем роли
            var adminRole = new Role {Id = 1, Name = adminRoleName};
            var userRole = new Role {Id = 2, Name = userRoleName};
            var adminUser = new User {Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id};

            modelBuilder.Entity<Role>().HasData(new Role[] {adminRole, userRole});
            modelBuilder.Entity<User>().HasData(new User[] {adminUser});

            base.OnModelCreating(modelBuilder);
        }
    }
}