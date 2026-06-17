using Microsoft.AspNetCore.Authorization;

namespace CakeOs.Web.Services.Authorization
{
    public class TenantAuthorizationHandler : AuthorizationHandler<TenantRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            TenantRequirement requirement)
        {
            var claim = context.User.FindFirst("tenantId")?.Value;

            if (int.TryParse(claim, out _))
                context.Succeed(requirement);
            else
                context.Fail(new AuthorizationFailureReason(this,
                    "El token no contiene un tenantId válido."));

            return Task.CompletedTask;
        }
    }
}
