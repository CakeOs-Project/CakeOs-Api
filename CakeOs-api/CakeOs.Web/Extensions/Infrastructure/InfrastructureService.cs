namespace CakeOs.Web.Extensions.Infrastructure
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config) 
        { 
            services.AddDataBaseService(config);

            return services;
        }
    }
}
