using Microsoft.AspNetCore.Authorization;

namespace ApiKeyAuth.Api
{
    public class OnlyEmployeeRequirement : IAuthorizationRequirement
    {
    }
}