# Stanza .NET SDK

Stanza is a developer-first tool for increasing reliability based on prioritized traffic management, quota allocation, and rate-limiting. On the back-end, it helps prevent downtime related to overload and excessive use of third-party APIs. On the front-end, it helps segment and weight your traffic, react automatically to overload or other conditions, and inspect the state of your critical user journeys.

"Stanza .NET SDK" provides higher-order functions (["guards"](https://docs.dev.getstanza.dev/glossary#guard)) for adding this fault tolerance to your .NET application.

## Installation

The SDK is available on nuget. You can install it with the following command:
```shell
dotnet add package GetStanza
```

## Usage

### Quickstart

After setting up your environment, API key, service, feature, and guard in the Stanza configuration dashboard, rate limiting may be added to your application like so:

```cs
using GetStanza;

using var stanza = new StanzaAPI(new() {
    APIKey = "my-api-key",
    Service = "my-service",
    Release = "1.0.0",
    Environment = "dev",
});

var myResourceGuard = stanza.GetGuard("my-guarded-resource");

if (myResourceGuard.Allowed()) {
  // ✅ Stanza Guard has *allowed* this workflow, business logic goes here.
} else {
  // 🚫 Stanza Guard has *blocked* this workflow, log the reason and return 429 status
}
```

### Depenency Injection
Using this specific service registration method is recommended so that the client will be automatically disposed.

https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-registration-methods
```cs
// Add stanza client
builder.Services.AddSingleton<IStanzaClient>(sp => new StanzaClient(new() {
    APIKey = "my-api-key",
    Service = "my-service",
    Release = "1.0.0",
    Environment = "dev",
}));
```

### Quality of Service

A guard that has been configured in the Stanza configuration dashboard for quality of service rate limiting may be used like so:

```cs
using GetStanza;

using var stanza = new StanzaAPI(new() {
        APIKey = "my-api-key",
        Service = "my-service",
        Release = "1.0.0",
        Environment = "dev",
    });

var myResourceGuard = stanza.GetGuard("my-qos-guarded-resource", new() {
    Feature = "my-qos-feature",
    Tags = new Dictionary<string, string>() {
        {"tier", "paid"},
    },
});

if (myResourceGuard.Allowed()) {
  // ✅ Stanza Guard has *allowed* this workflow, business logic goes here.
} else {
  // 🚫 Stanza Guard has *blocked* this workflow, log the reason and return 429 status
}
```

## Community

Join [Stanza's Community Discord](https://discord.gg/qaCRa2nMxY) to get involved and help us improve the SDK!