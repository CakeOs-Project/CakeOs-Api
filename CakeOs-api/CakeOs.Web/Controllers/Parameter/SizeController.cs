using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Entity.DTOs.Parameter.Size;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Parameter
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con parámetros de Tamaño (Size).
    /// CU-20: Crear parámetro — 
    /// CU-21: Editar parámetro — 
    /// CU-22: Activar/Desactivar parámetro — 
    /// CU-23: Listar parámetros —
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SizeController : ControllerBase
    {
        private readonly ISizeServices _services;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de Tamaño.
        /// </summary>
        /// <param name="services">Servicio de negocios para tamaños</param>
        public SizeController(ISizeServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #region "GET"

        /// <summary>
        /// CU-23: Obtiene la lista de todos los parámetros de tamaño.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Lista de parámetros de tamaño</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var sizes = await _services.GetAllAsync(cancellationToken);
                return Ok(sizes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { message = "Error al obtener los parámetros de tamaño", error = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un parámetro de tamaño específico por su ID.
        /// </summary>
        /// <param name="id">ID del parámetro</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Parámetro encontrado</returns>
        [HttpGet("{id}", Name = "GetSizeByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                var size = await _services.GetByIdAsync(id, cancellationToken);

                if (size is null)
                    return NotFound(new { message = $"Parámetro de tamaño con ID {id} no encontrado" });

                return Ok(size);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al obtener el parámetro de tamaño", error = ex.Message });
            }
        }

        #endregion

        #region "POST"

        /// <summary>
        /// CU-20: Crea un nuevo parámetro de tamaño.
        /// </summary>
        /// <param name="dto">Datos del parámetro a crear</param>
        /// <returns>Parámetro creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] SizeCreateDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { message = "Los datos del parámetro son requeridos" });

                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(new { message = "El nombre del parámetro es requerido" });

                var size = await _services.CreateAsync(dto);
                return CreatedAtRoute("GetSizeByIdAsync", new { id = size.Id }, size);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al crear el parámetro de tamaño", error = ex.Message });
            }
        }

        #endregion

        #region "PUT"

        /// <summary>
        /// CU-21: Actualiza un parámetro de tamaño existente.
        /// </summary>
        /// <param name="id">ID del parámetro a actualizar</param>
        /// <param name="dto">Datos del parámetro a actualizar</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SizeCreateDTO dto)
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

                return Ok(new { message = "Parámetro de tamaño actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al actualizar el parámetro de tamaño", error = ex.Message });
            }
        }

        #endregion

        #region "PATCH"

        /// <summary>
        /// CU-22: Activa o desactiva un parámetro de tamaño.
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
                    return NotFound(new { message = $"Parámetro de tamaño con ID {id} no encontrado" });

                var status = isActive ? "activado" : "desactivado";
                return Ok(new { message = $"Parámetro de tamaño {status} exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al cambiar el estado del parámetro de tamaño", error = ex.Message });
            }
        }

        /// <summary>
        /// Elimina (soft delete) un parámetro de tamaño.
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
                    return NotFound(new { message = $"Parámetro de tamaño con ID {id} no encontrado" });

                return Ok(new { message = "Parámetro de tamaño eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al eliminar el parámetro de tamaño", error = ex.Message });
            }
        }

        #endregion
    }
}
