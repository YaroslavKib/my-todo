using System.Collections.Generic;

namespace my_todo.Models
{
    public class TaskList
    {
        public long Id { get; set; }
        public List<long> TaskIds { get; } = new List<long>();
        public string OwnerId { get; set; }

        public TaskList() { }

        public TaskList(long id, string ownerId)
        {
            Id = id;
            OwnerId = ownerId;
        }
    }
}
