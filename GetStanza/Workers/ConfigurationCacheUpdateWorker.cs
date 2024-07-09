using System;
using System.Threading;
using GetStanza.Models;
using GetStanza.Providers.Interfaces;

namespace GetStanza.Workers;

public class ConfigurationCacheUpdateWorker(ConcurrentConfigurationsCache configsCache, IHubProvider hubProvider, CancellationToken stoppingToken) {
    private const int CONFIG_POLL_INTERVAL_SECS = 15;
    private readonly ConcurrentConfigurationsCache _configsCache = configsCache;
    private readonly IHubProvider _hubProvider = hubProvider;
    private readonly CancellationToken _stoppingToken = stoppingToken;

    public async void PollConfigurationUpdates() {
        while (!_stoppingToken.IsCancellationRequested) {
            foreach (var (guardName, guardConfigCache) in _configsCache.GuardConfigs) {
                var guardConfigResponse = await _hubProvider.FetchGuardConfigAsync(guardName,
                                                                              guardConfigCache.Tags,
                                                                              guardConfigCache.Version,
                                                                              CancellationToken.None);
                _configsCache.GuardConfigs[guardName] = new(guardConfigResponse.Config,
                                                            guardConfigResponse.Version,
                                                            guardConfigCache.Tags);
            }

            Thread.Sleep(TimeSpan.FromSeconds(CONFIG_POLL_INTERVAL_SECS));
        }
    }
}
