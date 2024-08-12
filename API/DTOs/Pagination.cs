namespace API.DTOs
{
    public class Pagination<T> where T : class
    {
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public T Data { get; set; }
    }
}
