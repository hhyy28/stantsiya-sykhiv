namespace StantsiyaSykhivApi.Data.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;

        public ICollection<Board>? Boards { get; set; }
        public ICollection<TaskItem>? Tasks { get; set; }
    }
}
