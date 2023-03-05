using Database.Local;
using Microsoft.EntityFrameworkCore;

namespace Projects.Service
{
    public class ProjectsDbContext : LocalDbContext
    {
        public ProjectsDbContext() : base() { }

        public DbSet<Project> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
