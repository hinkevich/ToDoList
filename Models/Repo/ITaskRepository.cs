using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models.Repo
{
    public interface ITaskRepository
    {
        IQueryable<UserTask> Tasks { get; }
        IQueryable<TaskCategory> Categories { get; }

        public Task AddUserTask(UserTask userTask);

        public Task<int> DeleteUserTask(int id);

        public  Task<int> UpdateUserTask(int id, UserTask userTask);

        public  Task<int> ChangeStatusUserTask(int id);

        public Task<UserTask> GetUserTask(int id);
        public Task<int> EditUserTask(UserTask userTask);


       
    }
}
