using System.ComponentModel.DataAnnotations;

namespace Todo.Data.DAL.DTO
{
    public class CreateTodoDto
    {

        public string Text{get;set;}
        public bool Status{get;set;}
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
    }
}