using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Auth;
using CakeOS.Entity.DTOs.Security.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [ApiController]
    [Route("api/security/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class UserController : SecurityCrudController<UserListDto, UserCreateDto, User>
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices service) : base(service)
        {
            _userService = service;
        }

        [HttpGet("by-email")]
        public async Task<IActionResult> GetByEmailAsync([FromQuery] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest(new { message = "El correo es requerido." });

            var data = await _userService.GetByEmailAsync(email);
            if (data is null)
                return NotFound(new { message = "Usuario no encontrado." });

            return Ok(data);
        }

        [HttpPatch("{userId:int}/change-password")]
        public async Task<IActionResult> ChangePasswordAsync(int userId, [FromBody] ChangePasswordDto dto)
        {
            if (userId <= 0)
                return BadRequest(new { message = "El id de usuario debe ser mayor que cero." });

            var changed = await _userService.ChangePasswordAsync(userId, dto);
            if (!changed)
                return Conflict(new { message = "No fue posible actualizar la contraseña." });

            return Ok(new { message = "Contraseña actualizada correctamente." });
        }
    }
}
