using CakeOs.Business.Interfaces.Business;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Business.Interfaces;
using CakeOs.Business.CustomJWT;
using CakeOs.Business.Interfaces.Parameter;
using CakeOs.Business.Services.Business;
using CakeOs.Business.Services.Parameter;
using CakeOs.Business.Services.Security;

namespace CakeOs.Web.Extensions.Module
{
    public static class BusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceServices, InvoiceServices>();
            services.AddScoped<IInvoiceItemServices, InvoiceItemServices>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IPaymentServices, PaymentService>();
            services.AddScoped<IProductServices, ProductService>();
            services.AddScoped<IFilledServices, FilledService>();
            services.AddScoped<IShapeServices, ShapeService>();
            services.AddScoped<ISizeServices, SizeService>();
            services.AddScoped<ITypeServices, TypeService>();
            services.AddScoped<IPersonServices, PersonServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IRolServices, RolServices>();
            services.AddScoped<IModuleServices, ModuleServices>();
            services.AddScoped<IFormServices, FormServices>();
            services.AddScoped<IPermissionServices, PermissionServices>();
            services.AddScoped<IFormModuleServices, FormModuleServices>();
            services.AddScoped<IRolFormPermissionServices, RolFormPermissionServices>();
            services.AddScoped<IToken, Token>();
            services.AddScoped<IAuthServices, AuthServices>();
            return services;
        }
    }
}
