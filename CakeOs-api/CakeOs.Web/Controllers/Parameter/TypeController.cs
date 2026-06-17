using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Entity.DTOs.Parameter.Type;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Parameter
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con parámetros de Tipo (Type).
    /// CU-20: Crear parámetro — 
    /// CU-21: Editar parámetro — 
    /// CU-22: Activar/Desactivar parámetro — 
    /// CU-23: Listar parámetros —
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class TypeController : ControllerBase
    {
        private readonly ITypeServices _services;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de Tipo.
        /// </summary>
        /// <param name="services">Servicio de negocios para tipos</param>
        public TypeController(ITypeServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #region "GET"

        /// <summary>
        /// CU-23: Obtiene la lista de todos los parámetros de tipo.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Lista de parámetros de tipo</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var types = await _services.GetAllAsync(cancellationToken);
                return Ok(types);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { message = "Error al obtener los parámetros de tipo", error = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un parámetro de tipo específico por su ID.
        /// </summary>
        /// <param name="id">ID del parámetro</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Parámetro encontrado</returns>
        [HttpGet("{id}", Name = "GetTypeByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                var type = await _services.GetByIdAsync(id, cancellationToken);

                if (type is null)
                    return NotFound(new { message = $"Parámetro de tipo con ID {id} no encontrado" });

                return Ok(type);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al obtener el parámetro de tipo", error = ex.Message });
            }
        }

        #endregion

        #region "POST"

        /// <summary>
        /// CU-20: Crea un nuevo parámetro de tipo.
        /// </summary>
        /// <param name="dto">Datos del parámetro a crear</param>
        /// <returns>Parámetro creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] TypeCreateDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { message = "Los datos del parámetro son requeridos" });

                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(new { message = "El nombre del parámetro es requerido" });

                var type = await _services.CreateAsync(dto);
                return CreatedAtRoute("GetTypeByIdAsync", new { id = type.Id }, type);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al crear el parámetro de tipo", error = ex.Message });
            }
        }

        #endregion

        #region "PUT"

        /// <summary>
        /// CU-21: Actualiza un parámetro de tipo existente.
        /// </summary>
        /// <param name="id">ID del parámetro a actualizar</param>
        /// <param name="dto">Datos del parámetro a actualizar</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TypeCreateDto dto)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                if (dto == null)
                    return BadRequest(new { message = "Los datos del parámetro son requeridos" });

                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(new { message = "El nombre del parámetro es requerido" });

                var result = await _services.UpdateAsync(id, dto);

                if (!result.Success)
                    return NotFound(result);

                return Ok(new { message = "Parámetro de tipo actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al actualizar el parámetro de tipo", error = ex.Message });
            }
        }

        #endregion

        #region "PATCH"

        /// <summary>
        /// CU-22: Activa o desactiva un parámetro de tipo.
        /// </summary>
        /// <param name="id">ID del parámetro</param>
        /// <param name="isActive">Nuevo estado (activo/inactivo)</param>
        [HttpPatch("{id}/toggle-active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ToggleActiveAsync(int id, [FromQuery] bool isActive)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                var result = await _services.ToggleActiveAsync(id, isActive);

                if (!result.Success)
                    return NotFound(new { message = $"Parámetro de tipo con ID {id} no encontrado" });

                var status = isActive ? "activado" : "desactivado";
                return Ok(new { message = $"Parámetro de tipo {status} exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al cambiar el estado del parámetro de tipo", error = ex.Message });
            }
        }

        /// <summary>
        /// Elimina (soft delete) un parámetro de tipo.
        /// </summary>
        /// <param name="id">ID del parámetro a eliminar</param>
        [HttpPatch("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                var result = await _services.SoftDeleteAsync(id);

                if (!result.Success)
                    return NotFound(new { message = $"Parámetro de tipo con ID {id} no encontrado" });

                return Ok(new { message = "Parámetro de tipo eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al eliminar el parámetro de tipo", error = ex.Message });
            }
        }

        #endregion
    }
}
