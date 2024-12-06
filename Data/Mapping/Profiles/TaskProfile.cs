using AutoMapper;
using Todo.Data.Domain.Models;
using Todo.Data.DTO;

namespace Todo.Data.Mapping.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskEntity, CreateTodoDto>().ReverseMap();
            CreateMap<TaskEntity,ChangeTextTodoDto>().ReverseMap();
            CreateMap<TaskEntity, ChangeStatusTodoDto>().ReverseMap();
            
        }
    }
}