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

        public TaskList Put(long id, TaskList req)
        {
            var taskList = _context.TaskLists.FirstOrDefault(t => t.Id == id);

            if (taskList == default(TaskList))
                return null;

            taskList.Name = req.Name;

            _context.SaveChanges();

            return taskList;
        }
        
        public IEnumerable<TaskList> GetByOwnerId(string ownerId)
        {
            return _context.TaskLists.Where(t => t.OwnerId == ownerId);
        }

        public TaskList Add(TaskList taskList)
        {
            _context.TaskLists.Add(taskList);
            _context.SaveChanges();

            return taskList;
        }
    }
}
