using my_todo.Data;
using my_todo.Models;
using System.Linq;
using System.Collections.Generic;

namespace my_todo.Services
{
    public class TaskService 
    {
        private ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Task> Add(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return GetByOwnerId(task.OwnerId);
        }

        public IEnumerable<Task> Delete(long id, string ownerId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == default(Task))
                return null;

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return GetByOwnerId(ownerId);
        }

        public IEnumerable<Task> Put(long id, Task req)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == default(Task))
                return null;
                
            task.Content = req.Content;
            task.IsDone = req.IsDone;
            task.TaskListId = req.TaskListId;

            _context.SaveChanges();

            return GetByOwnerId(task.OwnerId);
        }

        public IEnumerable<Task> DeleteAll(string ownerId)
        {
            _context.Tasks.RemoveRange(_context.Tasks.Where(t => t.OwnerId == ownerId));
            _context.SaveChanges();
 
            return GetByOwnerId(ownerId);
        }

        public IEnumerable<Task> GetByOwnerId(string id)
            => _context.Tasks.Where(t => t.OwnerId == id);

        public Task GetByTaskId(long id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == default(Task))
                return null;
            else
                return task;
        }
    }
}
