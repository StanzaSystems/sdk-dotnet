namespace GetStanza;

public record StanzaClientConfiguration
{
    public string ApiKey { get; set; }
    public string Service { get; set; }
    public string? Release { get; set; }
    public string? Environment { get; set; }
    public string? HubAddress { get; set; }
    public bool? StanzaHubNoTls { get; set; }
}
