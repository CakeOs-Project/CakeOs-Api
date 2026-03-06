using CakeOs.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CakeOs.Web.Extensions.Infrastructure
{
    public static class DataBaseService
    {
        public static IServiceCollection AddDataBaseService(this IServiceCollection services, IConfiguration config)
        {
            var sql = config.GetConnectionString("SqlServer");

            if (!string.IsNullOrWhiteSpace(sql)) 
            { 
                services.AddDbContext<ApplicationDbContext>(opt => 
                    opt.UseSqlServer(sql, s =>
                    {
                        s.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        s.EnableRetryOnFailure();
                        s.CommandTimeout(60);
                    }));
            }

            return services;
        }
    }
}
