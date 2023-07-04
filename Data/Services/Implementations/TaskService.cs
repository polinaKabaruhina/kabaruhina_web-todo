using Todo.Data.DAL.Repositories.Interfaces;
using Todo.Data.Domain.Models;
using Todo.Data.DTO;
using Todo.Data.Mapping;
using Todo.Data.Services.Interfaces;
using Todo.Data.Services.Enums;
using Todo.Data.Services.HelperModels;
using Microsoft.EntityFrameworkCore;

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

        public async Task<BaseSuccessResponse> Delete(int id)
        {
           try
            {
                var response = new BaseSuccessResponse();
                await repository.Delete(id);
                response.StatusCode = StatusCode.OK;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<BaseSuccessResponse> DeleteAllReady()
        {
            try
            {
                var response = new BaseSuccessResponse();
                await repository.DeleteAllReady();
                response.StatusCode = StatusCode.OK;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }
        public async Task<CustomSuccessResponse> GetPaginated(TaskPageParameters pageParameters, bool status)
        {
            try
            {
                var response = new CustomSuccessResponse()
                {
                    Data = new GetNewsDto()
                };
                var allTasks = await repository.SelectAll();
                var taskByPage = allTasks.Where(t => t.Status == status)
                                            .Skip(pageParameters.Page - 1 * pageParameters.perPage)
                                            .Take(pageParameters.perPage).ToList();
                response.Data.Content = taskByPage;
                response.Data.Ready = (int)taskByPage.Where(t => t.Status == true).Count();
                response.Data.NotReady = (int)taskByPage.Where(t => t.Status == false).Count();
                response.Data.NumbersOfElements = taskByPage.Count();
                return response;
            }
            catch (Exception)
            {
                return new CustomSuccessResponse()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<BaseSuccessResponse> PatchStatus(int id, bool status)
        {
            try
            {
                var response = new BaseSuccessResponse();
                var task = await repository.Select(id);
                task.Status = status;
                await repository.Update(task);
                response.StatusCode = StatusCode.OK;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<BaseSuccessResponse> PatchText(int id, ChangeTextTodoDto textTodoDto)
        {
            try
            {
                var response = new BaseSuccessResponse();
                var task = autoMapper.Mapper.Map<TaskEntity>(await repository.Select(id));
                task.Text = textTodoDto.Text;
                await repository.Update(task);
                response.StatusCode = StatusCode.OK;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }

        public async Task<BaseSuccessResponse> Patch(ChangeStatusTodoDto textTodoDto)
        {
            try
            {
                var response = new BaseSuccessResponse();
                var tasks = autoMapper.Mapper.Map<List<TaskEntity>>(await repository.SelectAll());
                await repository.UpdateAll(tasks);
                response.StatusCode = StatusCode.OK;
                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new BaseSuccessResponse()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Success = false
                };
            }
        }
    }
}