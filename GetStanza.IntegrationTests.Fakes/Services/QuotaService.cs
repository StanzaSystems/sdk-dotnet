using Grpc.Core;
using Stanza.Hub.V1;
using Hub = Stanza.Hub.V1;

namespace GetStanza.IntegrationTests.Fakes.Services;

public class QuotaService(ILogger<QuotaService> logger) : Hub.QuotaService.QuotaServiceBase
{
    private readonly ILogger<QuotaService> _logger = logger;

    /// <summary>
    /// Fake implementation of QuotaService.GetToken.
    /// To prevent granting a token, pass a guard whose name contains "NotGranted".
    /// </summary>
    /// <returns>A faked GetTokenResponse.</returns>
    public override Task<GetTokenResponse> GetToken(GetTokenRequest request, ServerCallContext context)
    {
        _logger.LogInformation("GetToken called with request: {request}", request);

        GetTokenResponse result = new()
        {
            Granted = true,
            Mode = Mode.Normal,
            Reason = Reason.SufficientQuota,
            Token = "fakeToken",
        };

        if (request.Selector is not null && request.Selector.GuardName.Contains("NotGranted"))
        {
            result.Granted = false;
            result.Reason = Reason.InsufficientQuota;
        }

        return Task.FromResult(result);
    }
}
