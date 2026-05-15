using CakeOs.Business.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CakeOs.Web.Controllers.Base
{
    /// <summary>
    /// Controlador CRUD genérico que proporciona operaciones estándar (GET, POST, PUT, DELETE).
    /// </summary>
    /// <typeparam name="TDto">El tipo de DTO que maneja el controlador.</typeparam>
    //[ApiController]
    //[Route("api/[controller]")]
    //public abstract class BaseCrudController<TDto> : BaseController<TDto> where TDto : class
    //{
    //    protected readonly IServices<TDto> _service;

    //    /// <summary>
    //    /// Inicializa una nueva instancia del controlador CRUD base.
    //    /// </summary>
    //    /// <param name="service">El servicio asociado.</param>
    //    protected BaseCrudController(IServices<TDto> service)
    //    {
    //        _service = service ?? throw new ArgumentNullException(nameof(service));
    //    }

    //    /// <summary>
    //    /// Obtiene todas las entidades.
    //    /// </summary>
    //    /// <param name="cancellationToken">Token de cancelación.</param>
    //    /// <returns>Lista de todas las entidades.</returns>
    //    [HttpGet]
    //    [ProducesResponseType(typeof(object), 200)]
    //    [ProducesResponseType(typeof(object), 500)]
    //    public virtual async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    //    {
    //        try
    //        {
    //            var result = await _service.GetAllAsync(cancellationToken);
    //            return Ok(result, "Entidades obtenidas exitosamente");
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError($"Error al obtener las entidades: {ex.Message}");
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene una entidad por su identificador.
    //    /// </summary>
    //    /// <param name="id">El identificador de la entidad.</param>
    //    /// <param name="cancellationToken">Token de cancelación.</param>
    //    /// <returns>La entidad encontrada.</returns>
    //    [HttpGet("{id}")]
    //    [ProducesResponseType(typeof(object), 200)]
    //    [ProducesResponseType(typeof(object), 404)]
    //    [ProducesResponseType(typeof(object), 500)]
    //    public virtual async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
    //    {
    //        try
    //        {
    //            if (id <= 0)
    //                return BadRequest("El identificador debe ser mayor que cero");

    //            var result = await _service.GetByIdAsync(id, cancellationToken);
    //            if (result == null)
    //                return NotFound($"Entidad con id {id} no encontrada");

    //            return Ok(result, "Entidad obtenida exitosamente");
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError($"Error al obtener la entidad: {ex.Message}");
    //        }
    //    }

    //    /// <summary>
    //    /// Obtiene una página de entidades.
    //    /// </summary>
    //    /// <param name="pageNumber">Número de página (comienza en 1).</param>
    //    /// <param name="pageSize">Tamaño de la página.</param>
    //    /// <param name="cancellationToken">Token de cancelación.</param>
    //    /// <returns>Página de entidades.</returns>
    //    [HttpGet("page/{pageNumber}/{pageSize}")]
    //    [ProducesResponseType(typeof(object), 200)]
    //    [ProducesResponseType(typeof(object), 400)]
    //    [ProducesResponseType(typeof(object), 500)]
    //    public virtual async Task<IActionResult> GetPage(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    //    {
    //        try
    //        {
    //            if (pageNumber <= 0 || pageSize <= 0)
    //                return BadRequest("El número de página y tamaño deben ser mayores que cero");

    //            var result = await _service.GetPageAsync(pageNumber, pageSize, cancellationToken);
    //            var count = await _service.GetCountAsync(cancellationToken);

    //            return Ok(new
    //            {
    //                data = result,
    //                total = count,
    //                pageNumber = pageNumber,
    //                pageSize = pageSize,
    //                totalPages = (count + pageSize - 1) / pageSize
    //            }, "Página obtenida exitosamente");
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError($"Error al obtener la página: {ex.Message}");
    //        }
    //    }

    //    /// <summary>
    //    /// Crea una nueva entidad.
    //    /// </summary>
    //    /// <param name="dto">El DTO con los datos de la entidad.</param>
    //    /// <param name="cancellationToken">Token de cancelación.</param>
    //    /// <returns>La entidad creada.</returns>
    //    [HttpPost]
    //    [ProducesResponseType(typeof(object), 201)]
    //    [ProducesResponseType(typeof(object), 400)]
    //    [ProducesResponseType(typeof(object), 500)]
    //    public virtual async Task<IActionResult> Create([FromBody] TDto dto, CancellationToken cancellationToken = default)
    //    {
    //        try
    //        {
    //            if (!IsModelValid(out var errorResponse))
    //                return errorResponse;

    //            if (dto == null)
    //                return BadRequest("El DTO no puede ser nulo");

    //            var result = await _service.CreateAsync(dto, cancellationToken);
    //            return Created(result, "Entidad creada exitosamente");
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError($"Error al crear la entidad: {ex.Message}");
    //        }
    //    }

    //    /// <summary>
    //    /// Actualiza una entidad existente.
    //    /// </summary>
    //    /// <param name="id">El identificador de la entidad.</param>
    //    /// <param name="dto">El DTO con los datos actualizados.</param>
    //    /// <param name="cancellationToken">Token de cancelación.</param>
    //    /// <returns>La entidad actualizada.</returns>
    //    [HttpPut("{id}")]
    //    [ProducesResponseType(typeof(object), 200)]
    //    [ProducesResponseType(typeof(object), 400)]
    //    [ProducesResponseType(typeof(object), 404)]
    //    [ProducesResponseType(typeof(object), 500)]
    //    public virtual async Task<IActionResult> Update(int id, [FromBody] TDto dto, CancellationToken cancellationToken = default)
    //    {
    //        try
    //        {
    //            if (id <= 0)
    //                return BadRequest("El identificador debe ser mayor que cero");

    //            if (!IsModelValid(out var errorResponse))
    //                return errorResponse;

    //            if (dto == null)
    //                return BadRequest("El DTO no puede ser nulo");

    //            var result = await _service.UpdateAsync(id, dto, cancellationToken);
    //            if (result == null)
    //                return NotFound($"Entidad con id {id} no encontrada");

    //            return Ok(result, "Entidad actualizada exitosamente");
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError($"Error al actualizar la entidad: {ex.Message}");
    //        }
    //    }

    //    /// <summary>
    //    /// Elimina una entidad por su identificador.
    //    /// </summary>
    //    /// <param name="id">El identificador de la entidad.</param>
    //    /// <param name="cancellationToken">Token de cancelación.</param>
    //    /// <returns>Confirmación de eliminación.</returns>
    //    [HttpDelete("{id}")]
    //    [ProducesResponseType(typeof(object), 200)]
    //    [ProducesResponseType(typeof(object), 400)]
    //    [ProducesResponseType(typeof(object), 404)]
    //    [ProducesResponseType(typeof(object), 500)]
    //    public virtual async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    //    {
    //        try
    //        {
    //            if (id <= 0)
    //                return BadRequest("El identificador debe ser mayor que cero");

    //            var result = await _service.DeleteAsync(id, cancellationToken);
    //            if (!result)
    //                return NotFound($"Entidad con id {id} no encontrada");

    //            return Ok(null, "Entidad eliminada exitosamente");
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError($"Error al eliminar la entidad: {ex.Message}");
    //        }
    //    }
    //}
}
