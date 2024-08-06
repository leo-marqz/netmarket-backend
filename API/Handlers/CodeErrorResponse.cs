using System;

namespace API.Handlers
{
    public class CodeErrorResponse
    {

        public CodeErrorResponse(int statusCode, string message = default)
        {
            StatusCode = statusCode;
            Message = message ?? getDefaultMessageForStatusCode(statusCode);
        }

        private string getDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "404 request error",
                401 => "Error, you are not authorized",
                404 => "Error, resource not found",
                500 => "Server error, try again later.",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
