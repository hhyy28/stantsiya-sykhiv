namespace StantsiyaSykhivApi.Data.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public TaskItem Task { get; set; } = null!;

        public int AuthorId { get; set; }
        public User Author { get; set; } = null!;

        public string Content { get; set; } = null!;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
