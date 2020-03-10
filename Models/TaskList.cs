using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace my_todo.Models
{
    public class TaskList
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string OwnerId { get; set; }

        public TaskList() 
        {
        }

        public TaskList(long id, string ownerId)
        {
            Id = id;
            OwnerId = ownerId;
        }
    }
}

