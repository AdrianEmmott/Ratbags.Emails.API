namespace Ratbags.Emails.API.Messaging;

public sealed record ForgotPasswordEmailRequest(
    string name, 
    string email, 
    Guid userId, 
    string token);

public sealed record ForgotPasswordEmailResponse(bool success);