using Ratbags.Core.Messaging.ASB.RequestReponse;
using Ratbags.Emails.API.Interfaces;

namespace Ratbags.Emails.API.Messaging;

public sealed class ForgotPasswordEmailHandler
    : IServiceBusRequestHandler<ForgotPasswordEmailRequest, ForgotPasswordEmailResponse>
{
    private readonly IAccountsEmailService _service;

    public ForgotPasswordEmailHandler(IAccountsEmailService service)
    {
        _service = service;
    }

    public async Task<ForgotPasswordEmailResponse> HandleAsync
        (ForgotPasswordEmailRequest request, CancellationToken ct)
    {
        await _service.ForgotPasswordSendAsync(
            name: request.name,
            email: request.email,
            userId: request.userId,
            token: request.token);

        return new ForgotPasswordEmailResponse(success: true);
    }
}
