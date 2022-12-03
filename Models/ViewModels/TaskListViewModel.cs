using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ToDoList.Models.ViewModels
{
    public class TaskListViewModel
    {
        public IQueryable<UserTask> Tasks { get; set; }
        public IQueryable<TaskCategory> Categories { get; set; }

        [BindProperty]
        public UserTask UserTask { get; set; }
    }
}
