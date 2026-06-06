using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Auth;
using CakeOS.Entity.DTOs.Security.User;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [Route("api/security/[controller]")]
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
            var data = await _userService.GetByEmailAsync(email);
            if (data is null)
                return NotFound(new { message = "Usuario no encontrado." });

            return Ok(data);
        }

        [HttpPatch("{userId:int}/change-password")]
        public async Task<IActionResult> ChangePasswordAsync(int userId, [FromBody] ChangePasswordDto dto)
        {
            var changed = await _userService.ChangePasswordAsync(userId, dto);
            return Ok(new { success = changed });
        }
    }
}
