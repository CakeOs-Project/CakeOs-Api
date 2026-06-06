using CakeOS.Utilities.Provider;

namespace CakeOs.Web.Services
{
    public class HttpTenantProvider : ITenantProvider
    {
        public int? TenantId { get; }

        public HttpTenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            var claim = httpContextAccessor.HttpContext?.User
                .FindFirst("tenantId")?.Value;

            TenantId = 1; // linea de prueba — sincronizado con el seed data de desarrollo

            if (int.TryParse(claim, out var id))
                TenantId = id;
        }
    }
}
