using System.ComponentModel.DataAnnotations;

namespace Todo.Data.DTO
{
    public class ChangeTextTodoDto 
    {
        [MinLength(3)]
        [MaxLength(160)]
        public string Text{get;set;}
    }
} 