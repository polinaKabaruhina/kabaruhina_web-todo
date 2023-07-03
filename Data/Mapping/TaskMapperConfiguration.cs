using AutoMapper;
using Todo.Data.DAL.DTO;
using Todo.Data.Mapping.Profiles;

namespace Todo.Data.Mapping
{
    public class TaskMapperConfiguration
    {
        public IMapper Mapper{get;set;}
        public void UseMapper()
        {
            var configuration = new MapperConfiguration(c => 
            {
                c.AddProfile<TaskProfile>();
            });
            configuration.AssertConfigurationIsValid();
            Mapper = configuration.CreateMapper();
        }
    }
}