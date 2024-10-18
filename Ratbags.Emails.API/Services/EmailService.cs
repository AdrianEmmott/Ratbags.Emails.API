using Ratbags.Emails.API.Interfaces;
using Ratbags.Emails.API.Models;
using System.Net;
using System.Net.Mail;

namespace Ratbags.Emails.API.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger, AppSettings appSetings)
    {
        _smtpClient = new SmtpClient(appSetings.Mail.SMTPSettings.Host, Convert.ToInt32(appSetings.Mail.SMTPSettings.Port));
        _smtpClient.EnableSsl = Convert.ToBoolean(appSetings.Mail.SMTPSettings.EnableSSL);
        _smtpClient.Credentials = new NetworkCredential(appSetings.Mail.SMTPSettings.Username, appSetings.Mail.SMTPSettings.Password);

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