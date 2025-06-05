using Microsoft.EntityFrameworkCore;
using StantsiyaSykhivApi.Data.Models.Entities;

namespace StantsiyaSykhivApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<Column> Columns => Set<Column>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<TaskColumnLink> TaskColumnLinks => Set<TaskColumnLink>();
        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<TaskItem>()
            .Property(t => t.Status)
            .HasConversion<string>();

            mb.Entity<TaskColumnLink>()
              .HasKey(x => new { x.TaskId, x.ColumnId });

            mb.Entity<TaskColumnLink>()
              .HasOne(x => x.Task)
              .WithMany(t => t.TaskColumnLinks)
              .HasForeignKey(x => x.TaskId);

            mb.Entity<TaskColumnLink>()
              .HasOne(x => x.Column)
              .WithMany(c => c.TaskColumnLinks)
              .HasForeignKey(x => x.ColumnId);

            mb.Entity<Project>().HasData(
                new Project { Id = 1, Title = "API Dev", Description = "Create backend API", OwnerId = 1 },
                new Project { Id = 2, Title = "Frontend UI", Description = "Build UI", OwnerId = 2 }
            );
            
            mb.Entity<Board>().HasData(
                new Board { Id = 1, Title = "Development", ProjectId = 1 },
                new Board { Id = 2, Title = "UI Design", ProjectId = 2 }
            );

            mb.Entity<Column>().HasData(
                new Column { Id = 1, Title = "To Do", BoardId = 1, Order = 1 },
                new Column { Id = 2, Title = "In Progress", BoardId = 1, Order = 2 },
                new Column { Id = 3, Title = "Done", BoardId = 1, Order = 3 }
            );

            mb.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Setup project", Description = "Initial project setup", StartDate = DateTime.UtcNow.AddDays(-2), EndDate = DateTime.UtcNow.AddDays(2), Status = Models.Entities.TaskStatus.ToDo, ProjectId = 1, AssigneeId = 2 },
                new TaskItem { Id = 2, Title = "Create login form", Description = "UI for login", StartDate = DateTime.UtcNow.AddDays(-1), EndDate = DateTime.UtcNow.AddDays(1), Status = Models.Entities.TaskStatus.InProgress, ProjectId = 2, AssigneeId = 3 }
            );

            mb.Entity<TaskColumnLink>().HasData(
                new TaskColumnLink { TaskId = 1, ColumnId = 1 },
                new TaskColumnLink { TaskId = 2, ColumnId = 2 }
            );

            mb.Entity<Comment>().HasData(
                new Comment { Id = 1, TaskId = 1, AuthorId = 1, Content = "Don't forget logging", Timestamp = DateTime.UtcNow },
                new Comment { Id = 2, TaskId = 2, AuthorId = 2, Content = "UI is almost done", Timestamp = DateTime.UtcNow }
            );
        }
    }
}
