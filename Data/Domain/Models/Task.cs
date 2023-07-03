using System.ComponentModel.DataAnnotations;

namespace Todo.Data.Domain.Models
{
    public class Task
    {
        public int Id{get;set;}
        public string Text{get;set;}
        public bool Status{get;set;}
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
    }
}