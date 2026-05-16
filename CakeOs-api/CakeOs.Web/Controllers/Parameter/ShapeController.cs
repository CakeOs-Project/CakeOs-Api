using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Entity.DTOs.Parameter.Shape;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Parameter
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con parámetros de Forma (Shape).
    /// CU-20: Crear parámetro — 
    /// CU-21: Editar parámetro — 
    /// CU-22: Activar/Desactivar parámetro — 
    /// CU-23: Listar parámetros —
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ShapeController : ControllerBase
    {
        private readonly IShapeServices _services;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de Forma.
        /// </summary>
        /// <param name="services">Servicio de negocios para formas</param>
        public ShapeController(IShapeServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #region "GET"

        /// <summary>
        /// CU-23: Obtiene la lista de todos los parámetros de forma.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Lista de parámetros de forma</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var shapes = await _services.GetAllAsync(cancellationToken);
                return Ok(shapes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { message = "Error al obtener los parámetros de forma", error = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un parámetro de forma específico por su ID.
        /// </summary>
        /// <param name="id">ID del parámetro</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Parámetro encontrado</returns>
        [HttpGet("{id}", Name = "GetShapeByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                var shape = await _services.GetByIdAsync(id, cancellationToken);

                if (shape is null)
                    return NotFound(new { message = $"Parámetro de forma con ID {id} no encontrado" });

                return Ok(shape);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al obtener el parámetro de forma", error = ex.Message });
            }
        }

        #endregion

        #region "POST"

        /// <summary>
        /// CU-20: Crea un nuevo parámetro de forma.
        /// </summary>
        /// <param name="dto">Datos del parámetro a crear</param>
        /// <returns>Parámetro creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] ShapeCreateDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { message = "Los datos del parámetro son requeridos" });

                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(new { message = "El nombre del parámetro es requerido" });

                var shape = await _services.CreateAsync(dto);
                return CreatedAtRoute("GetShapeByIdAsync", new { id = shape.Id }, shape);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al crear el parámetro de forma", error = ex.Message });
            }
        }

        #endregion

        #region "PUT"

        /// <summary>
        /// CU-21: Actualiza un parámetro de forma existente.
        /// </summary>
        /// <param name="id">ID del parámetro a actualizar</param>
        /// <param name="dto">Datos del parámetro a actualizar</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ShapeCreateDTO dto)
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

                return Ok(new { message = "Parámetro de forma actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al actualizar el parámetro de forma", error = ex.Message });
            }
        }

        #endregion

        #region "PATCH"

        /// <summary>
        /// CU-22: Activa o desactiva un parámetro de forma.
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

                if (!result)
                    return NotFound(new { message = $"Parámetro de forma con ID {id} no encontrado" });

                var status = isActive ? "activado" : "desactivado";
                return Ok(new { message = $"Parámetro de forma {status} exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al cambiar el estado del parámetro de forma", error = ex.Message });
            }
        }

        /// <summary>
        /// Elimina (soft delete) un parámetro de forma.
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

                if (!result)
                    return NotFound(new { message = $"Parámetro de forma con ID {id} no encontrado" });

                return Ok(new { message = "Parámetro de forma eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al eliminar el parámetro de forma", error = ex.Message });
            }
        }

        #endregion
    }
}
