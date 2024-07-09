namespace GetStanza.Models;

public record StanzaClientConfiguration
{
    public required string ApiKey { get; set; }
    public required string Service { get; set; }
    public string? Release { get; set; }
    public string? Environment { get; set; }
    public string? HubAddress { get; set; }
    public bool? StanzaHubNoTls { get; set; }
}
