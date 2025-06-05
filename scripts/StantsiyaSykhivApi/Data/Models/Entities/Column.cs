namespace StantsiyaSykhivApi.Data.Models.Entities
{
    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Order { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; } = null!;

        public ICollection<TaskColumnLink>? TaskColumnLinks { get; set; }
    }
}
