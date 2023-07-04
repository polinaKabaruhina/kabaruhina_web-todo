using Todo.Data.Domain.Models;

namespace Todo.Data.DTO
{
    public class GetNewsDto
    {
        public List<TaskEntity> Content{get;set;}
        public int NumbersOfElements{get;set;}
        public int NotReady{get;set;}
        public int Ready{get;set;}
    }
}