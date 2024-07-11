using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GetStanza.Providers.Interfaces;
using GetStanza.Providers.Models;
using Grpc.Core;
using Stanza.Hub.V1;

namespace GetStanza.Providers;

internal class HubProvider : IHubProvider
{
    private readonly ConfigService.ConfigServiceClient _configServiceClient;
    private readonly QuotaService.QuotaServiceClient _quotaServiceClient;
    private readonly HubProviderConfiguration _config;

    public HubProvider(
        HubProviderConfiguration config,
        ConfigService.ConfigServiceClient configServiceClient,
        QuotaService.QuotaServiceClient quotaServiceClient)
    {
        _configServiceClient = configServiceClient;
        _quotaServiceClient = quotaServiceClient;
        _config = config;
    }

    public async Task<GetGuardConfigResponse> FetchGuardConfigAsync(
        string guardName,
        IDictionary<string, string>? tags,
        string? versionSeen,
        CancellationToken cancellationToken)
    {
        GuardServiceSelector selector = new()
        {
            GuardName = guardName,
            Environment = _config.Environment,
            ServiceName = _config.Service,
            ServiceRelease = _config.Service,
        };

        if (tags is not null)
            selector.Tags.AddRange(tags.Select(tag => new Tag()
            {
                Key = tag.Key,
                Value = tag.Value
            }));

        return await _configServiceClient.GetGuardConfigAsync(new()
        {
            Selector = selector,
            VersionSeen = versionSeen ?? "",
        }, new Metadata { { "x-stanza-key", _config.ApiKey } }, cancellationToken: cancellationToken);
    }

    public GetGuardConfigResponse FetchGuardConfig(
        string guardName,
        IDictionary<string, string>? tags,
        string? versionSeen,
        CancellationToken cancellationToken)
    {
        GuardServiceSelector selector = new()
        {
            GuardName = guardName,
            Environment = _config.Environment,
            ServiceName = _config.Service,
            ServiceRelease = _config.Service,
        };

        if (tags is not null)
            selector.Tags.AddRange(tags.Select(tag => new Tag()
            {
                Key = tag.Key,
                Value = tag.Value
            }));

        return _configServiceClient.GetGuardConfig(new()
        {
            Selector = selector,
            VersionSeen = versionSeen ?? "",
        }, new Metadata { { "x-stanza-key", _config.ApiKey } }, cancellationToken: cancellationToken);
    }

    public async Task<GetTokenResponse> FetchQuotaTokenAsync(
        string guardName,
        string? featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float? weight,
        CancellationToken cancellationToken)
    {
        GuardFeatureSelector selector = new()
        {
            GuardName = guardName,
            Environment = _config.Environment,
            FeatureName = featureName,

        };
        if (tags is not null)
            selector.Tags.AddRange(tags.Select(tag => new Tag()
            {
                Key = tag.Key,
                Value = tag.Value
            }));

        GetTokenRequest request = new()
        {
            Selector = selector,
        };

        if (clientId is not null)
            request.ClientId = clientId;
        if (priorityBoost is not null)
            request.PriorityBoost = priorityBoost.Value;
        if (weight is not null)
            request.Weight = weight.Value;

        return await _quotaServiceClient.GetTokenAsync(request, new Metadata { { "x-stanza-key", _config.ApiKey } }, cancellationToken: cancellationToken);
    }

    public GetTokenResponse FetchQuotaToken(
        string guardName,
        string? featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float? weight,
        CancellationToken cancellationToken)
    {
        GuardFeatureSelector selector = new()
        {
            GuardName = guardName,
            Environment = _config.Environment,
            FeatureName = featureName,

        };
        if (tags is not null)
            selector.Tags.AddRange(tags.Select(tag => new Tag()
            {
                Key = tag.Key,
                Value = tag.Value
            }));

        GetTokenRequest request = new()
        {
            Selector = selector,
        };

        if (clientId is not null)
            request.ClientId = clientId;
        if (priorityBoost is not null)
            request.PriorityBoost = priorityBoost.Value;
        if (weight is not null)
            request.Weight = weight.Value;

        return _quotaServiceClient.GetToken(request, new Metadata { { "x-stanza-key", _config.ApiKey } }, cancellationToken: cancellationToken);
    }
}
