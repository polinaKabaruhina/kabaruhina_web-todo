using Todo.Data.DAL.Repositories.Interfaces;
using Todo.Data.Domain.Models;
using Todo.Data.DTO;
using Todo.Data.Mapping;
using Todo.Data.Services.Interfaces;
using Todo.Data.Services.Enums;

namespace Todo.Data.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public AutoMapperCreator autoMapper {get; set;}
        private readonly ITaskRepository repository;
        public TaskService(AutoMapperCreator autoMapper, ITaskRepository repository)
        {
            this.repository = repository;
            this.autoMapper = autoMapper;
            autoMapper.UseMapper();
        }

        public async Task<BaseSuccessResponse<TaskEntity>> Create(CreateTodoDto createTodo)
        {
            try
            {
                var response = new BaseSuccessResponse<TaskEntity>();
                var task = autoMapper.Mapper.Map<TaskEntity>(createTodo);
                response.StatusCode = StatusCode.Created;
                response.Data = await repository.Insert(task);
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse<TaskEntity>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false,
                };
            }
        }

        public async Task<BaseSuccessResponse<bool>> Delete(int id)
        {
           try
            {
                var response = new BaseSuccessResponse<bool>();
                await repository.Delete(id);
                response.StatusCode = StatusCode.OK;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<BaseSuccessResponse<bool>> DeleteAllReady()
        {
            try
            {
                var response = new BaseSuccessResponse<bool>();
                await repository.DeleteAll();
                response.StatusCode = StatusCode.OK;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }
    }
}