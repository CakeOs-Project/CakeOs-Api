using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.DTOs.Security.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var response = await _authServices.LoginAsync(dto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al realizar login", error = ex.Message });
            }
        }

        [HttpGet("token-info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTokenInfo([FromQuery] string? token = null)
        {
            try
            {
                var rawToken = token;

                if (string.IsNullOrWhiteSpace(rawToken))
                {
                    var authorization = Request.Headers.Authorization.ToString();
                    if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        rawToken = authorization["Bearer ".Length..].Trim();
                    }
                }

                if (string.IsNullOrWhiteSpace(rawToken))
                    return BadRequest(new { message = "Token requerido en query o header Authorization." });

                var response = await _authServices.GetTokenInfoAsync(rawToken);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Error al obtener informacion del token", error = ex.Message });
            }
        }
    }
}
