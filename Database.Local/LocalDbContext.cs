using Microsoft.EntityFrameworkCore;

namespace Database.Local
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext()
        {
            Database.EnsureCreated();
        }

        protected sealed override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=local.db");
        }
    }
}