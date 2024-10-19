using MassTransit;
using Ratbags.Core.Events.Accounts;
using Ratbags.Emails.API.Interfaces;

namespace Ratbags.Emails.Messaging.Consumers;

public class ForgotPasswordEmailConsumer : IConsumer<SendForgotPasswordEmailRequest>
{
    private readonly ILogger<ForgotPasswordEmailConsumer> _logger;
    private readonly IAccountsEmailService _emailService;

    public ForgotPasswordEmailConsumer(
        IAccountsEmailService emailService,
        ILogger<ForgotPasswordEmailConsumer> logger)
    {
        _emailService = emailService; 
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<SendForgotPasswordEmailRequest> context)
    {
        _logger.LogInformation("listening...");

        await _emailService.ForgotPasswordSendAsync(
            context.Message.Name, 
            context.Message.Email, 
            context.Message.UserId, 
            context.Message.Token);
    }
}