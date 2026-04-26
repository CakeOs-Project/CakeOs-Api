using CakeOs.Web.Extensions.Infrastructure;
using CakeOs.Web.Extensions.Module;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace CakeOs.Web.Extensions
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddModuleServices();

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
