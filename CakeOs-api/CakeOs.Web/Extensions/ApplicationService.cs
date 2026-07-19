using CakeOs.Business.Mapping;
using CakeOs.Web.Extensions.Infrastructure;
using CakeOs.Web.Extensions.Module;
using CakeOs.Web.Services;
using CakeOS.Utilities.Interfaces;
using CakeOS.Utilities.Provider;
using CakeOS.Utilities.Services;
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

            var config = MappingConfig.Register();

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddScoped<IPasswordHasherService, PasswordHasherService>();

            services.AddHttpContextAccessor();
            services.AddScoped<ITenantProvider, HttpTenantProvider>();
            services.AddScoped<ICurrentUserService, HttpCurrentUserService>();

            return services;
        }
    }
}
