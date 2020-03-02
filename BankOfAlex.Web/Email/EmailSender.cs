using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace BankOfAlex.Web.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public EmailSenderOptions Options { get; }

        public Task SendEmailAsync(string email,
                                   string subject,
                                   string htmlMessage)
        {
            var client = new SendGridClient(Options.SendGridKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.EmailAddresses.Notifications, Options.SendGridUser),
                Subject = subject,
                HtmlContent = htmlMessage
            };

            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(enable: false, enableText: false);

            return client.SendEmailAsync(msg);
        }
    }
}
