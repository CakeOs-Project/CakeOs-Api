using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Entity.DTOs.Parameter.Extras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Parameter
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class ExtraController : ControllerBase
    {
        private readonly IExtraServices _services;

        public ExtraController(IExtraServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        #region "GET"

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var extras = await _services.GetAllAsync(cancellationToken);
                return Ok(extras);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al obtener los extras", error = ex.Message });
            }
        }

        [HttpGet("{id}", Name = "GetExtraByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                var extra = await _services.GetByIdAsync(id, cancellationToken);

                if (extra is null)
                    return NotFound(new { message = $"Extra con ID {id} no encontrado" });

                return Ok(extra);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al obtener el extra", error = ex.Message });
            }
        }

        #endregion

        #region "POST"

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] ExtraCreateDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { message = "Los datos del extra son requeridos" });

                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(new { message = "El nombre del extra es requerido" });

                var extra = await _services.CreateAsync(dto);
                return CreatedAtRoute("GetExtraByIdAsync", new { id = extra.Id }, extra);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al crear el extra", error = ex.Message });
            }
        }

        #endregion

        #region "PUT"

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ExtraCreateDto dto)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { message = "El ID debe ser mayor que cero" });

                if (dto == null)
                    return BadRequest(new { message = "Los datos del extra son requeridos" });

                if (string.IsNullOrWhiteSpace(dto.Name))
                    return BadRequest(new { message = "El nombre del extra es requerido" });

                var result = await _services.UpdateAsync(id, dto);

                if (!result.Success)
                    return NotFound(result);

                return Ok(new { message = "Extra actualizado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al actualizar el extra", error = ex.Message });
            }
        }

        #endregion

        #region "PATCH"

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
                    return NotFound(new { message = $"Extra con ID {id} no encontrado" });

                var status = isActive ? "activado" : "desactivado";
                return Ok(new { message = $"Extra {status} exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al cambiar el estado del extra", error = ex.Message });
            }
        }

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
                    return NotFound(new { message = $"Extra con ID {id} no encontrado" });

                return Ok(new { message = "Extra eliminado exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al eliminar el extra", error = ex.Message });
            }
        }

        #endregion
    }
}
