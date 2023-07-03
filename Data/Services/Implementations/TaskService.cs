using Todo.Data.DAL.DTO;
using Todo.Data.DAL.Repositories.Interfaces;
using Todo.Data.Mapping;
using Todo.Data.Services.Interfaces;

namespace Todo.Data.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public TaskMapperConfiguration MapperConfiguration {get;set;}
        private readonly ITaskRepository repository;
        public TaskService(ITaskRepository repository, TaskMapperConfiguration MapperConfiguration)
        {
            this.repository = repository;
            this.MapperConfiguration = MapperConfiguration;
            MapperConfiguration.UseMapper();
        }

        public async Task<IBaseResponse<CreateTodoDto>> Create(CreateTodoDto entityDto)
        {
            try
            {
                var response  = new BaseResponse<CreateTodoDto>();
                var task = MapperConfiguration.Mapper.Map<Domain.Models.Task>(entityDto);
                await repository.Insert(task);
                response.StateCode = Enums.StateCode.Created;
                response.Data = entityDto;
                return response;
            }
            catch(Exception exp)
            {
                return new BaseResponse<CreateTodoDto>()
                {
                    Message = $"[Create: ] {exp.Message}",
                    StateCode = Enums.StateCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            try
            {
                var response  = new BaseResponse<bool>();
                await repository.Delete(id);
                response.StateCode = Enums.StateCode.Created;
                return response;
            }
            catch(Exception exp)
            {
                return new BaseResponse<bool>()
                {
                    Message = $"[Delete: ] {exp.Message}",
                    StateCode = Enums.StateCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteAllReady()
        {
            try
            {
                var response  = new BaseResponse<bool>();
                await repository.DeleteAll();
                response.StateCode = Enums.StateCode.Created;
                return response;
            }
            catch(Exception exp)
            {
                return new BaseResponse<bool>()
                {
                    Message = $"[Delete: ] {exp.Message}",
                    StateCode = Enums.StateCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<List<CreateTodoDto>>> SelectAll()
        {
            try
            {
                var response  = new BaseResponse<List<CreateTodoDto>>();
                var tasks = MapperConfiguration.Mapper.Map<List<CreateTodoDto>>(await repository.SelectAll());
                response.StateCode = Enums.StateCode.Created;
                response.Data = tasks;
                return response;
            }
            catch(Exception exp)
            {
                return new BaseResponse<List<CreateTodoDto>>()
                {
                    Message = $"[Delete: ] {exp.Message}",
                    StateCode = Enums.StateCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CreateTodoDto>> Select(int id)
        {
            try
            {
                var response  = new BaseResponse<CreateTodoDto>();
                var task = MapperConfiguration.Mapper.Map<CreateTodoDto>(await repository.Select(id));
                response.StateCode = Enums.StateCode.Created;
                response.Data = task;
                return response;
            }
            catch(Exception exp)
            {
                return new BaseResponse<CreateTodoDto>()
                {
                    Message = $"[Delete: ] {exp.Message}",
                    StateCode = Enums.StateCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CreateTodoDto>> PatchStatus(int id, bool status)
        {
            try
            {
                var response  = new BaseResponse<CreateTodoDto>();
                var task = MapperConfiguration.Mapper.Map<CreateTodoDto>(await repository.PatchStatus(id, status));
                response.StateCode = Enums.StateCode.Created;
                response.Data = task;
                return response;
            }
            catch(Exception exp)
            {
                return new BaseResponse<CreateTodoDto>()
                {
                    Message = $"[Delete: ] {exp.Message}",
                    StateCode = Enums.StateCode.InternalServerError
                };
            }
        }
    }
}