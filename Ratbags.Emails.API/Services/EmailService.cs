using Ratbags.Emails.API.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Ratbags.Emails.API.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _smtpClient = new SmtpClient("localhost", 2525); // TODO appsettings
        _smtpClient.EnableSsl = false;
        _smtpClient.Credentials = new NetworkCredential("", ""); // TODO appsettings

        _logger = logger;
    }

    public async Task RegisterConfirmEmailSendAsync(string name, string email, Guid userId, string token)
    {
        _logger.LogInformation($"sent register confirm email to user {email}");

        var confirmUrl = $"https://localhost:4200/register-confirm-email/{userId}/{token}";

        var mailMessage = new MailMessage("noreply@ratbags.com", email) // TODO appsettings
        {
            // TODO needs a template
            Subject = "Confirm your email address",
            Body = $@"<p>hello {name}!</p><p><a href='{confirmUrl}' target='_blank'>Confirm your email address </a> to complate the registration process</a></p>"
        };

        await _smtpClient.SendMailAsync(mailMessage);
    }

    public async Task ForgotPasswordSendAsync(string name, string email, Guid userId, string token)
    {
        _logger.LogInformation($"sent reset password email to user {email}");

        var confirmUrl = $"https://localhost:4200/reset-password/{userId}/{token}";

        var mailMessage = new MailMessage("noreply@ratbags.com", email) // TODO appsettings
        {
            // TODO needs a template
            Subject = "Rest your password",
            Body = $@"<p>hello {name}!</p><p><a href='{confirmUrl}' target='_blank'>Reset your password</a></p>"
        };

        await _smtpClient.SendMailAsync(mailMessage);
    }
}