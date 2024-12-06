using System.ComponentModel.DataAnnotations;

namespace Todo.Data.DTO
{
    public class ChangeStatusTodoDto
    {
        [Required]
        public bool Status{get;set;}
    }
} 