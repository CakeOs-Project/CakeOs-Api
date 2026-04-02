using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CakeOs.Web.Controllers.Base
{
    /// <summary>
    /// Controlador base genérico que proporciona funcionalidades comunes para todos los controladores.
    /// </summary>
    /// <typeparam name="TDto">El tipo de DTO que maneja el controlador.</typeparam>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TDto> : ControllerBase where TDto : class
    {
        /// <summary>
        /// Devuelve una respuesta exitosa (200 OK).
        /// </summary>
        protected IActionResult Ok(object? data = null, string message = "Operación realizada correctamente")
        {
            return StatusCode((int)HttpStatusCode.OK, new
            {
                success = true,
                statusCode = (int)HttpStatusCode.OK,
                message = message,
                data = data
            });
        }

        /// <summary>
        /// Devuelve una respuesta de creación exitosa (201 Created).
        /// </summary>
        protected IActionResult Created(object? data = null, string message = "Recurso creado exitosamente")
        {
            return StatusCode((int)HttpStatusCode.Created, new
            {
                success = true,
                statusCode = (int)HttpStatusCode.Created,
                message = message,
                data = data
            });
        }

        /// <summary>
        /// Devuelve una respuesta de solicitud incorrecta (400 Bad Request).
        /// </summary>
        protected IActionResult BadRequest(string message = "Solicitud inválida")
        {
            return StatusCode((int)HttpStatusCode.BadRequest, new
            {
                success = false,
                statusCode = (int)HttpStatusCode.BadRequest,
                message = message,
                data = (object?)null
            });
        }

        /// <summary>
        /// Devuelve una respuesta de no autorizado (401 Unauthorized).
        /// </summary>
        protected IActionResult Unauthorized(string message = "No autorizado")
        {
            return StatusCode((int)HttpStatusCode.Unauthorized, new
            {
                success = false,
                statusCode = (int)HttpStatusCode.Unauthorized,
                message = message,
                data = (object?)null
            });
        }

        /// <summary>
        /// Devuelve una respuesta de prohibido (403 Forbidden).
        /// </summary>
        protected IActionResult Forbidden(string message = "Acceso prohibido")
        {
            return StatusCode((int)HttpStatusCode.Forbidden, new
            {
                success = false,
                statusCode = (int)HttpStatusCode.Forbidden,
                message = message,
                data = (object?)null
            });
        }

        /// <summary>
        /// Devuelve una respuesta de no encontrado (404 Not Found).
        /// </summary>
        protected IActionResult NotFound(string message = "Recurso no encontrado")
        {
            return StatusCode((int)HttpStatusCode.NotFound, new
            {
                success = false,
                statusCode = (int)HttpStatusCode.NotFound,
                message = message,
                data = (object?)null
            });
        }

        /// <summary>
        /// Devuelve una respuesta de conflicto (409 Conflict).
        /// </summary>
        protected IActionResult Conflict(string message = "Conflicto en la solicitud")
        {
            return StatusCode((int)HttpStatusCode.Conflict, new
            {
                success = false,
                statusCode = (int)HttpStatusCode.Conflict,
                message = message,
                data = (object?)null
            });
        }

        /// <summary>
        /// Devuelve una respuesta de error interno del servidor (500 Internal Server Error).
        /// </summary>
        protected IActionResult InternalServerError(string message = "Error interno del servidor")
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new
            {
                success = false,
                statusCode = (int)HttpStatusCode.InternalServerError,
                message = message,
                data = (object?)null
            });
        }

        /// <summary>
        /// Valida que el modelo sea válido, si no, devuelve BadRequest.
        /// </summary>
        protected bool IsModelValid(out IActionResult? errorResponse)
        {
            errorResponse = null;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                errorResponse = BadRequest(string.Join(", ", errors));
                return false;
            }
            return true;
        }
    }
}
