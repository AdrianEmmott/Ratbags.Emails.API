using MassTransit;
using Ratbags.Core.Settings;
using Ratbags.Emails.Messaging.Consumers;

namespace Ratbags.Comments.API.ServiceExtensions;

public static class MassTransitServiceExtension
{
    public static IServiceCollection AddMassTransitWithRabbitMqServiceExtension(this IServiceCollection services, AppSettingsBase appSettings)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<RegisterConfirmEmailConsumer>();
            x.AddConsumer<ForgotPasswordEmailConsumer>();

            // rabbitmq config
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host($"rabbitmq://{appSettings.Messaging.Hostname}/{appSettings.Messaging.VirtualHost}", h =>
                {
                    h.Username(appSettings.Messaging.Username);
                    h.Password(appSettings.Messaging.Password);
                });

                cfg.ReceiveEndpoint("accounts.register.confirm-email", q =>
                {
                    q.ConfigureConsumer<RegisterConfirmEmailConsumer>(context);
                });

                cfg.ReceiveEndpoint("accounts.forgot-password.email", q =>
                {
                    q.ConfigureConsumer<ForgotPasswordEmailConsumer>(context);
                });
            });
        });

        return services;
    }
}