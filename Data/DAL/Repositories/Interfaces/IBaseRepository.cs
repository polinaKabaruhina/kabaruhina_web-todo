namespace Todo.Data.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<bool> Insert(T entity);
        public Task<bool> Delete(int id);
        public Task<bool> DeleteAll();
        public Task<T> Select(int id);
        public Task<List<T>> SelectAll();
    }
}