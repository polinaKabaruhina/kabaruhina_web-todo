using Microsoft.AspNetCore.Mvc;
using Todo.Data.DAL.DTO;
using Todo.Data.Services.HelperModels;
using Todo.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            await service.Delete(id);
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> DeleteAllReady()
        {
            await service.DeleteAllReady();
            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> getPaginated([FromQuery]PageParameter pageParameter, bool status)
        {
            var response = await service.SelectAll();
            var tasksDto = response.Data.Where(t => t.Status == status).Skip((pageParameter.Page - 1) * pageParameter.perPage).Take(pageParameter.perPage);
            return Results.Json(tasksDto);
        }

        [HttpPatch("status/{id}")]
        public async Task<IResult> patchStatus(int id, bool status)
        {
            var response = await service.PatchStatus(id, status);
            return Results.Content(response.Data.ToString());
        }
    }
}