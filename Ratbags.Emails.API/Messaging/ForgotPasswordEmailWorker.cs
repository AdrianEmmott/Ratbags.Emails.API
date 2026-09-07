using Azure.Messaging.ServiceBus;
using Ratbags.Core.Messaging.ASB.RequestReponse;
using Ratbags.Emails.API.Models;

namespace Ratbags.Emails.API.Messaging;

public sealed class ForgotPasswordEmailWorker
    : ServiceBusRequestReplyWorker<ForgotPasswordEmailRequest, ForgotPasswordEmailResponse>
{
    public ForgotPasswordEmailWorker(
        AppSettings appSettings,
        ServiceBusClient sbClient,
        IServiceScopeFactory scopeFactory,
        ILogger<ForgotPasswordEmailWorker> logger)
        : base(
            sbClient,
            appSettings.MessagingExtensions.ForgotPasswordEmailTopic,
            appSettings.Messaging.ASB.ResponseSubscription,
            scopeFactory,
            logger)
    { }
}
