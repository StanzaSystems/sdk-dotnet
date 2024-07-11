using GetStanza.Models;

namespace GetStanza.Providers.Models;

internal record HubProviderConfiguration(
    string ApiKey,
    string Service,
    string? Release,
    string? Environment,
    string? HubAddress,
    bool? HubNoTls)
{
    public readonly string ApiKey = ApiKey;
    public readonly string Service = Service;
    public readonly string Release = Release ?? "0.0.0";
    public readonly string Environment = Environment ?? "dev";
    public readonly string HubAddress = HubAddress ?? "https://hub.stanzasys.co:9020";
    public readonly bool StanzaHubNoTls = HubNoTls ?? false;
}
