using Microsoft.AspNetCore.Mvc;
using Todo.Data.Domain.Models;
using Todo.Data.DTO;
using Todo.Data.Services.Implementations;
using Todo.Data.Services.Interfaces;

namespace Todo.Controllers
{
    [ApiController]
    [Route("todo/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service;
        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<BaseSuccessResponse<TaskEntity>> Create(string text)
        {
            CreateTodoDto created = new CreateTodoDto
            {
                Text = text
            };
            var response = await service.Create(created);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<BaseSuccessResponse<bool>> Delete(int id)
        {
            var response = await service.Delete(id);
            return response;
        }

        [HttpDelete]
        public async Task<BaseSuccessResponse<bool>> DeleteAllReady()
        {
            var response = await service.DeleteAllReady();
            return response;
        }
    }
}