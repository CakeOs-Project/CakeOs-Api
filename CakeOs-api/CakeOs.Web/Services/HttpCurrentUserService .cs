using CakeOS.Utilities.Provider;

namespace CakeOs.Web.Services
{
    public class HttpCurrentUserService : ICurrentUserService
    {
        public int? UserId { get; }
        public int? RolId { get; }
        public string? RolName { get; }
        public string? FullName { get; }
        public string? Email { get; }

        public HttpCurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;
            if (user is null)
                return;

            if (int.TryParse(user.FindFirst("userId")?.Value, out var userId))
                UserId = userId;

            if (int.TryParse(user.FindFirst("rolId")?.Value, out var rolId))
                RolId = rolId;

            RolName = user.FindFirst("rolName")?.Value;
            FullName = user.FindFirst("fullName")?.Value;
            Email = user.FindFirst("email")?.Value;
        }

        public int RequireUserId()
        {
            return UserId ?? throw new UnauthorizedAccessException(
                "No se pudo determinar el usuario autenticado a partir del token.");
        }
    }
}
