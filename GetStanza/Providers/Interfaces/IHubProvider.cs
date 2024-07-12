using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stanza.Hub.V1;

namespace GetStanza.Providers.Interfaces;

/// <summary>
/// Provides connections to the Stanza Hub control plane.
/// </summary>
internal interface IHubProvider
{
    public Task<GetGuardConfigResponse> FetchGuardConfigAsync(
        string guardName,
        IDictionary<string, string>? tags,
        string? versionSeen,
        CancellationToken cancellationToken
    );
    public GetGuardConfigResponse FetchGuardConfig(
        string guardName,
        IDictionary<string, string>? tags,
        string? versionSeen,
        CancellationToken cancellationToken
    );
    public Task<GetTokenResponse> FetchQuotaTokenAsync(
        string guardName,
        string featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float weight,
        CancellationToken cancellationToken
    );
    public GetTokenResponse FetchQuotaToken(
        string guardName,
        string featureName,
        IDictionary<string, string>? tags,
        string? clientId,
        int? priorityBoost,
        float weight,
        CancellationToken cancellationToken
    );
}
