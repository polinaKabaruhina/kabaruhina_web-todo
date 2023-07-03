using Todo.Data.Domain.Models;

namespace Todo.Data.DAL.Repositories.Interfaces
{
    public interface ITaskRepository : IBaseRepository<Domain.Models.Task>
    {
        public Task<Domain.Models.Task> PatchStatus(int id, bool status);
    }
}