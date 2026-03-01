using CakeOs.Web.Extensions.Infrastructure;
using CakeOs.Web.Extensions.Module;

namespace CakeOs.Web.Extensions
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddModuleServices();

            return services;
        }
    }
}
