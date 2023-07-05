using System.ComponentModel.DataAnnotations;

namespace Todo.Data.Services.HelperModels
{
    public class TaskPageParameters
    {
        private const int MaxCountPage = 50;
        [Required]
        public int Page{get;set;}
        [Required]
        public int perPage
        {
            get
            {
                return _perPage;
            }
            set
            {
                _perPage = (perPage > MaxCountPage)? MaxCountPage : value;
            }
        }

        private int _perPage;
    }
}