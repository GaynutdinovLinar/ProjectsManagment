using Database.Local;
using Microsoft.EntityFrameworkCore;
using Projects.Service.Objects;

namespace Projects.Service
{
    public class ProjectsDbContext : LocalDbContext
    {
        public ProjectsDbContext() : base() { }

        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<ProjectCommand> ProjectCommands { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
