namespace Ratbags.Emails.API.Interfaces;

public interface IAccountsEmailService
{
    Task ForgotPasswordSendAsync(string name, string email, Guid userId, string token);
    Task RegisterConfirmEmailSendAsync(string name, string email, Guid userId, string token);
}
