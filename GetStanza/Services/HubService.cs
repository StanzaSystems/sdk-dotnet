using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GetStanza.Models;
using GetStanza.Providers.Interfaces;
using GetStanza.Services.Interfaces;
using Stanza.Hub.V1;

namespace GetStanza.Services;

internal class HubService : IHubService
{
    private readonly IHubProvider _hubProvider;
    private readonly ConcurrentConfigurationsCache _configurationsCache;

    public HubService(IHubProvider hubProvider, ConcurrentConfigurationsCache configurationsCache)
    {
        _hubProvider = hubProvider;
        _configurationsCache = configurationsCache;
    }

    public async Task<GuardConfig> GetGuardConfigAsync(
        string guardName,
        IDictionary<string, string>? tags,
        CancellationToken cancellationToken
    )
    {
        if (_configurationsCache.GuardConfigs.TryGetValue(guardName, out var guardConfigCache))
            return guardConfigCache.Config;

        var guardConfigResponse = await _hubProvider.FetchGuardConfigAsync(
            guardName,
            tags,
            null,
            cancellationToken
        );
        _configurationsCache.GuardConfigs[guardName] = new(
            guardConfigResponse.Config,
            guardConfigResponse.Version,
            tags
        );
        return guardConfigResponse.Config;
    }

    public GuardConfig GetGuardConfig(
        string guardName,
        IDictionary<string, string>? tags,
        CancellationToken cancellationToken
    )
    {
        if (_configurationsCache.GuardConfigs.TryGetValue(guardName, out var guardConfigCache))
            return guardConfigCache.Config;

        var guardConfigResponse = _hubProvider.FetchGuardConfig(
            guardName,
            tags,
            null,
            cancellationToken
        );
        _configurationsCache.GuardConfigs[guardName] = new(
            guardConfigResponse.Config,
            guardConfigResponse.Version,
            tags
        );
        return guardConfigResponse.Config;
    }

    public Task<GetTokenResponse> GetQuotaTokenAsync(
        string guardName,
        string featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float weight,
        CancellationToken cancellationToken
    ) =>
        _hubProvider.FetchQuotaTokenAsync(
            guardName,
            featureName,
            tags,
            clientId,
            priorityBoost,
            weight,
            cancellationToken
        );

    public GetTokenResponse GetQuotaToken(
        string guardName,
        string featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float weight,
        CancellationToken cancellationToken
    ) =>
        _hubProvider.FetchQuotaToken(
            guardName,
            featureName,
            tags,
            clientId,
            priorityBoost,
            weight,
            cancellationToken
        );
}
