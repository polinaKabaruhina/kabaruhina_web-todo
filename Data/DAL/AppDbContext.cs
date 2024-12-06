using Microsoft.EntityFrameworkCore;
using Todo.Data.Domain.Models;

namespace Todo.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TaskEntity> Tasks{get;set;}
    }
}