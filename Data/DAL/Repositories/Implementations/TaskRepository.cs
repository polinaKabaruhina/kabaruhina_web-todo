using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Delete(int id)
        {
            var task = await Select(id);
            context.Tasks.Remove(task);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAll()
        {
            var list = await SelectAll();
            context.RemoveRange(list);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insert(Domain.Models.Task entity)
        {
            await context.Tasks.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Domain.Models.Task> Select(int id)
        {
            return await context.Tasks.FindAsync(id);
        }

        public async Task<List<Domain.Models.Task>> SelectAll()
        {
            return await context.Tasks.ToListAsync();
        }
    }
}