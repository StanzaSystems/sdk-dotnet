using System;
using System.Threading;
using GetStanza.Models;
using GetStanza.Providers;
using GetStanza.Providers.Models;
using GetStanza.Services;
using GetStanza.Services.Interfaces;
using GetStanza.Workers;
using Grpc.Core;
using Grpc.Net.Client;
using Stanza.Hub.V1;

namespace GetStanza;

/// <summary>
/// This should be utilized as a singleton to ensure the stanza configuration is consistent across all threads and gRPC
/// pool connections do not become exhausted.
/// </summary>
public sealed class StanzaClient : IDisposable, IStanzaClient
{
    private readonly IHubService? _hubService;
    private readonly CancellationTokenSource _backgroundThreads;
    private readonly bool _failOpen = false;

    public StanzaClient(
        string apiKey,
        string service
    ) : this(apiKey, service, null, null, null, null) { }

    public StanzaClient(
        string apiKey,
        string service,
        string? release,
        string? environment,
        string? hubAddress,
        bool? stanzaHubNoTls
    )
    {
        _backgroundThreads = new CancellationTokenSource();
        try
        {
            // Create a new thread safe configurations cache, create a hub service with knowledge of it, and spin up a worker to periodically update the cache.
            ConcurrentConfigurationsCache configurationsCache = new();

            var hubProviderConfig = new HubProviderConfiguration(
                apiKey,
                service,
                release,
                environment,
                hubAddress,
                stanzaHubNoTls);
            var channel = GrpcChannel.ForAddress(
                hubProviderConfig.HubAddress,
                new GrpcChannelOptions
                {
                    Credentials = hubProviderConfig.StanzaHubNoTls
                        ? ChannelCredentials.Insecure
                        : ChannelCredentials.SecureSsl,
                }
            );

            HubProvider hubProvider =
                new(
                    hubProviderConfig,
                    new ConfigService.ConfigServiceClient(channel),
                    new QuotaService.QuotaServiceClient(channel)
                );

            _hubService = new HubService(hubProvider, configurationsCache);

            var pollConfigurationUpdatesToken = _backgroundThreads.Token;
            var configCacheUpdateWorker = new ConfigurationCacheUpdateWorker(
                configurationsCache,
                hubProvider,
                pollConfigurationUpdatesToken
            );
            var configCacheUpdateThread = new Thread(
                new ThreadStart(configCacheUpdateWorker.PollConfigurationUpdates)
            )
            {
                IsBackground = true
            };
            configCacheUpdateThread.Start();
        }
        catch (Exception e)
        {
            _failOpen = true;
        }
    }

    public void Dispose()
    {
        _backgroundThreads.Cancel();
        _backgroundThreads.Dispose();
    }

    public IGuard GetGuard(string guardName)
    {
        return GetGuard(guardName, null);
    }

    public IGuard GetGuard(string guardName, GuardOptions? options)
    {
        options ??= new()
        {
            Feature = "",
            PriorityBoost = 0,
            DefaultWeight = 0,
            Tags = null,
        };
        return new Guard(guardName, options, _hubService, _failOpen);
    }
}
