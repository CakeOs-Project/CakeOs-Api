namespace CakeOs.Web.Extensions.Module
{
    public static class ModuleServiceExtensions
    {
        public static IServiceCollection AddModuleServices(this IServiceCollection services)
        {
            services.AddBusinessService()
                    .AddDataService();

            return services;
        }
    }
}
