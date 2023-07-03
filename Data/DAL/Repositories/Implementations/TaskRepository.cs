using Todo.Data.DAL.Repositories.Interfaces;

namespace Todo.Data.DAL.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext context;
        public TaskRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Insert(Domain.Models.Task entity)
        {
            await context.Tasks.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }
    }
}