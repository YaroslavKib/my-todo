namespace my_todo.Models
{
    public class Task
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string OwnerId { get; set; }
        public bool IsDone { get; set; }
        public int TaskListId { get; set; }
        public TaskList TaskList { get; set; }

        public Task() { }

        public Task(long id, string content, string ownerId, bool isDone, int taskListId)
        {
            Id = id;
            Content = content;
            OwnerId = ownerId;
            IsDone = isDone;
            TaskListId = taskListId;
        }
    }
}
