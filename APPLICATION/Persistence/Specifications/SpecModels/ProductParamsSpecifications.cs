namespace APPLICATION.Persistence.Specifications.SpecModels
{
    public class ProductParamsSpecifications
    {
        private const int _maxPageSize = 25;
        private int _pageSize = 5;

        public string Sort { get; set; }
        public int? Category { get; set; }
        public int? Brand { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
        }
    }
}
