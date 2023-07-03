namespace Todo.Data.Services.HelperModels
{
    public class PageParameter
    {
        public const int MaxPageCount = 10;
        public int Page{get;set;} = 1;
        public int perPage
        {
            get
            {
                return _perPage;
            }
            set
            {
                _perPage = (value > MaxPageCount)? MaxPageCount : value;
            }
        }

        private int _perPage;
    }
}