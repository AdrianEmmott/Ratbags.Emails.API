using MassTransit;
using Ratbags.Core.Events.Accounts;
using Ratbags.Emails.API.Interfaces;

namespace Ratbags.Emails.Messaging.Consumers;

public class RegisterConfirmEmailConsumer : IConsumer<SendRegisterConfirmEmailRequest>
{
    private readonly ILogger<RegisterConfirmEmailConsumer> _logger;
    private readonly IAccountsEmailService _emailService;

    public RegisterConfirmEmailConsumer(
        IAccountsEmailService emailService,
        ILogger<RegisterConfirmEmailConsumer> logger)
    {
        _emailService = emailService; 
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<SendRegisterConfirmEmailRequest> context)
    {
        _logger.LogInformation("listening...");

        await _emailService.RegisterConfirmEmailSendAsync(
            context.Message.Name, 
            context.Message.Email,
            context.Message.UserId, 
            context.Message.Token);
    }
}