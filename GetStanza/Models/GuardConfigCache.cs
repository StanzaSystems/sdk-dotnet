using System.Collections.Generic;
using Stanza.Hub.V1;

namespace GetStanza.Models;

public class GuardConfigCache(GuardConfig guardConfig, string version, IDictionary<string, string>? tags) {
    public readonly string Version = version;
    public readonly GuardConfig Config = guardConfig;
    public readonly IDictionary<string, string>? Tags = tags;
}
