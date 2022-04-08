using Library.FilipVujeva.Contracts.Services;
using Library.FilipVujeva.Contracts.Settings;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Library.FilipVujeva.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task Send(string to, string subject, string body)
        {
            var sendGridClient = new SendGridClient(_emailSettings.Key);

            var message = new SendGridMessage
            {
                From = new EmailAddress(_emailSettings.From),
                Subject = subject,
                HtmlContent = body,
            };

            message.AddTo(new EmailAddress(to));
            var response = await sendGridClient.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Body.ReadAsStringAsync();
                throw new Exception(error);
            }
        }
    }
}
