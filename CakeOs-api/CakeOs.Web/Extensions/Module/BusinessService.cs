using CakeOs.Business.Interfaces.Business;
using CakeOs.Business.Services.Business;

namespace CakeOs.Web.Extensions.Module
{
    public static class BusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceServices, InvoiceServices>();
            services.AddScoped<IClientServices, ClientServices>();
            return services;
        }
    }
}
