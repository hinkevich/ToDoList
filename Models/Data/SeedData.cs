using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ToDoList.Models.Data
{
    public class SeedData
    {
        public static void EnsurePopolate(IApplicationBuilder app)
        {
            ToDoListDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ToDoListDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.TaskCategories.Any())
            {
                context.TaskCategories.AddRange(
                    new TaskCategory 
                    {
                        Category = "My Day",
                        IsDeleted = false,
                    },
                    new TaskCategory
                    {
                        Category = "Important",
                        IsDeleted = false,
                    },
                    new TaskCategory
                    {
                        Category = "Planned",
                        IsDeleted = false,
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
