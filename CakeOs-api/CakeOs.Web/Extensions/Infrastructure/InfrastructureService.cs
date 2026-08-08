using CakeOs.Web.Services.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CakeOs.Entity.DTOs.Transversal;
using System.Text.Json;

namespace CakeOs.Web.Extensions.Infrastructure
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config) 
        { 
            services.AddDataBaseService(config);

            var jwtKey = config["Jwt:Key"] ?? "CakeOs.Dev.Jwt.Key.Change.Me.2026";
            var jwtIssuer = config["Jwt:Issuer"] ?? "CakeOs";
            var jwtAudience = config["Jwt:Audience"] ?? "CakeOs.Client";

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,
                        ValidateAudience = true,
                        ValidAudience = jwtAudience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = async context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonSerializer.Serialize(
                                ApiResponse.Fail(StatusCodes.Status401Unauthorized, "No autenticado.")));
                        },
                        OnForbidden = async context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonSerializer.Serialize(
                                ApiResponse.Fail(StatusCodes.Status403Forbidden, "No autorizado.")));
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireTenant", policy =>
                    policy.Requirements.Add(new TenantRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, TenantAuthorizationHandler>();

            return services;
        }
    }
}
