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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*            builder.Entity<User>()
                            .HasData(new User
                            {

                                FirstName = "Admin",
                                LastName = "Admin",
                                Email = "admin@admin.com",
                                ConcurrencyStamp = Guid.NewGuid().ToString()
                            }, new User
                            {
                                ConcurrencyStamp = Guid.NewGuid().ToString()
                            });
                        builder.Entity<Role>()
                        .HasData(new Role
                        {

                            Name = "Administrators",
                            NormalizedName = "ADMINISTRATORS",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        }, new Role
                        {
                            Name = "Users",
                            NormalizedName = "USERS",
                            ConcurrencyStamp = Guid.NewGuid().ToString()
                        });*/

            builder.Entity<User>().ToTable("Users");
            

        }
    }

}
