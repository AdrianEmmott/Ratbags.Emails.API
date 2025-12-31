using Ratbags.Core.Messaging.ASB.RequestReponse;
using Ratbags.Emails.API.Models;

namespace Ratbags.Emails.API.Messaging;

public sealed class ForgotPasswordEmailWorker 
    : ServiceBusRequestReplyWorker<ForgotPasswordEmailRequest, ForgotPasswordEmailResponse>
{
    public ForgotPasswordEmailWorker(
        AppSettings appSettings,
        IServiceScopeFactory scopeFactory,
        ILogger<ForgotPasswordEmailWorker> logger) 
        : base(
            appSettings.Messaging.ASB.Connection,
            appSettings.MessagingExtensions.ForgotPasswordEmailTopic,
            appSettings.Messaging.ASB.ResponseSubscription,
            scopeFactory,
            logger)
    { }
}
