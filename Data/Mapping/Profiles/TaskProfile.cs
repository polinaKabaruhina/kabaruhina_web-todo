using AutoMapper;
using Todo.Data.DAL.DTO;

namespace Todo.Data.Mapping.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Domain.Models.Task, CreateTodoDto>().ReverseMap();
        }
    }
}