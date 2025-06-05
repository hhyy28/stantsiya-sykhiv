using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StantsiyaSykhivApi.Data.Models.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public ICollection<Column>? Columns { get; set; }
    }
}
