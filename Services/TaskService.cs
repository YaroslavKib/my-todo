using my_todo.Data;
using my_todo.Models;
using System.Linq;

namespace my_todo.Services
{
    public class TaskService 
    {
        private ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Task GetById(long id)
            => _context.Tasks.First(t => t.Id == id);
    }
}
