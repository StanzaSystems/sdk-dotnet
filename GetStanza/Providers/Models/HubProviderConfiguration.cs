using GetStanza.Models;

namespace GetStanza.Providers.Models;

public record HubProviderConfiguration(StanzaClientConfiguration Config)
{
    public readonly string ApiKey = Config.ApiKey;
    public readonly string Service = Config.Service;
    public readonly string Release = Config.Release ?? "0.0.0";
    public readonly string Environment = Config.Environment ?? "dev";
    public readonly string HubAddress = Config.HubAddress ?? "https://hub.stanzasys.co:9020";
    public readonly bool StanzaHubNoTls = Config.StanzaHubNoTls ?? false;
}
