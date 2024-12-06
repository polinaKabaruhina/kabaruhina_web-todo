using Todo.Data.DTO;

namespace Todo.Data.Services.Interfaces
{
    public interface IBaseResponse<T>
    {
        public T Data{get;set;}
    }
}