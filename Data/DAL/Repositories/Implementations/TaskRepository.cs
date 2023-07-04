using Microsoft.EntityFrameworkCore;
using Todo.Data.DAL.Repositories.Interfaces;
using Todo.Data.Domain.Models;

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

        public async Task<bool> DeleteAllReady()
        {
            var list = await context.Tasks.Where(t => t.Status == true).ToListAsync();
            context.Tasks.RemoveRange(list);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<TaskEntity> Insert(TaskEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await context.Tasks.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskEntity> Select(int id)
        {
            return await context.Tasks.FindAsync(id);
        }

        public async Task<List<TaskEntity>> SelectAll()
        {
            return await context.Tasks.ToListAsync();
        }

        public async Task Update(TaskEntity entity)
        {
            context.Tasks.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAll(List<TaskEntity> entities)
        {
            context.Tasks.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}