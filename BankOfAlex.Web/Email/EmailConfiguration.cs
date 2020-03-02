using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankOfAlex.Web.Email
{
    public static class EmailConfiguration
    {
        public static void AddCustomEmailSender(this IServiceCollection services,
                                                IConfiguration configuration)
        {
            services.Configure<EmailSenderOptions>(configuration.GetSection(nameof(Email)));

            services.AddSingleton<IEmailSender, EmailSender>();
        }
    }
}
