using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Starter.Data;
using Starter.Models;

namespace Starter
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>())){

                if (!context.Categories.Any())
                    context.Categories.Add(new Category { Name="Category Abc"});

                
                context.SaveChanges();
            }
        }
    }
}