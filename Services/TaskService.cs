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
        public IEnumerable<Task> GetByOwnerId(string id)
            => _context.Tasks.Where(t => t.OwnerId == id);

        public Task GetByTaskId(long id)
            => _context.Tasks.First(t => t.Id == id);
    }
}
