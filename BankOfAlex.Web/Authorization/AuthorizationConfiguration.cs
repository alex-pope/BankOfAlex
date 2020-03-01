using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BankOfAlex.Web.Authorization
{
    public static class AuthorizationConfiguration
    {
        public static void AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
                {
                    options.AddPolicy("IsAuthenticated", policy =>
                        {
                            policy.RequireAuthenticatedUser();
                        });

                    options.AddPolicy("IsAuthorizedToUseTheApp", policy =>
                        {
                            policy.Requirements.Add(new AuthorizedToUseTheAppRequirement());
                        });
                });

            services.AddSingleton<IAuthorizationHandler, AuthorizedToUseTheAppHandler>();
        }
    }
}
