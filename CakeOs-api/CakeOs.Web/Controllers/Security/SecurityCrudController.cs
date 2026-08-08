using CakeOs.Business.Base;
using CakeOS.Entity.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [ApiController]
    [Produces("application/json")]
    public abstract class SecurityCrudController<TListDto, TCreateDto, TEntity> : ControllerBase
        where TListDto : class
        where TCreateDto : class
        where TEntity : BaseDomain
    {
        protected readonly IServices<TListDto, TCreateDto, TEntity> _service;

        protected SecurityCrudController(IServices<TListDto, TCreateDto, TEntity> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var data = await _service.GetAllAsync(cancellationToken);
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
                return BadRequest(new { message = "El id debe ser mayor que cero." });

            var data = await _service.GetByIdAsync(id, cancellationToken);
            if (data is null)
                return NotFound(new { message = "Registro no encontrado." });

            return Ok(data);
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created, created);
        }

        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> UpdateAsync(int id, [FromBody] TCreateDto dto)
        {
            if (id <= 0)
                return BadRequest(new { message = "El id debe ser mayor que cero." });

            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }

        [HttpPatch("{id:int}/toggle-active")]
        public virtual async Task<IActionResult> ToggleActiveAsync(int id, [FromQuery] bool isActive)
        {
            if (id <= 0)
                return BadRequest(new { message = "El id debe ser mayor que cero." });

            var result = await _service.ToggleActiveAsync(id, isActive);
            return Ok(result);
        }

        [HttpPatch("{id:int}/delete")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "El id debe ser mayor que cero." });

            var result = await _service.SoftDeleteAsync(id);
            return Ok(result);
        }
    }
}
