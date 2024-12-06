using Todo.Data.DTO;
using Todo.Data.Services.Enums;
using Todo.Data.Services.Interfaces;

namespace Todo.Data.Services.Implementations
{
    public class CustomSuccessResponse : IBaseResponse<GetNewsDto>
    {
        public StatusCode StatusCode{get;set;}
        public bool Success{get;set;}
        public GetNewsDto Data {get;set;}
    }
}