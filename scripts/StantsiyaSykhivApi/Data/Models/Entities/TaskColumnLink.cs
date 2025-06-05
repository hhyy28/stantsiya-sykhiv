namespace StantsiyaSykhivApi.Data.Models.Entities
{
    public class TaskColumnLink
    {
        public int TaskId { get; set; }
        public TaskItem Task { get; set; } = null!;

        public int ColumnId { get; set; }
        public Column Column { get; set; } = null!;
    }
}
