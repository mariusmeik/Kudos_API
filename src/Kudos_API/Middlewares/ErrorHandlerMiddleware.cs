using Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace KudosAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    EmployeeNotFoundException => (int)HttpStatusCode.NotFound,
                    ReasonNotFoundException => (int)HttpStatusCode.NotFound,
                    SenderIsReceiverException=> (int)HttpStatusCode.BadRequest,
                    KudosNotFoundException=> (int)HttpStatusCode.NotFound,
                    ArgumentException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }

}
