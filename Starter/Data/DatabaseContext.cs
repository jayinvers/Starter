using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Starter.Models;

namespace Starter.Data
{
    public partial class DatabaseContext : IdentityDbContext<User>
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        // TODO: Add your data model(Entity Model) 

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        private List<Product> getProducts(int startNum, int endNum, int categoryId)
        {
            List<Product> products = new List<Product>();
            for(int i = startNum; i < endNum; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    ProductName = $"product {i}",
                    Description = $"This is a description {i}",
                    Price = 100.00m + i,
                    Sn = $"sn0000{i}",
                    Detail = $"{i} Here you go.",
                    CategoryId = categoryId
                });
            }

            return products;

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category(){
                    CategoryId = 1,
                    Name = "Women",
                    Slug = "women",
                    ParentId = 0
                },
                new Category(){
                    CategoryId = 2,
                    Name = "Men",
                    Slug = "men",
                    ParentId = 0
                },
                new Category(){
                    CategoryId = 3,
                    Name = "Kids",
                    Slug = "kids",
                    ParentId = 0
                },
                new Category()
                {
                    CategoryId = 4,
                    Name = "Baby",
                    Slug = "baby",
                    ParentId = 0
                }

            );

            builder.Entity<Product>().HasData(getProducts(1,20,1));
            builder.Entity<Product>().HasData(getProducts(20, 40, 2));
            builder.Entity<Product>().HasData(getProducts(40, 60, 3));
            builder.Entity<Product>().HasData(getProducts(60, 80, 4));

            builder.Entity<User>().ToTable("Users");
            

        }
    }

}
