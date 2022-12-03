using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        { }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
       
    }
}
