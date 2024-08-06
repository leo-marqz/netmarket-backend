using API.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (System.Exception ex)
            {
                this.logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = this.env.IsDevelopment()
                    ? new CodeErrorException(StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new CodeErrorException(StatusCodes.Status500InternalServerError);

                var result = System.Text.Json.JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(result);
            }
        }
    }
}
