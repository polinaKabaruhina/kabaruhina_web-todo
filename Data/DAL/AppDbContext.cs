using Microsoft.EntityFrameworkCore;
using Todo.Data.DAL.ModelConfigurations;

namespace Todo.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Domain.Models.Task> Tasks{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskModelConfiguration());
        }
    }
}