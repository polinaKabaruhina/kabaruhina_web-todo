using Microsoft.AspNetCore.Mvc;
using Todo.Data.Domain.Models;
using Todo.Data.DTO;
using Todo.Data.Services.HelperModels;
using Todo.Data.Services.Implementations;
using Todo.Data.Services.Interfaces;

namespace Todo.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class todoController : ControllerBase
    {
        private readonly ITaskService service;
        public todoController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost(Name = "create")]
        public async Task<BaseSuccessResponse<TaskEntity>> Create(CreateTodoDto createTodoDto)
        {

            var response = await service.Create(createTodoDto);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<BaseSuccessResponse> Delete(int id)
        {
            var response = await service.Delete(id);
            return response;
        }

        [HttpDelete]
        public async Task<BaseSuccessResponse> DeleteAllReady()
        {
            var response = await service.DeleteAllReady();
            return response;
        }

        [HttpGet]
        public async Task<CustomSuccessResponse> GetPaginated([FromQuery]TaskPageParameters parameters, bool status)
        {
            var response = await service.GetPaginated(parameters, status);
            return response;
        }
        
        [HttpPatch("status/{id}")]
        public async Task<BaseSuccessResponse> PatchStatus(int id, bool status)
        {
            var response =  await service.PatchStatus(id, status);
            return response;
        }

        [HttpPatch("text/{id}")]
        public async Task<BaseSuccessResponse> PatchText(int id, ChangeTextTodoDto textTodoDto)
        {
            var response =  await service.PatchText(id, textTodoDto);
            return response;
        }

        [HttpPatch]
        public async Task<BaseSuccessResponse> patch(ChangeStatusTodoDto textTodoDto)
        {
            var response =  await service.Patch(textTodoDto);
            return response;
        }
    }
}