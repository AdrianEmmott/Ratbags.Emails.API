using Ratbags.Emails.API.Interfaces;
using Ratbags.Emails.API.Services;

namespace Ratbags.Emails.API.ServiceExtensions;

public static class DIServiceExtension
{
    public static IServiceCollection AddDIServiceExtension(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
