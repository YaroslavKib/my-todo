using my_todo.Data;

namespace my_todo.Services
{
    public class TaskListSerivce 
    {
        private ApplicationDbContext _context;

        public TaskListSerivce(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}
