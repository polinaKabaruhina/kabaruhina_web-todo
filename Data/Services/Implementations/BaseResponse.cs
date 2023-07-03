using Todo.Data.Services.Enums;
using Todo.Data.Services.Interfaces;

namespace Todo.Data.Services.Implementations
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public StateCode StateCode{get;set;}
        public string Message{get;set;}
        public T Data {get; set;}
    }
}