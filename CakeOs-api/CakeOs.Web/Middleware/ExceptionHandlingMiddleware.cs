using System.Net;
using System.Text.Json;

namespace CakeOs.Web.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción no controlada: {Method} {Path}",
                    context.Request.Method, context.Request.Path);

                await WriteErrorResponseAsync(context, ex);
            }
        }

        private static async Task WriteErrorResponseAsync(HttpContext context, Exception ex)
        {
            var (statusCode, message) = ex switch
            {
                ArgumentNullException or ArgumentException or ArgumentOutOfRangeException
                    => (HttpStatusCode.BadRequest, ex.Message),
                UnauthorizedAccessException
                    => (HttpStatusCode.Unauthorized, ex.Message),
                InvalidOperationException
                    => (HttpStatusCode.Conflict, ex.Message),
                _
                    => (HttpStatusCode.InternalServerError, "Ocurrió un error interno. Por favor intente más tarde.")
            };

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var body = JsonSerializer.Serialize(new { message });
            await context.Response.WriteAsync(body);
        }
    }
}
