using Newtonsoft.Json;

namespace Acerto.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IHostEnvironment enviroment)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, enviroment, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, IHostEnvironment envoroment, Exception exeption)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            if (!envoroment.IsProduction())
            {
                context.Response.ContentType = "application/json";

                var result = JsonConvert.SerializeObject(new
                {
                    Error = exeption.Message,
                    Details = exeption.InnerException?.Message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}