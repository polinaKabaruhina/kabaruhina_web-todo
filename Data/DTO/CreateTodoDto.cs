using System.ComponentModel.DataAnnotations;

namespace Todo.Data.DTO
{
    public class CreateTodoDto
    {
        [MinLength(3)]
        [MaxLength(160)]
        public string Text{get;set;}
    }
}