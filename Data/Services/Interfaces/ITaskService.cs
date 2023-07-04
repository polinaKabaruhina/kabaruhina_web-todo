using Todo.Data.Domain.Models;
using Todo.Data.DTO;
using Todo.Data.Mapping;
using Todo.Data.Services.HelperModels;
using Todo.Data.Services.Implementations;

namespace Todo.Data.Services.Interfaces
{
    public interface ITaskService
    {
        public AutoMapperCreator autoMapper{get;set;}
        public Task<BaseSuccessResponse<TaskEntity>> Create(CreateTodoDto createTodo);
        public Task<BaseSuccessResponse> DeleteAllReady();
        public Task<BaseSuccessResponse> Delete(int id);
        public Task<CustomSuccessResponse> GetPaginated(TaskPageParameters pageParameters, bool status);
        public Task<BaseSuccessResponse> PatchStatus(int id, bool status);
        public Task<BaseSuccessResponse> PatchText(int id, ChangeTextTodoDto textTodoDto);
    }
}