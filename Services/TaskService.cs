using my_todo.Data;

namespace my_todo.Services
{
    public class TaskService 
    {
        private ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}
