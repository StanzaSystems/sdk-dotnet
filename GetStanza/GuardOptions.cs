using System.Collections.Generic;

namespace GetStanza;

public class GuardOptions
{
    public string? Feature { get; set; }
    public int PriorityBoost { get; set; }
    public float DefaultWeight { get; set; }
    public string? ClientId { get; set; }
    public Dictionary<string, string>? Tags { get; set; }
}