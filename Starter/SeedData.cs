using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Starter.Data;
using Starter.Models;

namespace Starter
{
    public static class SeedData
    {
        public const string AdministratorRole = "Administrator";
        public const string CustomerRole = "Customer";

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            //            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            //           {
            //                if (!context.Categories.Any())
            //                    context.Categories.Add(new Category { Name="Category Abc"});
            //                    context.SaveChanges();
            //            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            await EnsureRolesAsync(roleManager, AdministratorRole);
            await EnsureRolesAsync(roleManager, CustomerRole);
            await EnsureTestAdminAsync(userManager, "admin", "admin@admin.com", "11111111", AdministratorRole);
            await EnsureTestAdminAsync(userManager, "user", "user@shop.com", "11111111", CustomerRole);





        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(roleName);

            if (alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        private static async Task EnsureTestAdminAsync(UserManager<User> userManager, string username, string email,string pwd, string roleName)
        {
            var testUser = await userManager.Users
                .Where(x => x.UserName == username)
                .SingleOrDefaultAsync();

            if (testUser != null) return;

            testUser = new User
            {
                UserName = username,
                Email = email
            };
            await userManager.CreateAsync(testUser, pwd);
            await userManager.AddToRoleAsync(testUser, roleName);
        }
    }
}