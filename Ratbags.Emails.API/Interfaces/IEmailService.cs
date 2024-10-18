namespace Ratbags.Emails.API.Interfaces;

public interface IEmailService
{
    Task ForgotPasswordSendAsync(string name, string email, Guid userId, string token);
    Task RegisterConfirmEmailSendAsync(string name, string email, Guid userId, string token);
}
