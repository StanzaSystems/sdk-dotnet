using Shouldly;
using GetStanza.IntegrationTests.Fixture;

namespace GetStanza.IntegrationTests;

[Collection(TestCollections.ApiIntegration)]
public class StanzaClientTests : IDisposable
{
    private const string DEFAULT_GUARD_NAME = "TestGuard";
    private const string REPORT_ONLY = "ReportOnly";
    private const string NO_QUOTA_CHECK = "NoQuotaCheck";
    private const string TOKEN_NOT_GRANTED = "NotGranted";
    private readonly StanzaClient _stanzaClient;
    public StanzaClientTests(TestServerFixture testServerFixture)
    {
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
    public async Task StanzaClientShouldFailOpen()
    {
        // Arrange
        var stanzaClient = new StanzaClient(new()
        {
            ApiKey = "",
            Service = "",
            Release = "",
            Environment = "",
            HubAddress = "http://localhost:1234", // Unreachable host
            StanzaHubNoTls = false,
        });

        // Act
        var guard = stanzaClient.GetGuard(DEFAULT_GUARD_NAME);

        // Assert
        guard.Allowed().ShouldBe(true);
        (await guard.AllowedAsync()).ShouldBe(true);
    }

    [Fact]
    public async Task ReportOnlyShouldNotBlock()
    {
        // Act
        var guard = _stanzaClient.GetGuard(REPORT_ONLY + TOKEN_NOT_GRANTED);
        // Assert
        guard.Allowed().ShouldBe(true);
        (await guard.AllowedAsync()).ShouldBe(true);
    }

    [Fact]
    public async Task DisabledCheckQuotaShouldNotBlock()
    {
        // Act
        var guard = _stanzaClient.GetGuard(NO_QUOTA_CHECK + TOKEN_NOT_GRANTED);
        // Assert
        guard.Allowed().ShouldBe(true);
        (await guard.AllowedAsync()).ShouldBe(true);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task GuardAllowedShouldRespectTokenGranted(bool granted)
    {
        // Act
        var guard = _stanzaClient.GetGuard(granted ? DEFAULT_GUARD_NAME : TOKEN_NOT_GRANTED);
        // Assert
        guard.Allowed().ShouldBe(granted);
        (await guard.AllowedAsync()).ShouldBe(granted);
    }
}
