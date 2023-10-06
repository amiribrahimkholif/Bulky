using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "History", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Science Fiction", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(
               new Product 
               { 
                   Id = 1,
                   Title = "Book1", 
                   ISBN = "1111",
                   Description = "Description 1",
                   Author = "Author1", 
                   ListPrice = 100 , 
                   Price = 150 ,
                   Price50 = 140 , 
                   Price100 = 120,
                   CategoryId = 1,
                   ImageUrl=""
               },
               new Product 
               { 
                   Id = 2,
                   Title = "Book2", 
                   ISBN = "2222",
                   Description = "Description 2",
                   Author = "Author1",
                   ListPrice = 100, 
                   Price = 150, 
                   Price50 = 140, 
                   Price100 = 120,
                   CategoryId = 2,
                   ImageUrl = ""
               },
               new Product
               {
                   Id = 3,
                   Title = "Book",
                   ISBN = "3333",
                   Description = "Description 3",
                   Author = "Author3",
                   ListPrice = 100,
                   Price = 150,
                   Price50 = 140,
                   Price100 = 120,
                   CategoryId = 3,
                   ImageUrl = ""
               }
           );

            base.OnModelCreating(modelBuilder);
        }


    }
}
