using Microsoft.Extensions.Options;
using Ratbags.Core.Messaging.ASB.RequestReponse;
using Ratbags.Emails.API.Interfaces;
using Ratbags.Emails.API.Messaging;
using Ratbags.Emails.API.Models;
using Ratbags.Emails.API.Services;

namespace Ratbags.Emails.API.ServiceExtensions;

public static class DIServiceExtension
{
    public static IServiceCollection AddDIServiceExtension(this IServiceCollection services)
    {
        services.AddScoped<IAccountsEmailService, AccountsEmailService>();

        // expose appSettings as IOptions<T> singleton
        services.AddSingleton(x => x.GetRequiredService<IOptions<AppSettings>>().Value);

        // service bus
        services.AddHostedService<ForgotPasswordEmailWorker>();
        services.AddScoped<IServiceBusRequestHandler<ForgotPasswordEmailRequest, ForgotPasswordEmailResponse>, ForgotPasswordEmailHandler>();

        return services;
    }
}
