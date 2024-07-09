# Usage
## Run as a Service
Run: `dotnet run`

You can then run grpcui to explore the fakes by running: 
`grpcui -plaintext -port 4500 localhost:5265`

(If you are running within the devcontainer, grpcui should already be installed for you)

## Integration Test Fixture
### Requirements
Your project must use Xunit.

### Usage
Include a reference to this project in your tests project and create a `Fixture` directory within your project.

Within that directory, create these three files:

#### TestCollection.cs
```cs
namespace [YOUR NAMESPACE HERE];

public static class TestCollections
{
    public const string ApiIntegration = "ApiIntegration";
}
```
#### TestServerCollection
```cs
using Xunit;

namespace [YOUR NAMESPACE HERE];

[CollectionDefinition(TestCollections.ApiIntegration)]
public class TestServerCollection : ICollectionFixture<TestServerFixture>
{
}
```
#### TestServerFixture
```cs
using GetStanza.IntegrationTests.Fakes;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace [YOUR NAMESPACE HERE];

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
```
Then within your test, add the fixture like so:
#### YourIntegrationTest.cs
```cs
using Shouldly;
using GetStanza.IntegrationTests.Fixture;

namespace [YOUR NAMESPACE HERE];

[Collection(TestCollections.ApiIntegration)]
public class YourTest : IDisposable
{
    private readonly StanzaClient _stanzaClient;

    public YourTest(TestServerFixture testServerFixture)
    {
        /*
        NOTE: StanzaClient comes from the GetStanza SDK package,
              but any gRPC client can be used with this fixture
        */
        _stanzaClient = new StanzaClient(new()
        {
            ApiKey = "",
            Service = "",
            Release = "",
            Environment = "",
            HubAddress = testServerFixture.HubAddress,
            StanzaHubNoTls = true,
        });
    }

    public void Dispose()
    {
        _stanzaClient.Dispose();
    }

    [Fact]
    public async Task TestShouldPass()
    {
        // Arrange
        // Act
        // Assert
    }
}
```
# Generating protos:
```sh
buf generate https://github.com/StanzaSystems/apis.git --include-imports
```
