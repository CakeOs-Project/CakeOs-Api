using CakeOs.Data.Interfaz.IBusinessData;
using CakeOs.Data.Interfaz.ISecurityData;
using CakeOs.Data.Repository.BusinessData;
using CakeOs.Data.Repository.SecurityData;

namespace CakeOs.Web.Extensions.Module
{
    public static class DataService
    {
        public static IServiceCollection AddDataService(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceData, InvoiceData>();
            services.AddScoped<IClientData, ClientData>();
            services.AddScoped<IPersonData, PersonData>();
            services.AddScoped<IInvoiceItemData, InvoiceItemData>();
            return services;
        }
    }
}
