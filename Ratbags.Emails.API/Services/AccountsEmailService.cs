using Ratbags.Emails.API.Interfaces;
using Ratbags.Emails.API.Models;
using System.Net;
using System.Net.Mail;

namespace Ratbags.Emails.API.Services;

public class AccountsEmailService : IAccountsEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly ILogger<AccountsEmailService> _logger;
    private readonly AppSettings _appSettings;

    public AccountsEmailService(ILogger<AccountsEmailService> logger, AppSettings appSetings)
    {
        _appSettings = appSetings;

        _smtpClient = new SmtpClient(appSetings.Mail.SMTPSettings.Host, Convert.ToInt32(_appSettings.Mail.SMTPSettings.Port));
        _smtpClient.EnableSsl = Convert.ToBoolean(_appSettings.Mail.SMTPSettings.EnableSSL);
        _smtpClient.Credentials = new NetworkCredential(_appSettings.Mail.SMTPSettings.Username, _appSettings.Mail.SMTPSettings.Password);

        _logger = logger;
    }

    public async Task RegisterConfirmEmailSendAsync(string name, string email, Guid userId, string token)
    {
        // TODO appsettings for the domain
        var confirmUrl = $"https://localhost:4200/register-confirm-email/{userId}/{token}";

        var mailMessage = new MailMessage(_appSettings.Mail.NoReplyEmail, email)
        {
            // TODO needs a template
            Subject = "Confirm your email address",
            Body = $@"<p>hello {name}!</p><p><a href='{confirmUrl}' target='_blank'>Confirm your email address </a> to complate the registration process</a></p>"
        };

        try
        {
            await _smtpClient.SendMailAsync(mailMessage);
            _logger.LogInformation($"sent register confirm email to user {email}");
        }
        catch (SmtpException e)
        {
            _logger.LogError($"error sending register confirm email address for {email}: {e.Message}");
            throw;
        }
    }

    public async Task ForgotPasswordSendAsync(string name, string email, Guid userId, string token)
    {
        // TODO appsettings for the domain
        var confirmUrl = $"https://localhost:4200/reset-password/{userId}/{token}";

        var mailMessage = new MailMessage(_appSettings.Mail.NoReplyEmail, email)
        {
            // TODO needs a template
            Subject = "Reset your password",
            Body = $@"<p>hello {name}!</p><p><a href='{confirmUrl}' target='_blank'>Reset your password</a></p>"
        };

        try
        {
            await _smtpClient.SendMailAsync(mailMessage);
            _logger.LogInformation($"sent reset password email to user {email}");
        }
        catch (SmtpException e)
        {
            _logger.LogError($"error sending forgot password email for {email}: {e.Message}");
            throw;
        }
    }
}