using Microsoft.AspNetCore.Mvc;
using Todo.Data.DAL.DTO;
using Todo.Data.Services.Interfaces;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service;
        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IResult> Create(string text)
        {
            CreateTodoDto taskDto = new CreateTodoDto()
            {
                Text = text,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await service.Create(taskDto);
            return Results.Ok();
        }
    }
}