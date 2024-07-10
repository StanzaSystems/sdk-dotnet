using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stanza.Hub.V1;

namespace GetStanza.Services.Interfaces;

/// <summary>
/// Coordinates caching and fetching Hub models.
/// </summary>
internal interface IHubService {
    public Task<GuardConfig> GetGuardConfigAsync(
        string guardName,
        IDictionary<string, string>? tags,
        CancellationToken cancellationToken);
    public GuardConfig GetGuardConfig(
        string guardName,
        IDictionary<string, string>? tags,
        CancellationToken cancellationToken);
    public Task<GetTokenResponse> GetQuotaTokenAsync(
        string guardName,
        string? featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float? weight,
        CancellationToken cancellationToken);
    public GetTokenResponse GetQuotaToken(
        string guardName,
        string? featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float? weight,
        CancellationToken cancellationToken);
}
