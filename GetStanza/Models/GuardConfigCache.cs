using System.Collections.Generic;
using Stanza.Hub.V1;

namespace GetStanza.Models;

internal class GuardConfigCache
{
    public readonly string Version;
    public readonly GuardConfig Config;
    public readonly IDictionary<string, string>? Tags;

    public GuardConfigCache(GuardConfig guardConfig, string version, IDictionary<string, string>? tags)
    {
        Version = version;
        Config = guardConfig;
        Tags = tags;
    }
}
