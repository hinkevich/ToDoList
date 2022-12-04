using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models.Repo
{
    public class ECTaskRepository : ITaskRepository
    {
        private readonly ToDoListDbContext _dbContext;
        public ECTaskRepository(ToDoListDbContext context)
        {
            _dbContext = context;
        }
        public IQueryable<UserTask> Tasks { get => _dbContext.Tasks; }

        public IQueryable<TaskCategory> Categories { get => _dbContext.TaskCategories; }

        public async Task AddUserTask(UserTask userTask)
        {
            _dbContext.Tasks.Add(userTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> ChangeStatusUserTask(int id)
        {
            UserTask userTask = await _dbContext.Tasks.FindAsync(id);

            if (userTask.IsDone)
            {
                userTask.IsDone = false;
            }
            else
            {
                userTask.IsDone = true;
            }
            _dbContext.Attach(userTask).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(userTask.Id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
            return id;
        }

        public async Task<int> DeleteUserTask(int id)
        {
            UserTask userTask = await _dbContext.Tasks.FindAsync(id);

            if (userTask != null)
            {
                _dbContext.Tasks.Remove(userTask);
                await _dbContext.SaveChangesAsync();
            }
            return id;
        }

        public async Task<int> EditUserTask(UserTask userTask)
        {
            
            _dbContext.Attach(userTask).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(userTask.Id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
            return userTask.Id;
        }

        public async Task<UserTask> GetUserTask(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public Task<int> UpdateUserTask(int id, UserTask userTask)
        {
            throw new System.NotImplementedException();
        }

        private bool UserTaskExists(int id)
        {
            return _dbContext.Tasks.Any(e => e.Id == id);
        }
    }
    
}
