namespace StantsiyaSykhivApi.Data.Models.Entities
{
    public enum TaskStatus { ToDo, InProgress, Done }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.ToDo;

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public int? AssigneeId { get; set; }
        public User? Assignee { get; set; }

        public ICollection<TaskColumnLink>? TaskColumnLinks { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
