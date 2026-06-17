namespace CakeOs.Web.Extensions.Module
{
    public static class CorsExtension
    {
        private const string PolicyName = "CakeOsPolicy";

        public static IServiceCollection AddCorsService(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration
                .GetSection("Cors:AllowedOrigins")
                .Get<string[]>() ?? [];

            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsService(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            return app;
        }
    }
}
