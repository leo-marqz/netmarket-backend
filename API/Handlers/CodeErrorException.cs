namespace API.Handlers
{
    public class CodeErrorException : CodeErrorResponse
    {
        //for middleware
        public CodeErrorException(int statusCode, string message = default, string details = default) 
        : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}
