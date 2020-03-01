using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfAlex.Web.Authorization
{
    public class AuthorizedToUseTheAppHandler : AuthorizationHandler<AuthorizedToUseTheAppRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       AuthorizedToUseTheAppRequirement requirement)
        {
            if (context.User.Claims.Any(x => x.Type.StartsWith("Action:")))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
