using System.Collections.Concurrent;

namespace GetStanza.Models;

///<summary>
/// This class serves as the thread safe storage of guard and service configurations.
/// Only one instance of this class should ever exist for any one StanzaClient instance.
///<\summary>
public class ConcurrentConfigurationsCache()
{
    public readonly ConcurrentDictionary<string, GuardConfigCache> GuardConfigs = new();
}
