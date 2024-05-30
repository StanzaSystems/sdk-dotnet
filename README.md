# Stanza .NET SDK
## MVP
As a .NET developer
I want to be able to add stanza rate limiting to my application painlessly.

I want to be able to add the stanza sdk to a project using nuget:
```
dotnet add package GetStanza
```
I want to be able to use the stanza sdk through a factory:
```cs
using GetStanza;

var factory = new StanzaQuotaFactory("apikey", "servicename", "release", "environment", "hubaddress");

var quotaProvider = factory.CreateQuotaProvider();

// Guard a code block
// TODO: IsQuotaAvailable could possibly take a DTO as well, also tags is a list
//       Also how do we mark a guard as inbound/outbound/internal at the SDK layer?
if (quotaProvider.IsQuotaAvailable("guardname", "featurename", "priorityBoost", "defaultWeight", "tags")) { 
    // Do the logic
} else {
    // Signal that resource was blocked by stanza guard
}
```
I want to be able to use the stanza sdk through dependency injection:
```cs
// In Program.cs
using GetStanza;
using worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

// Here is where the user would tie into the standard .NET ecosystem for managing environment variables, and pass those directly to us
builder.Services.AddStanzaQuotaProvider("apikey", "servicename", "release", "environment", "hubaddress");

var host = builder.Build();
host.Run();

// In Worker.cs
using GetStanza;

namespace worker;

public class Worker : BackgroundService
{
    private readonly IQuotaProvider _quotaProvider;

    public Worker(IQuotaProvider quotaProvider) => _quotaProvider = quotaProvider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Guard a code block
            if (_quotaProvider.IsQuotaAvailable("guardname", "featurename", "priorityBoost", "defaultWeight", "tags")) { 
                // Do the logic
            } else {
                // Signal that resource was blocked by stanza guard
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
```

## Post MVP
I want to seamlessly guard inbound requests in the same way that I add authentication middleware to my api endpoints:
```cs
using GetStanza;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace

[Route("api")]
[ApiController]
public class ApiController : Controller
{
    [HttpGet("guarded")]
    [Authorize]
    [StanzaGuard("guardname", "featurename", "priorityBoost", "defaultWeight", "tags")]
    public IActionResult Guarded()
    {
        // We only enter this controller endpoint if the SDK already determined we were not blocked on this guard
        return Ok();
    }
}
```
I want to seamlessly guard outbound requests using an HttpClientHandler:
```cs
public async void MakeGuardedRequest() {
    var stanzaHandler = new StanzaHandler("guardname", "featurename", "priorityBoost", "defaultWeight", "tags");

    using HttpClient client = new HttpClient(stanzaHandler);
    HttpResponseMessage response = await client.GetAsync("http://localhost:1234/guarded_resource/");
     if (response.IsSuccessStatusCode) {
        // Guard was not blocked
    } else if (response.StatusCode == HttpStatusCode.TooManyRequests) {
        // Guard was blocked
    }
}
```
