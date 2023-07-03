using Todo.Data.DAL.DTO;
using Todo.Data.Mapping;

namespace Todo.Data.Services.Interfaces
{
    public interface IBaseService<T>
    {
        public TaskMapperConfiguration MapperConfiguration{get;set;}
        public Task<IBaseResponse<T>> Create(CreateTodoDto entityDto);
        public Task<IBaseResponse<bool>> Delete(int id);
        public Task<IBaseResponse<bool>> DeleteAllReady();
    }
}