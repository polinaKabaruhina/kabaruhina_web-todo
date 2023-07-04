namespace Todo.Data.Services.HelperModels
{
    public class TaskPageParameters
    {
        private const int MaxCountPage = 50;
        public int Page{get;set;}
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