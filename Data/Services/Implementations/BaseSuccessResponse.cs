using Todo.Data.Services.Interfaces;
using Todo.Data.Services.Enums;

namespace Todo.Data.Services.Implementations
{
    public class BaseSuccessResponse<T> : IBaseResponse<T>
    {
        public StatusCode StatusCode{get;set;}
        public bool Success{get;set;}
        public T Data {get; set;}
    }

    public class BaseSuccessResponse
    {
        public StatusCode StatusCode{get;set;}
        public bool Success{get;set;}
    }
}