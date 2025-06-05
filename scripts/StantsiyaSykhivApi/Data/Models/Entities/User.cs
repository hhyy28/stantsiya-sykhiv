namespace StantsiyaSykhivApi.Data.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<TaskItem>? Tasks { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
