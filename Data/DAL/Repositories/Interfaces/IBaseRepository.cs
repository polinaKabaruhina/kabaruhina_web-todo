namespace Todo.Data.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<bool> Insert(T entity);
    }
}