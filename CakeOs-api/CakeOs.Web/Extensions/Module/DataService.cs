using CakeOs.Data.Interfaces.Business;
using CakeOs.Data.Interfaces.Security;
using CakeOs.Data.Repository.BusinessData;
using CakeOs.Data.Repository.SecurityData;

namespace CakeOs.Web.Extensions.Module
{
    public static class DataService
    {
        public static IServiceCollection AddDataService(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceRepository, InvoiceData>();
            services.AddScoped<IInvoiceItemRepository, InvoiceItemData>();
            services.AddScoped<IClientRepository, ClientData>();
            services.AddScoped<IPersonRepository, PersonData>();
            services.AddScoped<IInvoiceItemRepository, InvoiceItemData>();
            services.AddScoped<IPaymentRepository, PaymentData>();
            services.AddScoped<IProductRepository, ProductData>();
            services.AddScoped<IFilledRepository, FilledData>();
            services.AddScoped<IShapeRepository, ShapeData>();
            services.AddScoped<ISizeRepository, SizeData>();
            services.AddScoped<ITypeRepository, TypeData>();
            return services;
        }
    }
}
