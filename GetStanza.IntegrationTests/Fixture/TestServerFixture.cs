using GetStanza.IntegrationTests.FakeHub;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace GetStanza.IntegrationTests.Fixture;

public sealed class TestServerFixture : IDisposable
{
    private static readonly int hubPort = 5000;
    private readonly IHost _host;

    public TestServerFixture()
    {
        _host = Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>().ConfigureKestrel(options =>
                {
                    options.Listen(IPAddress.Any, hubPort,
                        listenOptions => { listenOptions.Protocols = HttpProtocols.Http2; });
                });
            }).Build();
        _host.RunAsync();
    }

    public string HubAddress = $"http://localhost:{hubPort}";

    public void Dispose()
    {
        _host.StopAsync();
    }
}
