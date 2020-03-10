using my_todo.Data;
using System.Collections.Generic;
using my_todo.Models;
using System.Linq;

namespace my_todo.Services
{
    public class TaskListService 
    {
        private ApplicationDbContext _context;

        public TaskListService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public TaskList GetById(long id)
        {
            return _context.TaskLists.First(t => t.Id == id);
        }
        
        public IEnumerable<TaskList> GetByOwnerId(string ownerId)
        {
            return _context.TaskLists.Where(t => t.OwnerId == ownerId);
        }

        public IEnumerable<TaskList> Add(TaskList taskList)
        {
            _context.TaskLists.Add(taskList);
            _context.SaveChanges();

            return GetByOwnerId(taskList.OwnerId);
        }
    }
}
