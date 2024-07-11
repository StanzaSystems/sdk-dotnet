using Grpc.Core;
using Stanza.Hub.V1;
using Hub = Stanza.Hub.V1;

namespace GetStanza.IntegrationTests.Fakes.Services;

public class ConfigService : Hub.ConfigService.ConfigServiceBase
{
    private readonly ILogger<ConfigService> _logger;

    public ConfigService(ILogger<ConfigService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Fake implementation of ConfigService.GetGuardConfig.
    /// To enable report only, pass a guard whose name contains "ReportOnly".
    /// To disable quota check, pass a guard whose name contains "NoQuotaCheck".
    /// </summary>
    /// <returns>A faked GetGuardConfigResponse.</returns>
    public override Task<GetGuardConfigResponse> GetGuardConfig(
        GetGuardConfigRequest request,
        ServerCallContext context
    )
    {
        _logger.LogInformation("GetGuardConfig called with request: {request}", request);

        GetGuardConfigResponse result =
            new()
            {
                Config = new()
                {
                    CheckQuota = true,
                    QuotaTags = { },
                    ReportOnly = false,
                    ValidateIngressTokens = false
                },
                ConfigDataSent = true,
                Version = "1"
            };

        if (request.Selector is not null)
        {
            result.Config.ReportOnly = request.Selector.GuardName.Contains("ReportOnly");
            result.Config.CheckQuota = !request.Selector.GuardName.Contains("NoQuotaCheck");
        }

        return Task.FromResult(result);
    }
}
