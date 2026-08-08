using CakeOs.Entity.DTOs.Transversal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CakeOs.Web.Filters
{
    /// <summary>Normaliza todas las respuestas de los controladores en el contrato público de la API.</summary>
    public sealed class ApiResponseFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is StatusCodeResult statusResult)
            {
                var statusCode = statusResult.StatusCode;
                context.Result = new ObjectResult(statusCode >= 400
                    ? ApiResponse.Fail(statusCode, GetErrorMessage(statusCode, null))
                    : ApiResponse.Ok(statusCode))
                {
                    StatusCode = statusCode
                };
            }
            else if (context.Result is ObjectResult result && result.Value is not ApiResponse)
            {
                var statusCode = result.StatusCode ?? StatusCodes.Status200OK;

                if (result.Value is ResponseDto serviceResult)
                {
                    statusCode = serviceResult.Success
                        ? statusCode
                        : GetStatusCode(serviceResult.ErrorType);

                    result.StatusCode = statusCode;
                    result.Value = serviceResult.Success
                        ? ApiResponse.Ok(statusCode, message: serviceResult.Message)
                        : ApiResponse.Fail(statusCode, serviceResult.Message);
                }
                else if (result.Value is ValidationProblemDetails validation)
                {
                    result.Value = ApiResponse.Fail(statusCode, "La solicitud contiene datos inválidos.", validation.Errors);
                }
                else
                {
                    var message = statusCode >= 400 ? GetErrorMessage(statusCode, result.Value) : "Operación realizada correctamente.";
                    result.Value = statusCode >= 400
                        ? ApiResponse.Fail(statusCode, message)
                        : ApiResponse.Ok(statusCode, result.Value, message);
                }
            }

            await next();
        }

        private static int GetStatusCode(ResponseErrorType errorType) => errorType switch
        {
            ResponseErrorType.NotFound => StatusCodes.Status404NotFound,
            ResponseErrorType.Conflict => StatusCodes.Status409Conflict,
            ResponseErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ResponseErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status400BadRequest
        };

        private static string GetErrorMessage(int statusCode, object? value)
        {
            var message = value?.GetType().GetProperty("message")?.GetValue(value)?.ToString()
                ?? value?.GetType().GetProperty("Message")?.GetValue(value)?.ToString();

            return message ?? statusCode switch
            {
                StatusCodes.Status400BadRequest => "La solicitud es inválida.",
                StatusCodes.Status401Unauthorized => "No autenticado.",
                StatusCodes.Status403Forbidden => "No autorizado.",
                StatusCodes.Status404NotFound => "Recurso no encontrado.",
                StatusCodes.Status409Conflict => "La operación entra en conflicto con el estado actual.",
                _ => "Ocurrió un error al procesar la solicitud."
            };
        }
    }
}
