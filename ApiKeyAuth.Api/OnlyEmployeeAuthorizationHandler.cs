using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ApiKeyAuth.Api
{
    public class OnlyEmployeeAuthorizationHandler : AuthorizationHandler<OnlyEmployeeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OnlyEmployeeRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Employee))
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}