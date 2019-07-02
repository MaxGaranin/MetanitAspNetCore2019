using Microsoft.EntityFrameworkCore;

namespace MobileStore.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 1,
                    Name = "iPhone 6S",
                    Company = "Apple",
                    Price = 600
                },
                new Phone
                {
                    Id = 2,
                    Name = "Samsung Galaxy Edge",
                    Company = "Samsung",
                    Price = 550
                },
                new Phone
                {
                    Id = 3,
                    Name = "Lumia 950",
                    Company = "Microsoft",
                    Price = 500
                }
            );
        }
    }
}